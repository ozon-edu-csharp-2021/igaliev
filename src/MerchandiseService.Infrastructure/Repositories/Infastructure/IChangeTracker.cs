using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;

namespace MerchandiseService.Infrastructure.Repositories.Infastructure
{
    public interface IChangeTracker
    {
        IEnumerable<Entity> TrackedEntities { get; }

        public void Track(Entity entity);
    }
}