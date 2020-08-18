using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace LLFCWebFormAPI.Controllers
{
    public class FormToWord
    {
        public void ApplyDataToBookmark(Dictionary<string, string> bookmarks, Document doc)
        {
            foreach (var bookmark in bookmarks)
            {
                Bookmark bm = doc.Bookmarks[bookmark.Key];
                Range range = bm.Range;
                range.Text = bookmark.Value;
                range.Font.Color = WdColor.wdColorBlack;
                //range.Font.Bold = 1;
                doc.Bookmarks.Add(bookmark.Key, range);
            }
        }

        public void DownloadFile(string Filename, string FileLocation)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(FileLocation + Filename + ".docx"), "C:/" + Filename + ".docx");
            }
        }
    }
}