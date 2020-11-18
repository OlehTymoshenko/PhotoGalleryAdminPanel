using System.Threading.Tasks;
using PhotoGalleryAdminPanel.Models;

namespace PhotoGalleryAdminPanel.Services.PushNotifications
{
    public interface IPushNotificationService
    {
        Task<string> SendPushNotification(PushNotificationViewModel notification);
    }
}
