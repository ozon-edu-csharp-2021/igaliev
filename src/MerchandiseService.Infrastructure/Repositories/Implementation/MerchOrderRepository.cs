using Dapper;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Domain.SeedWork;
using MerchandiseService.Infrastructure.Models;
using MerchandiseService.Infrastructure.Repositories.Infastructure;
using MerchandiseService.Infrastructure.Repositories.Interfaces;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories
{
    public class MerchOrderRepository : IMerchOrderRepository
    {
        private List<MerchOrder> _merchOrders;

        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        public MerchOrderRepository(List<MerchOrder> merchOrders, IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _merchOrders = merchOrders;
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public IUnitOfWork UnitOfWork { get; }
        public async Task<IAggregateRoot> CreateAsync(MerchOrder itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                INSERT INTO orders (status, employee_id, merch_pack)
                VALUES (@Status, @EmployeeId, @MerchPack);";

            var parameters = new
            {
                Status = itemToCreate.Status.Id,
                EmployeeId = itemToCreate.EmployeeId,
                MerchPack = itemToCreate.MerchKit.Id,
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

        public async Task<IAggregateRoot> UpdateAsync(MerchOrder itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                        UPDATE merch_orders
                        SET status = @Status, employee_id = @EmployeeId, merch_pack = @MerchKit, date_of_issue = @DateOfIssue
                        WHERE id = @Id;";

            var parameters = new
            {
                Id = itemToUpdate.Id,
                Status = itemToUpdate.Status.Id,
                EmployeeId = itemToUpdate.EmployeeId,
                MerchPack = itemToUpdate.MerchKit.Id,
                DateOfIssue = itemToUpdate.IssuedDate
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



        public async Task<MerchOrder> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                                SELECT merch_orders.id, merch_orders.status, merch_orders.employee_id, 
                                       merch_orders.merch_pack, merch_orders.date_of_issue, employees.first_name,
                                       employees.last_name, employees.middle_name,
                                       employees.email, employees.clothing_size, employees.id
                                FROM merch_orders
                                INNER JOIN employees on employees.id = merch_orders.employee_id
                                WHERE merch_orders.id = @Id;";

            var parameters = new
            {
                Id = id
            };

            var commandDefinition = new CommandDefinition(sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var orders = await connection.QueryAsync<EmployeeModel, MerchOrderModel, MerchOrder>(commandDefinition,
                (employee, merchOrder) =>
                {
                    var newOrder = new MerchOrder(
                        employee.Id,
                        Enumeration.GetAll<MerchKit>().FirstOrDefault(it => it.Id.Equals(merchOrder.MerchPack))
                    );
                    newOrder.Employee = new Employee(
                        new PersonName(employee.FirstName, employee.LastName, employee.MiddleName),
                        new Email(employee.Email),
                        Enumeration.GetAll<ClothingSize>()
                            .FirstOrDefault(it => it.Id.Equals(employee.ClothingSize)));
                    newOrder.IssuedDate = merchOrder.DateOfIssue;
                    newOrder.Status = Enumeration.GetAll<MerchOrderStatus>()
                        .FirstOrDefault(it => it.Id.Equals(merchOrder.Status));
                    return newOrder;
                });

            MerchOrder result = null;
            if (orders.Any())
            {
                result = orders.ToArray()[0];
            }

            _changeTracker.Track(result);
            return result;
        }

        public async Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default)
        {

            const string sql = @"
                                SELECT merch_orders.id, merch_orders.status, merch_orders.employee_id, 
                                       merch_orders.merch_pack, merch_orders.date_of_issue, 
                                       employees.id, employees.first_name,
                                       employees.last_name, employees.middle_name,
                                       employees.email, employees.clothing_size
                                FROM merch_orders
                                INNER JOIN employees on merch_orders.employee_id = employees.id
                                WHERE merch_orders.employee_id = @EmployeeId;";

            var parameters = new
            {
                EmployeeId = id
            };

            var commandDefinition = new CommandDefinition(sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);

            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var orders = await connection.QueryAsync<EmployeeModel, MerchOrderModel, MerchOrder>(commandDefinition,
                (employee, merchOrder) =>
                {
                    var newOrder = new MerchOrder(
                        employee.Id,
                        Enumeration.GetAll<MerchKit>().FirstOrDefault(it => it.Id.Equals(merchOrder.MerchPack))
                    );
                    newOrder.Employee = new Employee(
                        new PersonName(employee.FirstName, employee.LastName, employee.MiddleName),
                       new Email(employee.Email),
                        Enumeration.GetAll<ClothingSize>()
                            .FirstOrDefault(it => it.Id.Equals(employee.ClothingSize)));
                    newOrder.IssuedDate = merchOrder.DateOfIssue;
                    newOrder.Status = Enumeration.GetAll<MerchOrderStatus>()
                        .FirstOrDefault(it => it.Id.Equals(merchOrder.Status));
                    return newOrder;
                });

            var result = orders.ToList();

            foreach (var order in result)
            {
                _changeTracker.Track(order);
            }

            return result;
        }


    }
}