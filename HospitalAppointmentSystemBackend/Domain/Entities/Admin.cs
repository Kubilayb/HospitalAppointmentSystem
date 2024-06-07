namespace Domain.Entities
{
    public class Admin : User
    {
        public virtual ICollection<AdminAction> AdminActions { get; set; }
    }
}