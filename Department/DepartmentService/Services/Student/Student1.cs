using DepartmentDomain.Entity;
using DepartmentReposatory.Reposatory;
using DepartmentService.EventBus;
using DepartmentService.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentService.Services.Student
{
    public class Student1 : IIntegrationEventHandler<AddNewItemEvent>
    {
        private readonly IGenericRepository<Department> _repository;

        public Student1(IGenericRepository<Department> repository)
        {

            _repository = repository;

        }
        async Task IIntegrationEventHandler<AddNewItemEvent>.HandleAsync(AddNewItemEvent @event)
        {
            var emplo = new Department()
            {
                Id = @event.Id,
                Name = @event.Name,
            };
            _repository.Insert(emplo);
        }
    }
}
