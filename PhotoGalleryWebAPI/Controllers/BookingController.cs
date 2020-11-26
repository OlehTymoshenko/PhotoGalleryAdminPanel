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
        private readonly ILogger<BookingController> logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            this.bookingService = bookingService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            try
            {
                var reservations =  bookingService.GetAll();
            
                if(reservations == null)
                {
                    logger.LogWarning("Request {@Path} | Method {ServiceMethodName} return null", this.HttpContext.Request.Path, nameof(bookingService.GetAll));
                    return new NoContentResult();
                }
                else
                {
                    logger.LogDebug("Request {@Path}| Reservations list get from storage successfully ", this.HttpContext.Request.Path);
                }

                var res = from item in reservations
                          select new
                          {
                              id = item.Id,
                              name = item.Name,
                              reservationDateTime = item.ReservationDateTime.ToUniversalTime().ToString("o"),
                              duration = item.Duration.ToString()
                          };

                if(res == null)
                {
                    logger.LogWarning("Request {Path} | Creating result reservation list failed.", this.HttpContext.Request.Path);
                    return StatusCode(500);
                }
                else
                {
                    logger.LogDebug("Request {Path} | Creating result reservation list successfully.", this.HttpContext.Request.Path);
                }


                return new JsonResult(res);
            }
            catch(Exception ex)
            {
                logger.LogError(ex ,"Request {Path} | Unexpected exception", this.HttpContext.Request.Path);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Post(ReservationDTO reservationDTO)
        {
            try
            {
                Reservation reservation = new Reservation()
                {
                    Id = reservationDTO.Id,
                    Name = reservationDTO.Name,
                    ReservationDateTime = DateTime.Parse(reservationDTO.ReservationDateTime).ToUniversalTime(),
                    Duration = TimeSpan.Parse(reservationDTO.Duration)
                };

                if(reservation == null)
                {
                    logger.LogWarning("Request {Path} | New reservation is equal to null", this.HttpContext.Request.Path);
                    return StatusCode(500);
                }
                else
                {
                    logger.LogDebug("Request {Path} | Creating reservation for adding to storage is successfully", this.HttpContext.Request.Path);
                }

                return bookingService.Add(reservation);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Request {Path} | Unexpected exception", this.HttpContext.Request.Path);
                return StatusCode(500);
            }
        }
    }
}
