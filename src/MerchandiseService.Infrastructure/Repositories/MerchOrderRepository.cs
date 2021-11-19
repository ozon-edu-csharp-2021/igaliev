using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Infrastructure.Repositories.Infastructure;
using MerchandiseService.Infrastructure.Repositories.Interfaces;
using Npgsql;

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
        public Task<IAggregateRoot> CreateAsync(IAggregateRoot itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IAggregateRoot> UpdateAsync(IAggregateRoot itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public  async Task<int> Add(MerchOrder merchOrder, CancellationToken cancellationToken)
        {
            _merchOrders.Add(merchOrder);
           
            //TODO: заглущка
            return merchOrder.Id;
        }

        public async Task<MerchOrder> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _merchOrders.Where(order => order.Id == id).FirstOrDefault();
        }

        public async  Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return _merchOrders.Where(order => order.EmployeeId == id).ToList();
        }
    }
}