using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorSchedule : Entity
    {
        public int DoctorId { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime AvailableStartTime { get; set; }
        public DateTime AvailableEndTime { get; set; }

        public Doctor Doctor { get; set; }
    }
}
