using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation;
using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;

namespace MerchandiseService.Infastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IUnitOfWork UnitOfWork { get; }
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