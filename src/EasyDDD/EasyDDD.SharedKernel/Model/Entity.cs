using Ardalis.GuardClauses;
using EasyDDD.SharedKernel.Interfaces;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDDD.SharedKernel.Model
{
    /// <summary>
    /// Represent a Entity of TId.
    /// </summary>
    /// <typeparam name="TId">The Id type.</typeparam>
    public abstract class Entity<TId> : IEntity<TId>
    {
        [NotMapped]
        private readonly ConcurrentQueue<IDomainEvent> events = new ConcurrentQueue<IDomainEvent>();

        /// <summary>
        /// Gets or sets a unique identifier.
        /// </summary>
        required public TId Id { get; set; }

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>
        /// The domain events.
        /// </value>
        [NotMapped]
        public IProducerConsumerCollection<IDomainEvent> Events => this.events;

        /// <summary>
        /// Publishes an domain event.
        /// </summary>
        /// <param name="event">The domain event.</param>
        public void PublishEvent(IDomainEvent @event)
        {
            Guard.Against.Null(@event, nameof(@event));
            this.events.Enqueue(@event);
        }
    }
}
