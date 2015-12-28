using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace station.Models
{
    public class DataPoint
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public Double Value { get; set; }


        public Equipment Equipment {get;set;}
    }
}