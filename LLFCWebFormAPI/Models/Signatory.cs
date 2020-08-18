using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class Signatory
    {
        public int SignatoryID { get; set; }

        public Employee EmployeeDetail { get; set; }

        public Department Department { get; set; }
    }
}