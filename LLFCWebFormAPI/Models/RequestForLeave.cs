using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class RequestForLeave
    {
        public string FileName { get; set; }

        public Person Employee { get; set; }

        public string DateOfFiling { get; set; }

        public string InclusiveDateFrom { get; set; }

        public string InclusiveDateTo { get; set; }

        public string GroupUnit { get; set; }

        public string Salary { get; set; }

        public int LeaveTypeID { get; set; }

        public string LeaveCausePurpose { get; set; }

        public string OtherReason { get; set; }
    }
}