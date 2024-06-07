using Core.DataAccess;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
