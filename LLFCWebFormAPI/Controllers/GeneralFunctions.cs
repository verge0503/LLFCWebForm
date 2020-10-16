using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LLFCWebFormAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers
{
    public class GeneralFunctions
    {
        public string ToTitleCase (string TextToConvert)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            TextToConvert = textInfo.ToTitleCase(TextToConvert);

            return TextToConvert;
        }

        public string CheckIfNull (string ValueToCheck)
        {
            string returnString = "";

            if(ValueToCheck != null)
            {
                returnString = ValueToCheck;
            }

            return returnString;
        }

        public void GenerateWebsiteJobRequestPDF()
        {
            PdfWriter writer = new PdfWriter("D:\\Backend\\LLFCWebForm\\LLFCWebFormAPI\\FormsTemplate\\demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph Firstline_Header = new Paragraph("LBP Leasing and Finance Corporation")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(14);

            document.Add(Firstline_Header);

            Paragraph Secondline_Header = new Paragraph("Information Technology Unit")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(14);

            document.Add(Secondline_Header);

            Paragraph Thirdline_Header = new Paragraph("WEBSITE JOB REQUEST FORM")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(14)
                .SetBold();

            document.Add(Thirdline_Header);

            Paragraph Fourth_Header = new Paragraph("http://www.lbpleasing.com")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(14);

            document.Add(Fourth_Header);

            document.Close();
        }
    }
}