using Core.DataAccess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminAction : Entity
    {
        public int AdminId { get; set; }
        public AdminActionType ActionType { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Admin { get; set; }
    }


}
