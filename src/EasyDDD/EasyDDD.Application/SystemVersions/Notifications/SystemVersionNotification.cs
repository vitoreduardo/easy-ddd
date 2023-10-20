using MediatR;

namespace EasyDDD.Application.SystemVersions.Notifications
{
    public class SystemVersionNotification : INotification
    {
        public SystemVersionNotification(
            int id,
            string message)
        {
            Id=id;
            Message=message;
        }

        public int Id { get; }

        public string Message { get; }

        internal sealed class SystemVersionNotificationHandler : INotificationHandler<SystemVersionNotification>
        {
            public Task Handle(SystemVersionNotification notification, CancellationToken cancellationToken)
            {
                return Task.Run(() =>
                {
                    Console.WriteLine(notification.Message);
                });
            }
        }
    }
}
