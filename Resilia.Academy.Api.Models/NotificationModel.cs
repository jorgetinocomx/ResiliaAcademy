namespace Resilia.Academy.Api.Models
{
    /// <summary>
    /// Represents a single notification.
    /// </summary>
    public class NotificationModel
    {
        /// <summary>
        /// Notification title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Notification message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// When the nofitication was generated.
        /// </summary>
        public string TimeAgo { get; set; }
    }
}
