using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class JSON
    {
        public string Message { get; set; }

        public LLFCForm FormData { get; set; }

        public object Data { get; set; }
    }
}