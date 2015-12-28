using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace station.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public int StationID { get; set; }
        public int SensorID { get; set; }

        public Station Station { get; set; }
        public Sensor Sensor { get; set; }
    }
}