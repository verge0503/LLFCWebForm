using LLFCWebFormAPI.Controllers.FormClass;
using LLFCWebFormAPI.Models;
using LLFCWebFormAPI.Models.CreditFacilityProposal;
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
    public class LLFCCreditFacilityProposalController : ApiController
    {
        DatabaseAccess DatabaseAccess = new DatabaseAccess();

        string connectionString = WebConfigurationManager.AppSettings["DBConnectionString"];

        [HttpGet]
        public IHttpActionResult GetAccountList()
        {
            JSON JSONReturn = new JSON();
            List<AccountDetails> Accounts = new List<AccountDetails>();

            Accounts = DatabaseAccess.AccountList();

            JSONReturn.Data = Accounts;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewClientDetails(ClientDetails Param)
        {
            JSON JSONReturn = new JSON();
            ClientDetails clientDetails = new ClientDetails();
            AccountDetails accountDetails = new AccountDetails();

            accountDetails = DatabaseAccess.AddNewAccount(Param);

            Param.AccountDetails.AccountID = accountDetails.AccountID;

            DatabaseAccess.AddNewClientDetails(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = clientDetails;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateClientDetails(ClientDetails Param)
        {
            JSON JSONReturn = new JSON();
            ClientDetails clientDetails = new ClientDetails();

            DatabaseAccess.UpdateClientDetails(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = clientDetails;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetClientDetails(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            ClientDetails clientDetails = new ClientDetails();

            clientDetails = DatabaseAccess.GetClientDetails(Param);

            JSONReturn.Data = clientDetails;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewOtherCollateral(OtherCollateral Param)
        {
            JSON JSONReturn = new JSON();

            DatabaseAccess.AddNewOtherCollateral(Param);
            JSON returnJSON = new JSON();

            try
            {
                //JSONReturn.Data = clientDetails;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetOtherCollateral(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            OtherCollateral otherCollateral = new OtherCollateral();

            otherCollateral = DatabaseAccess.GetOtherCollateral(Param);

            JSONReturn.Data = otherCollateral;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateOtherCollateral(OtherCollateral Param)
        {
            JSON JSONReturn = new JSON();
            OtherCollateral otherCollateral = new OtherCollateral();

            DatabaseAccess.UpdateOtherCollateral(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = otherCollateral;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewTermsAndConditions(TermsAndConditions Param)
        {
            JSON JSONReturn = new JSON();

            DatabaseAccess.AddNewTermsAndConditions(Param);
            JSON returnJSON = new JSON();

            try
            {
                //JSONReturn.Data = clientDetails;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetTermsAndConditions(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            TermsAndConditions termsAndConditions = new TermsAndConditions();

            termsAndConditions = DatabaseAccess.GetTermsAndConditions(Param);

            JSONReturn.Data = termsAndConditions;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateTermsAndConditions(TermsAndConditions Param)
        {
            JSON JSONReturn = new JSON();
            TermsAndConditions termsAndConditions = new TermsAndConditions();

            DatabaseAccess.UpdateTermsAndConditions(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = termsAndConditions;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewBasisForRecommendation(BasisForRecommendation Param)
        {
            JSON JSONReturn = new JSON();

            DatabaseAccess.AddNewBasisForRecommendation(Param);
            JSON returnJSON = new JSON();

            try
            {
                //JSONReturn.Data = clientDetails;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetBasisForRecommendation(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            BasisForRecommendation basisForRecommendation = new BasisForRecommendation();

            basisForRecommendation = DatabaseAccess.GetBasisForRecommendation(Param);

            JSONReturn.Data = basisForRecommendation;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateBasisForRecommendation(BasisForRecommendation Param)
        {
            JSON JSONReturn = new JSON();
            BasisForRecommendation basisForRecommendation = new BasisForRecommendation();

            DatabaseAccess.UpdateBasisForRecommendation(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = basisForRecommendation;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewProjectDescription(ProjectDescription Param)
        {
            JSON JSONReturn = new JSON();

            DatabaseAccess.AddNewProjectDescription(Param);
            JSON returnJSON = new JSON();

            try
            {
                //JSONReturn.Data = clientDetails;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetProjectDescription(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            ProjectDescription projectDescription = new ProjectDescription();

            projectDescription = DatabaseAccess.GetProjectDescription(Param);

            JSONReturn.Data = projectDescription;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateProjectDescription(ProjectDescription Param)
        {
            JSON JSONReturn = new JSON();
            ProjectDescription projectDescription = new ProjectDescription();

            DatabaseAccess.UpdateProjectDescription(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = projectDescription;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult AddNewLLFCExperienceAccountRelationship(LLFCExperienceAccountRelationship Param)
        {
            JSON JSONReturn = new JSON();

            DatabaseAccess.AddNewLLFCExperienceAccountRelationship(Param);
            JSON returnJSON = new JSON();

            try
            {
                //JSONReturn.Data = clientDetails;
                //JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetLLFCExperienceAccountRelationship(AccountDetails Param)
        {
            JSON JSONReturn = new JSON();
            LLFCExperienceAccountRelationship lLFCExperienceAccountRelationship = new LLFCExperienceAccountRelationship();

            lLFCExperienceAccountRelationship = DatabaseAccess.GetLLFCExperienceAccountRelationship(Param);

            JSONReturn.Data = lLFCExperienceAccountRelationship;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateLLFCExperienceAccountRelationship(LLFCExperienceAccountRelationship Param)
        {
            JSON JSONReturn = new JSON();
            LLFCExperienceAccountRelationship lLFCExperienceAccountRelationship = new LLFCExperienceAccountRelationship();

            DatabaseAccess.UpdateLLFCExperienceAccountRelationship(Param);
            JSON returnJSON = new JSON();

            try
            {
                JSONReturn.Data = lLFCExperienceAccountRelationship;
                JSONReturn.Message = connectionString;
            }
            catch (Exception ex)
            {
                returnJSON.Message = ex.Message;
                return Json(returnJSON);
            }

            return Json(JSONReturn);
        }
    }
}