using Core.DataAccess;
using Core.Entities;
using Core.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>, IRepository<Appointment>
    {
		public Task<List<LastOneDayPatients>> GetLastOneDayPatients();
		public Task<List<TodaysAppointments>> GetTodaysAppointments();
	}
}
