using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ATD.Data;
using System.Transactions;

namespace ATD.Management
{
   public class SqlMasterManeger
    {
        string _connStr = "";
        string _userID = "";
        string _lastError = "";

        public SqlMasterManeger(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        public DataTable GetATD_EmployeeList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                                string sqlText = @"SELECT EMP_ID
                                          ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS EMP_Title_ID2
                                          ,EMP_Title_ID
                                          ,EMP_FName
                                          ,EMP_LName
                                          , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
                                          ,EMP_Register_Date
                                          , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
                                          ,EMP_Resigned_Flag_Date   
                                          ,EMP_Type_ID
                                          ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
                                          ,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID2 
                                          ,EMP_Dep_ID
                                           ,(select isnull(EMP_Dep_Desc,'ERROR') from ATD_Employee_Department where ATD_Employee_Department.EMP_Dep_ID = ATD_Employee.EMP_Dep_ID) AS EMP_Dep_ID2         
                                           ,WorkDay_ID
                                            ,TeamCode
                                                    ,( case when TeamCode = 'A'THEN 'Kumku'
                                                      when TeamCode  = 'B'THEN 'Nurse 1'
                                                      when TeamCode  = 'C'THEN 'Nurse 2'
                                                      when TeamCode  = 'D'THEN 'Trainee'
                                                      when TeamCode  = 'E'THEN 'Cleaner A'
                                                      when TeamCode  = 'F'THEN 'Cleaner B'
                                                      when TeamCode  = 'G'THEN 'Cleaner C'
                                                    else '-' end) as TeamCode2
                                      
                                          ,Created_by
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                            ,( case  when Shitf_Type_ID  = '1'THEN 'Day'
                                               when Shitf_Type_ID  = '2'THEN 'Shift'
                                               else '-' end) as Shitf_Type_ID2
                                            ,Shitf_Type_ID
                                          FROM ATD_Employee ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee");

            }
            return dataSet.Tables[0];
        }

