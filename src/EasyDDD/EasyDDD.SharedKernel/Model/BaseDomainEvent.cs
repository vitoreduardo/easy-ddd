using MediatR;

namespace EasyDDD.SharedKernel.Model
{
    /// <summary>
    /// Represent a domain event base.
    /// </summary>
    public abstract class BaseDomainEvent : INotification
    {
        /// <summary>
        /// Gets or Sets a date occurred.
        /// </summary>
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
