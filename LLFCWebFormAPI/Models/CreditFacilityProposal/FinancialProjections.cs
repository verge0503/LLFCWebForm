using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class FinancialProjections
    {
        public AccountDetails AccountDetails { get; set; }

        public int FinancialProjectionsID { get; set; }

        public string BasicAssumptions { get; set; }

        public string ProjectedIncome { get; set; }

        public string ProjectedCashFlows { get; set; }
    }
}