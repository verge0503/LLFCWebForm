using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class JobOfferForOfficerClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateJobOfferForOfficer(JobOfferForOfficer Param)
        {
            JSON returnJSON = new JSON();

            Application app = new Application();
            object misValue = System.Reflection.Missing.Value;


            if (File.Exists(FormController.ServerPathTempForms() + Param.Filename + ".docx"))
            {
                File.Delete(FormController.ServerPathTempForms() + Param.Filename + ".docx");
            }

            try
            {
                File.Copy(FormController.ServerPathFormsTemplate() + "Job Offer For Officer.docx", FormController.ServerPathTempForms() + Param.Filename + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.Filename + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "Date", Param.Date },
                    { "PersonName", GenFunct.ToTitleCase($"{Param.PersonName.FirstName} {Param.PersonName.MiddleName}. {Param.PersonName.LastName} {Param.PersonName.Suffix}")},
                    { "PositionTitle", Param.Position.PositionDescription},
                    { "SalaryGrade", $"{Param.SalaryGrade} / {Param.SalaryGradeStep}" },
                    { "MonthlySalary", Param.MonthlySalary },
                    { "RATA", Param.RATA },
                    { "StartDate", Param.StartDate },
                };

                FormToWord.ApplyDataToBookmark(bookmarks, doc);

                doc.Save();
                doc.ExportAsFixedFormat(FormController.ServerPathTempForms() + Param.Filename + ".pdf", WdExportFormat.wdExportFormatPDF);
                doc.Close();

                app.Quit();

                LLFCForm LLFCFormObj = new LLFCForm();
                LLFCFormObj.FormDownloadFile = Param.Filename;

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