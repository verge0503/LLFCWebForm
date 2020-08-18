using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class PurchaseRequest
    {
        public string FileName { get; set; }

        public GroupUnit GroupUnit { get; set; }

        public string Date { get; set; }

        public List<PurchaseItem> Items { get; set; }

        public string Purpose { get; set; }

        public string Attachments { get; set; }

    }
}