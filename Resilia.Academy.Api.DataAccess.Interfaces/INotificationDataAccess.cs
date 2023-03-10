using Resilia.Academy.Api.Entities;

namespace Resilia.Academy.Api.DataAccess.Interfaces
{
    /// <summary>
    /// Defines the interfaces/contracts for the notification data access.
    /// </summary>
    public interface INotificationDataAccess
    {
        /// <summary>
        /// Get notifications for an specific user using the email.
        /// </summary>
        /// <param name="forUser">User email.</param>
        /// <returns>All notifications found.</returns>
        public IEnumerable<Notification> GetNotifications(string forUser);

        /// <summary>
        /// Stores an notification entry on database.
        /// </summary>
        /// <param name="data">Entity to store in the database.</param>
        /// <returns>Inserted notification (including the AUTOGENERATED ID).</returns>
        public Notification NewNotification(Notification data);
    }
}
