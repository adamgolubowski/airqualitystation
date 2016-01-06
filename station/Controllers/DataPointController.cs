using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using station.Models;
using station.DAL;
using station.DTOs;
using System.Web.Http.Cors;

namespace station.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET")]
    public class DataPointController : ApiController
    {
        private StationContext db = new StationContext();

        // GET: api/DataPoint
        [Route("api/datapoints")]
        [HttpGet]
        public IQueryable<DatapointDTO> GetDataPoints()
        {
            var query = from datapoint in db.DataPoints
                        from equipment in db.Equipments
                            .Where(e => e.ID == datapoint.equipmentID)
                        from station in db.Stations
                            .Where(s => s.ID == equipment.StationID)
                        from sensor in db.Sensors
                            .Where(s => s.ID == equipment.SensorID)
                        select new DatapointDTO
                        {
                            ID = datapoint.ID,
                            TimeStamp = datapoint.TimeStamp,
                            Value = datapoint.Value,
                            MeasureType = sensor.MeasureType,
                            StationName = station.Name,
                            SensorType = sensor.Model
                        };
            return query;
        }

        //select by date range
        [Route("api/datapoints/{start:datetime}/{end:datetime}")]
        [HttpGet]
        public IQueryable<DatapointDTO> GetDataPoints(DateTime start, DateTime end)
        {
            var query = from datapoint in db.DataPoints
                            .Where(d=>d.TimeStamp>=start && d.TimeStamp<=end)
                        from equipment in db.Equipments
                            .Where(e => e.ID == datapoint.equipmentID)
                        from station in db.Stations
                            .Where(s => s.ID == equipment.StationID)
                        from sensor in db.Sensors
                            .Where(s => s.ID == equipment.SensorID)
                        select new DatapointDTO
                        {
                            ID = datapoint.ID,
                            TimeStamp = datapoint.TimeStamp,
                            Value = datapoint.Value,
                            MeasureType = sensor.MeasureType,
                            StationName = station.Name,
                            SensorType = sensor.Model
                        };
            return query;
        }

        [Route("api/stations/{id:int}/sensors/{sensorID:int}/datapoints/{start:datetime}/{end:datetime}")]
        [HttpGet]
        public IQueryable<DatapointDTO> GetDataPoints(int id, int sensorID, DateTime start, DateTime end)
        {
            //MeasureType measureT = (MeasureType)Enum.Parse(typeof(MeasureType), category, true);
            var query = from datapoint in db.DataPoints
                            .Where(d => d.TimeStamp >= start && d.TimeStamp <= end && d.equipmentID==sensorID)
                        from equipment in db.Equipments
                            .Where(e => e.ID == datapoint.equipmentID)
                        from station in db.Stations
                            .Where(s => s.ID == equipment.StationID && s.ID == id)
                        from sensor in db.Sensors
                            .Where(s => s.ID == equipment.SensorID)
                        select new DatapointDTO
                        {
                            ID = datapoint.ID,
                            TimeStamp = datapoint.TimeStamp,
                            Value = datapoint.Value,
                            MeasureType = sensor.MeasureType,
                            StationName = station.Name,
                            SensorType = sensor.Model
                        };
            return query;
        }

        // POST: api/DataPoint
        [ResponseType(typeof(DataPoint))]
        public IHttpActionResult PostDataPoint(DataPoint dataPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DataPoints.Add(dataPoint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dataPoint.ID }, dataPoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataPointExists(int id)
        {
            return db.DataPoints.Count(e => e.ID == id) > 0;
        }
    }
}