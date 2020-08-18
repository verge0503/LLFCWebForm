using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LLFCWebFormAPI.Models
{
    public class LLFCForm
    {
        public int FormID { get; set; }

        public int FormDescription { get; set; }

        public string FormFilename { get; set; }

        public string FormLocation { get; set; }

        public string FormDownloadFile { get; set; }

        public StreamContent Content { get; set; }
    }
}