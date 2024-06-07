namespace Domain.Entities
{
    public class Doctor : User
    {
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<PatientReport> PatientReports { get; set; }
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
