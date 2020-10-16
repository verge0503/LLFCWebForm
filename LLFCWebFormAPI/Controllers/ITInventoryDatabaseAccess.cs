using LLFCWebFormAPI.Models;
using LLFCWebFormAPI.Models.ITInvetory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;

namespace LLFCWebFormAPI.Controllers
{
    public class ITInventoryDatabaseAccess
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

        public List<Employee> GetEmployeeList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployeeList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Employee = new Employee();

                    Employee.EmployeeID = Convert.ToInt32(reader["Employee_ID"]);
                    Employee.EmployeeCode = Convert.ToInt32(reader["Code"]);
                    Employee.EmployeeLastName = reader["Last_Name"].ToString();
                    Employee.EmployeeFirstName = reader["First_Name"].ToString();
                    Employee.EmployeeMiddleName = reader["Middle_Name"].ToString();
                    Employee.EmployeeSuffix = reader["Suffix"].ToString();
                    Employee.FullName = $" {Employee.EmployeeFirstName } { Employee.EmployeeLastName} {Employee.EmployeeSuffix}";

                    employees.Add(Employee);
                }
            }

            return employees;
        }

        public List<ITECategory> GetITECategoryList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            List<ITECategory> categories = new List<ITECategory>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetITECategoryList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ITECategory category = new ITECategory();

                    category.CategoryID = Convert.ToInt32(reader["Category_ID"]);
                    category.CategoryDescription = reader["Category_Description"].ToString();

                    categories.Add(category);
                }
            }

            return categories;
        }

        public Laptop AddNewLaptop(Laptop laptop)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            Laptop laptopObj = new Laptop();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddNewLaptop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SerialNumber", laptop.SerialNumber);
                cmd.Parameters.AddWithValue("@Brand", laptop.LaptopBrand);
                cmd.Parameters.AddWithValue("@Model", laptop.LaptopModel);
                cmd.Parameters.AddWithValue("@Storage", laptop.LaptopStorage);
                cmd.Parameters.AddWithValue("@ScreenSize", laptop.LaptopScreenSize);
                cmd.Parameters.AddWithValue("@Processor", laptop.LaptopProcessor);
                cmd.Parameters.AddWithValue("@RAM", laptop.LaptopRAM);
                cmd.Parameters.AddWithValue("@OS", laptop.LaptopOS);
                cmd.Parameters.AddWithValue("@DateAcquired", laptop.ITEInventory.DateAcquired);
                cmd.Parameters.AddWithValue("@Price", laptop.ITEInventory.Price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return laptopObj;
        }

        public Laptop UpdateLaptop(Laptop laptop)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            Laptop laptopObj = new Laptop();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateLaptop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InventoryID", laptop.ITEInventory.ITEInventoryID);
                cmd.Parameters.AddWithValue("@DateAcquired", laptop.ITEInventory.DateAcquired);
                cmd.Parameters.AddWithValue("@Price", laptop.ITEInventory.Price);

                cmd.Parameters.AddWithValue("@LaptopID", laptop.LaptopID);
                cmd.Parameters.AddWithValue("@SerialNumber", laptop.SerialNumber);
                cmd.Parameters.AddWithValue("@Brand", laptop.LaptopBrand);
                cmd.Parameters.AddWithValue("@Model", laptop.LaptopModel);
                cmd.Parameters.AddWithValue("@Storage", laptop.LaptopStorage);
                cmd.Parameters.AddWithValue("@ScreenSize", laptop.LaptopScreenSize);
                cmd.Parameters.AddWithValue("@Processor", laptop.LaptopProcessor);
                cmd.Parameters.AddWithValue("@RAM", laptop.LaptopRAM);
                cmd.Parameters.AddWithValue("@OS", laptop.LaptopOS);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return laptopObj;
        }

        public List<Laptop> GetLaptops()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            List<Laptop> laptops = new List<Laptop>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetLaptopList", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Laptop = new Laptop();
                    var ITEInventory = new ITEInventory();

                    Laptop.ITEInventory = ITEInventory;

                    Laptop.ITEInventory.ITEInventoryID = Convert.ToInt32(reader["ITE_Inventory_ID"]);
                    Laptop.ITEInventory.CategoryID = Convert.ToInt32(reader["Category_ID_FK"]);
                    Laptop.ITEInventory.StatusID = Convert.ToInt32(reader["Status_ID_FK"]);
                    Laptop.ITEInventory.DateAcquired = Convert.ToDateTime(reader["Date_Acquired"]);
                    Laptop.ITEInventory.Price = Convert.ToDecimal(reader["Price"]);

                    Laptop.LaptopID = Convert.ToInt32(reader["Laptop_ID"]);
                    Laptop.SerialNumber = reader["Laptop_Serial_Number"].ToString();
                    Laptop.LaptopBrand = reader["Laptop_Brand"].ToString();
                    Laptop.LaptopModel = reader["Laptop_Model"].ToString();
                    Laptop.Description = Laptop.LaptopBrand + " " + Laptop.LaptopModel;
                    Laptop.LaptopStorage = reader["Laptop_Storage"].ToString();
                    Laptop.LaptopScreenSize = reader["Laptop_Screen_Size"].ToString();
                    Laptop.LaptopProcessor = reader["Laptop_Processor"].ToString();
                    Laptop.LaptopRAM = reader["Laptop_RAM"].ToString();
                    Laptop.LaptopOS = reader["Laptop_OS"].ToString();

                    laptops.Add(Laptop);
                }
            }

            return laptops;
        }

        public List<Laptop> GetLaptopListByStatus(ITEStatus status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LLFCWebFormsDB"].ConnectionString;

            List<Laptop> laptops = new List<Laptop>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetLaptopListByStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StatusID", status.StatusID);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Laptop = new Laptop();
                    var ITEInventory = new ITEInventory();

                    Laptop.ITEInventory = ITEInventory;

                    Laptop.ITEInventory.ITEInventoryID = Convert.ToInt32(reader["ITE_Inventory_ID"]);
                    Laptop.ITEInventory.CategoryID = Convert.ToInt32(reader["Category_ID_FK"]);
                    Laptop.ITEInventory.StatusID = Convert.ToInt32(reader["Status_ID_FK"]);
                    Laptop.ITEInventory.DateAcquired = Convert.ToDateTime(reader["Date_Acquired"]);
                    Laptop.ITEInventory.Price = Convert.ToDecimal(reader["Price"]);

                    Laptop.LaptopID = Convert.ToInt32(reader["Laptop_ID"]);
                    Laptop.SerialNumber = reader["Laptop_Serial_Number"].ToString();
                    Laptop.LaptopBrand = reader["Laptop_Brand"].ToString();
                    Laptop.LaptopModel = reader["Laptop_Model"].ToString();
                    Laptop.Description = Laptop.LaptopBrand + " " + Laptop.LaptopModel;
                    Laptop.LaptopStorage = reader["Laptop_Storage"].ToString();
                    Laptop.LaptopScreenSize = reader["Laptop_Screen_Size"].ToString();
                    Laptop.LaptopProcessor = reader["Laptop_Processor"].ToString();
                    Laptop.LaptopRAM = reader["Laptop_RAM"].ToString();
                    Laptop.LaptopOS = reader["Laptop_OS"].ToString();

                    laptops.Add(Laptop);
                }
            }

            return laptops;
        }
    }
}