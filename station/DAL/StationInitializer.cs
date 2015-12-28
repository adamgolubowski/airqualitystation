using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using station.Models;

namespace station.DAL
{
    public class StationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StationContext>
    {
        protected override void Seed(StationContext context)
        {
            var stations = new List<Station>()
            {
                new Station{Name="Białystok-Centrum",LocLattitude=23.157905,LocLongitude=53.134699},
                new Station{Name="Warszawa-Nowogrodzka",LocLattitude=20.9918983,LocLongitude=52.2249882}
            };
            stations.ForEach(s=>context.Stations.Add(s));
            context.SaveChanges();

            var sensors =new List<Sensor>(){
                new Sensor{Model="MQ-131",MeasureType=MeasureType.O3},
                new Sensor{Model="MQ-9",MeasureType=MeasureType.CO},
                new Sensor{Model="GP2Y1010AU0F",MeasureType=MeasureType.Dust},
                new Sensor{Model="DHT-21",MeasureType=MeasureType.Temperature},
                new Sensor{Model="DHT-21",MeasureType=MeasureType.Humidity}
            };
            sensors.ForEach(s => context.Sensors.Add(s));
            context.SaveChanges();

            //var equipments = new List<Equipment>()
            //{
            //    new Equipment{StationID=1,SensorID=1},
            //    new Equipment{StationID=1,SensorID=2},
            //    new Equipment{StationID=1,SensorID=3},
            //    new Equipment{StationID=1,SensorID=4},
            //    new Equipment{StationID=1,SensorID=5},
            //    new Equipment{StationID=2,SensorID=1},
            //    new Equipment{StationID=2,SensorID=2},
            //    new Equipment{StationID=2,SensorID=3},
            //    new Equipment{StationID=2,SensorID=4},
            //    new Equipment{StationID=2,SensorID=5},
            //};
            //equipments.ForEach(e => context.Equipments.Add(e));
            //context.SaveChanges();



        }
    }
}