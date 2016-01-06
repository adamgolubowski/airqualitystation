using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using station.Models;
namespace station.DTOs
{
    public class DatapointDTO
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public Double Value { get; set; }
        public MeasureType MeasureType { get; set; }
        public String StationName { get; set; }
        public String SensorType { get; set; }
    }
}