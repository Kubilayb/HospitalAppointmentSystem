using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Contexts
{
    public class HospitalAppointmentSystemDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HospitalAppointmentSystem;User Id=sa;Password=YourStrongPassword123!;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Admin>().ToTable("Admins");

            
            modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                Password = "adminpassword", // Parolayı hash'lemelisiniz
                PhoneNumber = "1234567890",
                Address = "Admin Address"
            });

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 2,
                    FirstName = "Doctor",
                    LastName = "User",
                    Email = "doctor@example.com",
                    Password = "doctorpassword", // Parolayı hash'lemelisiniz
                    PhoneNumber = "1234567891",
                    Address = "Doctor Address"
                });

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 3,
                    FirstName = "Patient",
                    LastName = "User",
                    Email = "patient@example.com",
                    Password = "patientpassword", // Parolayı hash'lemelisiniz
                    PhoneNumber = "1234567892",
                    Address = "Patient Address"
                });

            base.OnModelCreating(modelBuilder);
     
             
        }
    }
}
