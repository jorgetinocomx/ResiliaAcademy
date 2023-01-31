using Microsoft.AspNetCore.SignalR;
using Resilia.Academy.Api.Models;

namespace Resilia.Academy.Api.Hubs
{
    /// <summary>
    /// Defines the push notifications hub that will be used by the web app client.
    /// </summary>
    public class NotificationsHub : Hub
    {
        /// <summary>
        /// Send a  "new notification broadcast"
        /// </summary>
        /// <remarks>
        /// This method will be called if the user calls the next code from the javascript client code.
        /// <code>
        /// connection.invoke("SendBroadCastNofication",...)
        /// </code>
        /// </remarks>
        /// <param name="newNotification">The notification that has been received.</param>
        public void SendBroadcastNotification(NotificationModel newNotification)
        {
            Clients.All.SendAsync("ReceiveNotification", newNotification);
        }

        /// <summary>
        /// Send notification list and specify the user that needs to receive the notifications.
        /// </summary>
        /// <param name="user">Notification owner (user)</param>
        /// <param name="notificationList"></param>

        public void SendNotificationListForOneUser(string user,IEnumerable<NotificationModel> notificationList)
        {
            Clients.All.SendAsync("ReceiveNotificationList",user, notificationList);
        }
    }
}
