using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace station.Models
{

    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Double LocLongitude { get; set; }
        public Double LocLattitude { get; set; }
        //public string? Key { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}