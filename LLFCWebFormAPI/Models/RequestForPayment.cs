using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class RequestForPayment
    {
        public string FileName { get; set; }

        public string RequestDate { get; set; }

        public string Payee { get; set; }

        public string AmountInWords { get; set; }

        public decimal AmountInValue { get; set; }

        public string Purpose { get; set; }

        public string DueDate { get; set; }

        public int FormOfPaymentID { get; set; }

        public string OtherFormOfPayment { get; set; }

        public Person PreparedBy { get; set; }

        public Person RecommendedBy { get; set; }
    }
}