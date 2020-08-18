using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class BasisForRecommendation
    {

        public AccountDetails AccountDetails { get; set; }

        public int BasisForRecommendationID { get; set; }

        public string CharacterAP { get; set; }

        public string CharacterPerformance { get; set; }

        public string CapacityAP { get; set; }

        public string CapacityPerformance { get; set; }

        public string CapitalAP { get; set; }

        public string CapitalPerformance { get; set; }

        public string ConditionAP { get; set; }

        public string ConditionPerformance { get; set; }
    }
}