using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;


namespace ATD.Data
{

   


    #region Master

    public partial class ATD_Employee
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_Employee(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_Employee";
            tableMapping.ColumnMappings.Add("EMP_ID", "EMP_ID");
            tableMapping.ColumnMappings.Add("EMP_FName", "EMP_FName");
            tableMapping.ColumnMappings.Add("EMP_LName", "EMP_LName");
            tableMapping.ColumnMappings.Add("EMP_Register_Status", "EMP_Register_Status");
            tableMapping.ColumnMappings.Add("EMP_Register_Date", "EMP_Register_Date");
            tableMapping.ColumnMappings.Add("EMP_Resigned_Flag", "EMP_Resigned_Flag");
            tableMapping.ColumnMappings.Add("EMP_Resigned_Flag_Date", "EMP_Resigned_Flag_Date");
            tableMapping.ColumnMappings.Add("EMP_vacation_Flag", "EMP_vacation_Flag");
            tableMapping.ColumnMappings.Add("EMP_Title_ID", "EMP_Title_ID");
            tableMapping.ColumnMappings.Add("EMP_Type_ID", "EMP_Type_ID");
            tableMapping.ColumnMappings.Add("EMP_Dep_ID", "EMP_Dep_ID");
            tableMapping.ColumnMappings.Add("WorkDay_ID", "WorkDay_ID");
            tableMapping.ColumnMappings.Add("TeamCode", "TeamCode");
            tableMapping.ColumnMappings.Add("Shitf_Type_ID", "Shitf_Type_ID");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
                                       SELECT  EMP_ID
                                                  ,EMP_FName
                                                  ,EMP_LName
                                                  ,EMP_Register_Status
                                                  ,EMP_Register_Date
                                                  ,EMP_Resigned_Flag
                                                  ,EMP_Resigned_Flag_Date
                                                  ,EMP_vacation_Flag
                                                  ,EMP_Title_ID
                                                  ,EMP_Type_ID
                                                  ,EMP_Dep_ID
                                                  ,WorkDay_ID
                                                  ,TeamCode
                                                   ,Shitf_Type_ID
                                                  ,Created_by
                                                  ,Created_Time
                                                  ,Updated_by
                                                  ,Updated_Time
                                              FROM ATD_Employee
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Employee   WHERE EMP_ID = @originalEMP_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalEMP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Employee ( EMP_ID,EMP_FName,EMP_LName,EMP_Register_Status,EMP_Register_Date,EMP_Resigned_Flag,EMP_Resigned_Flag_Date,EMP_vacation_Flag,EMP_Title_ID,EMP_Type_ID,EMP_Dep_ID,WorkDay_ID,TeamCode,Shitf_Type_ID,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @EMP_ID,@EMP_FName,@EMP_LName,@EMP_Register_Status,@EMP_Register_Date,@EMP_Resigned_Flag,@EMP_Resigned_Flag_Date,@EMP_vacation_Flag,@EMP_Title_ID,@EMP_Type_ID,@EMP_Dep_ID,@WorkDay_ID,@TeamCode,@Shitf_Type_ID,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_FName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_FName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_LName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_LName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Register_Status", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Register_Status", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Register_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EMP_Register_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Resigned_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Resigned_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Resigned_Flag_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EMP_Resigned_Flag_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_vacation_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_vacation_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkDay_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Shitf_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Shitf_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Employee SET EMP_ID=@EMP_ID,EMP_FName=@EMP_FName,EMP_LName=@EMP_LName,EMP_Register_Status=@EMP_Register_Status,EMP_Register_Date=@EMP_Register_Date,EMP_Resigned_Flag=@EMP_Resigned_Flag,EMP_Resigned_Flag_Date=@EMP_Resigned_Flag_Date,Updated_by=@Updated_by ,Updated_Time=GetDate(),EMP_vacation_Flag=@EMP_vacation_Flag,EMP_Title_ID=@EMP_Title_ID,EMP_Type_ID=@EMP_Type_ID,EMP_Dep_ID=@EMP_Dep_ID,WorkDay_ID=@WorkDay_ID,TeamCode=@TeamCode,Shitf_Type_ID=@Shitf_Type_ID
                                                WHERE EMP_ID = @originalEMP_ID;
                                                SELECT * FROM ATD_Employee WHERE EMP_ID = @originalEMP_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_FName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_FName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_LName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_LName", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Register_Status", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Register_Status", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Register_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EMP_Register_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Resigned_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Resigned_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Resigned_Flag_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EMP_Resigned_Flag_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_vacation_Flag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_vacation_Flag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkDay_ID", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Shitf_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Shitf_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalEMP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_Employee WHERE EMP_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

    public partial class ATD_Employee_Title
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_Employee_Title(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_Employee_Title";
            tableMapping.ColumnMappings.Add("EMP_Title_ID", "EMP_Title_ID");
            tableMapping.ColumnMappings.Add("EMP_Title_Desc", "EMP_Title_Desc");
            tableMapping.ColumnMappings.Add("EMP_Title_Activated", "EMP_Title_Activated");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
          SELECT   EMP_Title_ID
      ,EMP_Title_Desc
      ,EMP_Title_Activated
      ,Created_by
      ,Created_Time
      ,Updated_by
      ,Updated_Time
  FROM ATD_Employee_Title
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Employee_Title   WHERE EMP_Title_ID = @originalEMP_Title_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalEMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Employee_Title ( EMP_Title_ID,EMP_Title_Desc,EMP_Title_Activated,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @EMP_Title_ID,@EMP_Title_Desc,@EMP_Title_Activated,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Title_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Title_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Title_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Title_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Employee_Title SET EMP_Title_ID=@EMP_Title_ID,EMP_Title_Desc=@EMP_Title_Desc,EMP_Title_Activated=@EMP_Title_Activated,Updated_by=@Updated_by ,Updated_Time=GetDate() 
                                                WHERE EMP_Title_ID = @originalEMP_Title_ID;
                                                SELECT * FROM ATD_Employee_Title WHERE EMP_Title_ID = @originalEMP_Title_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Title_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Title_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Title_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Title_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalEMP_Title_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Title_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_Employee_Title WHERE EMP_Title_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
   
    public partial class ATD_Employee_Department
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_Employee_Department(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_Employee_Department";
            tableMapping.ColumnMappings.Add("EMP_Dep_ID", "EMP_Dep_ID");
            tableMapping.ColumnMappings.Add("EMP_Dep_Desc", "EMP_Dep_Desc");
            tableMapping.ColumnMappings.Add("Activated", "Activated");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
       SELECT  EMP_Dep_ID
      ,EMP_Dep_Desc
      ,Activated
      ,Created_by
      ,Created_Time
      ,Updated_by
      ,Updated_Time
  FROM ATD_Employee_Department
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Employee_Department   WHERE EMP_Dep_ID = @originalEMP_Dep_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalEMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Employee_Department ( EMP_Dep_ID,EMP_Dep_Desc,Activated,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @EMP_Dep_ID,@EMP_Dep_Desc,@Activated,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Dep_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Employee_Department SET EMP_Dep_ID=@EMP_Dep_ID,EMP_Dep_Desc=@EMP_Dep_Desc,Activated=@Activated,Updated_by=@Updated_by ,Updated_Time=GetDate() 
                                                WHERE EMP_Dep_ID = @originalEMP_Dep_ID;
                                                SELECT * FROM ATD_Employee_Department WHERE EMP_Dep_ID = @originalEMP_Dep_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Dep_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalEMP_Dep_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Dep_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_Employee_Department WHERE EMP_Dep_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

    public partial class ATD_Employee_Type
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_Employee_Type(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_Employee_Type";
            tableMapping.ColumnMappings.Add("EMP_Type_ID", "EMP_Type_ID");
            tableMapping.ColumnMappings.Add("EMP_Type_Desc", "EMP_Type_Desc");
            tableMapping.ColumnMappings.Add("EMP_Type_Activated", "EMP_Type_Activated");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
       SELECT  EMP_Type_ID
      ,EMP_Type_Desc
      ,EMP_Type_Activated
      ,Created_by
      ,Created_Time
      ,Updated_by
      ,Updated_Time
  FROM ATD_Employee_Type
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Employee_Type   WHERE EMP_Type_ID = @originalEMP_Type_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalEMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Employee_Type ( EMP_Type_ID,EMP_Type_Desc,EMP_Type_Activated,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @EMP_Type_ID,@EMP_Type_Desc,@EMP_Type_Activated,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Type_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Type_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EMP_Type_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Type_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Employee_Type SET EMP_Type_ID=@EMP_Type_ID,EMP_Type_Desc=@EMP_Type_Desc,EMP_Type_Activated=@EMP_Type_Activated,Updated_by=@Updated_by ,Updated_Time=GetDate() 
                                                WHERE EMP_Type_ID = @originalEMP_Type_ID;
                                                SELECT * FROM ATD_Employee_Type WHERE EMP_Type_ID = @originalEMP_Type_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Type_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "EMP_Type_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EMP_Type_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "EMP_Type_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalEMP_Type_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EMP_Type_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_Employee_Type WHERE EMP_Type_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

    public partial class ATD_Vacation
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_Vacation(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_Vacation";
            tableMapping.ColumnMappings.Add("VA_ID", "VA_ID");
            tableMapping.ColumnMappings.Add("VA_Desc", "VA_Desc");
            tableMapping.ColumnMappings.Add("VA_Date", "VA_Date");
            tableMapping.ColumnMappings.Add("VA_Activated", "VA_Activated");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
      SELECT  VA_ID
      ,VA_Desc
      ,VA_Date
      ,VA_Activated
      ,Created_by
      ,Created_Time
      ,Updated_by
      ,Updated_Time
  FROM ATD_Vacation
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Vacation   WHERE VA_ID = @originalVA_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalVA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VA_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Vacation ( VA_ID,VA_Desc,VA_Date,VA_Activated,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @VA_ID,@VA_Desc,@VA_Date,@VA_Activated,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@VA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VA_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@VA_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "VA_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@VA_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "VA_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@VA_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "VA_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Vacation SET VA_ID=@VA_ID,VA_Desc=@VA_Desc,VA_Date=@VA_Date,VA_Activated=@VA_Activated,Updated_by=@Updated_by ,Updated_Time=GetDate() 
                                                WHERE VA_ID = @originalVA_ID;
                                                SELECT * FROM ATD_Vacation WHERE VA_ID = @originalVA_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@VA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VA_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@VA_Desc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "VA_Desc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@VA_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "VA_Date", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@VA_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "VA_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalVA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VA_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_Vacation WHERE VA_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }

    public partial class ATD_WorkDay
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public ATD_WorkDay(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ATD_WorkDay";
            tableMapping.ColumnMappings.Add("WorkDay_ID", "WorkDay_ID");
            tableMapping.ColumnMappings.Add("WorkDay_From_Day_ID", "WorkDay_From_Day_ID");
            tableMapping.ColumnMappings.Add("WorkDay_To_Day_ID", "WorkDay_To_Day_ID");
            tableMapping.ColumnMappings.Add("WorkDay_Activated", "WorkDay_Activated");
            tableMapping.ColumnMappings.Add("Created_by", "Created_by");
            tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");
            tableMapping.ColumnMappings.Add("Updated_by", "Updated_by");
            tableMapping.ColumnMappings.Add("Updated_Time", "Updated_Time");


            /*
                                SELECT  WorkDay_ID
                                              ,WorkDay_Activated
                                              ,Created_by
                                              ,Created_Time
                                              ,Updated_by
                                              ,Updated_Time
                                              ,WorkDay_From_Day_ID
                                              ,WorkDay_To_Day_ID
                                          FROM ATD_WorkDay
             */
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_WorkDay   WHERE WorkDay_ID = @originalWorkDay_ID";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWorkDay_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;

            _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_WorkDay ( WorkDay_ID,WorkDay_From_Day_ID,WorkDay_To_Day_ID,WorkDay_Activated,Created_by,Created_Time,Updated_by ,Updated_Time) VALUES
             ( @WorkDay_ID,@WorkDay_From_Day_ID,@WorkDay_To_Day_ID,@WorkDay_Activated,@Created_by,GetDate(),@Updated_by,GetDate()) ";
            _adapter.InsertCommand.CommandType = CommandType.Text;

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkDay_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkDay_From_Day_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_From_Day_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkDay_To_Day_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_To_Day_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkDay_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "WorkDay_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_WorkDay SET WorkDay_ID=@WorkDay_ID,WorkDay_From_Day_ID=@WorkDay_From_Day_ID,WorkDay_To_Day_ID=@WorkDay_To_Day_ID,WorkDay_Activated=@WorkDay_Activated,Updated_by=@Updated_by ,Updated_Time=GetDate() 
                                                WHERE WorkDay_ID = @originalWorkDay_ID;
                                                SELECT * FROM ATD_WorkDay WHERE WorkDay_ID = @originalWorkDay_ID";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkDay_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkDay_From_Day_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_From_Day_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkDay_To_Day_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_To_Day_ID", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkDay_Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "WorkDay_Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Updated_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Updated_by", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWorkDay_ID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkDay_ID", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM ATD_WorkDay WHERE WorkDay_ID = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }

        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }


    public partial class PPINCTTeam
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTTeam(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTTeam";
            tableMapping.ColumnMappings.Add("TeamCode", "TeamCode");
            tableMapping.ColumnMappings.Add("TeamDesc", "TeamDesc");
            tableMapping.ColumnMappings.Add("Activated", "Activated");
            tableMapping.ColumnMappings.Add("ShiftFlag", "ShiftFlag");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTTeam   WHERE TeamCode = @originalTeamCode ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalTeamCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTTeam ( TeamCode,TeamDesc,Activated,ShiftFlag,CreateBy,CreateTime,UpdateBy,UpdateTime ) 
            VALUES ( @TeamCode,@TeamDesc,@Activated,@ShiftFlag,@CreateBy, GetDate(),@UpdateBy, GetDate() ) ; 
            SELECT PPINCTTeam.* FROM  PPINCTTeam  WHERE TeamCode =@TeamCode  ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeamDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamDesc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShiftFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ShiftFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTTeam SET TeamCode=@TeamCode,TeamDesc=@TeamDesc,Activated=@Activated,ShiftFlag=@ShiftFlag,
            UpdateBy=@UpdateBy,UpdateTime= GetDate()  WHERE TeamCode = @originalTeamCode  ; 
            SELECT PPINCTTeam.* FROM  PPINCTTeam  WHERE TeamCode = @originalTeamCode ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeamDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamDesc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShiftFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ShiftFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalTeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(string Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTTeam WHERE TeamCode = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
    public partial class PPINCTTimeWork
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTTimeWork(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTTimeWork";
            tableMapping.ColumnMappings.Add("WrkCode", "WrkCode");
            tableMapping.ColumnMappings.Add("WrkDesc", "WrkDesc");
            tableMapping.ColumnMappings.Add("StartHour", "StartHour");
            tableMapping.ColumnMappings.Add("StartMinute", "StartMinute");
            tableMapping.ColumnMappings.Add("EndHour", "EndHour");
            tableMapping.ColumnMappings.Add("EndMinute", "EndMinute");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("ShiftFlag", "ShiftFlag");
            tableMapping.ColumnMappings.Add("Activated", "Activated");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTTimeWork   WHERE WrkCode = @originalWrkCode ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTTimeWork 
            ( WrkCode,WrkDesc,StartHour,StartMinute,EndHour,EndMinute,StartTime,EndTime,ShiftFlag,Activated,
             CreateBy,CreateTime,UpdateBy,UpdateTime ) 
     VALUES ( @WrkCode,@WrkDesc,@StartHour,@StartMinute,@EndHour,@EndMinute,@StartTime,@EndTime,@ShiftFlag,@Activated,
            @CreateBy,GetDate(),@UpdateBy, GetDate() ) ; 
            SELECT PPINCTTimeWork.* FROM  PPINCTTimeWork  WHERE WrkCode = @WrkCode ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkDesc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@StartHour", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StartHour", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@StartMinute", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StartMinute", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EndHour", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EndHour", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EndMinute", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EndMinute", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "StartTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EndTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShiftFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ShiftFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTTimeWork SET 
            WrkCode=@WrkCode,WrkDesc=@WrkDesc,StartHour=@StartHour,StartMinute=@StartMinute,EndHour=@EndHour,
            EndMinute=@EndMinute,StartTime=@StartTime,EndTime=@EndTime,ShiftFlag=@ShiftFlag,Activated=@Activated,
            UpdateBy=@UpdateBy,UpdateTime= GetDate()  WHERE WrkCode = @originalWrkCode  ; 
            SELECT PPINCTTimeWork.* FROM  PPINCTTimeWork  WHERE WrkCode = @originalWrkCode ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkDesc", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StartHour", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StartHour", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StartMinute", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StartMinute", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EndHour", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EndHour", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EndMinute", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EndMinute", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "StartTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EndTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShiftFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ShiftFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activated", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "Activated", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(string Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTTimeWork WHERE WrkCode = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
    public partial class PPINCTWorkDate
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTWorkDate(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTWorkDate";
            tableMapping.ColumnMappings.Add("WrkDateKey", "WrkDateKey");
            tableMapping.ColumnMappings.Add("WrkYearKey", "WrkYearKey");
            tableMapping.ColumnMappings.Add("WrkDay", "WrkDay");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            tableMapping.ColumnMappings.Add("PlanQty", "PlanQty");
            tableMapping.ColumnMappings.Add("FinalIniQty", "FinalIniQty");
            tableMapping.ColumnMappings.Add("FinalActQty", "FinalActQty");
            tableMapping.ColumnMappings.Add("ClosedFlag", "ClosedFlag");
            tableMapping.ColumnMappings.Add("ClosedDate", "ClosedDate");
            tableMapping.ColumnMappings.Add("ClosedBy", "ClosedBy");
            tableMapping.ColumnMappings.Add("PeriodInMonth", "PeriodInMonth");
            tableMapping.ColumnMappings.Add("FMPlanQty", "FMPlanQty");
            tableMapping.ColumnMappings.Add("FMFinalIniQty", "FMFinalIniQty");
            tableMapping.ColumnMappings.Add("FMFinalActQty", "FMFinalActQty");
            //PlanQty,FinalIniQty,FinalActQty,ClosedFlag,ClosedDate,ClosedBy
            //FMPlanQty,FMFinalIniQty,FMFinalActQty
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTWorkDate   WHERE WrkDateKey = @originalWrkDateKey ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWrkDateKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkDateKey", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTWorkDate 
	        ( WrkYearKey,WrkDay,CreateBy,CreateTime,UpdateBy,UpdateTime ,PlanQty,FinalIniQty,FinalActQty,ClosedFlag,ClosedDate,ClosedBy  ,PeriodInMonth
              ,FMPlanQty,FMFinalIniQty,FMFinalActQty  )
     VALUES ( @WrkYearKey,@WrkDay,@CreateBy, GetDate(),@UpdateBy, GetDate() ,@PlanQty,@FinalIniQty,@FinalActQty,@ClosedFlag,@ClosedDate,@ClosedBy ,@PeriodInMonth 
              ,@FMPlanQty,@FMFinalIniQty,@FMFinalActQty) ; 
            SELECT PPINCTWorkDate.* FROM  PPINCTWorkDate  WHERE WrkDateKey = SCOPE_IDENTITY() ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkDateKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkDateKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "WrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            //PlanQty,FinalIniQty,FinalActQty,ClosedFlag,ClosedDate,ClosedBy

            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@PlanQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "PlanQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@FinalIniQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FinalIniQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@FinalActQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FinalActQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClosedFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ClosedFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClosedBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClosedBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ClosedDate", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@PeriodInMonth", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PeriodInMonth", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@FMPlanQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMPlanQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@FMFinalIniQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMFinalIniQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@FMFinalActQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMFinalActQty", DataRowVersion.Current, false, null, "", "", ""));

            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTWorkDate 
             SET WrkYearKey=@WrkYearKey,WrkDay=@WrkDay,UpdateBy=@UpdateBy,UpdateTime= GetDate() 
               ,PlanQty=@PlanQty,FinalIniQty =@FinalIniQty,FinalActQty =@FinalActQty,ClosedFlag =@ClosedFlag,
               ClosedDate =@ClosedDate,ClosedBy =@ClosedBy  ,PeriodInMonth =@PeriodInMonth
               ,FMPlanQty=@FMPlanQty,FMFinalIniQty=@FMFinalIniQty,FMFinalActQty =@FMFinalActQty
             WHERE WrkDateKey = @originalWrkDateKey  ; 
              SELECT PPINCTWorkDate.* FROM  PPINCTWorkDate  WHERE WrkDateKey = @originalWrkDateKey ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkDateKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkDateKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "WrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWrkDateKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkDateKey", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PlanQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "PlanQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FinalIniQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FinalIniQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FinalActQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FinalActQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClosedFlag", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "ClosedFlag", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClosedBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClosedBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ClosedDate", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PeriodInMonth", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PeriodInMonth", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FMPlanQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMPlanQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FMFinalIniQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMFinalIniQty", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FMFinalActQty", SqlDbType.Decimal, 0, ParameterDirection.Input, 0, 0, "FMFinalActQty", DataRowVersion.Current, false, null, "", "", ""));

        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTWorkDate WHERE WrkDateKey = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
    public partial class PPINCTWorkYear
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTWorkYear(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTWorkYear";
            tableMapping.ColumnMappings.Add("WrkYearKey", "WrkYearKey");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTWorkYear   WHERE WrkYearKey = @originalWrkYearKey ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTWorkYear ( WrkYearKey,CreateBy,CreateTime,UpdateBy,UpdateTime ) 
            VALUES ( @WrkYearKey,@CreateBy, GetDate(),@UpdateBy, GetDate() ) ; 
            SELECT PPINCTWorkYear.* FROM  PPINCTWorkYear  WHERE WrkYearKey = SCOPE_IDENTITY() ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTWorkYear 
            SET WrkYearKey=@WrkYearKey,UpdateBy=@UpdateBy,UpdateTime= GetDate()  WHERE WrkYearKey = @originalWrkYearKey  ; 
            SELECT PPINCTWorkYear.* FROM  PPINCTWorkYear  WHERE WrkYearKey = @originalWrkYearKey ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWrkYearKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkYearKey", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTWorkYear WHERE WrkYearKey = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
    public partial class PPINCTWorkCal
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTWorkCal(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTWorkCal";
            tableMapping.ColumnMappings.Add("WrkCalKey", "WrkCalKey");
            tableMapping.ColumnMappings.Add("WrkDay", "WrkDay");
            tableMapping.ColumnMappings.Add("TeamCode", "TeamCode");
            tableMapping.ColumnMappings.Add("WrkCode", "WrkCode");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTWorkCal   WHERE WrkCalKey = @originalWrkCalKey ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTWorkCal ( WrkDay,TeamCode,WrkCode,CreateBy,CreateTime,UpdateBy,UpdateTime ) 
            VALUES (@WrkDay,@TeamCode,@WrkCode,@CreateBy, GetDate(),@UpdateBy, GetDate() ) ; 
            SELECT PPINCTWorkCal.* FROM  PPINCTWorkCal  WHERE WrkCalKey = SCOPE_IDENTITY() ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "WrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTWorkCal SET WrkDay=@WrkDay,TeamCode=@TeamCode,WrkCode=@WrkCode,CreateBy=@CreateBy,CreateTime= GetDate(),UpdateBy=@UpdateBy,UpdateTime= GetDate()  WHERE WrkCalKey = @originalWrkCalKey  ; 
            SELECT PPINCTWorkCal.* FROM  PPINCTWorkCal  WHERE WrkCalKey = @originalWrkCalKey ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "WrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeamCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeamCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "WrkCode", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTWorkCal WHERE WrkCalKey = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
    public partial class PPINCTWorkCalShift
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        public PPINCTWorkCalShift(SqlConnection connection)
        {
            _connection = connection;
        }
        private SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                    InitAdapter();
                return _adapter;
            }
        }
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping tableMapping = new DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PPINCTWorkCalShift";
            tableMapping.ColumnMappings.Add("WrkCalShiftKey", "WrkCalShiftKey");
            tableMapping.ColumnMappings.Add("WrkCalKey", "WrkCalKey");
            tableMapping.ColumnMappings.Add("ShiftWrkDay", "ShiftWrkDay");
            tableMapping.ColumnMappings.Add("TimeFrom", "TimeFrom");
            tableMapping.ColumnMappings.Add("TimeTo", "TimeTo");
            tableMapping.ColumnMappings.Add("TotalMin", "TotalMin");
            tableMapping.ColumnMappings.Add("CreateBy", "CreateBy");
            tableMapping.ColumnMappings.Add("CreateTime", "CreateTime");
            tableMapping.ColumnMappings.Add("UpdateBy", "UpdateBy");
            tableMapping.ColumnMappings.Add("UpdateTime", "UpdateTime");
            Adapter.TableMappings.Add(tableMapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = _connection;
            _adapter.DeleteCommand.CommandText = " DELETE FROM PPINCTWorkCalShift   WHERE WrkCalShiftKey = @originalWrkCalShiftKey ";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalWrkCalShiftKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalShiftKey", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = _connection;
            _adapter.InsertCommand.CommandText = @"INSERT INTO  PPINCTWorkCalShift ( WrkCalKey,ShiftWrkDay,TimeFrom,TimeTo,TotalMin,CreateBy,CreateTime,UpdateBy,UpdateTime ) 
            VALUES (@WrkCalKey,@ShiftWrkDay,@TimeFrom,@TimeTo,@TotalMin,@CreateBy, GetDate(),@UpdateBy, GetDate() ) ; 
            SELECT PPINCTWorkCalShift.* FROM  PPINCTWorkCalShift  WHERE WrkCalShiftKey = SCOPE_IDENTITY() ";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkCalShiftKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalShiftKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@WrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShiftWrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ShiftWrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TimeFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "TimeFrom", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TimeTo", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "TimeTo", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@TotalMin", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalMin", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = _connection;
            _adapter.UpdateCommand.CommandText = @"UPDATE  PPINCTWorkCalShift 
            SET WrkCalKey=@WrkCalKey,ShiftWrkDay=@ShiftWrkDay,TimeFrom=@TimeFrom,TimeTo=@TimeTo,TotalMin=@TotalMin,CreateBy=@CreateBy,CreateTime= GetDate(),UpdateBy=@UpdateBy,UpdateTime= GetDate()  WHERE WrkCalShiftKey = @originalWrkCalShiftKey  ; 
            SELECT PPINCTWorkCalShift.* FROM  PPINCTWorkCalShift  WHERE WrkCalShiftKey = @originalWrkCalShiftKey ";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkCalShiftKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalShiftKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WrkCalKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalKey", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShiftWrkDay", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ShiftWrkDay", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TimeFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "TimeFrom", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TimeTo", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "TimeTo", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TotalMin", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalMin", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CreateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateBy", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UpdateBy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UpdateTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "UpdateTime", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalWrkCalShiftKey", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WrkCalShiftKey", DataRowVersion.Original, false, null, "", "", ""));
        }
        public int DeleteRecord(int Key)
        {
            SqlCommand command = new SqlCommand("DELETE FROM PPINCTWorkCalShift WHERE WrkCalShiftKey = @Key ", this._connection);
            command.Parameters.Add(new SqlParameter("@Key", Key));
            return command.ExecuteNonQuery();
        }
        public int UpdateRecord(DataTable dataTable)
        {
            return Adapter.Update(dataTable);
        }
        public int UpdateRecord(params DataRow[] dataRows)
        {
            return Adapter.Update(dataRows);
        }
    }
   

    #endregion 

}
