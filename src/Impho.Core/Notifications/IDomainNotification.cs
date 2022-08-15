namespace Impho.Core.Notifications
{
    public interface IDomainNotification
    {
        string Type { get; }
        string Error { get; }
        string Detail { get; }
    }
}
