namespace Impho.Core.Notifications
{
    public class DomainNotification : IDomainNotification
    {
        public string Type { get; private set; }
        public string Error { get; private set; }
        public string Detail { get; private set; }

        public DomainNotification(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
