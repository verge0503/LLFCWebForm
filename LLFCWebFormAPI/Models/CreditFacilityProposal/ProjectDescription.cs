using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class ProjectDescription
    {
        public AccountDetails AccountDetails { get; set; }

        public int ProjectDescriptionID { get; set; }

        public string ProposedFacilityDescription { get; set; }
    }
}