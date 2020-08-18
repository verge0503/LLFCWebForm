using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class ITAccessRequest
    {

        public string FileName { get; set; }

        public Employee Employee { get; set; }

        public Position Position { get; set; }

        public GroupUnit GroupUnit { get; set; }

        public YesNo LLFCEmail { get; set; }

        public YesNo Internet { get; set; }

        public YesNo MainEntrance { get; set; }

        public YesNo SecurityRoom { get; set; }

        public YesNo ServerRoom { get; set; }

        public YesNo PrinterBlackCopy { get; set; }

        public YesNo PrinterColoredCopy { get; set; }

        public YesNo Telephone { get; set; }

        public YesNo Biometrics { get; set; }

        public YesNo Jeonsoft { get; set; }

        public YesNo DMS { get; set; }

        public YesNo FMS { get; set; }

        public YesNo Jet { get; set; }

    }
}