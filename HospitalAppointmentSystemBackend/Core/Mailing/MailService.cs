using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text;
using Core.Entities;
using Core.Models;

namespace Core.Mailing
{
	public class MailService : IMailService
	{
		private readonly IConfiguration _configuration;
		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		
		public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
		{
			await SendMailAsync(new[] {to}, subject, body, isBodyHtml);
		}

		public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
		{
			MailMessage mail = new();
			mail.IsBodyHtml = isBodyHtml;
			foreach (string to in tos)
				mail.To.Add(to);
			mail.Subject = subject;
			mail.Body = body;
			mail.From = new(_configuration["Mail:UserName"], "Hospital App", System.Text.Encoding.UTF8);

			SmtpClient smtp = new();
			smtp.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:Password"]);
			smtp.Port = 587;
			smtp.EnableSsl = true;
			smtp.Host = _configuration["Mail:Host"];
			await smtp.SendMailAsync(mail);
		}
		public async Task BookedAppointmentMailAsync(string to, DateTime startTime, string userName, string userSurname)
		{
			string mail = $"Sayın {userName} {userSurname} merhaba, " +
				$"{startTime} tarihinde randevunuz oluşturulmuştur.";
			await SendMailAsync(to, "Randevu Bilgilendirme", mail);
		}
		public async Task BookedAppointmentReminderMailAsync(List<LastOneDayPatients> patients)
		{
			foreach (var item in patients)
			{
				string mail = $"Sayın {item.Username} {item.Surname} merhaba, " +
				$"{item.StartTime} tarihindeki randevunuza 24 saatten az zaman kalmıştır.";

				await SendMailAsync(item.To, "Randevu Hatırlatma", mail);
			}
		}

		public async Task BookedAppointmentReminderToDoctorMailAsync(List<TodaysAppointments> doctors)
		{
			foreach (var item in doctors)
			{
				string mail = $"Sayın {item.Username} {item.Surname} merhaba, " +
				$"{item.StartTime} tarihindeki {item.PatientName} {item.Surname} isimli hasta ile randevunuz vardır.";

				await SendMailAsync(item.To, "Randevu Hatırlatma", mail);
			}
		}
	}
}
