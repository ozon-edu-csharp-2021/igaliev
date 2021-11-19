using System.Collections.Generic;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Infrastructure.Repositories.Infastructure
{
    public interface IChangeTracker
    {
        IEnumerable<Entity> TrackedEntities { get; }

        public void Track(Entity entity);
    }
}