using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Domain.SeedWork
{
    public interface IRepository<TAggregationRoot>
    {
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// Создать новую сущность
        /// </summary>
        /// <param name="itemToCreate">Объект для создания</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Созданная сущность</returns>
        Task<IAggregateRoot> CreateAsync(TAggregationRoot itemToCreate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить существующую сущность
        /// </summary>
        /// <param name="itemToUpdate">Объект для создания</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Обновленная сущность сущность</returns>
        Task<IAggregateRoot> UpdateAsync(TAggregationRoot itemToUpdate, CancellationToken cancellationToken = default);
    }
}
