using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor : Entity
    {
        public string Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<PatientReport> PatientReports { get; set; }
        public ICollection<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
