namespace EasyDDD.SharedKernel.Interfaces
{
    /// <summary>
    /// Defines a dispatcher to the domain events.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// Dispatches a domain event asynchronously.
        /// </summary>
        /// <param name="event">The domain event.</param>
        /// <returns>The task.</returns>
        Task DispatchAsync(IDomainEvent @event);
    }
}
