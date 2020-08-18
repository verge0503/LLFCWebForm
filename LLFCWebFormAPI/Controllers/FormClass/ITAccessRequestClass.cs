using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class ITAccessRequestClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateITAccessRequest(ITAccessRequest Param)
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
                File.Copy(FormController.ServerPathFormsTemplate() + "IT Access Request.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "EmployeeName", GenFunct.ToTitleCase($"{Param.Employee.EmployeeFirstName} {Param.Employee.EmployeeMiddleName}. {Param.Employee.EmployeeLastName} {Param.Employee.EmployeeSuffix}")},
                    { "EmployeeCode", Param.Employee.EmployeeCode.ToString()},
                    { "Position", Param.Position.PositionDescription },
                    { "GroupUnit", Param.GroupUnit.GroupUnitDescription },
                };

                if (Param.LLFCEmail.Selected == 1) { IfYes(bookmarks, "LLFCEmailYes", "LLFCEmailRemarks", Param.LLFCEmail.Remarks); } else { IfYes(bookmarks, "LLFCEmailNo", "LLFCEmailRemarks", Param.LLFCEmail.Remarks); }
                if (Param.Internet.Selected == 1) { IfYes(bookmarks, "InternetYes", "InternetRemarks", Param.Internet.Remarks); } else { IfYes(bookmarks, "InternetNo", "InternetRemarks", Param.Internet.Remarks); }
                if (Param.MainEntrance.Selected == 1) { IfYes(bookmarks, "MainEntranceYes", "MainEntranceRemarks", Param.MainEntrance.Remarks); } else { IfYes(bookmarks, "MainEntranceNo", "MainEntranceRemarks", Param.MainEntrance.Remarks); }
                if (Param.SecurityRoom.Selected == 1) { IfYes(bookmarks, "SecurityRoomYes", "SecurityRoomRemarks", Param.SecurityRoom.Remarks); } else { IfYes(bookmarks, "SecurityRoomNo", "SecurityRoomRemarks", Param.SecurityRoom.Remarks); }
                if (Param.ServerRoom.Selected == 1) { IfYes(bookmarks, "ServerRoomYes", "ServerRoomRemarks", Param.ServerRoom.Remarks); } else { IfYes(bookmarks, "ServerRoomNo", "ServerRoomRemarks", Param.ServerRoom.Remarks); }
                if (Param.PrinterBlackCopy.Selected == 1) { IfYes(bookmarks, "PrinterBlackYes", "PrinterBlackRemarks", Param.PrinterBlackCopy.Remarks); } else { IfYes(bookmarks, "PrinterBlackNo", "PrinterBlackRemarks", Param.LLFCEmail.Remarks); }
                if (Param.PrinterColoredCopy.Selected == 1) { IfYes(bookmarks, "PrinterColoredYes", "PrinterColoredRemarks", Param.PrinterColoredCopy.Remarks); } else { IfYes(bookmarks, "PrinterColoredNo", "PrinterColoredRemarks", Param.PrinterColoredCopy.Remarks); }
                if (Param.Telephone.Selected == 1) { IfYes(bookmarks, "TelephoneYes", "TelephoneRemarks", Param.Telephone.Remarks); } else { IfYes(bookmarks, "TelephoneNo", "TelephoneRemarks", Param.Telephone.Remarks); }
                if (Param.Biometrics.Selected == 1) { IfYes(bookmarks, "BiometricsYes", "BiometricsRemarks", Param.Biometrics.Remarks); } else { IfYes(bookmarks, "BiometricsNo", "BiometricsRemarks", Param.Biometrics.Remarks); }
                if (Param.Jeonsoft.Selected == 1) { IfYes(bookmarks, "JPSYes", "JPSRemarks", Param.Jeonsoft.Remarks); } else { IfYes(bookmarks, "JPSNo", "JPSRemarks", Param.Jeonsoft.Remarks); }
                if (Param.DMS.Selected == 1) { IfYes(bookmarks, "DMSYes", "DMSRemarks", Param.DMS.Remarks); } else { IfYes(bookmarks, "DMSNo", "DMSRemarks", Param.DMS.Remarks); }
                if (Param.FMS.Selected == 1) { IfYes(bookmarks, "FMSYes", "FMSRemarks", Param.FMS.Remarks); } else { IfYes(bookmarks, "FMSNo", "FMSRemarks", Param.FMS.Remarks); }
                if (Param.Jet.Selected == 1) { IfYes(bookmarks, "JetReportsYes", "JetReportsRemarks", Param.Jet.Remarks); } else { IfYes(bookmarks, "JetReportsNo", "JetReportsRemarks", Param.Jet.Remarks); }

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