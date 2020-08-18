using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class TermsAndConditions
    {
        public AccountDetails AccountDetails { get; set; }

        public int TermsAndConditionsID { get; set; }

        public string ProposedFacility { get; set; }

        public string Purpose { get; set;}

        public string AmountFacility { get; set; }

        public string LLFCTraining { get; set; }

        public string Term { get; set; }

        public string InterestRate { get; set; }

        public string ModeOfPayment { get; set; }

        public string AvailmentMethod { get; set; }

        public string SecurityCollateral { get; set; }

        public string OtherCondition { get; set; }

        public string OtherTermsAndCondition { get; set; }
    }
}