using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoGalleryWebAPI.Models;
using PhotoGalleryWebAPI.Services;

namespace PhotoGalleryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            var reservations =  await bookingService.GetAll();

            var res = from item in reservations
                      select new
                      {
                          item.Id,
                          item.Name,
                          ReservationDateTime = item.ReservationDateTime.ToUniversalTime().ToString("o"),
                          Duration = item.Duration.ToString()
                      };

            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Post(Reservation reservation)
        {
            return await bookingService.Add(reservation);
        }
    }
}
