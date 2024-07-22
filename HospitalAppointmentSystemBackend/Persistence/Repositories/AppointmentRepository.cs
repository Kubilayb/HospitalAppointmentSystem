using Application.Repositories;
using Core.DataAccess;
using Core.Entities;
using Core.Models;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AppointmentRepository : EfRepositoryBase<Appointment, HospitalAppointDbContext>, IAppointmentRepository
    {
        public AppointmentRepository(HospitalAppointDbContext context) : base(context)
        {
        }
		public async Task<List<LastOneDayPatients>> GetLastOneDayPatients()
		{
			List<LastOneDayPatients> lastOneDayPatients = new List<LastOneDayPatients>();


			var appointmentPatientUserEmails = from Appointment in Context.Appointments
											   join Patient in Context.Patients on Appointment.PatientId equals Patient.Id
											   join Users in Context.BaseUsers on Patient.UserId equals Users.Id
											   where Appointment.StartTime > DateTime.Now && Appointment.StartTime < DateTime.Now.AddHours(24)
											   select new
											   {
												   To = Users.Email,
												   StartTime = Appointment.StartTime,
												   Username = Users.FirstName,
												   Surname = Users.LastName
											   };

			foreach (var item in appointmentPatientUserEmails)
			{
				LastOneDayPatients lastOneDayPatients1 = new LastOneDayPatients();

				lastOneDayPatients1.To = item.To;
				lastOneDayPatients1.StartTime = item.StartTime;
				lastOneDayPatients1.Username = item.Username;
				lastOneDayPatients1.Surname = item.Surname;

				lastOneDayPatients.Add(lastOneDayPatients1);
			}

			return lastOneDayPatients;
		}

		public async Task<List<TodaysAppointments>> GetTodaysAppointments()
		{
			List<TodaysAppointments> todaysAppointments = new List<TodaysAppointments>();

			var appointmenDoctorsUserEmails = from Appointment in Context.Appointments
											  join DoctorAvailability in Context.DoctorAvailabilities on Appointment.DoctorAvailabilityId equals DoctorAvailability.Id
											  join Patient in Context.Patients on Appointment.PatientId equals Patient.Id
											  join Doctor in Context.Doctors on DoctorAvailability.DoctorId equals Doctor.Id
											  join Users in Context.BaseUsers on Doctor.UserId equals Users.Id
											  where Appointment.StartTime > DateTime.Now && Appointment.StartTime < DateTime.Now.AddHours(24)
											  select new
											  {
												  To = Users.Email,
												  StartTime = Appointment.StartTime,
												  Username = Users.FirstName,
												  Surname = Users.LastName,
												  PatientName = Patient.User.FirstName,
												  PatientSurname = Patient.User.LastName,
											  };

			foreach (var item in todaysAppointments)
			{
				TodaysAppointments todaysAppointment1 = new TodaysAppointments();

				todaysAppointment1.To = item.To;
				todaysAppointment1.StartTime = item.StartTime;
				todaysAppointment1.Username = item.Username;
				todaysAppointment1.Surname = item.Surname;
				todaysAppointment1.PatientName = item.PatientName;
				todaysAppointment1.PatientSurname = item.PatientSurname;

				todaysAppointments.Add(todaysAppointment1);
			}

			return todaysAppointments;
		}
	}
}
