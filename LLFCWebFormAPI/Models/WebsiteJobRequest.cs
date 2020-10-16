using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class WebsiteJobRequest
    {
        public string FileName { get; set; }

        public List<WebsiteJobRequestContent> WebsiteContentRequest { get; set; }

        public Employee RequestedBy { get; set; }

        public Employee ConfirmedBy { get; set; }

    }
}