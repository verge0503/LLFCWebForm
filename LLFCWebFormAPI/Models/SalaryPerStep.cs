using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class SalaryPerStep
    {
        public int Salary_Per_Step_ID { get; set; }

        public int SalaryGrade { get; set; }

        public int Step { get; set; }

        public int Salary { get; set; }
    }
}