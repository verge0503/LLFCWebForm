using LLFCWebFormAPI.Models;
using LLFCWebFormAPI.Models.CreditFacilityProposal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace LLFCWebFormAPI.Controllers
{
    public class DatabaseAccess
    {
        //string conn = WebConfigurationManager.AppSettings["DBconn"];

        GeneralFunctions genFunc = new GeneralFunctions();
        const string APP_SETTING_ERROR_MESSAGE = "Invalid or missing appSetting, ";

        public string GetStringFromAppSetting()
        {
            if (WebConfigurationManager.AppSettings["DBconn"] != null && !String.IsNullOrEmpty(WebConfigurationManager.AppSettings["DBconn"].ToString()))
            {
                return WebConfigurationManager.AppSettings["DBconn"].ToString();
            }
            else
            {
                throw new Exception(APP_SETTING_ERROR_MESSAGE + "DBconn");
            }
        }

        public List<Department> DepartmentList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<Department> DeparmentList = new List<Department>();
            Department DepartmentObj;

            string strSQL = "SELECT Department_ID, Department_Description FROM tbl_LLFCDepartmentList";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentObj = new Department();
                            DepartmentObj.DepartmentID = Convert.ToInt32(reader["Department_ID"]);
                            DepartmentObj.DepartmentDescription = reader["Department_Description"].ToString();

                            DeparmentList.Add(DepartmentObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return DeparmentList;
        }

        public List<LeaveType> LeaveTypeList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<LeaveType> LeaveTypeList = new List<LeaveType>();
            LeaveType LeaveTypeObj;

            string strSQL = "SELECT Leave_ID, Leave_Description FROM tbl_LLFCLeaveTypeList";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaveTypeObj = new LeaveType();
                            LeaveTypeObj.LeaveTypeID = Convert.ToInt32(reader["Leave_ID"]);
                            LeaveTypeObj.LeaveTypeDescription = reader["Leave_Description"].ToString();

                            LeaveTypeList.Add(LeaveTypeObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return LeaveTypeList;
        }

        public List<FormOfPayment> FormOfPaymentList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<FormOfPayment> FormOfPaymentList = new List<FormOfPayment>();
            FormOfPayment FormOfPaymentObj;

            string strSQL = "SELECT Form_Of_Payment_ID, Form_Of_Payment_Description FROM tbl_FormOfPayment";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FormOfPaymentObj = new FormOfPayment();
                            FormOfPaymentObj.FormOfPaymentID = Convert.ToInt32(reader["Form_Of_Payment_ID"]);
                            FormOfPaymentObj.FormOfPaymentDescription = reader["Form_Of_Payment_Description"].ToString();

                            FormOfPaymentList.Add(FormOfPaymentObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return FormOfPaymentList;
        }

        public List<Position> PositionList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<Position> PositionList = new List<Position>();
            Position PositionObj;

            string strSQL = "SELECT Position_ID, Position_Description FROM tbl_LLFCPositionList";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PositionObj = new Position();
                            PositionObj.PositionID = Convert.ToInt32(reader["Position_ID"]);
                            PositionObj.PositionDescription = reader["Position_Description"].ToString();

                            PositionList.Add(PositionObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return PositionList;
        }

        public List<SalaryGrade> SalaryGradeList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<SalaryGrade> SalaryGradeList = new List<SalaryGrade>();
            SalaryGrade SalaryGradeObj;

            string strSQL = "SELECT Salary_Grade_ID, Salary_Grade FROM tbl_SalaryGrade";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalaryGradeObj = new SalaryGrade();
                            SalaryGradeObj.SGID = Convert.ToInt32(reader["Salary_Grade_ID"]);
                            SalaryGradeObj.SG = Convert.ToInt32(reader["Salary_Grade"]);

                            SalaryGradeList.Add(SalaryGradeObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return SalaryGradeList;
        }

        public List<SalaryPerStep> SalaryPerStepList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<SalaryPerStep> SalaryPerStepList = new List<SalaryPerStep>();
            SalaryPerStep SalaryPerStepObj;

            string strSQL = "SELECT Salary_Per_Step_ID, Salary_Grade_ID_FK, Salary_Grade_Step, Salary_Per_Step FROM tbl_SalaryPerStep";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalaryPerStepObj = new SalaryPerStep();
                            SalaryPerStepObj.Salary_Per_Step_ID = Convert.ToInt32(reader["Salary_Per_Step_ID"]);
                            SalaryPerStepObj.SalaryGrade = Convert.ToInt32(reader["Salary_Grade_ID_FK"]);
                            SalaryPerStepObj.Step = Convert.ToInt32(reader["Salary_Grade_Step"]);
                            SalaryPerStepObj.Salary = Convert.ToInt32(reader["Salary_Per_Step"]);

                            SalaryPerStepList.Add(SalaryPerStepObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return SalaryPerStepList;
        }

        public Signatory GetSignatory(int EmployeeID)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            Signatory SignatoryObj = new Signatory();
            Employee EmployeeObj;
            Department DepartmentObj;

            string strSQL = "SELECT EmpToSup.Employee_To_Superior_ID, EmpToSup.Employee_ID_FK, EmpToSup.Superior_ID_FK, EmpList.Employee_FirstName, EmpList.Employee_LastName, EmpList.Employee_MiddleName, " +
                        "EmpList.Employee_Suffix, EmpList.Employee_Code " +
                        "FROM (tbl_EmployeeToSuperior EmpToSup LEFT OUTER JOIN " +
                        "tbl_LLFCEmployeeList EmpList ON EmpList.Employee_ID = EmpToSup.Superior_ID_FK) " +
                        "WHERE (EmpToSup.Employee_ID_FK =" + EmployeeID + ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            SignatoryObj = new Signatory();
                            EmployeeObj = new Employee();
                            DepartmentObj = new Department();

                            EmployeeObj.EmployeeID = Convert.ToInt32(reader["Superior_ID_FK"]);
                            EmployeeObj.EmployeeFirstName = reader["Employee_FirstName"].ToString();
                            EmployeeObj.EmployeeLastName = reader["Employee_LastName"].ToString();
                            EmployeeObj.EmployeeMiddleName = reader["Employee_MiddleName"].ToString();
                            EmployeeObj.EmployeeSuffix = reader["Employee_Suffix"].ToString();

                            //DepartmentObj.DepartmentID = Convert.ToInt32(reader["Department_ID"]);
                            //DepartmentObj.DepartmentDescription = reader["Department_Description"].ToString();

                            //SignatoryObj.SignatoryID = Convert.ToInt32(reader["Signatory_ID"]);
                            SignatoryObj.EmployeeDetail = EmployeeObj;
                            //SignatoryObj.Department = DepartmentObj;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return SignatoryObj;
        }

        public FormOfPayment GetFormOfPayment (int FormPaymentID)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            FormOfPayment FormOfPaymentObj = new FormOfPayment();

            string strSQL = "SELECT Form_Of_Payment_ID, Form_Of_Payment_Description FROM tbl_FormOfPayment WHERE Form_Of_Payment_ID = " + FormPaymentID;

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            FormOfPaymentObj.FormOfPaymentID = Convert.ToInt32(reader["Form_Of_Payment_ID"].ToString());
                            FormOfPaymentObj.FormOfPaymentDescription = reader["Form_Of_Payment_Description"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return FormOfPaymentObj;
        }

        public Department GetDepartment(int DepartmentID)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            Department DepartmentObj = new Department();

            string strSQL = "SELECT Department_ID, Department_Description FROM tbl_LLFCDepartmentList WHERE Department_ID = " + DepartmentID;

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            DepartmentObj.DepartmentID = Convert.ToInt32(reader["Department_ID"].ToString());
                            DepartmentObj.DepartmentDescription = reader["Department_Description"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return DepartmentObj;
        }

        public int GetEmployeeID (int EmployeeID)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            Employee employeeObj = new Employee();

            string strSQL = "SELECT Employee_ID, Employee_FirstName, Employee_LastName, Employee_MiddleName, Employee_Suffix " +
                "FROM tbl_LLFCEmployeeList WHERE (Employee_Code = " + EmployeeID +")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            employeeObj.EmployeeID = Convert.ToInt32(reader["Employee_ID"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return employeeObj.EmployeeID;

        }

        public AccountDetails AddNewAccount(ClientDetails clientDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            accountDetailsObj.AccountName = clientDetails.AccountDetails.AccountName;

            string strSQL = "INSERT INTO tbl_CFPAccountList (Account_Name, Date_Added) VALUES (@AccountName, @DateAdded)";
            string strSQL2 = "SELECT @@Identity";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    DateTime test = DateTime.Now;
                    command.Parameters.AddWithValue("@AccountName", accountDetailsObj.AccountName);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.UtcNow.Date);

                    command.ExecuteNonQuery();

                    command.CommandText = strSQL2;
                    accountDetailsObj.AccountID = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }


            return accountDetailsObj;
        }

        public List<AccountDetails> AccountList()
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            List<AccountDetails> accounts = new List<AccountDetails>();
            AccountDetails accountDetailsObj = new AccountDetails();

            string strSQL = "SELECT Account_ID, Account_Name, Date_Added FROM tbl_CFPAccountList";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountDetailsObj = new AccountDetails();
                            accountDetailsObj.AccountID = Convert.ToInt32(reader["Account_ID"]);
                            accountDetailsObj.AccountName = reader["Account_Name"].ToString();
                            accountDetailsObj.Date = reader["Date_Added"].ToString();

                            accounts.Add(accountDetailsObj);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return accounts;
        }

        public void AddNewClientDetails(ClientDetails clientDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPAccountClientDetails (Account_ID_FK, Business_Address, Contact_Number_Person, Industry, PSIC_Code, Client_Type, Tax_Identification_Number, Income_Tax_Paid, Manpower_Complement, Credit_Rating, Client_Since, Account_Source) " +
                "VALUES (" +
                "@AccountID, " +
                "@BusinessAddress, " +
                "@ContactPerson, " +
                "@Industry, " +
                "@PSICCode, " +
                "@ClientType, " +
                "@TaxID, " +
                "@IncomeTaxPaid, " +
                "@ManpowerComplement, " +
                "@CreditRating, " +
                "@ClientSince, " +
                "@AccountSource)";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", clientDetails.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@BusinessAddress", genFunc.CheckIfNull(clientDetails.BusinessAddress));
                    command.Parameters.AddWithValue("@ContactPerson", genFunc.CheckIfNull(clientDetails.ContactPerson));
                    command.Parameters.AddWithValue("@Industry", genFunc.CheckIfNull(clientDetails.Industry));
                    command.Parameters.AddWithValue("@PSICCode", genFunc.CheckIfNull(clientDetails.PSICCode));
                    command.Parameters.AddWithValue("@ClientType", genFunc.CheckIfNull(clientDetails.ClientType));
                    command.Parameters.AddWithValue("@TaxID", genFunc.CheckIfNull(clientDetails.TaxID));
                    command.Parameters.AddWithValue("@IncomeTaxPaid", genFunc.CheckIfNull(clientDetails.IncomeTaxPaid));
                    command.Parameters.AddWithValue("@ManpowerComplement", genFunc.CheckIfNull(clientDetails.ManpowerComplement));
                    command.Parameters.AddWithValue("@CreditRating", genFunc.CheckIfNull(clientDetails.CreditRating));
                    command.Parameters.AddWithValue("@ClientSince", genFunc.CheckIfNull(clientDetails.ClientSince));
                    command.Parameters.AddWithValue("@AccountSource", genFunc.CheckIfNull(clientDetails.AccountSource));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void UpdateClientDetails(ClientDetails clientDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPAccountClientDetails SET " +
                "Business_Address = @BusinessAddress, " +
                "Contact_Number_Person = @ContactPerson, " +
                "Industry = @Industry, " +
                "PSIC_Code = @PSICCode, " +
                "Client_Type = @ClientType, " +
                "Tax_Identification_Number = @TaxID, " +
                "Income_Tax_Paid = @IncomeTaxPaid, " +
                "Manpower_Complement = @ManpowerComplement, " +
                "Credit_Rating = @CreditRating, " +
                "Client_Since = @ClientSince, " +
                "Account_Source = @AccountSource " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@BusinessAddress", clientDetails.BusinessAddress);
                    command.Parameters.AddWithValue("@ContactPerson", clientDetails.ContactPerson);
                    command.Parameters.AddWithValue("@Industry", clientDetails.Industry);
                    command.Parameters.AddWithValue("@PSICCode", clientDetails.PSICCode);
                    command.Parameters.AddWithValue("@ClientType", clientDetails.ClientType);
                    command.Parameters.AddWithValue("@TaxID", clientDetails.TaxID);
                    command.Parameters.AddWithValue("@IncomeTaxPaid", clientDetails.IncomeTaxPaid);
                    command.Parameters.AddWithValue("@ManpowerComplement", clientDetails.ManpowerComplement);
                    command.Parameters.AddWithValue("@CreditRating", clientDetails.CreditRating);
                    command.Parameters.AddWithValue("@ClientSince", clientDetails.ClientSince);
                    command.Parameters.AddWithValue("@AccountSource", clientDetails.AccountSource);
                    command.Parameters.AddWithValue("@AccountID", clientDetails.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public ClientDetails GetClientDetails(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            ClientDetails clientDetailsObj = new ClientDetails();

            string strSQL = "SELECT * FROM tbl_CFPAccountClientDetails WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            clientDetailsObj.AccountDetails = accountDetailsObj;
                            clientDetailsObj.BusinessAddress = reader["Business_Address"].ToString();
                            clientDetailsObj.ContactPerson = reader["Contact_Number_Person"].ToString();
                            clientDetailsObj.Industry = reader["Industry"].ToString();
                            clientDetailsObj.PSICCode = reader["PSIC_Code"].ToString();
                            clientDetailsObj.ClientType = reader["Client_Type"].ToString();
                            clientDetailsObj.TaxID = reader["Tax_Identification_Number"].ToString();
                            clientDetailsObj.IncomeTaxPaid = reader["Income_Tax_Paid"].ToString();
                            clientDetailsObj.ManpowerComplement = reader["Manpower_Complement"].ToString();
                            clientDetailsObj.CreditRating = reader["Credit_Rating"].ToString();
                            clientDetailsObj.ClientSince = reader["Client_Since"].ToString();
                            clientDetailsObj.AccountSource = reader["Account_Source"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return clientDetailsObj;
        }

        public void AddNewOtherCollateral(OtherCollateral otherCollateral)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPOtherCollateral (Account_ID_FK, OtherCollateral_Description) VALUES (@AccountID, @OtherCollateralDescriptiion)";
            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", otherCollateral.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@OtherCollateralDescriptiion", genFunc.CheckIfNull(otherCollateral.OtherCollateralDescription));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public OtherCollateral GetOtherCollateral(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            OtherCollateral otherCollateralObj = new OtherCollateral();

            string strSQL = "SELECT * FROM tbl_CFPOtherCollateral WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            otherCollateralObj.AccountDetails = accountDetailsObj;
                            otherCollateralObj.OtherCollateralID = Convert.ToInt32(reader["OtherCollateral_ID"]); 
                            otherCollateralObj.OtherCollateralDescription = reader["OtherCollateral_Description"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return otherCollateralObj;
        }

        public void UpdateOtherCollateral(OtherCollateral otherCollateral)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPOtherCollateral SET " +
                "OtherCollateral_Description = @OtherCollateralDescription " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@OtherCollateralDescription", otherCollateral.OtherCollateralDescription);
                    command.Parameters.AddWithValue("@AccountID", otherCollateral.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void AddNewTermsAndConditions(TermsAndConditions termsAndConditions)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPTermsAndConditions(Account_ID_FK, Proposed_Facility, Purpose, Amount_Facility, LLFC_Training, Term, Interest_Rate, Mode_Of_Payment, Availment_Method, Security_Collateral, Other_Conditions, Other_Terms_And_Conditions)" +
                "VALUES(" +
                "@AccountID," +
                "@ProposedFacility," +
                "@Purpose," +
                "@AmountFacility," +
                "@LLFCTraining," +
                "@Term," +
                "@InterestRate," +
                "@ModeOfPayment," +
                "@AvailmentMethod," +
                "@SecurityCollateral," +
                "@OtherCondition," +
                "@OtherTermsAndCondition" +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", termsAndConditions.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@ProposedFacility", genFunc.CheckIfNull(termsAndConditions.ProposedFacility));
                    command.Parameters.AddWithValue("@Purpose", genFunc.CheckIfNull(termsAndConditions.Purpose));
                    command.Parameters.AddWithValue("@AmountFacility", genFunc.CheckIfNull(termsAndConditions.AmountFacility));
                    command.Parameters.AddWithValue("@LLFCTraining", genFunc.CheckIfNull(termsAndConditions.LLFCTraining));
                    command.Parameters.AddWithValue("@Term", genFunc.CheckIfNull(termsAndConditions.Term));
                    command.Parameters.AddWithValue("@InterestRate", genFunc.CheckIfNull(termsAndConditions.InterestRate));
                    command.Parameters.AddWithValue("@ModeOfPayment", genFunc.CheckIfNull(termsAndConditions.ModeOfPayment));
                    command.Parameters.AddWithValue("@AvailmentMethod", genFunc.CheckIfNull(termsAndConditions.AvailmentMethod));
                    command.Parameters.AddWithValue("@SecurityCollateral", genFunc.CheckIfNull(termsAndConditions.SecurityCollateral));
                    command.Parameters.AddWithValue("@OtherCondition", genFunc.CheckIfNull(termsAndConditions.OtherCondition));
                    command.Parameters.AddWithValue("@OtherTermsAndCondition", genFunc.CheckIfNull(termsAndConditions.OtherTermsAndCondition));
                    
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public TermsAndConditions GetTermsAndConditions(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            TermsAndConditions termsAndConditionsObj = new TermsAndConditions();

            string strSQL = "SELECT * FROM tbl_CFPTermsAndConditions WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            termsAndConditionsObj.AccountDetails = accountDetailsObj;
                            termsAndConditionsObj.TermsAndConditionsID = Convert.ToInt32(reader["Terms_And_Conditions_ID"]);
                            termsAndConditionsObj.ProposedFacility = reader["Proposed_Facility"].ToString();
                            termsAndConditionsObj.Purpose = reader["Purpose"].ToString();
                            termsAndConditionsObj.AmountFacility = reader["Amount_Facility"].ToString();
                            termsAndConditionsObj.LLFCTraining = reader["LLFC_Training"].ToString();
                            termsAndConditionsObj.Term = reader["Term"].ToString();
                            termsAndConditionsObj.InterestRate = reader["Interest_Rate"].ToString();
                            termsAndConditionsObj.ModeOfPayment = reader["Mode_Of_Payment"].ToString();
                            termsAndConditionsObj.AvailmentMethod = reader["Availment_Method"].ToString();
                            termsAndConditionsObj.SecurityCollateral = reader["Security_Collateral"].ToString();
                            termsAndConditionsObj.OtherCondition = reader["Other_Conditions"].ToString();
                            termsAndConditionsObj.OtherTermsAndCondition = reader["Other_Terms_And_Conditions"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return termsAndConditionsObj;
        }

        public void UpdateTermsAndConditions(TermsAndConditions termsAndConditions)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPTermsAndConditions SET " +
                "Proposed_Facility = @ProposedFacility, " +
                "Purpose = @Purpose, " +
                "Amount_Facility = @AmountFacility, " +
                "LLFC_Training = @LLFCTraining, " +
                "Term = @Term, " +
                "Interest_Rate = @InterestRate, " +
                "Mode_Of_Payment = @ModeOfPayment, " +
                "Availment_Method = @AvailmentMethod, " +
                "Security_Collateral = @SecurityCollateral, " +
                "Other_Conditions = @OtherCondition, " +
                "Other_Terms_And_Conditions = @OtherTermsAndCondition " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@ProposedFacility", termsAndConditions.ProposedFacility);
                    command.Parameters.AddWithValue("@Purpose", termsAndConditions.Purpose);
                    command.Parameters.AddWithValue("@AmountFacility", termsAndConditions.AmountFacility);
                    command.Parameters.AddWithValue("@LLFCTraining", termsAndConditions.LLFCTraining);
                    command.Parameters.AddWithValue("@Term", termsAndConditions.Term);
                    command.Parameters.AddWithValue("@InterestRate", termsAndConditions.InterestRate);
                    command.Parameters.AddWithValue("@ModeOfPayment", termsAndConditions.ModeOfPayment);
                    command.Parameters.AddWithValue("@AvailmentMethod", termsAndConditions.AvailmentMethod);
                    command.Parameters.AddWithValue("@SecurityCollateral", termsAndConditions.SecurityCollateral);
                    command.Parameters.AddWithValue("@OtherCondition", termsAndConditions.OtherCondition);
                    command.Parameters.AddWithValue("@OtherTermsAndCondition", termsAndConditions.OtherTermsAndCondition);
                    command.Parameters.AddWithValue("@AccountID", termsAndConditions.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void AddNewBasisForRecommendation(BasisForRecommendation basisForRecommendation)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPBasisForRecommendation(Account_ID_FK, Character_AP, Character_Performance, Capacity_AP, Capacity_Performance, Capital_AP, Capital_Performance, Condition_AP, Condition_Performance)" +
                "VALUES(" +
                "@AccountID," +
                "@CharacterAP," +
                "@CharacterPerformance," +
                "@CapacityAP," +
                "@CapacityPerformance," +
                "@CapitalAP," +
                "@CapitalPerformance," +
                "@ConditionAP," +
                "@ConditionPerformance" +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", basisForRecommendation.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@CharacterAP", genFunc.CheckIfNull(basisForRecommendation.CapacityAP));
                    command.Parameters.AddWithValue("@CharacterPerformance", genFunc.CheckIfNull(basisForRecommendation.CapacityPerformance));
                    command.Parameters.AddWithValue("@CapacityAP", genFunc.CheckIfNull(basisForRecommendation.CapacityAP));
                    command.Parameters.AddWithValue("@CapacityPerformance", genFunc.CheckIfNull(basisForRecommendation.CapacityPerformance));
                    command.Parameters.AddWithValue("@CapitalAP", genFunc.CheckIfNull(basisForRecommendation.CapitalAP));
                    command.Parameters.AddWithValue("@CapitalPerformance", genFunc.CheckIfNull(basisForRecommendation.CapitalPerformance));
                    command.Parameters.AddWithValue("@ConditionAP", genFunc.CheckIfNull(basisForRecommendation.ConditionAP));
                    command.Parameters.AddWithValue("@ConditionPerformance", genFunc.CheckIfNull(basisForRecommendation.ConditionPerformance));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public BasisForRecommendation GetBasisForRecommendation(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            BasisForRecommendation basisForRecommendationObj = new BasisForRecommendation();

            string strSQL = "SELECT * FROM tbl_CFPBasisForRecommendation WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            basisForRecommendationObj.AccountDetails = accountDetailsObj;
                            basisForRecommendationObj.BasisForRecommendationID = Convert.ToInt32(reader["Basis_For_Recommendation_ID"]);
                            basisForRecommendationObj.CharacterAP = reader["Character_AP"].ToString();
                            basisForRecommendationObj.CharacterPerformance = reader["Character_Performance"].ToString();
                            basisForRecommendationObj.CapacityAP = reader["Capacity_AP"].ToString();
                            basisForRecommendationObj.CapacityPerformance = reader["Capacity_Performance"].ToString();
                            basisForRecommendationObj.CapitalAP = reader["Capital_AP"].ToString();
                            basisForRecommendationObj.CapitalPerformance = reader["Capital_Performance"].ToString();
                            basisForRecommendationObj.ConditionAP = reader["Condition_AP"].ToString();
                            basisForRecommendationObj.ConditionPerformance = reader["Condition_Performance"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return basisForRecommendationObj;
        }

        public void UpdateBasisForRecommendation(BasisForRecommendation basisForRecommendation)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPBasisForRecommendation SET " +
                "Character_AP = @CharacterAP, " +
                "Character_Performance = @CharacterPerformance, " +
                "Capacity_AP = @CapacityAP, " +
                "Capacity_Performance = @CapacityPerformance, " +
                "Capital_AP = @CapitalAP, " +
                "Capital_Performance = @CapitalPerformance, " +
                "Condition_AP = @ConditionAP, " +
                "Condition_Performance = @ConditionPerformance " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@CharacterAP", basisForRecommendation.CharacterAP);
                    command.Parameters.AddWithValue("@CharacterPerformance", basisForRecommendation.CharacterPerformance);
                    command.Parameters.AddWithValue("@CapacityAP", basisForRecommendation.CapacityAP);
                    command.Parameters.AddWithValue("@CapacityPerformance", basisForRecommendation.CapacityPerformance);
                    command.Parameters.AddWithValue("@CapitalAP", basisForRecommendation.CapitalAP);
                    command.Parameters.AddWithValue("@CapitalPerformance", basisForRecommendation.CapitalPerformance);
                    command.Parameters.AddWithValue("@ConditionAP", basisForRecommendation.ConditionAP);
                    command.Parameters.AddWithValue("@ConditionPerformance", basisForRecommendation.ConditionPerformance);
                    command.Parameters.AddWithValue("@AccountID", basisForRecommendation.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        } 

        public void AddNewProjectDescription(ProjectDescription projectDescription)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPProjectDescription(Account_ID_FK, Proposed_Facility)" +
                "VALUES(" +
                "@AccountID," +
                "@ProposedFacility" +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", projectDescription.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@ProposedFacility", genFunc.CheckIfNull(projectDescription.ProposedFacilityDescription));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public ProjectDescription GetProjectDescription(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            ProjectDescription projectDescriptionObj = new ProjectDescription();

            string strSQL = "SELECT * FROM tbl_CFPProjectDescription WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            projectDescriptionObj.AccountDetails = accountDetailsObj;
                            projectDescriptionObj.ProjectDescriptionID = Convert.ToInt32(reader["Project_Description_ID"]);
                            projectDescriptionObj.ProposedFacilityDescription = reader["Proposed_Facility"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return projectDescriptionObj;
        }

        public void UpdateProjectDescription(ProjectDescription projectDescription)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPProjectDescription SET " +
                "Proposed_Facility = @ProposedFacility " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@ProposedFacility", projectDescription.ProposedFacilityDescription);
                    command.Parameters.AddWithValue("@AccountID", projectDescription.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void AddNewLLFCExperienceAccountRelationship(LLFCExperienceAccountRelationship lLFCExperienceAccountRelationship)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPLLFCExperienceAccountRelationship(Account_ID_FK, LLFC_Experience_Account_Relationship_Description)" +
                "VALUES(" +
                "@AccountID," +
                "@LLFCExperienceAccountRelationshipDescription" +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", lLFCExperienceAccountRelationship.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@LLFCExperienceAccountRelationshipDescription", genFunc.CheckIfNull(lLFCExperienceAccountRelationship.LLFCExperienceAccountRelationshipDescription));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public LLFCExperienceAccountRelationship GetLLFCExperienceAccountRelationship(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            LLFCExperienceAccountRelationship lLFCExperienceAccountRelationshipObj = new LLFCExperienceAccountRelationship();

            string strSQL = "SELECT * FROM tbl_CFPLLFCExperienceAccountRelationship WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            lLFCExperienceAccountRelationshipObj.AccountDetails = accountDetailsObj;
                            lLFCExperienceAccountRelationshipObj.LLFCExperienceAccountRelationshipID = Convert.ToInt32(reader["LLFC_Experience_Account_Relationship_ID"]);
                            lLFCExperienceAccountRelationshipObj.LLFCExperienceAccountRelationshipDescription = reader["LLFC_Experience_Account_Relationship_Description"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return lLFCExperienceAccountRelationshipObj;
        }

        public void UpdateLLFCExperienceAccountRelationship(LLFCExperienceAccountRelationship lLFCExperienceAccountRelationship)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPLLFCExperienceAccountRelationship SET " +
                "LLFC_Experience_Account_Relationship_Description = @LLFCExperienceAccountRelationshipDescription " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@LLFCExperienceAccountRelationshipDescription", lLFCExperienceAccountRelationship.LLFCExperienceAccountRelationshipDescription);
                    command.Parameters.AddWithValue("@AccountID", lLFCExperienceAccountRelationship.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void AddNewFinancialPosition(FinancialPosition financialPosition)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPFinancialPosition(Account_ID_FK, Auditor, Auditors_Unqualified_Opinion, Liquidity, Solvency_And_Capital_Adequacy, Profitability)" +
                "VALUES(" +
                "@AccountID," +
                "@Auditor," +
                "@AuditorsUnqualifiedOpinion," +
                "@Liquidity," +
                "@SolvencyAndCapitalAdequacy," +
                "@Profitability" +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", financialPosition.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@Auditor", genFunc.CheckIfNull(financialPosition.Auditor));
                    command.Parameters.AddWithValue("@AuditorsUnqualifiedOpinion", genFunc.CheckIfNull(financialPosition.AuditorsUnqualifiedOpinion));
                    command.Parameters.AddWithValue("@Liquidity", genFunc.CheckIfNull(financialPosition.Liquidity));
                    command.Parameters.AddWithValue("@SolvencyAndCapitalAdequacy", genFunc.CheckIfNull(financialPosition.SolvencyAndCapitalAdequacy));
                    command.Parameters.AddWithValue("@Profitability", genFunc.CheckIfNull(financialPosition.Profitability));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public FinancialPosition GetFinancialPosition(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            FinancialPosition financialPositionoBJ = new FinancialPosition();

            string strSQL = "SELECT * FROM tbl_CFPFinancialPosition WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            financialPositionoBJ.AccountDetails = accountDetailsObj;
                            financialPositionoBJ.FinancialPositionID = Convert.ToInt32(reader["Financial_Position_ID"]);
                            financialPositionoBJ.Auditor = reader["Auditor"].ToString();
                            financialPositionoBJ.AuditorsUnqualifiedOpinion = reader["Auditors_Unqualified_Opinion"].ToString();
                            financialPositionoBJ.Liquidity = reader["Liquidity"].ToString();
                            financialPositionoBJ.SolvencyAndCapitalAdequacy = reader["Solvency_And_Capital_Adequacy"].ToString();
                            financialPositionoBJ.Profitability = reader["Profitability"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return financialPositionoBJ;
        }

        public void UpdateFinancialPosition(FinancialPosition financialPosition)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPFinancialPosition SET " +
                "Auditor = @Auditor, " +
                "Auditors_Unqualified_Opinion = @AuditorsUnqualifiedOpinion, " +
                "Liquidity = @Liquidity, " +
                "Solvency_And_Capital_Adequacy = @SolvencyAndCapitalAdequacy, " +
                "Profitability = @Profitability " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@Auditor", financialPosition.Auditor);
                    command.Parameters.AddWithValue("@AuditorsUnqualifiedOpinion", financialPosition.AuditorsUnqualifiedOpinion);
                    command.Parameters.AddWithValue("@Liquidity", financialPosition.Liquidity);
                    command.Parameters.AddWithValue("@SolvencyAndCapitalAdequacy", financialPosition.SolvencyAndCapitalAdequacy);
                    command.Parameters.AddWithValue("@Profitability", financialPosition.Profitability);
                    command.Parameters.AddWithValue("@AccountID", financialPosition.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public void AddNewFinancialProjections(FinancialProjections financialProjections)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "INSERT INTO tbl_CFPFinancialProjections(Account_ID_FK, Basic_Assumptions, Projected_Income, Projected_Cash_Flows)" +
                "VALUES(" +
                "@AccountID," +
                "@BasicAssumptions, " +
                "@ProjectedIncome, " +
                "@ProjectedCashFlows " +
                ")";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", financialProjections.AccountDetails.AccountID);
                    command.Parameters.AddWithValue("@BasicAssumptions", genFunc.CheckIfNull(financialProjections.BasicAssumptions));
                    command.Parameters.AddWithValue("@ProjectedIncome", genFunc.CheckIfNull(financialProjections.ProjectedIncome));
                    command.Parameters.AddWithValue("@ProjectedCashFlows", genFunc.CheckIfNull(financialProjections.ProjectedCashFlows));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

        public FinancialProjections GetFinancialProjections(AccountDetails accountDetails)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            AccountDetails accountDetailsObj = new AccountDetails();
            FinancialProjections financialProjectionsObj = new FinancialProjections();

            string strSQL = "SELECT * FROM tbl_CFPFinancialProjections WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@AccountID", accountDetails.AccountID);

                    using (OleDbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            accountDetailsObj.AccountID = accountDetails.AccountID;
                            accountDetailsObj.AccountName = accountDetails.AccountName;
                            accountDetailsObj.Date = accountDetails.Date;

                            financialProjectionsObj.AccountDetails = accountDetailsObj;
                            financialProjectionsObj.FinancialProjectionsID = Convert.ToInt32(reader["Financial_Projections_ID"]);
                            financialProjectionsObj.BasicAssumptions = reader["Basic_Assumptions"].ToString();
                            financialProjectionsObj.ProjectedIncome = reader["Projected_Income"].ToString();
                            financialProjectionsObj.ProjectedCashFlows = reader["Projected_Cash_Flows"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

            return financialProjectionsObj;
        }

        public void UpdateFinancialProjections(FinancialProjections financialProjections)
        {
            string conn = WebConfigurationManager.AppSettings["DBconn"];

            string strSQL = "UPDATE tbl_CFPFinancialProjections SET " +
                "Basic_Assumptions = @BasicAssumptions, " +
                "Projected_Income = @ProjectedIncome, " +
                "Projected_Cash_Flows = @ProjectedCashFlows " +
                "WHERE Account_ID_FK = @AccountID";

            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(strSQL, connection);
                try
                {
                    command.Parameters.AddWithValue("@BasicAssumptions", financialProjections.BasicAssumptions);
                    command.Parameters.AddWithValue("@ProjectedIncome", financialProjections.ProjectedIncome);
                    command.Parameters.AddWithValue("@ProjectedCashFlows", financialProjections.ProjectedCashFlows);
                    command.Parameters.AddWithValue("@AccountID", financialProjections.AccountDetails.AccountID);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }
    }
}