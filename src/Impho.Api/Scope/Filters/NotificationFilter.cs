using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Impho.Api.Scope.Responses;
using Impho.Core.Notifications;

namespace Impho.Api.Scope.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly IDomainNotificationHandler _notificationHandler;

        public NotificationFilter(IDomainNotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationHandler.HasNotifications)
            {
                context.Result = GetBadRequestObjectResult(_notificationHandler.GetNotifications(), context.HttpContext.Request.Path.Value);
            }

            await next();
        }

        public BadRequestObjectResult GetBadRequestObjectResult(IEnumerable<IDomainNotification> notifications, string? instance)
        {
            var response = new BadRequestResponse(instance);

            notifications.ToList().ForEach(notification =>
            {
                response.Errors.Add(new BadRequestResponseError(notification.Type, notification.Error, notification.Detail));
            });

            return new BadRequestObjectResult(response);
        }
    }
}
