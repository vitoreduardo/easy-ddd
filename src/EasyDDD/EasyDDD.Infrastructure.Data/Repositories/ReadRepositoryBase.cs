using EasyDDD.Infrastructure.Data.DbContexts.BoundedContext;
using EasyDDD.SharedKernel.Interfaces;
using EasyDDD.SharedKernel.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyDDD.Infrastructure.Data.Repositories
{
    public class ReadRepositoryBase<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
        protected readonly MyDbContext _dbContext;

        public ReadRepositoryBase(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<List<T>> ListAsync(ISpecification<T> specification)
        {
            return ApplySpecification(specification);
        }

        private List<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec).ToList();
        }
    }
}
