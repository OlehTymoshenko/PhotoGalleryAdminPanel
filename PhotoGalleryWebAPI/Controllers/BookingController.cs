using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoGalleryWebAPI.Models;
using PhotoGalleryWebAPI.Services;

namespace PhotoGalleryWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly ILogger logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            this.bookingService = bookingService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            var reservations =  await bookingService.GetAll();
            logger.Log(LogLevel.Critical, "Test critical log {id}", 10);

            var res = from item in reservations
                      select new
                      {
                          id = item.Id,
                          name = item.Name,
                          reservationDateTime = item.ReservationDateTime.ToUniversalTime().ToString("o"),
                          duration = item.Duration.ToString()
                      };
            return new JsonResult(res);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Post(ReservationDTO reservationDTO)
        {
            Reservation reservation = new Reservation()
            {
                Id = reservationDTO.Id,
                Name = reservationDTO.Name,
                ReservationDateTime = DateTime.Parse(reservationDTO.ReservationDateTime).ToUniversalTime(),
                Duration = TimeSpan.Parse(reservationDTO.Duration)
            };
            return await bookingService.Add(reservation);
        }
    }
}
