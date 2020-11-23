using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using PhotoGalleryWebAPI.Models;

namespace PhotoGalleryWebAPI.Data.JSONFile
{
    public class JsonFileBookingRepository : JSONFileRepository<Reservation>
    {
        public JsonFileBookingRepository() : base()
        {

        }
    }
}
