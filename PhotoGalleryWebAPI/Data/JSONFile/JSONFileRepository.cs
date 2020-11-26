using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhotoGalleryWebAPI.Models;

namespace PhotoGalleryWebAPI.Data.JSONFile
{
    public abstract class JSONFileRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly string JSON_FILE_NAME;

        private int id; // reservation ID. Id require, because reservations store in JSON file

        private JArray jsonStorage; // reservations

        private ILogger<JSONFileRepository<TEntity>> logger;

        public JSONFileRepository(ILogger<JSONFileRepository<TEntity>> logger)
        {
            JSON_FILE_NAME = Path.Combine(Directory.GetCurrentDirectory(), @"Data\JSONFile\Reservations.json");
            this.logger = logger;
            InitJsonStorage();
            SeedData();
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return this.jsonStorage.ToObject<IEnumerable<TEntity>>();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Method: {methodName} | Unexpected Exception, cant get all reservations list" , nameof(GetAll));
                return null;
            }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {

                if(entity == null)
                {
                    logger.LogWarning("Method: {methodName} | Entity for adding is null", nameof(Add));
                    return entity;
                }
                entity.Id = ++this.id;
                jsonStorage.Add(JToken.FromObject(entity));
                return entity;


            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Method: {methodName} | Unexpected Exception", nameof(Add));
                return null;
            }
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
                logger.LogInformation("Method: {methodName} | Changes in reservation storage saved to storage successfully", nameof(SaveChanges));
           
            }
            catch (IOException ioEx)
            {
                logger.LogError(ioEx, "Method: {methodName} | IO Exception, cant save changes to reservation storage," +
                    " storage path {storagePath}", nameof(SaveChanges), JSON_FILE_NAME);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Method: {methodName} | Unexpected exception, cant save changes to reservation storage," +
                        " storage path {storagePath}", nameof(SaveChanges), JSON_FILE_NAME);
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
                logger.LogDebug("Method: {methodName} | Connectiont to reservation storage completed successfully", nameof(InitJsonStorage));
            }
            catch (IOException ioEx)
            {
                jsonStorage = new JArray();
                logger.LogError(ioEx, "Method: {methodName} | IO Exception, cant connect to storage with reservations," +
                    " storage path {storagePath}. Empty storage created", nameof(InitJsonStorage), JSON_FILE_NAME);
            }
            catch (Exception ex)
            {
                jsonStorage = new JArray();
                logger.LogError(ex, "Method: {methodName} | Unexpected exception, cant connect to storage with reservations," +
                        " storage path {storagePath}. Empty storage created", nameof(InitJsonStorage), JSON_FILE_NAME);
            }
            finally
            {
                id = jsonStorage.ToObject<IEnumerable<TEntity>>().Max(entity => entity.Id).GetValueOrDefault();
            }
        }

        private void SeedData()
        {
            try
            {
                if (jsonStorage.Count > 0) 
                {
                    logger.LogDebug("Method: {methodName} | Reservation storage is not empty", nameof(SeedData));
                    return;
                }
                jsonStorage.Add(JToken.FromObject(new Reservation() { Id = id++, Duration = new TimeSpan(1, 45, 0), Name = "Oleh", ReservationDateTime = DateTime.UtcNow.AddHours(1).ToUniversalTime() }));
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Method: {methodName} | Unexpected exception", nameof(SeedData), JSON_FILE_NAME);
            }
        }
    }
}
