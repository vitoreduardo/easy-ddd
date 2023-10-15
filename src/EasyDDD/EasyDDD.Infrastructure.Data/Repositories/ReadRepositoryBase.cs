using EasyDDD.Infrastructure.Data.DbContexts.BoundedContext;
using EasyDDD.Infrastructure.Data.Spec;
using EasyDDD.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDDD.Infrastructure.Data.Repositories
{
    public class ReadRepositoryBase<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
        protected readonly MyDbContext _dbContext;

        public ReadRepositoryBase(MyDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
            => await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
            => await ApplySpecification(specification).FirstOrDefaultAsync();

        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Set<T>().ToListAsync(cancellationToken);

        public async Task<List<T>> ListAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).ToListAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
    }
}
