using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using PhotoGalleryAdminPanel.Models;

namespace PhotoGalleryAdminPanel.Services.PushNotifications
{
	public class PushNotificationService : IPushNotificationService
	{
		private const string ROOT_PATH_FOR_TOPICS = "/topics/";
		private const string DEFAULT_NOTIFICATION_IMAGE_URL = "https://cdn.auth0.com/blog/get-started-ionic/logo.png";

		public FirebaseMessaging messagingFB { get; set; }

		public PushNotificationService() { }

		public async Task<string> SendPushNotification(PushNotificationViewModel notification)
		{
			var msg = new Message()
			{
				Topic = ROOT_PATH_FOR_TOPICS + (notification.Topic ?? "all"),
				Notification = new Notification()
				{
					Title = notification.Title ?? "Photo gallery notification",
					Body = notification.Body ?? "",
					ImageUrl = notification.ImageUrl ?? DEFAULT_NOTIFICATION_IMAGE_URL
				}
			};

			return await messagingFB.SendAsync(msg);
		}
	}
}
