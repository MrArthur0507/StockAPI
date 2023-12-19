using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{

    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpPost]
        [Route("createNotification")]
        public IActionResult CreateNotification(NotificationViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            return StatusCode(_notificationService.CreateNotifcation(model).Result);
        }
    }
}
