using Microsoft.AspNetCore.SignalR;
using Resilia.Academy.Api.Business.Interfaces;
using Resilia.Academy.Api.DataAccess.Interfaces;
using Resilia.Academy.Api.Hubs;
using Resilia.Academy.Api.Models;

namespace Resilia.Academy.Api.Business
{
    /// <summary>
    /// Apply business rules or transformations to the notifications data to be applied into the principal resilia business.
    /// </summary>
    public class NotificationBusiness: INotificationBusiness
    {
        private INotificationDataAccess _dataAccess;
        private readonly IHubContext<NotificationsHub> _hubContext;


        /// <summary>
        /// Inject the data access instance.
        /// </summary>
        /// <param name="dataAccess">Instanced data access.</param>
        /// <param name="hubContext">SignalR dependency with the notifications hub.</param>
        public NotificationBusiness(INotificationDataAccess dataAccess, IHubContext<NotificationsHub> hubContext)
        {
            _dataAccess= dataAccess;
            _hubContext= hubContext;
        }

        /// <summary>
        /// Connects to database and transform some extracted database.
        /// </summary>
        /// <param name="forUser">User email.</param>
        /// <returns></returns>
        public IEnumerable<NotificationModel> GetNotifications(string forUser)
        {
            var rawData = _dataAccess.GetNotifications(forUser);
            var notifications = new List<NotificationModel>();
            foreach (var item in rawData)
            {
                var notification = new NotificationModel() { Id = item.Id, Title = "New notification", Message = item.Message, TimeAgo = RelativeDate(item.CreationDate), IsRead = item.IsRead };
                notifications.Add(notification);
            }
            return notifications;
        }
        /// <summary>
        /// IMPLEMENTATION FOR: Creates the notification entity and store it in the DB.
        /// </summary>
        /// <param name="newNotificationData">Required data to create a notification.</param>
        /// <returns>Generated notification ID.</returns>
        public int NewNotification(NewNotificationModel newNotificationData)
        {
            var entityToBeStored = new Entities.Notification() 
            {
                Title= newNotificationData.Title,
                Message = newNotificationData.Message,
                Recipient = newNotificationData.Recipient,
                Author= newNotificationData.Author,
                IsRead = false,
                CreationDate = DateTime.Now,
                ReadDate = null
            };  
            var insertedNotification = _dataAccess.NewNotification(entityToBeStored);

            // Send the push notification (as a broadcast)
            if(insertedNotification.Id != 0)
            {
                var notification = new NotificationModel() 
                { 
                    Id = insertedNotification.Id, 
                    Title = insertedNotification.Title, 
                    Message = insertedNotification.Message,
                    TimeAgo = RelativeDate(insertedNotification.CreationDate) 
                };

                var notificationList = GetNotifications(newNotificationData.Recipient);
                _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
                _hubContext.Clients.All.SendAsync("ReceiveNotificationList", newNotificationData.Recipient,  notificationList);
            }
            return insertedNotification.Id;
        }


        /// <summary>
        /// Given an specific date, calculates relative date 
        /// From: https://stackoverflow.com/questions/11/calculate-relative-time-in-c-sharp
        /// </summary>
        /// <param name="theDate">Date used to calculate the relative</param>
        /// <returns>Relative date.</returns>
        private string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minute ago");
            thresholds.Add(45 * minute, "{0} minutes ago");
            thresholds.Add(120 * minute, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");
            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }

    }
}
