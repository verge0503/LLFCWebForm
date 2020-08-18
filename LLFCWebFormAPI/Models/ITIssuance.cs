using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class ITIssuance
    {
        public string FileName { get; set; }

        public Employee EmployeeFullName { get; set; }

        public string ControlNumber { get; set; }

        public string Date { get; set; }

        public GroupUnit GroupUnit { get; set; }

        public List<EquipmentSpecification> EquipmentSpecification { get; set; }
    }
}