using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class RequestForPaymentClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateRequestForPayment(RequestForPayment Param)
        {
            JSON returnJSON = new JSON();

            Application app = new Application();
            object misValue = System.Reflection.Missing.Value;

            if (File.Exists(FormController.ServerPathTempForms() + Param.FileName + ".docx"))
            {
                File.Delete(FormController.ServerPathTempForms() + Param.FileName + ".docx");
            }

            try
            {
                File.Copy(FormController.ServerPathFormsTemplate() + "Request for Payment.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "RequestDate", Param.RequestDate },
                    { "Payee", Param.Payee },
                    { "AmountInWords",  $"{NumberToText.Convert(Param.AmountInValue)} Pesos" },
                    { "AmountInValue", "₱ " + String.Format("{0:n}", Param.AmountInValue) },
                    { "Purpose", Param.Purpose },
                    { "DueDate", Param.DueDate },
                    { "PreparedBy", GenFunct.ToTitleCase($"{Param.PreparedBy.FirstName} {Param.PreparedBy.MiddleName}. {Param.PreparedBy.LastName} {Param.PreparedBy.Suffix}") },
                    { "FormOfPayment", GetFormOfPaymentDescription(Param.FormOfPaymentID, Param.OtherFormOfPayment) },
                    //{ "OtherFormOfPayment", Param.OtherFormOfPayment },
                    { "RecommendedBy", GenFunct.ToTitleCase($"{Param.RecommendedBy.FirstName} {Param.RecommendedBy.MiddleName}. {Param.RecommendedBy.LastName} {Param.RecommendedBy.Suffix}") }
                };

                FormToWord.ApplyDataToBookmark(bookmarks, doc);

                doc.Save();
                doc.Close();

                app.Quit();

                LLFCForm LLFCFormObj = new LLFCForm();
                LLFCFormObj.FormDownloadFile = Param.FileName;

                returnJSON.FormData = LLFCFormObj;
            }
            catch (Exception ex)
            {
                app.Quit();
                returnJSON.Message = $"Error Occured: {ex.Message}";
            }

            return returnJSON;
        }

        public string GetFormOfPaymentDescription (int ParamFormOfPaymentID, string OtherFormOfPayment)
        {
            string FormOfPaymentDescription;
            int FormOfPaymentID = ParamFormOfPaymentID;

            if(FormOfPaymentID == 3)
            {
                FormOfPaymentDescription = OtherFormOfPayment;
            } 
            else
            {
                FormOfPayment FormOfPaymentObj = DBAccess.GetFormOfPayment(FormOfPaymentID);
                FormOfPaymentDescription = FormOfPaymentObj.FormOfPaymentDescription;
            }

            return FormOfPaymentDescription;
        }
    }
}