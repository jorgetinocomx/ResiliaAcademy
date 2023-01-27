using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resilia.Academy.Api.Business.Interfaces;
using Resilia.Academy.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Resilia.Academy.Api.Controllers
{
    /// <summary>
    /// Manages all the Resilia notifications.
    /// </summary>
    [ApiController]
    [Route("api/notification")]
    [EnableCors("_myAllowSpecificOriginsForResiliaApp")]
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationBusiness _business;

        /// <summary>
        /// Inject the dependencies.
        /// </summary>
        /// <param name="logger">MS logger dependency instanciated.</param>
        /// <param name="business">Notifications business dependency instanciated.</param>
        public NotificationController(ILogger<NotificationController> logger, INotificationBusiness business)
        {
            _logger = logger;
            _business = business;
        }

        /// <summary>
        /// Get all the notifications for an specific userEmail.
        /// </summary>
        /// <param name="userEmail">User email.</param>
        /// <returns>Notifications.</returns>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<NotificationModel> Get([EmailAddress] string userEmail)
        {
            _logger.LogDebug($"Requested notifications for user : {userEmail}");
            var notifications = _business.GetNotifications(userEmail);
            return notifications;
        }

        /// <summary>
        /// Put some notifications for an specific userEmail.
        /// </summary>
        /// <param name="newNotificationData">Required data to craete a notification..</param>
        /// <returns>Notification id generated. When 0, no notification was generated.</returns>
        [HttpPost()]
        public IActionResult New(NewNotificationModel newNotificationData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var notificationId = _business.NewNotification(newNotificationData);
            _logger.LogDebug($"A notification with this ID was generated : {notificationId}");
            return Ok(notificationId);
        }
    }
}
