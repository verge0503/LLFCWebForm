using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class DisclosureStatement
    {
        public string FileName { get; set; }

        public string BorrowerLessee { get; set; }

        public string Address { get; set; }

        public int MLA { get; set; }

        public int LNA { get; set; }

        public int STCL { get; set; }

        public int LS { get; set; }

        public int PN { get; set; }

        public decimal AmountToBeFinanced { get; set; }

        public decimal FinanceChargesANDFP { get; set; }

        public decimal FinanceChargesADFP { get; set; }

        public decimal FinanceChargesBNDFP { get; set; }

        public decimal FinanceChargesBDFP { get; set; }

        public decimal TotalFinanceChargesNDFP { get; set; }

        public decimal TotalFinanceChargesDFP { get; set; }

        public decimal NonFinanceChargesANDFP { get; set; }

        public decimal NonFinanceChargesADFP { get; set; }

        public decimal NonFinanceChargesBNDFP { get; set; }

        public decimal NonFinanceChargesBDFP { get; set; }

        public decimal NonFinanceChargesCNDFP { get; set; }

        public decimal NonFinanceChargesCDFP { get; set; }

        public decimal NonFinanceChargesDNDFP { get; set; }

        public decimal NonFinanceChargesDDFP { get; set; }

        public decimal NonFinanceChargesENDFP { get; set; }

        public decimal NonFinanceChargesEDFP { get; set; }

        public decimal TotalNonFinanceChargesNDFP { get; set; }

        public decimal TotalNonFinanceChargesDFP { get; set; }

        public decimal TotalDeductionsFromProceedsOfLeaseLoan { get; set; }

        public decimal NetAmountToBeFinanced { get; set; }

        public string LesseeBorrowerFirstName { get; set; }

        public string LesseeBorrowerLastName { get; set; }

        public string LesseeBorrowerMiddleInitial { get; set; }

        public string LesseeBorrowerSuffix { get; set; }

        public DateTime DateCertified { get; set; }

        public DateTime LesseeBorrowerTIN { get; set; }
    }
}