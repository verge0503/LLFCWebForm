using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.ITInvetory
{
    public class ITEInventory
    {
        public int ITEInventoryID { get; set; }

        public int CategoryID { get; set; }

        public int StatusID { get; set; }

        public DateTime DateAcquired { get; set; }

        public decimal Price { get; set; }
       
        public string ItemDescription { get; set; }
    }
}