using EasyDDD.SharedKernel.Model;

namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IReadRepository<T> where T : class, IAggregateRoot
    {
        Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity<TId>, IAggregateRoot;

        Task<T> GetAsync<T, TId>(T spec) where T : BaseEntity<TId>, IAggregateRoot;

        Task<List<T>> ListAsync<T, TId>() where T : BaseEntity<TId>, IAggregateRoot;

        Task<List<T>> ListAsync<T, TId>(T spec) where T : BaseEntity<TId>, IAggregateRoot;

        Task<int> CountAsync<T, TId>(T spec) where T : BaseEntity<TId>, IAggregateRoot;
    }
}
