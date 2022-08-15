namespace Impho.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private readonly ICollection<IDomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<IDomainNotification>();
        }

        public bool HasNotifications => _notifications.Any();

        public IEnumerable<IDomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(IDomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
