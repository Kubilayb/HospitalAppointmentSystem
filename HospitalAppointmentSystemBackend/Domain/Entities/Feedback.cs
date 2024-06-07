using Core.DataAccess;

namespace Domain.Entities
{
    public class Feedback : Entity
    {
        public string FeedbackTitle { get; set; }
        public string FeedbackDescription { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
