using Resilia.Academy.Api.Models;

namespace Resilia.Academy.Api.Business.Interfaces
{
    /// <summary>
    /// Defines the possible business methods for the notification entity.
    /// </summary>
    public interface INotificationBusiness
    {
        /// <summary>
        /// Connects to database and transform some extracted database.
        /// </summary>
        /// <param name="forUser">User email.</param>
        /// <returns></returns>
        public IEnumerable<NotificationModel> GetNotifications(string forUser);

        /// <summary>
        /// Creates the notification entity and store it in the DB.
        /// </summary>
        /// <param name="newNotificationData">Required data to create a notification.</param>
        /// <returns>Generated notification ID.</returns>
        public int NewNotification(NewNotificationModel newNotificationData);
    }
}
