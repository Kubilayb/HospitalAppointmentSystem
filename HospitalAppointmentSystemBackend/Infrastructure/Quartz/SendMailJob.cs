using Application.Repositories;
using Core.Mailing;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Infrastructure.Quartz
{
	public class SendMailJob : IJob
	{
		private readonly IMailService _mailService;
		private readonly ILogger _logger;
		private readonly IAppointmentRepository _appointmentRepository;

		public SendMailJob(IMailService mailService, ILogger<SendMailJob> logger, IAppointmentRepository appointmentRepository)
		{
			_mailService = mailService;
			_logger = logger;
			_appointmentRepository = appointmentRepository;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			var mailList = await _appointmentRepository.GetLastOneDayPatients();
			var mailList2 = await _appointmentRepository.GetTodaysAppointments();
			await _mailService.BookedAppointmentReminderMailAsync(mailList);
			await _mailService.BookedAppointmentReminderToDoctorMailAsync(mailList2);
		}
	}
}
