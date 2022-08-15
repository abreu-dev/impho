namespace Impho.Core.Notifications
{
    public interface IDomainNotificationHandler
    {
        bool HasNotifications { get; }
        IEnumerable<IDomainNotification> GetNotifications();

        Task Handle(IDomainNotification notification, CancellationToken cancellationToken);
    }
}
