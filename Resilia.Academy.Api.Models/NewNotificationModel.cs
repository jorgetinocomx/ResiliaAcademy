using System.ComponentModel.DataAnnotations;

namespace Resilia.Academy.Api.Models
{
    /// <summary>
    /// Defines all the data that is required to create a new notification through the API.
    /// </summary>
    public class NewNotificationModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Notification title.
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        /// <summary>
        /// Notification message.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Message { get; set; }

        /// <summary>
        /// Notification author (is not allways the recipient of the notification).
        /// </summary>
        [Required]
        [EmailAddress]
        public string Author { get; set; }

        /// <summary>
        /// Notification recipient.
        /// </summary>
        [EmailAddress]
        public string Recipient { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
