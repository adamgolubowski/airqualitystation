using station.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace station.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class StationContext : DbContext
    {
        //public StationContext() : base("airQualityMonitoringSystem")
        //public StationContext() : base("Server=eu-cdbr-azure-north-d.cloudapp.net;Database=airQualityMonitoringSystem;Uid=bdb8ea4d1a58d6;Pwd=cd9e8733") 
        public StationContext() : base("StationDB")
        {
            //DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}