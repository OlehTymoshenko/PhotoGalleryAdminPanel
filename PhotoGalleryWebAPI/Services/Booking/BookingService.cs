using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PhotoGalleryWebAPI.Data;
using PhotoGalleryWebAPI.Models;


namespace PhotoGalleryWebAPI.Services
{
    public class BookingService : IBookingService
    {
        private IRepository<Reservation> repository;
        ILogger<BookingService> logger;

        public BookingService(IRepository<Reservation> repository, ILogger<BookingService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public IEnumerable<Reservation> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch(NullReferenceException nullRef)
            {
                logger.LogError(nullRef, "Method: BookingService.GetAll | BookingService ref is null");
                return null;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Method: BookingService.GetAll | Unexpected exception");
                return null;
            }
        }

        public Reservation Add(Reservation reservation)
        {
            try
            {
                var createdReservation = repository.Add(reservation);
                repository.SaveChanges();
                return createdReservation;
            }
            catch (NullReferenceException nullRef)
            {
                logger.LogError(nullRef, "Method: BookingService.Add | BookingService ref is null");
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Method: BookingService.GetAll | Unexpected exception");
                return null;
            }
            
        }
    }
}
