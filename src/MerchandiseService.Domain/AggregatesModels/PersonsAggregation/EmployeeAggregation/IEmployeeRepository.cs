using System.Collections.Generic;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee FindEmployeeByEmail(string email);

        /// <summary>
        /// Получить список вакантных менеджеров
        /// </summary>
        IEnumerable<Manager> GetVacantManagers();

        /// <summary>
        /// Поиск сотрудника по ID
        /// </summary>
        Employee FindEmployeeById(long id);

        /// <summary>
        /// Сохраняет сотрудника в БД
        /// </summary>
        void Save(Employee employee);

        /// <summary>
        /// Возвращает всех-всех сотрудников
        /// </summary>
        ICollection<Employee> GetAllEmployees();
    }
}