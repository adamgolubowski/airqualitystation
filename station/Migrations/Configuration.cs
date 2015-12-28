namespace station.Migrations
{
    using System.Data.Entity.Migrations;
    using station.Models;
    using System.Collections.Generic;
    //using Microsoft.AspNet.Identity;
    //using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<station.DAL.StationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //bool AddUserAndRole(station.DAL.StationContext context)
        //{
        //    IdentityResult ir;
        //    var rm = new RoleManager<IdentityRole>
        //        (new RoleStore<IdentityRole>(context));
        //    ir = rm.Create(new IdentityRole("canEdit"));
        //    var um = new UserManager<ApplicationUser>(
        //        new UserStore<ApplicationUser>(context));
        //    var user = new ApplicationUser()
        //    {
        //        UserName = "stationAdmin",
        //    };
        //    ir = um.Create(user, "stationAdminPass");
        //    if (ir.Succeeded == false)
        //        return ir.Succeeded;
        //    ir = um.AddToRole(user.Id, "canEdit");
        //    return ir.Succeeded;

        //}

        protected override void Seed(station.DAL.StationContext context)
        {
            //AddUserAndRole(context);

            var stations = new List<Station>()
            {
                new Station{Name="Bia³ystok-Centrum",LocLattitude=53.134699,LocLongitude=23.157905},
                new Station{Name="Warszawa-Nowogrodzka",LocLattitude=52.2249882,LocLongitude=20.9918983}
            };
            stations.ForEach(s => context.Stations.Add(s));
            context.SaveChanges();

            var sensors = new List<Sensor>(){
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
