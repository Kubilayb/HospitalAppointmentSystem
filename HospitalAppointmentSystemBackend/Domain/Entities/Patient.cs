namespace Domain.Entities
{
    public class Patient : User
    {
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<PatientReport> PatientReports { get; set; }
    }
}
