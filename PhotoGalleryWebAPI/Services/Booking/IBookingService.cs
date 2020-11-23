using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoGalleryWebAPI.Models;

namespace PhotoGalleryWebAPI.Services
{
    public interface IBookingService
    {
        public Task<IEnumerable<Reservation>> GetAll();

        public Task<Reservation> Add(Reservation reservation);
    }
}
