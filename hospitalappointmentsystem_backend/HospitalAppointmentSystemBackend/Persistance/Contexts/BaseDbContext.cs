using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<SystemStats> SystemStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=HospitalAppointmentSystem;User Id=sa;Password=YourStrongPassword123!;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<PatientReport>()
                .HasOne(r => r.Patient)
                .WithMany(u => u.PatientReports)
                .HasForeignKey(r => r.PatientId);

            modelBuilder.Entity<PatientReport>()
                .HasOne(r => r.Doctor)
                .WithMany(d => d.PatientReports)
                .HasForeignKey(r => r.DoctorId);

            modelBuilder.Entity<PatientReport>()
                .HasOne(r => r.Appointment)
                .WithOne(a => a.PatientReport)
                .HasForeignKey<PatientReport>(r => r.AppointmentId);

            modelBuilder.Entity<DoctorSchedule>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSchedules)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<AdminAction>()
                .HasOne(aa => aa.Admin)
                .WithMany(u => u.AdminActions)
                .HasForeignKey(aa => aa.AdminId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId);

            /*

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@example.com",
                    Password = HashPassword("adminpassword"),
                    PhoneNumber = "1234567890",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    FirstName = "Doctor",
                    LastName = "User",
                    Email = "doctor@example.com",
                    Password = HashPassword("doctorpassword"),
                    PhoneNumber = "1234567891",
                    Role = UserRole.Doctor
                },
                new User
                {
                    Id = 3,
                    FirstName = "Patient",
                    LastName = "User",
                    Email = "patient@example.com",
                    Password = HashPassword("patientpassword"),
                    PhoneNumber = "1234567892",
                    Role = UserRole.Patient
                });

            base.OnModelCreating(modelBuilder);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        } */

        }
    }
}
