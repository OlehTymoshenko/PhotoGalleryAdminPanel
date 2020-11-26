using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoGalleryWebAPI.Models;

namespace PhotoGalleryWebAPI.Services
{
    public interface IBookingService
    {
        public IEnumerable<Reservation> GetAll();

        public Reservation Add(Reservation reservation);
    }
}