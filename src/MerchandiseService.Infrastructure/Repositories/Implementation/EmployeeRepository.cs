using Dapper;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.SeedWork;
using MerchandiseService.Infrastructure.Models;
using MerchandiseService.Infrastructure.Repositories.Infastructure;
using MerchandiseService.Infrastructure.Repositories.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public EmployeeRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }
        public async Task<IAggregateRoot> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                     INSERT INTO employees (first_name, last_name, middle_name, email, clothing_size)
                     VALUES (@FirstName, @LastName, @MiddleName, @Email, @ClothingSize);";

            var parameters = new
            {
                FirstName = itemToCreate.Name.FirstName,
                LastName = itemToCreate.Name.LastName,
                MiddleName = itemToCreate.Name.MiddleName,
                Email = itemToCreate.Email.Value,
                ClothingSize = itemToCreate.Size.Id
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToCreate);
            return itemToCreate;
        }

        public async Task<IAggregateRoot> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                             UPDATE employees
                             SET first_name = @FirstName, last_name = @LastName, middle_name = @MiddleName, email = @Email, clothing_size = @ClothingSize
                             WHERE id = @Id;";

            var parameters = new
            {
                Id = itemToUpdate.Id,
                FirstName = itemToUpdate.Name.FirstName,
                LastName = itemToUpdate.Name.LastName,
                MiddleName = itemToUpdate.Name.MiddleName,
                Email = itemToUpdate.Email.Value,
                ClothingSize = itemToUpdate.Size.Id
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToUpdate);
            return itemToUpdate;
        }

        public async Task<Employee> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                         SELECT employees.id, employees.first_name,
                                employees.last_name, employees.middle_name,
                                employees.email, employees.clothing_size
                         FROM employees
                         WHERE employees.id = @Id;";

            var parameters = new
            {
                Id = id
            };

            var commandDefinition = new CommandDefinition(sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);


            var employee = await connection.QueryFirstAsync<EmployeeModel>(commandDefinition);

            var result = new Employee(new PersonName(employee.FirstName, employee.LastName, employee.MiddleName),
                new Email(employee.Email),
                Enumeration.GetAll<ClothingSize>().FirstOrDefault(it => it.Id.Equals(employee.ClothingSize)));

            _changeTracker.Track(result);

            return result;
        }

        public async Task<Employee> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                         SELECT employees.id, employees.first_name,
                                employees.last_name, employees.middle_name,
                                employees.email, employees.clothing_size
                         FROM employees
                         WHERE employees.email = @Email;";

            var parameters = new
            {
                Email = email
            };

            var commandDefinition = new CommandDefinition(sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var employee = await connection.QueryFirstAsync<EmployeeModel>(commandDefinition);

            var result = new Employee(new PersonName(employee.FirstName, employee.LastName, employee.MiddleName),
                new Email(employee.Email),
                Enumeration.GetAll<ClothingSize>().FirstOrDefault(it => it.Id.Equals(employee.ClothingSize)));

            _changeTracker.Track(result);

            return result;
        }

        public async Task<List<Employee>> GetAllEmployees(CancellationToken cancellationToken = default)
        {
            const string sql = @"
                         SELECT employees.id, employees.first_name,
                                employees.last_name, employees.middle_name,
                                employees.email, employees.clothing_size
                         FROM employees;";


            var commandDefinition = new CommandDefinition(sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var employees = await connection.QueryAsync<EmployeeModel>(commandDefinition);

            var result = employees.Select(x => new Employee(new PersonName(x.FirstName, x.LastName, x.MiddleName),
                new Email(x.Email),
                Enumeration.GetAll<ClothingSize>().FirstOrDefault(it => it.Id.Equals(x.ClothingSize)))).ToList();

            foreach (var employee in result)
            {
                _changeTracker.Track(employee);
            }
            return result;
        }


    }
}
