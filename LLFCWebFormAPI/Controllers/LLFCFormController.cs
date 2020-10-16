using LLFCWebFormAPI.Controllers.FormClass;
using LLFCWebFormAPI.Models;
using LLFCWebFormAPI.Models.ITInvetory;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LLFCWebFormAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LLFCFormController : ApiController
    {
        FormToWord FormToWord = new FormToWord();
        DatabaseAccess DatabaseAccess = new DatabaseAccess();
        ITInventoryDatabaseAccess ITInventoryDBAccess = new ITInventoryDatabaseAccess();

        //string connectionString = WebConfigurationManager.AppSettings["DBConnectionString"];
        
        LLFCFormController FormController = new LLFCFormController();
        DatabaseAccess DBAccess = new DatabaseAccess();
        GeneralFunctions GenFunct = new GeneralFunctions();

        public string ServerPathTempForms()
        {
            var serverPath = HttpContext.Current.Server.MapPath("~/TempForms/");

            return serverPath.ToString();
        }

        public string ServerPathFormsTemplate()
        {
            var serverPath = HttpContext.Current.Server.MapPath("~/FormsTemplate/");

            return serverPath.ToString();
        }

        [HttpPost]
        public IHttpActionResult GenerateRequestForLeave(RequestForLeave Param)
        {
            //JSON returnJSON = new JSON();

            //try
            //{
            //    RequestForLeaveClass requestForLeaveClass = new RequestForLeaveClass();

            //    returnJSON = requestForLeaveClass.GenerateRequestForLeave(Param);

            //    var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

            //    return response;
            //}
            //catch (Exception ex)
            //{
            //    returnJSON.Message = ex.Message;
            //    return Json(returnJSON);
            //}

            JSON returnJSON = new JSON();

            //DateTime dateTime = DateTime.UtcNow.Date;

            //string EmployeeName = GenFunct.ToTitleCase($"{Param.Employee.FullName}");
            //string DateOfFiling = dateTime.ToString("MM/dd/yyyy");
            //string InclusiveDateFrom = Param.InclusiveDateFrom;
            //string InclusiveDateTo = Param.InclusiveDateTo;
            //string GroupUnit = Param.GroupUnit;
            ////string Salary = Param.Salary;
            //string TypeOfLeave;

            //if (Param.LeaveTypeID == 1)
            //{
            //    TypeOfLeave = "VacationLeave";
            //}
            //else if (Param.LeaveTypeID == 2)
            //{
            //    TypeOfLeave = "SickLeave";
            //}
            //else if (Param.LeaveTypeID == 3)
            //{
            //    TypeOfLeave = "TerminalLeave";
            //}
            //else
            //{
            //    TypeOfLeave = "OtherLeave";
            //}

            //int EmployeeID = DBAccess.GetEmployeeID(Param.Employee.EmployeeID);

            //Signatory LeaveFormSignatory = DBAccess.GetSignatory(EmployeeID);
            //Employee SignatoryDetails = LeaveFormSignatory.EmployeeDetail;
            //string SignatoryFullname = GenFunct.ToTitleCase($"{SignatoryDetails.EmployeeFirstName} {SignatoryDetails.EmployeeMiddleName}. {SignatoryDetails.EmployeeLastName} {SignatoryDetails.EmployeeSuffix}");

            //Application app = new Application();
            //object misValue = System.Reflection.Missing.Value;

            //if (File.Exists(FormController.ServerPathTempForms() + Param.FileName + ".docx"))
            //{
            //    File.Delete(FormController.ServerPathTempForms() + Param.FileName + ".docx");
            //}

            //try
            //{
            //    File.Copy(FormController.ServerPathFormsTemplate() + "Application for Leave of Absence.docx", FormController.ServerPathTempForms() + Param.FileName + ".docx");

            //    Document doc = app.Documents.Open(FormController.ServerPathTempForms() + Param.FileName + ".docx");

            //    Dictionary<string, string> bookmarks = new Dictionary<string, string> {
            //        { "DateOfFiling", DateOfFiling },
            //        { "InclusiveDateFrom", InclusiveDateFrom },
            //        { "InclusiveDateTo", InclusiveDateTo },
            //        { "EmployeeName", EmployeeName },
            //        { "GroupUnit", DBAccess.GetDepartment(Convert.ToInt32(Param.GroupUnit)).DepartmentDescription },
            //        //{ "Salary", Salary },
            //        { TypeOfLeave, "X"},
            //        { "CausePurpose", Param.LeaveCausePurpose },
            //        { "SpecifiedOtherLeave", Param.OtherReason },
            //        { "Signatory", SignatoryFullname }
            //    };

            //    FormToWord.ApplyDataToBookmark(bookmarks, doc);

            //    doc.Save();
            //    //doc.SaveAs2(FormController.ServerPathTempForms() + Param.FileName + ".pdf", WdSaveFormat.wdFormatPDF);
            //    doc.Close();

            //    app.Quit();

            //    LLFCForm LLFCFormObj = new LLFCForm();
            //    LLFCFormObj.FormDownloadFile = Param.FileName;

            //    returnJSON.FormData = LLFCFormObj;
            //}
            //catch (Exception ex)
            //{
            //    app.Quit();
            //    returnJSON.Message = $"Error Occured: {ex.Message}";
            //}

            return Json(returnJSON);
        }

        [HttpPost]
        public IHttpActionResult GenerateRequestForPayment(RequestForPayment Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                RequestForPaymentClass requestForPaymentClass = new RequestForPaymentClass();

                returnJSON = requestForPaymentClass.GenerateRequestForPayment(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateLoanAgreement(LoanAgreement Param)
        {
            JSON returnJSON = new JSON();

            Application app = new Application();
            //object misValue = System.Reflection.Missing.Value;

            if (!File.Exists(ServerPathTempForms() + Param.FileName + ".docx"))
            {
                File.Copy(ServerPathFormsTemplate() + "Loan Agreement.docx", ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(ServerPathTempForms() + Param.FileName + ".docx");

                string terms = "";
                string undertakings = "";
                string otherTerms = "";
                string termsAndManners = "";

                //int TermAndConditionLength = Param.TermsAndConditions.Count;
                int TermAndConditionCounter = 0;
                int SpecificUndertakingCounter = 0;
                int OtherTermCounter = 0;
                int TermAndMannerCounter = 0;

                foreach (TermAndCondition term in Param.TermsAndConditions)
                {
                    TermAndConditionCounter += 1;

                    terms += term.frm_textArea;

                    if (TermAndConditionCounter < Param.TermsAndConditions.Count)
                    {
                        terms += Environment.NewLine;
                    }
                }

                foreach (SpecificUndertaking undertaking in Param.SpecificUndertakings)
                {
                    SpecificUndertakingCounter += 1;

                    undertakings += undertaking.frm_textArea;

                    if (SpecificUndertakingCounter < Param.SpecificUndertakings.Count)
                    {
                        undertakings += Environment.NewLine;
                    }
                }

                foreach (OtherTermAndCondition otherTerm in Param.OtherTermsAndConditions)
                {
                    OtherTermCounter += 1;

                    otherTerms += otherTerm.frm_textArea;

                    if (OtherTermCounter < Param.OtherTermsAndConditions.Count)
                    {
                        otherTerms += Environment.NewLine;
                    }
                }

                foreach (TermAndMannerOfPayment termAndManner in Param.TermsAndMannersOfPayment)
                {
                    TermAndMannerCounter += 1;

                    termsAndManners += Environment.NewLine + termAndManner.frm_textArea;
                }

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    { "LoanAgreementNumberHeader", "Loan Agreement No. " + Param.LoanAgreementNumber.ToString() },
                    { "BorrowerCompanyNameHeader", Param.BorrowerCompanyName },
                    { "LoanAgreementNumber", "LOAN AGREEMENT NO. " + Param.LoanAgreementNumber.ToString() },
                    { "LLFCPresidentName", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "BorrowerCompanyName", Param.BorrowerCompanyName },
                    { "BorrowerCompanyAddress", Param.BorrowerCompanyAddress },
                    { "BorrowerAuthorizedSignatoryPosition", Param.BorrowerAuthorizedSignatoryPosition },
                    { "BorrowerAuthorizedSignatoryName",  Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "TypeOfFacility", Param.TypeOfFacility },
                    { "AmountInWords", "PESOS: " + NumberToText.Convert(Param.AmountInValue) + " ONLY "},
                    { "AmountInValue", "(₱ " + String.Format("{0:n}", Param.AmountInValue) + ")"},
                    { "AmountInWordsArticle1", "PESOS: " + NumberToText.Convert(Param.AmountInValue) + " ONLY "},
                    { "AmountInValueArticle1", "(₱ " + String.Format("{0:n}", Param.AmountInValue) + ")"},
                    { "PurposeOfTheLoan", Param.PurposeOfTheLoan},
                    { "LLFCPresidentPage1", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "LLFCPresidentPage2", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "LLFCPresidentPage3", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "LLFCPresidentPage4", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "LLFCPresidentPage5", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "LLFCPresidentPage6", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName },
                    { "AuthorizedSignatoryPage1", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AuthorizedSignatoryPage2", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AuthorizedSignatoryPage3", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AuthorizedSignatoryPage4", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AuthorizedSignatoryPage5", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AuthorizedSignatoryPage6", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "WitnessPage1", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "WitnessPage2", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "WitnessPage3", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "WitnessPage4", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "WitnessPage5", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "WitnessPage6", Param.WitnessFirstName + ' ' + Param.WitnessMiddleInitial + ". " + Param.WitnessLastName },
                    { "AccountOfficerPage1", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "AccountOfficerPage2", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "AccountOfficerPage3", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "AccountOfficerPage4", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "AccountOfficerPage5", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "AccountOfficerPage6", Param.AccountOfficerFirstName + ' ' + Param.AccountOfficerMiddleInitial + ". " + Param.AccountOfficerLastName },
                    { "CompanyNamePage5", Param.BorrowerCompanyName },
                    { "AuthorizedSignatoryPositionPage5", Param.BorrowerAuthorizedSignatoryPosition },
                    { "AcknowledgementAuthorizedSignatoryName", Param.BorrowerAuthorizedSignatoryFirstName + ' ' + Param.BorrowerAuthorizedSignatoryMiddleInitial + ". " + Param.BorrowerAuthorizedSignatoryLastName },
                    { "AcknowledgementAuthorizedSignatoryTINNum", Param.BorrowerAuthorizedSignatoryTINNumber },
                    { "AcknowledgementBorrowerCompanyName", Param.BorrowerCompanyName },
                    { "AcknowledgementBorrowerCompanyTINNumber", Param.BorrowerCompanyTINNumber},
                    { "LLFCPresidentAcknowledgement", Param.LLFCPresidentFirstName + ' ' + Param.LLFCPresidentMiddleInitial + ". " + Param.LLFCPresidentLastName},
                    { "LLFCPresidentTINNumAcknowledgement", Param.LLFCPresidentTINNum },
                    { "Article2Section1TermsAndCondition", terms },
                    { "Article3Section2SpecificUndertakings", undertakings },
                    { "Article8OtherTermsAndConditions", otherTerms },
                    //{ "Article3Section2SpecificUndertakings", termsAndManners },
                };

                FormToWord.ApplyDataToBookmark(bookmarks, doc);

                doc.Save();
                //doc.SaveAs2(ServerPathTempForms() + Param.FileName + ".pdf", WdSaveFormat.wdFormatPDF);
                doc.Close();

                app.Quit();

                var response = ResponseMessage(Response(Param.FileName));

                return response;
            }
            else
            {
                returnJSON.Message = "Error";
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateDisclosureStatement(DisclosureStatement Param)
        {
            JSON returnJSON = new JSON();

            Application app = new Application();
            //object misValue = System.Reflection.Missing.Value;

            if (!File.Exists(ServerPathTempForms() + Param.FileName + ".docx"))
            {
                File.Copy(ServerPathFormsTemplate() + "Disclosure Statement.docx", ServerPathTempForms() + Param.FileName + ".docx");

                Document doc = app.Documents.Open(ServerPathTempForms() + Param.FileName + ".docx");

                Dictionary<string, string> bookmarks = new Dictionary<string, string> {
                    //{ "NameOfBorrowerLessee", Param.LesseeBorrowerFirstName + " " + Param.LesseeBorrowerMiddleInitial + ". " + Param.LesseeBorrowerLastName + " " + Param.LesseeBorrowerSuffix },
                    { "BorrowerLessee", Param.BorrowerLessee},
                    { "Address", Param.Address },
                    { "MLANum", Param.MLA.ToString() },
                    { "LNANum", Param.LNA.ToString() },
                    { "STCLNum", Param.STCL.ToString() },
                    { "LSNum", Param.LS.ToString() },
                    { "PNNum", Param.PN.ToString() },
                    { "AmountToBeFinanced", Param.AmountToBeFinanced.ToString() },
                };

                FormToWord.ApplyDataToBookmark(bookmarks, doc);

                doc.Save();
                //doc.SaveAs2(ServerPathTempForms() + Param.FileName + ".pdf", WdSaveFormat.wdFormatPDF);
                doc.Close();

                app.Quit();

                var response = ResponseMessage(Response(Param.FileName));

                return response;
            }
            else
            {
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateFieldOfWorkAuthMemo(FieldWorkAuthMemo Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                FieldWorkAuthMemoClass fieldWorkAuthMemoClass = new FieldWorkAuthMemoClass();

                returnJSON = fieldWorkAuthMemoClass.GenerateFieldWorkAuthorizationMemo(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateJobOfferForOfficer(JobOfferForOfficer Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                JobOfferForOfficerClass jobOfferForOfficerClass = new JobOfferForOfficerClass();

                returnJSON = jobOfferForOfficerClass.GenerateJobOfferForOfficer(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateJobOfferForSupervisoryAndRankAndFile(JobOfferForOfficer Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                JobOfferForSupervisoryAndRankAndFileClass jobOfferForSupervisoryAndRankAndFileClass = new JobOfferForSupervisoryAndRankAndFileClass();

                returnJSON = jobOfferForSupervisoryAndRankAndFileClass.GenerateJobOfferForSupervisoryAndRankAndFile(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateITAccessRequest(ITAccessRequest Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                ITAccessRequestClass iTAccessRequestClass = new ITAccessRequestClass();

                returnJSON = iTAccessRequestClass.GenerateITAccessRequest(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GeneratePurchaseRequest(PurchaseRequest Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                PurchaseRequestClass purchaseRequestClass = new PurchaseRequestClass();

                returnJSON = purchaseRequestClass.GeneratePurchaseRequest(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateITIssuance(ITIssuance Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                ITIssuanceClass iTIssuanceClass = new ITIssuanceClass();

                returnJSON = iTIssuanceClass.GenerateITIssuance(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpPost]
        public IHttpActionResult GenerateWebsiteJobRequest(WebsiteJobRequest Param)
        {
            JSON returnJSON = new JSON();

            try
            {
                WebsiteJobRequestClass websiteJobRequestClass = new WebsiteJobRequestClass();

                returnJSON = websiteJobRequestClass.GenerateWebsiteJobRequest(Param);

                var response = ResponseMessage(Response(returnJSON.FormData.FormDownloadFile));

                return response;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDepartmentList()
        {
            JSON JSONReturn = new JSON();
            List<Department> Departments = new List<Department>();

            Departments = DatabaseAccess.DepartmentList();

            try
            {
                JSONReturn.Data = Departments;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetLeaveTypeList()
        {
            JSON JSONReturn = new JSON();
            List<LeaveType> LeaveTypes = new List<LeaveType>();

            LeaveTypes = DatabaseAccess.LeaveTypeList();

            JSONReturn.Data = LeaveTypes;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetFormOfPaymentList()
        {
            JSON JSONReturn = new JSON();
            List<FormOfPayment> FormOfPayments = new List<FormOfPayment>();

            FormOfPayments = DatabaseAccess.FormOfPaymentList();

            JSONReturn.Data = FormOfPayments;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetPositionList()
        {
            JSON JSONReturn = new JSON();
            List<Position> PositionList = new List<Position>();

            PositionList = DatabaseAccess.PositionList();

            JSONReturn.Data = PositionList;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetSalaryGradeList()
        {
            JSON JSONReturn = new JSON();
            List<SalaryGrade> SalaryGradeList = new List<SalaryGrade>();

            SalaryGradeList = DatabaseAccess.SalaryGradeList();

            JSONReturn.Data = SalaryGradeList;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetSalaryPerStep()
        {
            JSON JSONReturn = new JSON();
            List<SalaryPerStep> SalaryPerStepList = new List<SalaryPerStep>();

            SalaryPerStepList = DatabaseAccess.SalaryPerStepList();

            JSONReturn.Data = SalaryPerStepList;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        public HttpResponseMessage Response(string filename)
        {
            var path = ServerPathTempForms() + filename + ".docx";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;

            return result;
        }

        public HttpResponseMessage ResponsePDF(string filename)
        {
            var path = ServerPathTempForms() + filename + ".pdf";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;

            return result;
        }
    }

}