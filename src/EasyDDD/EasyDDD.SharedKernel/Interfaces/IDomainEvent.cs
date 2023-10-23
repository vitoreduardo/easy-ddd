
using MediatR;

namespace EasyDDD.SharedKernel.Interfaces
{
    public interface IDomainEvent : INotification
    {
        DateTime DateOcurred { get; }
    }
}
