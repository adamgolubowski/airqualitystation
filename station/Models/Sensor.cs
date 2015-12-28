using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace station.Models
{
    public enum MeasureType
    {
        Temperature, Humidity, CO2, NO2, CO, O3, NH3, Dust
    }

    public class Sensor
    {
        public int ID { get; set; }
        public String Model { get; set; }

        public MeasureType MeasureType { get; set; }
    }
}
