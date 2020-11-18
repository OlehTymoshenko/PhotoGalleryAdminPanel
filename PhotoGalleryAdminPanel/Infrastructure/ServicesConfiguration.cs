using System;
using Microsoft.Extensions.DependencyInjection;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

using PhotoGalleryAdminPanel.Services.PushNotifications;
using System.IO;

namespace PhotoGalleryAdminPanel.Infrastructure
{
    internal static class ServicsProviderExtensions
    {
        internal static void AddPushNotificationService(this IServiceCollection services)
        {
            var appFB = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FireBaseCredentials.json"))
            });

            var msgServiceFB = FirebaseMessaging.GetMessaging(appFB);

            services.AddScoped<IPushNotificationService>(cfg => new PushNotificationService { messagingFB = msgServiceFB });
        }
    }
}
