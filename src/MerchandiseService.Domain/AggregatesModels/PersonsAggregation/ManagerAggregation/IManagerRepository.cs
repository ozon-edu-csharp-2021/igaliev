using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation
{
    public interface IManagerRepository
    {
        Task<Manager> FindByIdAsync(long id, CancellationToken cancellationToken = default);
        
        Task<Manager> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
        
        Task<ICollection<Manager>> GetAllEmployees(CancellationToken cancellationToken = default);
    }
}