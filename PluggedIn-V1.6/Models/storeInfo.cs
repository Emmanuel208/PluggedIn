

namespace PluggedIn_V1._6.Models
{
    using System;
    using System.Collections.Generic;
    using System.Spatial;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class storeInfo
    {


        public int storeID { get; set; }
        public string storeName { get; set; }

        public string storeLocation { get; set; }

        public System.Data.Entity.Spatial.DbGeography GeoLocation { get; set; }


        public double? lat
        {
            get; set;
        }
        public double? lng
        {
            get;
            set;
        }

        public double? Distance { get; set; }

    }



}
