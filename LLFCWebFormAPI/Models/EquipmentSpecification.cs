using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class EquipmentSpecification
    {
        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string Particulars { get; set; }

        public string AcquisitionCost { get; set; }

        public string PropertyNumber { get; set; }
    }
}