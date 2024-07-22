using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class TodaysAppointments
	{
		public string To { get; set; }
		public DateTime StartTime { get; set; }
		public string Username { get; set; }
		public string Surname { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
    }
}
