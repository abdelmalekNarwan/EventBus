using DepartmentDomain.Entity;
using DepartmentReposatory.Reposatory;
using DepartmentService.EventBus;
using DepartmentService.IServices;
using DepartmentService.Services.Dto;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace DepartmentService.Services
{
    public class DepartmentService : IDepartmentAppService 
    {
        private readonly IGenericRepository<Department> _repository;
        private readonly IEventBus _eventBus;

        public DepartmentService(IGenericRepository<Department> repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }
        public async Task<List<string>> GetEmplyeeByDepartmentId(CreateEmployeeDto  input)
        {
           // var Names = _repository.GetAll().Select(a => a.Name).ToList();
            var Names =new  List<string>();
            var newItem = new CreateEmployeeDto { Name =input.Name,Id=input.Id  };
            var @event = new AddNewItemEvent {Name=newItem.Name,Id=newItem.Id };

            _eventBus.Publish(@event);
            return Names ;
        }
    }
}
