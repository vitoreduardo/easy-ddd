using EasyDDD.SharedKernel.Interfaces;
using EasyDDD.SharedKernel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyDDD.Infrastructure.Data.DbContexts
{
    public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public BaseDbContext(
            DbContextOptions<TContext> options,
            IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher=dispatcher;
        }

        public async Task<bool> CommitAsync()
        {
            // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
            // performed through the DbContext will be committed
            return await SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entitiesWithEvents = ChangeTracker.Entries<Entity<Guid>>()
               .Select(e => e.Entity)
               .Where(e => e.Events.Any())
               .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                while (entity.Events.TryTake(out IDomainEvent @event))
                    await _dispatcher.DispatchAsync(@event).ConfigureAwait(false);
            }

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

    }
}
