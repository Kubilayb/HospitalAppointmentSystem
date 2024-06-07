using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class AdminAction : Entity
    {
        public ActionType ActionType { get; set; }
        public string ActionDetails { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
