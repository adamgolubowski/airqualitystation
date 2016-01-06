namespace station.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataPoint",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false, precision: 0),
                        Value = c.Double(nullable: false),
                        equipmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Equipment", t => t.equipmentID, cascadeDelete: true)
                .Index(t => t.equipmentID);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StationID = c.Int(nullable: false),
                        SensorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sensor", t => t.SensorID, cascadeDelete: true)
                .ForeignKey("dbo.Station", t => t.StationID, cascadeDelete: true)
                .Index(t => t.StationID)
                .Index(t => t.SensorID);
            
            CreateTable(
                "dbo.Sensor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(unicode: false),
                        MeasureType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Station",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        LocLongitude = c.Double(nullable: false),
                        LocLattitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataPoint", "equipmentID", "dbo.Equipment");
            DropForeignKey("dbo.Equipment", "StationID", "dbo.Station");
            DropForeignKey("dbo.Equipment", "SensorID", "dbo.Sensor");
            DropIndex("dbo.Equipment", new[] { "SensorID" });
            DropIndex("dbo.Equipment", new[] { "StationID" });
            DropIndex("dbo.DataPoint", new[] { "equipmentID" });
            DropTable("dbo.Station");
            DropTable("dbo.Sensor");
            DropTable("dbo.Equipment");
            DropTable("dbo.DataPoint");
        }
    }
}
