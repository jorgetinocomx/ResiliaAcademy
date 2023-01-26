using System.ComponentModel.DataAnnotations.Schema;

namespace Resilia.Academy.Api.Entities
{
    /// <summary>
    /// Represents a single record in the table "Notification".
    /// </summary>
    [Table("Notification")]
    public class Notification
    {
        /// <summary>
        /// Notification ID.
        /// </summary>
        public int Id { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// Notification title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Notification message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Notification author (is not allways the recipient of the notification).
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Notification recipient.
        /// </summary>
       public string Recipient { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// True when notification has already read.
        /// </summary>
        public bool IsRead { get; set; }

       /// <summary>
       /// When the nofitication is created.
       /// </summary>
       public DateTime CreationDate { get; set; }

       /// <summary>
       /// When the notification was read.
       /// </summary>
       public DateTime? ReadDate { get; set;}

    }
}
