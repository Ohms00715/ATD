using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace ATD.Data
{
   public class DataAdopterTransaction
    {
       public partial class ATD_ImportFiles_TRN
       {
           private SqlConnection _connection;
           private SqlDataAdapter _adapter;
           public ATD_ImportFiles_TRN(SqlConnection connection)
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
               tableMapping.DataSetTable = "ATD_Machine_Import";
               tableMapping.ColumnMappings.Add("NO", "NO");
               tableMapping.ColumnMappings.Add("Mchn", "Mchn");
               tableMapping.ColumnMappings.Add("Name", "Name");
               tableMapping.ColumnMappings.Add("Mode", "Mode");
               tableMapping.ColumnMappings.Add("IOMd", "IOMd");
               tableMapping.ColumnMappings.Add("Datetime", "Datetime");
               tableMapping.ColumnMappings.Add("Created_by", "Created_by");
               tableMapping.ColumnMappings.Add("Created_Time", "Created_Time");


               /*
                     SELECT  NO
                              ,Mchn
                              ,EnNo
                              ,Name
                              ,Mode
                              ,IOMd
                              ,Datetime
                              ,Created_by
                              ,Created_Time
                          FROM ATD_Machine_Import
                */
               Adapter.TableMappings.Add(tableMapping);
               _adapter.DeleteCommand = new SqlCommand();
               _adapter.DeleteCommand.Connection = _connection;
               _adapter.DeleteCommand.CommandText = " DELETE FROM ATD_Machine_Import   WHERE NO = @originalNO";
               _adapter.DeleteCommand.CommandType = CommandType.Text;
               _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@originalNO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NO", DataRowVersion.Original, false, null, "", "", ""));
               _adapter.InsertCommand = new SqlCommand();
               _adapter.InsertCommand.Connection = _connection;

               _adapter.InsertCommand.CommandText = @"INSERT INTO  ATD_Machine_Import ( Mchn,EnNo,Name,Mode,IOMd,Datetime,Created_by,Created_Time) VALUES
             (@Mchn,@EnNo,@Name,@Mode,@IOMd,@Datetime,@Created_by,GetDate()) ";
               _adapter.InsertCommand.CommandType = CommandType.Text;

               //_adapter.InsertCommand.Parameters.Add(new SqlParameter("@NO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NO", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mchn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Mchn", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@EnNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EnNo", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mode", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@IOMd", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IOMd", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Datetime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Datetime", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.InsertCommand.Parameters.Add(new SqlParameter("@Created_by", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Created_by", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand = new SqlCommand();
               _adapter.UpdateCommand.Connection = _connection;
               _adapter.UpdateCommand.CommandText = @"UPDATE  ATD_Machine_Import SET Mchn=@Mchn,EnNo=@EnNo,Name=@Name ,Mode=@Mode,IOMd=@IOMd,Datetime=@Datetime 
                                                WHERE NO = @originalNO;
                                                SELECT * FROM ATD_Machine_Import WHERE NO = @originalNO";
               //_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NO", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mchn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Mchn", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EnNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EnNo", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Mode", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IOMd", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IOMd", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Datetime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Datetime", DataRowVersion.Current, false, null, "", "", ""));
               _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@originalNO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NO", DataRowVersion.Original, false, null, "", "", ""));
           }
           public int DeleteRecord(int Key)
           {
               SqlCommand command = new SqlCommand("DELETE FROM ATD_Machine_Import WHERE NO = @Key ", this._connection);
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
    }
}
