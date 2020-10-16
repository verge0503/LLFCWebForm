using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.ITInvetory
{
    public class Laptop
    {
        public ITEInventory ITEInventory { get; set; }

        public int LaptopID { get; set; }

        public string SerialNumber { get; set; }

        public string LaptopBrand { get; set; }

        public string LaptopModel { get; set; }

        public string Description { get; set; }

        public string LaptopStorage { get; set; }

        public string LaptopScreenSize {get; set;}

        public string LaptopProcessor { get; set; }

        public string LaptopRAM { get; set; }

        public string LaptopOS { get; set; }

    }
}