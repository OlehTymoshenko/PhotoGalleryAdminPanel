using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoGalleryWebAPI.Data;
using PhotoGalleryWebAPI.Models;


namespace PhotoGalleryWebAPI.Services
{
    public class BookingService : IBookingService
    {
        private IRepository<Reservation> repository;

        public BookingService(IRepository<Reservation> repository)
        {
            this.repository = repository;
        }


        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            return await repository.AddAsync(reservation);
        }
    }
}
