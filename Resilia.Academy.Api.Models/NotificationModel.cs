using System.ComponentModel.DataAnnotations;

namespace Resilia.Academy.Api.Models
{
    /// <summary>
    /// Represents a single notification.
    /// </summary>
    public class NotificationModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Notification ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Notification title.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Notification message
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// When the nofitication was generated.
        /// </summary>
        [Required]
        public string TimeAgo { get; set; }

        /// <summary>
        /// Says if notification was already read.
        /// </summary>
        public bool IsRead { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
