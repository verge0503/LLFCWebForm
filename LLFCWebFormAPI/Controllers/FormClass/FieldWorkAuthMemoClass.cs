using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class FieldWorkAuthMemoClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateFieldWorkAuthorizationMemo(FieldWorkAuthMemo Param)
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
                File.Copy(FormController.ServerPathFormsTemplate() + "Field Work Authorization Memorandum.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "ToName", GenFunct.ToTitleCase($"{Param.Employee.EmployeeFirstName} {Param.Employee.EmployeeMiddleName}. {Param.Employee.EmployeeLastName} {Param.Employee.EmployeeSuffix}")},
                    { "ToPosition", Param.Position.PositionDescription},
                    { "Subject", Param.Subject },
                    { "Date", Param.Date },
                    { "DateOfFW", Param.DateOfFieldWork },
                    { "TimeOfFW", $"{DateTime.Parse(Param.FromTimeOfFiedWork).ToString(@"hh\:mm tt")} to {DateTime.Parse(Param.ToTimeOfFiedWork).ToString(@"hh\:mm tt")}"},
                    { "ProceedDirectlyFromResidence", Param.ProceedDirectlyFromResidence },
                    { "PersonToSee", GenFunct.ToTitleCase($"{Param.PersonToSee.FirstName} {Param.PersonToSee.MiddleName}. {Param.PersonToSee.LastName} {Param.PersonToSee.Suffix}") },
                    { "OfficeBusinessName", Param.OfficeBusinessName },
                    { "CompleteAddress", Param.CompleteAddress },
                    { "Purpose", Param.Purpose },
                    { "OtherInstruction", Param.OtherInstruction },
                };

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