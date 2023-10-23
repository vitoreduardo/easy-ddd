using MediatR;

namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IHandle<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
