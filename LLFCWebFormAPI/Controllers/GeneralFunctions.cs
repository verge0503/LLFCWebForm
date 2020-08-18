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
    }
}