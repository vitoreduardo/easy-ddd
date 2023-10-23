using EasyDDD.Domain.SystemVersions.Events;
using MediatR;

namespace EasyDDD.Application.SystemVersions.Handler
{
    public class CandidateReleaseVersionUpdatedHandler : INotificationHandler<CandidateReleaseVersionUpdated>
    {
        public Task Handle(CandidateReleaseVersionUpdated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Send Email: New version available{notification.NewVersion} - {notification.DateOcurred}");

            return Task.CompletedTask;
        }
    }
}
