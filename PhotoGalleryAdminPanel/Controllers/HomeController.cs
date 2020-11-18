using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoGalleryAdminPanel.Models;
using PhotoGalleryAdminPanel.Services.PushNotifications;

namespace PhotoGalleryAdminPanel.Controllers
{
    public class HomeController : Controller
    {
		private IPushNotificationService pushNotifService;

		public HomeController(IPushNotificationService pushNotifService)
		{
			this.pushNotifService = pushNotifService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CreatePushNotification()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> CreatePushNotification(PushNotificationViewModel notification)
		{
			await pushNotifService.SendPushNotification(notification);

			return RedirectToAction(nameof(CreatePushNotification));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
