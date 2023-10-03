using EasyDDD.SharedKernel.Model;

namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
    {
        Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;

        Task UpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;

        Task DeleteAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
    }
}
