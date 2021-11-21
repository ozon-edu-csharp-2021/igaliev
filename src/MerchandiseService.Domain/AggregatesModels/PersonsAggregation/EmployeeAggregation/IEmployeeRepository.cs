
using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee FindEmployeeByEmail(string email);
        Employee FindEmployeeById(long id);
        void Save(Employee employee);
        ICollection<Employee> GetAllEmployees();
        

    }
}