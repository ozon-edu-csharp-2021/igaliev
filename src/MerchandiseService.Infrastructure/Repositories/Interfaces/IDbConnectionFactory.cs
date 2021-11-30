using System;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories.Interfaces
{
    public interface IDbConnectionFactory<TConnection> : IDisposable
    {
        Task<TConnection> CreateConnection(CancellationToken token);
    }
}