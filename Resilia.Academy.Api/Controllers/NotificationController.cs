using Microsoft.AspNetCore.Mvc;
using Resilia.Academy.Api.Models;

namespace Resilia.Academy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all the notifications for an specific user.
        /// </summary>
        /// <param name="user">User email.</param>
        /// <returns>Notifications.</returns>
        [HttpGet]
        public IEnumerable<NotificationModel> Get(string user)
        {
            var fakeNotification = new NotificationModel() { Title = " Hi , there", Message = "this is notifiation", TimeAgo = "right now" };
            var arrayNotif = new NotificationModel[1] {fakeNotification};
            return arrayNotif;
        }
    }
}
