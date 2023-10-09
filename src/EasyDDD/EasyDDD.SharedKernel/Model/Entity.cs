using EasyDDD.SharedKernel.Interfaces;

namespace EasyDDD.SharedKernel.Model
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        public required TId Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
