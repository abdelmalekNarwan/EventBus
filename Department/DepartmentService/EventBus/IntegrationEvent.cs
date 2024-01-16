using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentService.EventBus
{
    public abstract class IntegrationEvent
    {
        public Guid Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