        public DataTable GetATD_EmployeeList2()
        {
            DataSet dataSet = null;
            string sqlText = "";

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                sqlText = @"SELECT EMP_ID
                                           ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
                                          ,(CONVERT(varchar,EMP_ID) + ' ' + EMP_FName) as EMP_FName2
                                          ,EMP_FName
                                          ,EMP_LName
                                          , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
                                          ,Convert(varchar,EMP_Register_Date,5) AS EMP_Register_Date
                                          , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
                                          ,EMP_Resigned_Flag_Date
                                          ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
                                          --,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID
                                          ,ATD_Employee.EMP_Type_ID AS EMP_Type_ID                  
                                        ,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID2
                                          , (select isnull(EMP_Dep_Desc,'ERROR') from ATD_Employee_Department where ATD_Employee_Department.EMP_Dep_ID = ATD_Employee.EMP_Dep_ID) AS EMP_Dep_ID
                                          ,WorkDay_ID
                                          ,( case when TeamCode = 'A'THEN 'Kumku'
                                                      when TeamCode  = 'B'THEN 'Nurse 1'
                                                      when TeamCode  = 'C'THEN 'Nurse 2'
                                                      when TeamCode  = 'D'THEN 'Trainee'
                                                      when TeamCode  = 'E'THEN 'Cleaner A'
                                                      when TeamCode  = 'F'THEN 'Cleaner B'
                                                      when TeamCode  = 'G'THEN 'Cleaner C'
                                                    else '-' end) as TeamCode
                                          ,Created_by
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                          ,Shitf_Type_ID  
                                          FROM ATD_Employee --where EMP_Type_ID = '1'";




                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee");

                sqlText = @"SELECT EMP_ID
                                           ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
                                          ,(CONVERT(varchar,EMP_ID) + ' ' + EMP_FName) as EMP_FName2
                                          ,EMP_FName
                                          ,EMP_LName
                                          , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
                                          ,Convert(varchar,EMP_Register_Date,5) AS EMP_Register_Date
                                          , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
                                          ,EMP_Resigned_Flag_Date
                                          ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
                                           ,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID
                                          , (select isnull(EMP_Dep_Desc,'ERROR') from ATD_Employee_Department where ATD_Employee_Department.EMP_Dep_ID = ATD_Employee.EMP_Dep_ID) AS EMP_Dep_ID
                                          ,WorkDay_ID
                                          ,( case when TeamCode = 'A'THEN 'Kumku'
                                                      when TeamCode  = 'B'THEN 'Nurse 1'
                                                      when TeamCode  = 'C'THEN 'Nurse 2'
                                                      when TeamCode  = 'D'THEN 'Trainee'
                                                      when TeamCode  = 'E'THEN 'Cleaner A'
                                                      when TeamCode  = 'F'THEN 'Cleaner B'
                                                      when TeamCode  = 'G'THEN 'Cleaner C'
                                                    else '-' end) as TeamCode
                                          ,Created_by
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                          ,Shitf_Type_ID  
                                          FROM ATD_Employee where EMP_Type_ID = '2'";

                dataSet.Merge((DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee2")));

                sqlText = @"SELECT EMP_ID
                                           ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
                                          ,(CONVERT(varchar,EMP_ID) + ' ' + EMP_FName) as EMP_FName2
                                          ,EMP_FName
                                          ,EMP_LName
                                          , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
                                          ,Convert(varchar,EMP_Register_Date,5) AS EMP_Register_Date
                                          , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
                                          ,EMP_Resigned_Flag_Date
                                          ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
                                           ,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID
                                          , (select isnull(EMP_Dep_Desc,'ERROR') from ATD_Employee_Department where ATD_Employee_Department.EMP_Dep_ID = ATD_Employee.EMP_Dep_ID) AS EMP_Dep_ID
                                          ,WorkDay_ID
                                          ,TeamCode
                                          ,Created_by
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                          ,Shitf_Type_ID  
                                          FROM ATD_Employee where EMP_Type_ID = '3'";

                dataSet.Merge((DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee3")));

                sqlText = @"SELECT EMP_ID
                                           ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
                                          ,(CONVERT(varchar,EMP_ID) + ' ' + EMP_FName) as EMP_FName2
                                          ,EMP_FName
                                          ,EMP_LName
                                          , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
                                          ,Convert(varchar,EMP_Register_Date,5) AS EMP_Register_Date
                                          , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
                                          ,EMP_Resigned_Flag_Date
                                          ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
                                           ,(select isnull(EMP_Type_Desc,'ERROR') from ATD_Employee_Type where ATD_Employee_Type.EMP_Type_ID = ATD_Employee.EMP_Type_ID) AS EMP_Type_ID
                                          , (select isnull(EMP_Dep_Desc,'ERROR') from ATD_Employee_Department where ATD_Employee_Department.EMP_Dep_ID = ATD_Employee.EMP_Dep_ID) AS EMP_Dep_ID
                                          ,WorkDay_ID
                                          ,TeamCode
                                          ,Created_by
                                          ,Created_Time
                                          ,Updated_by
                                          ,Updated_Time
                                          ,Shitf_Type_ID  
                                          FROM ATD_Employee where EMP_Type_ID = '4'";

                dataSet.Merge((DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee4")));


            }
            return dataSet.Tables[0];
        }

  





        public DataTable GetATD_EmployeeTitleList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT EMP_Title_ID
                                                  ,EMP_Title_Desc
                                                  ,EMP_Title_Activated
                                                  ,Created_by
                                                  ,Created_Time
                                                  ,Updated_by
                                                  ,Updated_Time
                                                   FROM ATD_Employee_Title";

                
               dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Employee_Title");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_EmployeeDepartmentList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"  SELECT  EMP_Dep_ID
                                                  ,EMP_Dep_Desc
                                                  ,Activated
                                                  ,Created_by
                                                  ,Created_Time
                                                  ,Updated_by
                                                  ,Updated_Time
                                              FROM ATD_Employee_Department";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Employee_Department");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_EmployeeTypeList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"  SELECT  EMP_Type_ID
                                                      ,EMP_Type_Desc
                                                      ,EMP_Type_Activated
                                                      ,Created_by
                                                      ,Created_Time
                                                      ,Updated_by
                                                      ,Updated_Time
                                                  FROM ATD_Employee_Type";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Employee_Type");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_VacationList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT  VA_ID
                                              ,VA_Desc
                                              ,VA_Date
                                              ,VA_Activated
                                              ,Created_by
                                              ,Created_Time
                                              ,Updated_by
                                              ,Updated_Time
                                          FROM ATD_Vacation";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Vacation");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_WorkDayList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT  WorkDay_ID
                                              ,WorkDay_Activated
                                              ,Created_by
                                              ,Created_Time
                                              ,Updated_by
                                              ,Updated_Time
                                              ,WorkDay_From_Day_ID
                                              ,WorkDay_To_Day_ID
                                          FROM ATD_WorkDay";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_WorkDay");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_DayPerWeekList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                            string sqlText = @" SELECT  DPW_ID
                                                      ,DPW_Desc

                                                      ,DPW_Activated
                                                  FROM ATD_Day_Per_Week";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Day_Per_Week");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_DayPerWeekList2()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT DPW_ID
                                                      ,DPW_Desc
                                                                          ,DPW_Activated
                                                                      FROM ATD_Day_Per_Week
                                                                           ";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Day_Per_Week2");

            }
            return dataSet.Tables[0];
        }









        public DataTable GetATD_ShiftTypeList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"    SELECT Shift_Type_ID
                                          ,Shift_Type_Desc
                                          ,Shift_Type_Activated
                                            FROM ATD_Shift_Type";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Shift_Type");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_ShiftTypeList2()
        {
            DataSet dataSet = null;


            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"    SELECT  Shift_Type_ID
      
	                                      ,CASE  (Shift_Type_ID)
	                                      WHEN '1' Then 'เช้า'
	                                      WHEN '2' Then 'ดึก'
                                          WHEN '3' Then 'วันหยุด'
	                                      END AS Day_or_Night
      
                                      FROM ATD_Shift_Type";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Shift_Type");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_TypeScanList(string Activated)
        {
            DataSet dataSet = null;
            string Acti="";
            if (Activated == "1")
            {
                Acti = " AND Type_Scan_Activated = 1";
            }
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @" SELECT  Type_Scan_ID
                                              ,Type_Scan_Desc
                                             ,Type_Scan_Activated
                                          FROM ATD_Type_Scan WHERE 1=1 ";
                sqlText += Acti;


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Type_Scan");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_RemarkScanList()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"        SELECT   Scan_Remark_ID
                                                     ,Scan_Remark_Desc
                                                     ,Activated
                                                  FROM ATD_Scan_Remark";


                dataSet = DataHelper.ExecuteDataSet(connection,
                                                     sqlText,
                                                     CommandType.Text,
                                                     null,
                                                     "ATD_Scan_Remark");

            }
            return dataSet.Tables[0];
        }
 
 
       
       
       
       




        #region Save data
        public int SaveMastertoDB(DataTable dt, string Tcode)
        {
            this.LastError = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Created_by"] = this._userID;
                    drr["Updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                       new ATD_Employee(connect).UpdateRecord(dt);
                    

                    }
                    scope.Complete();
                }
                return 1;
            }
            catch (Exception exp)
            {
                sb.AppendLine("Call Error :: SaveData()");
                sb.AppendLine("Message: " + exp.Message.ToString());
                sb.AppendLine("Source: " + exp.Source.ToString());
                sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
                this.LastError = sb.ToString();
                return -1;
            }
        }
       public int SaveMastertoDB2(DataTable dt, string Tcode)
        {
            this.LastError = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Created_by"] = this._userID;
                    drr["Updated_by"] = this._userID;
                }
                if (drr.RowState == DataRowState.Modified)
                {
                    drr["Updated_by"] = this._userID;
                }

            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ATD_Employee_Title(connect).UpdateRecord(dt);
                    

                    }
                    scope.Complete();
                }
                return 1;
            }
            catch (Exception exp)
            {
                sb.AppendLine("Call Error :: SaveData()");
                sb.AppendLine("Message: " + exp.Message.ToString());
                sb.AppendLine("Source: " + exp.Source.ToString());
                sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
                this.LastError = sb.ToString();
                return -1;
            }
        }
       public int SaveMastertoDB3(DataTable dt, string Tcode)
       {
           this.LastError = "";
           StringBuilder sb = new StringBuilder();

           foreach (DataRow drr in dt.Rows)
           {
               if (drr.RowState == DataRowState.Added)
               {
                   drr["Created_by"] = this._userID;
                   drr["Updated_by"] = this._userID;
               }
               if (drr.RowState == DataRowState.Modified)
               {
                   drr["Updated_by"] = this._userID;
               }

           }

           try
           {
               using (System.Transactions.TransactionScope scope = new TransactionScope())
               {
                   using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                   {
                       connect.Open();

                       new ATD_Employee_Department(connect).UpdateRecord(dt);


                   }
                   scope.Complete();
               }
               return 1;
           }
           catch (Exception exp)
           {
               sb.AppendLine("Call Error :: SaveData()");
               sb.AppendLine("Message: " + exp.Message.ToString());
               sb.AppendLine("Source: " + exp.Source.ToString());
               sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
               this.LastError = sb.ToString();
               return -1;
           }
       }
       public int SaveMastertoDB4(DataTable dt, string Tcode)
       {
           this.LastError = "";
           StringBuilder sb = new StringBuilder();

           foreach (DataRow drr in dt.Rows)
           {
               if (drr.RowState == DataRowState.Added)
               {
                   drr["Created_by"] = this._userID;
                   drr["Updated_by"] = this._userID;
               }
               if (drr.RowState == DataRowState.Modified)
               {
                   drr["Updated_by"] = this._userID;
               }

           }

           try
           {
               using (System.Transactions.TransactionScope scope = new TransactionScope())
               {
                   using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                   {
                       connect.Open();

                       new ATD_Employee_Type(connect).UpdateRecord(dt);


                   }
                   scope.Complete();
               }
               return 1;
           }
           catch (Exception exp)
           {
               sb.AppendLine("Call Error :: SaveData()");
               sb.AppendLine("Message: " + exp.Message.ToString());
               sb.AppendLine("Source: " + exp.Source.ToString());
               sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
               this.LastError = sb.ToString();
               return -1;
           }
       }
       public int SaveMastertoDB5(DataTable dt, string Tcode)
       {
           this.LastError = "";
           StringBuilder sb = new StringBuilder();

           foreach (DataRow drr in dt.Rows)
           {
               if (drr.RowState == DataRowState.Added)
               {
                   drr["Created_by"] = this._userID;
                   drr["Updated_by"] = this._userID;
               }
               if (drr.RowState == DataRowState.Modified)
               {
                   drr["Updated_by"] = this._userID;
               }

           }

           try
           {
               using (System.Transactions.TransactionScope scope = new TransactionScope())
               {
                   using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                   {
                       connect.Open();

                       new ATD_Vacation(connect).UpdateRecord(dt);


                   }
                   scope.Complete();
               }
               return 1;
           }
           catch (Exception exp)
           {
               sb.AppendLine("Call Error :: SaveData()");
               sb.AppendLine("Message: " + exp.Message.ToString());
               sb.AppendLine("Source: " + exp.Source.ToString());
               sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
               this.LastError = sb.ToString();
               return -1;
           }
       }
       public int SaveMastertoDB6(DataTable dt, string Tcode)
       {
           this.LastError = "";
           StringBuilder sb = new StringBuilder();

           foreach (DataRow drr in dt.Rows)
           {
               if (drr.RowState == DataRowState.Added)
               {
                   drr["Created_by"] = this._userID;
                   drr["Updated_by"] = this._userID;
               }
               if (drr.RowState == DataRowState.Modified)
               {
                   drr["Updated_by"] = this._userID;
               }

           }

           try
           {
               using (System.Transactions.TransactionScope scope = new TransactionScope())
               {
                   using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                   {
                       connect.Open();

                       new ATD_WorkDay(connect).UpdateRecord(dt);


                   }
                   scope.Complete();
               }
               return 1;
           }
           catch (Exception exp)
           {
               sb.AppendLine("Call Error :: SaveData()");
               sb.AppendLine("Message: " + exp.Message.ToString());
               sb.AppendLine("Source: " + exp.Source.ToString());
               sb.AppendLine("StackTrace: " + exp.StackTrace.ToString());
               this.LastError = sb.ToString();
               return -1;
           }
       }






  




















        #endregion
      
     
#region properties

        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion
    }
}
