// <copyright file="IEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDDD.SharedKernel.Interfaces
{
    /// <summary>
    /// Represent a Entity of TId.
    /// </summary>
    /// <typeparam name="TId">The Id type.</typeparam>
    public interface IEntity<TId>
    {
        TId Id { get; set; }

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>
        /// The domain events.
        /// </value>
        [NotMapped]
        IProducerConsumerCollection<IDomainEvent> Events { get; }

        /// <summary>
        /// Publishes an domain event.
        /// </summary>
        /// <param name="event">The domain event.</param>
        void PublishEvent(IDomainEvent @event);
    }
}
