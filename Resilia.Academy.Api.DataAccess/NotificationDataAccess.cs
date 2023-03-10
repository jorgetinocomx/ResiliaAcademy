using Resilia.Academy.Api.DataAccess.Interfaces;
using Resilia.Academy.Api.Entities;

namespace Resilia.Academy.Api.DataAccess
{
    /// <summary>
    /// In charge of connection to the database to get all the information.
    /// </summary>
    /// <remarks>
    /// This implementation uses MS SQL server as the DB provider.
    /// </remarks>
    public class NotificationDataAccess: INotificationDataAccess
    {
        private readonly ApiDbContext _context;

        /// <summary>
        /// Injects the ApiDbContext.
        /// </summary>
        /// <param name="context">Created instance for the context.</param>
        public NotificationDataAccess(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get notifications for an specific user using the email.
        /// </summary>
        /// <param name="forUser">User email.</param>
        /// <returns>All notifications found.</returns>
        public IEnumerable<Notification> GetNotifications(string forUser)
        {
            var itemsFound = _context
                                .Notifications
                                .Where(notif => notif.Recipient == forUser)
                                .OrderByDescending(notif => notif.CreationDate)
                                .AsEnumerable();
            return itemsFound;
        }

        /// <summary>
        /// Stores an notification entry on database.
        /// </summary>
        /// <param name="data">Entity to store in the database.</param>
        /// <returns>Inserted notification (including the AUTOGENERATED ID).</returns>
        public Notification NewNotification(Notification data)
        {
             _context
                    .Notifications
                    .Add(data);
            _context.SaveChanges();
            return data;
        }
    }
}
