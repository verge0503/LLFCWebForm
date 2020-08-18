using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class JobOfferForOfficer
    {
        public string Filename { get; set; }

        public string Date { get; set; }

        public string MonthlySalary { get; set; }

        public Person PersonName { get; set; }

        public Position Position { get; set; }

        public string GroupUnit { get; set; }

        public string RATA { get; set; }


        public string SalaryGrade { get; set; }

        public string SalaryGradeStep { get; set; }

        public string StartDate { get; set; }

        public string WorkIn { get; set; }

        public string WorkOut { get; set; }

    }
}