using LLFCWebFormAPI.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LLFCWebFormAPI.Controllers.FormClass
{
    public class ITIssuanceClass
    {
        LLFCFormController FormController = new LLFCFormController();
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public JSON GenerateITIssuance(ITIssuance Param)
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
                File.Copy(FormController.ServerPathFormsTemplate() + "IT Issuance.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "ControlNumber", Param.ControlNumber },
                    { "Date", Param.Date },
                    { "IssuedTo",  GenFunct.ToTitleCase($"{Param.EmployeeFullName.EmployeeFirstName} {Param.EmployeeFullName.EmployeeMiddleName}. {Param.EmployeeFullName.EmployeeLastName} {Param.EmployeeFullName.EmployeeSuffix}") },
                    { "Unit", Param.GroupUnit.GroupUnitDescription },
                };

                Table EquipmentSpec = doc.Tables[2];

                int TableRowCount = EquipmentSpec.Rows.Count;

                int itemCount = Param.EquipmentSpecification.Count;

                for (int i = 0; i <= TableRowCount; i++)
                {
                    int row = i + 2;
                    EquipmentSpec.Cell(row, 1).Range.Text = Param.EquipmentSpecification[i].Quantity.ToString();
                    EquipmentSpec.Cell(row, 2).Range.Text = Param.EquipmentSpecification[i].Unit.ToString();
                    EquipmentSpec.Cell(row, 3).Range.Text = Param.EquipmentSpecification[i].Particulars.ToString();
                    EquipmentSpec.Cell(row, 4).Range.Text = Param.EquipmentSpecification[i].AcquisitionCost.ToString();
                    EquipmentSpec.Cell(row, 5).Range.Text = Param.EquipmentSpecification[i].PropertyNumber.ToString();

                    itemCount = itemCount - 1;

                    if (itemCount == 0)
                    {
                        break;
                    }
                }

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