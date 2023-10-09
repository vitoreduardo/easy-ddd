using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyDDD.Infrastructure.Data.DbContexts
{
    public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
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
            //var entitiesWithEvents = ChangeTracker.Entries<IEntity<Guid>>()
            //   .Select(e => e.Entity)
            //   .Where(e => e.DomainEvents.Any())
            //   .ToArray();

            //foreach (var entity in entitiesWithEvents)
            //{
            //    while (entity.DomainEvents.TryTake(out IDomainEvent @event))
            //        await _dispatcher.DispatchAsync(@event).ConfigureAwait(false);
            //}

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

    }
}
