using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation;
using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<IAggregateRoot> CreateAsync(IAggregateRoot itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAggregateRoot> UpdateAsync(IAggregateRoot itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Employee FindEmployeeByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Manager> GetVacantManagers()
        {
            throw new System.NotImplementedException();
        }

        public Employee FindEmployeeById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Employee> GetAllEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}