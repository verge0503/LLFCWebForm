using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class RequestForLeaveClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateRequestForLeave(RequestForLeave Param)
        {
            JSON returnJSON = new JSON();

            DateTime dateTime = DateTime.UtcNow.Date;

            string EmployeeName = GenFunct.ToTitleCase($"{Param.Employee.FirstName} {Param.Employee.MiddleName}. {Param.Employee.LastName} {Param.Employee.Suffix}");
            string DateOfFiling = dateTime.ToString("MM/dd/yyyy");
            string InclusiveDateFrom = Param.InclusiveDateFrom;
            string InclusiveDateTo = Param.InclusiveDateTo;
            string GroupUnit = Param.GroupUnit;
            //string Salary = Param.Salary;
            string TypeOfLeave;

            if (Param.LeaveTypeID == 1)
            {
                TypeOfLeave = "VacationLeave";
            }
            else if (Param.LeaveTypeID == 2)
            {
                TypeOfLeave = "SickLeave";
            }
            else if (Param.LeaveTypeID == 3)
            {
                TypeOfLeave = "TerminalLeave";
            }
            else
            {
                TypeOfLeave = "OtherLeave";
            }

            int EmployeeID = DBAccess.GetEmployeeID(Param.Employee.FirstName, Param.Employee.LastName);

            Signatory LeaveFormSignatory = DBAccess.GetSignatory(EmployeeID);
            Employee SignatoryDetails = LeaveFormSignatory.EmployeeDetail;
            string SignatoryFullname = GenFunct.ToTitleCase($"{SignatoryDetails.EmployeeFirstName} {SignatoryDetails.EmployeeMiddleName}. {SignatoryDetails.EmployeeLastName} {SignatoryDetails.EmployeeSuffix}");

            Application app = new Application();
            object misValue = System.Reflection.Missing.Value;

            if (File.Exists(FormController.ServerPathTempForms() + Param.FileName + ".docx"))
            {
                File.Delete(FormController.ServerPathTempForms() + Param.FileName + ".docx");
            }

            try
            {
                File.Copy(FormController.ServerPathFormsTemplate() + "Application for Leave of Absence.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "DateOfFiling", DateOfFiling },
                    { "InclusiveDateFrom", InclusiveDateFrom },
                    { "InclusiveDateTo", InclusiveDateTo },
                    { "EmployeeName", EmployeeName },
                    { "GroupUnit", DBAccess.GetDepartment(Convert.ToInt32(Param.GroupUnit)).DepartmentDescription },
                    //{ "Salary", Salary },
                    { TypeOfLeave, "X"},
                    { "CausePurpose", Param.LeaveCausePurpose },
                    { "SpecifiedOtherLeave", Param.OtherReason },
                    { "Signatory", SignatoryFullname }
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
    }
}