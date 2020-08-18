using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class SalaryGrade
    {
        public int SGID { get; set; }

        public int SG { get; set; }

        public List<SalaryPerStep> SalaryPerStep { get; set; }
    }
}