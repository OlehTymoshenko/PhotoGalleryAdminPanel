using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhotoGalleryWebAPI.Models;

namespace PhotoGalleryWebAPI.Data.JSONFile
{
    public abstract class JSONFileRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly string JSON_FILE_NAME;

        private static int id;

        static JSONFileRepository()
        {
            id = 0;
        }


        private JArray jsonStorage;

        public JSONFileRepository()
        {
            JSON_FILE_NAME = Path.Combine(Directory.GetCurrentDirectory(), @"Data\JSONFile\Reservations.json");
            InitJsonStorage();
            SeedData();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {     
            return Task.FromResult(this.jsonStorage.ToObject<IEnumerable<TEntity>>());
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            this.jsonStorage.Add(JToken.FromObject(entity));
            SaveChanges();
            return Task.FromResult(entity);
        }

        public void SaveChanges()
        {
            try
            {
                using (StreamWriter fileWriter = File.CreateText(JSON_FILE_NAME))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(fileWriter))
                {
                    jsonStorage.WriteTo(jsonWriter);
                }
            }
            catch
            {
                jsonStorage = new JArray();
                throw;
            }
        }


        private void InitJsonStorage()
        {
            try
            {
                using (StreamReader fileReader = File.OpenText(JSON_FILE_NAME))
                using (JsonTextReader jsonReader = new JsonTextReader(fileReader))
                {
                    jsonStorage = JArray.Load(jsonReader);
                }
            }
            catch (Exception ex)
            {
                jsonStorage = new JArray();
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

        private void SeedData()
        {
            if (jsonStorage.Count > 0) return;
            jsonStorage.Add(JToken.FromObject(new Reservation() { Id = id++, Duration = new TimeSpan(1, 45, 0), Name = "Oleh", ReservationDateTime = DateTime.UtcNow.AddHours(1) }));
            this.SaveChanges();
        }

    }
}
