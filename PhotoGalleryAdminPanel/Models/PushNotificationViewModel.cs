using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryAdminPanel.Models
{
    public class PushNotificationViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
        public string ImageUrl { get; set; }
    }
}
