using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcFutbol.Models
{
    public class Takimlarim
    {

        public int TakimId { get; set; }
        public string TakimAdi { get; set; }
        public string TakimSehri { get; set; }
        public string TakimUlkesi { get; set; }
        public int TakimGalibiyet { get; set; }
        public int TakimMalubiyet { get; set; }
        public int TakimBeraberlik { get; set; }


    }
}