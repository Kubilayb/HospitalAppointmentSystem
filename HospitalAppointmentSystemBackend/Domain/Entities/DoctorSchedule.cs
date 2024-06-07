using Core.DataAccess;

namespace Domain.Entities
{
    public class DoctorSchedule : Entity
    {
        public DateTime AvailableDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
