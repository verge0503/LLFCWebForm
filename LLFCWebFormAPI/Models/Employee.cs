using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string EmployeeCode { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeMiddleName { get; set; }

        public string EmployeeSuffix { get; set; }
    }
}