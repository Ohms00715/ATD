using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ATD.Management
{
    public class DataHelper
    {
        public static DataSet ExecuteDataSet(System.Data.SqlClient.SqlConnection connection, string sqlText, CommandType commandType, SqlParameter[] parameters, params string[] tableNames)
        {

            SqlDataAdapter adapter = new SqlDataAdapter(sqlText, connection);

            adapter.SelectCommand.CommandType = commandType;

            if (parameters != null)
            {

                foreach (SqlParameter parameter in parameters)

                    adapter.SelectCommand.Parameters.Add(parameter);

            }

            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet);

            if (tableNames != null)
            {

                int tableCount = dataSet.Tables.Count < tableNames.Length ? dataSet.Tables.Count : tableNames.Length;

                for (int i = 0; i < tableCount; i++)

                    dataSet.Tables[i].TableName = tableNames[i];

            }

            return dataSet;

        }

        public static DateTime ExecuteServerDateTime(System.Data.SqlClient.SqlConnection connection)
        {
            SqlDataReader rdr = null;
            DateTime dateTime;
            System.Data.SqlClient.SqlCommand dataCommand;
            string sqlText = " SELECT GetDate() AS  currentDate  ";
            dataCommand = new SqlCommand(sqlText, connection);
            rdr = dataCommand.ExecuteReader();
            if (rdr != null)
            {
                rdr.Read();
                dateTime = (DateTime)rdr["currentDate"];
                rdr.Close();
            }
            else
            {
                dateTime = System.DateTime.Now;
            }

            return dateTime;
        }
    }

}
