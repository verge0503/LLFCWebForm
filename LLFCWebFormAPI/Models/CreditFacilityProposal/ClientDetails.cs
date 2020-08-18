using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models.CreditFacilityProposal
{
    public class ClientDetails
    {
        public AccountDetails AccountDetails { get; set; }

        public string BusinessAddress { get; set; }

        public string ContactPerson { get; set; }

        public string Industry { get; set; }

        public string PSICCode { get; set; }

        public string ClientType { get; set; }

        public string TaxID { get; set; }

        public string IncomeTaxPaid { get; set; }

        public string ManpowerComplement { get; set; }

        public string CreditRating { get; set; }

        public string ClientSince { get; set; }

        public string AccountSource { get; set; }
    }
}