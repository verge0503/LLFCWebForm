using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class OtherCollateral
    {
        public AccountDetails AccountDetails { get; set; }

        public int OtherCollateralID { get; set; }

        public string OtherCollateralDescription { get; set; }
    }
}