using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SystemStats : Entity
    {
        public string MetricType { get; set; }
        public string MetricValue { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
