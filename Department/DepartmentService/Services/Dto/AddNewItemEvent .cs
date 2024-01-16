using DepartmentService.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentService.Services.Dto
{
    internal class AddNewItemEvent: IntegrationEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
