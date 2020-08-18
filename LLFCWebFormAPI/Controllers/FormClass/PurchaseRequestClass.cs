using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class PurchaseRequestClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GeneratePurchaseRequest (PurchaseRequest Param)
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
                File.Copy(FormController.ServerPathFormsTemplate() + "Purchase Request.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "GroupUnit", Param.GroupUnit.GroupUnitDescription},
                    { "Date", Param.Date},
                    { "Purpose", Param. Purpose},
                    { "Attachments", Param.Attachments}
                };

                Table PurchaseItemRequest = doc.Tables[2];

                int TableRowCount = PurchaseItemRequest.Rows.Count;

                int itemCount = Param.Items.Count;

                for (int i = 0; i <= TableRowCount; i++)
                {
                    int row = i + 2;
                    PurchaseItemRequest.Cell(row, 1).Range.Text = Param.Items[i].Quantity.ToString();
                    PurchaseItemRequest.Cell(row, 2).Range.Text = Param.Items[i].Unit.ToString();
                    PurchaseItemRequest.Cell(row, 3).Range.Text = Param.Items[i].ItemDescription.ToString();
                    PurchaseItemRequest.Cell(row, 4).Range.Text = Param.Items[i].EstimatedUnitCost.ToString();
                    PurchaseItemRequest.Cell(row, 5).Range.Text = Param.Items[i].EstimatedCost.ToString();

                    itemCount = itemCount - 1;

                    if (itemCount == 0)
                    {
                        break;
                    }
                }

                FormToWord.ApplyDataToBookmark(bookmarks, doc);

                doc.Save();
                doc.ExportAsFixedFormat(FormController.ServerPathTempForms() + Param.FileName + ".pdf", WdExportFormat.wdExportFormatPDF);
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
    }
}