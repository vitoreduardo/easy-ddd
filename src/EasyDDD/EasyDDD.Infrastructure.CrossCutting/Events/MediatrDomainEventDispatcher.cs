using Ardalis.GuardClauses;
using EasyDDD.SharedKernel.Interfaces;
using MediatR;

namespace EasyDDD.Infrastructure.CrossCutting.Events
{
    public class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public MediatrDomainEventDispatcher(IMediator mediator)
        {
            _mediator=mediator;
        }

        public async Task DispatchAsync(IDomainEvent @event)
        {
            Guard.Against.Null(@event, nameof(@event));

            await _mediator.Publish(@event).ConfigureAwait(false);
        }
    }
}
