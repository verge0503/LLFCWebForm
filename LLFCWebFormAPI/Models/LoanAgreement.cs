using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class LoanAgreement
    {
        public string FileName { get; set; }

        public int LoanAgreementNumber { get; set; }

        public string LLFCPresidentFirstName { get; set; }

        public string LLFCPresidentLastName { get; set; }

        public string LLFCPresidentMiddleInitial { get; set; }

        public string LLFCPresidentTINNum { get; set; }

        public string BorrowerCompanyName { get; set; }

        public string BorrowerCompanyAddress { get; set; }

        public string BorrowerCompanyTINNumber { get; set; }

        public string BorrowerAuthorizedSignatoryFirstName { get; set; }

        public string BorrowerAuthorizedSignatoryLastName { get; set; }

        public string BorrowerAuthorizedSignatoryMiddleInitial { get; set; }

        public string BorrowerAuthorizedSignatoryPosition { get; set; }

        public string BorrowerAuthorizedSignatoryTINNumber { get; set; }

        public string TypeOfFacility { get; set; }

        public string AmountInWords { get; set; }

        public decimal AmountInValue { get; set; }

        public string LoanAmount { get; set; }

        public string AmountInWordsArticle1 { get; set; }

        public string AmountInValueArticle1 { get; set; }

        public string PurposeOfTheLoan { get; set; }

        public string WitnessFirstName { get; set; }

        public string WitnessLastName { get; set; }

        public string WitnessMiddleInitial { get; set; }

        public string AccountOfficerFirstName { get; set; }

        public string AccountOfficerLastName { get; set; }

        public string AccountOfficerMiddleInitial { get; set; }

        public List<TermAndMannerOfPayment> TermsAndMannersOfPayment { get; set; }

        public List<TermAndCondition> TermsAndConditions { get; set; }

        public List<SpecificUndertaking> SpecificUndertakings { get; set; }

        public List<OtherTermAndCondition> OtherTermsAndConditions { get; set; }
    }
}