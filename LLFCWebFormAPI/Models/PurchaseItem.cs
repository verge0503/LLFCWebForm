using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class PurchaseItem
    {
        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string ItemDescription { get; set; }

        public string EstimatedUnitCost { get; set; }

        public string EstimatedCost { get; set; }
    }
}