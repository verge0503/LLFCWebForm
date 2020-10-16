using LLFCWebFormAPI.Models;
using LLFCWebFormAPI.Models.ITInvetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LLFCWebFormAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class LLFCITInventoryController : ApiController
    {
        ITInventoryDatabaseAccess ITInventoryDBAccess = new ITInventoryDatabaseAccess();

        [HttpGet]
        public IHttpActionResult GetEmployeeList()
        {
            JSON JSONReturn = new JSON();
            List<Employee> employees = new List<Employee>();

            employees = ITInventoryDBAccess.GetEmployeeList();

            JSONReturn.Data = employees;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetITECategoryList()
        {
            JSON JSONReturn = new JSON();
            List<ITECategory> categories = new List<ITECategory>();

            categories = ITInventoryDBAccess.GetITECategoryList();

            JSONReturn.Data = categories;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }


        [HttpPost]
        public IHttpActionResult AddNewLaptop(Laptop Param)
        {
            JSON JSONReturn = new JSON();
            Laptop laptop = new Laptop();

            laptop = ITInventoryDBAccess.AddNewLaptop(Param);

            JSONReturn.Data = laptop;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult UpdateLaptop(Laptop Param)
        {
            JSON JSONReturn = new JSON();
            Laptop laptop = new Laptop();

            laptop = ITInventoryDBAccess.UpdateLaptop(Param);

            JSONReturn.Data = laptop;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpPost]
        public IHttpActionResult GetLaptopListByStatus(ITEStatus Param)
        {
            JSON JSONReturn = new JSON();
            List<Laptop> laptops = new List<Laptop>();

            laptops = ITInventoryDBAccess.GetLaptopListByStatus(Param);

            JSONReturn.Data = laptops;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

        [HttpGet]
        public IHttpActionResult GetLaptopList()
        {
            JSON JSONReturn = new JSON();
            List<Laptop> laptops = new List<Laptop>();

            laptops = ITInventoryDBAccess.GetLaptops();

            JSONReturn.Data = laptops;
            JSONReturn.Message = "Success";

            return Json(JSONReturn);
        }

    }
}
