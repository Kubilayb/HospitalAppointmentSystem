using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : Entity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; } // Randevu durumu için AppointmentStatus enum'ı kullanıldı

        public User Patient { get; set; }
        public Doctor Doctor { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}
