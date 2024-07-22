using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;
using Core.Mailing;
using Application.Features.Appointments.Rules;
using Application.Services.PatientService;
using Application.Services.UserService;

namespace Application.Features.Appointments.Commands.Create
{
	public class CreateAppointmentCommand : IRequest<CreateAppointmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, Write, Add];
        public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
		{
			private readonly IAppointmentRepository _appointmentRepository;
			private readonly IMapper _mapper;
			private readonly IMailService _mailService;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;
            private readonly IPatientService _patientService;
			public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IMailService mailService, AppointmentBusinessRules appointmentBusinessRules, IPatientService patientService)
			{
				_appointmentRepository = appointmentRepository;
				_mapper = mapper;
				_mailService = mailService;
				_appointmentBusinessRules = appointmentBusinessRules;
				_patientService = patientService;
			}

			public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {
                await _appointmentBusinessRules.ValidateAppointmentCreation(request);

                Appointment appointment = _mapper.Map<Appointment>(request);
                appointment.Status = AppointmentStatus.Booked;

                await _appointmentRepository.AddAsync(appointment);

				User user = await _patientService.GetUserAsync(request.PatientId);
				await _mailService.BookedAppointmentMailAsync(user.Email, appointment.StartTime, user.FirstName, user.LastName);
				CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);

                return response;
            }
		}
	}
}
