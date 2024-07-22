using Infrastructure.Quartz;
using Infrastructure.SignalR.HubService;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
			services.AddQuartz(q =>
			{
				q.UseMicrosoftDependencyInjectionJobFactory();
				q.ScheduleJob<SendMailJob>(trigger => trigger
					.WithIdentity("SendRecurringMailTrigger")
					.StartAt(DateBuilder.TodayAt(15, 53, 00)) // Gece yarısı
					.WithSimpleSchedule(s =>
						s.WithIntervalInHours(24) // Her 24 saatte bir
						.RepeatForever()
					)
				);
			});

			services.AddQuartzHostedService(options =>
			{
				options.WaitForJobsToComplete = true;
			});
			services.AddScoped<ILiveChatHubService, LiveChatHubService>();
            services.AddSignalR();
            return services;
        }
    }
}
