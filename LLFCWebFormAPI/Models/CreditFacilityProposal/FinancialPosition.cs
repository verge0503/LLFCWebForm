using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class FinancialPosition
    {
        public AccountDetails AccountDetails { get; set; }

        public int FinancialPositionID { get; set; }

        public string Auditor { get; set; }

        public string AuditorsUnqualifiedOpinion { get; set; }

        public string Liquidity { get; set; }

        public string SolvencyAndCapitalAdequacy { get; set; }

        public string Profitability { get; set; }
    }
}