using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class WebsiteJobRequestClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateWebsiteJobRequest(WebsiteJobRequest Param)
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
                File.Copy(FormController.ServerPathFormsTemplate() + "Website Job Request Form.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "RequestedBy",  GenFunct.ToTitleCase($"{Param.RequestedBy.EmployeeFirstName} {Param.RequestedBy.EmployeeMiddleName}. {Param.RequestedBy.EmployeeLastName} {Param.RequestedBy.EmployeeSuffix}") },
                    { "ConfirmedBy",  GenFunct.ToTitleCase($"{Param.ConfirmedBy.EmployeeFirstName} {Param.ConfirmedBy.EmployeeMiddleName}. {Param.ConfirmedBy.EmployeeLastName} {Param.ConfirmedBy.EmployeeSuffix}") },
                };

                Table JobRequestContents = doc.Tables[1];

                int TableRowCount = JobRequestContents.Rows.Count;

                int itemCount = Param.WebsiteContentRequest.Count;

                for (int i = 0; i <= TableRowCount; i++)
                {
                    int row = i + 2;

                    JobRequestContents.Cell(row, 1).Range.Text = Param.WebsiteContentRequest[i].ContentRequest.ToString();
                    JobRequestContents.Cell(row, 2).Range.Text = Param.WebsiteContentRequest[i].Comments.ToString();

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

        public void IfYes(Dictionary<string, string> bookmark, string bookmarkName, string bookmarkRemarks, string remarks)
        {
            string Check = ((char)0x2714).ToString();
            bookmark.Add(bookmarkName, Check);
            bookmark.Add(bookmarkRemarks, remarks);
        }
    }
}