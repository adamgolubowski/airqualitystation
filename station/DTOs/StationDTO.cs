using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace station.DTOs
{
    public class StationDTO
    {
        public int stationID { get; set; }
        public string stationName { get; set; }
        public string equipmentID {get;set;}
        public string MeasureType {get; set;}
        public string sensorModel {get; set;}
    }
}