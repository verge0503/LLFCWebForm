using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class FieldWorkAuthMemo
    {
        public string FileName { get; set; }

        public Employee Employee { get; set; }

        public Position Position { get; set; }

        public string Subject { get; set; }

        public string Date { get; set; }

        public string DateOfFieldWork { get; set; }

        public string FromTimeOfFiedWork { get; set; }

        public string ToTimeOfFiedWork { get; set; }

        public string ProceedDirectlyFromResidence { get; set; }

        public Person PersonToSee { get; set; }

        public string OfficeBusinessName { get; set; }

        public string CompleteAddress { get; set; }

        public string Purpose { get; set; }

        public string OtherInstruction { get; set; }
    }
}