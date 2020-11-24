using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoGalleryWebAPI.Data;

namespace PhotoGalleryWebAPI.Models
{
    public class Reservation : IEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
