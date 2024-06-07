using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification : Entity
    {
        public NotificationType NotificationType { get; set; }
        public string NotificationMessage { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
