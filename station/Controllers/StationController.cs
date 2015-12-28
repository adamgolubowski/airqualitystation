using station.DAL;
using station.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace station.Controllers
{
    public class StationController : ApiController
    {
        private StationContext db = new StationContext();

        public IQueryable<StationDTO> GetStations()
        {

            var query = from station in db.Stations
                        from equipment in db.Equipments
                            .Where(s=>s.StationID==station.ID)
                            .DefaultIfEmpty()
                        from sensor in db.Sensors
                            .Where(s=>s.ID==equipment.SensorID)
                            .DefaultIfEmpty()
                        select new StationDTO
                        {
                            stationID = station.ID,
                            stationName = station.Name,
                            equipmentID = equipment.ID.ToString(),
                            MeasureType = sensor.MeasureType.ToString(),
                            sensorModel = sensor.Model
                        };

            return query;
        }

        public IQueryable<StationDTO> GetStation(int? id)
        {

            var query = from station in db.Stations
                        .Where(s=>s.ID==id)
                        from equipment in db.Equipments
                            .Where(s => s.StationID == station.ID)
                            .DefaultIfEmpty()
                        from sensor in db.Sensors
                            .Where(s => s.ID == equipment.SensorID)
                            .DefaultIfEmpty()
                        select new StationDTO
                        {
                            stationID = station.ID,
                            stationName = station.Name,
                            equipmentID = equipment.ID.ToString(),
                            MeasureType = sensor.MeasureType.ToString(),
                            sensorModel = sensor.Model
                        };

            return query;
        }
    }
}
