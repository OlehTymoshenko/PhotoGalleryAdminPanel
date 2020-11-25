using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryWebAPI.Models
{
    public class ReservationDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ReservationDateTime { get; set; }
        public string Duration { get; set; }
    }
}
