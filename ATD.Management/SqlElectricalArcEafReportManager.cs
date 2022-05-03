using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using ATD.Data;
namespace ATD.Management
{
    public class SqlElectricalArcEafReportManager
    {
        #region Variable
        private string _connStr;
        private string _userID;
        private string _tableName = "PP_TOU_Elec_Calendar";
        private string _tableNamePPElecArc = "PPElecArc";
        private string _tableNamePPElecArcReport = "PPElecArcReport";
        private string _tableNamePPElecArcGrandTotalReport = "PPElecArcGrandTotalReport";
        #endregion Variable

        public SqlElectricalArcEafReportManager(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }

        #region Get data

        public DataTable GetListYearTOU()
        {
            DataSet dataSet = null;
            string sqlText = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"select Year(GDate) as GYear
                              from PP_TOU_Elec_Calendar
                             group by Year(GDate)
                             order by Year(GDate) desc";
                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        //new SqlParameter("@sEndingBalanceDate", sEndingBalanceDate)
                                                       },
                                    "ListYearTOU");
            }
            return dataSet.Tables[0];
        }

        public DataTable GetElecArcEafReportByDate(DateTime DateFrom, DateTime DateTo)
        {
            DataSet dataSet = null;
            string strCriteria = "";
            string sqlText = "";
            string strDateFrom = "";
            string strDateTo = "";

            strDateFrom = DateFrom.Year.ToString("0000") + DateFrom.Month.ToString("00") + DateFrom.Day.ToString("00");
            strDateTo = DateTo.Year.ToString("0000") + DateTo.Month.ToString("00") + DateTo.Day.ToString("00");

            strCriteria = string.Format("where convert(varchar,ProductDate,112) between '{0}' and '{1}'", strDateFrom, strDateTo);

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"select  
		                            nameDay + ' ' + convert(varchar(11),ProductDate,6) as ProductionDate
		                            ,HeatStart
		                            ,HeatEnd
		                            --,First_power_on_time
		                            --,Tapping_end_time
		                            ,left(DATENAME(DW,First_power_on_time),3) + ' ' + 
		                             CONVERT(varchar(11),First_power_on_time,6) + ' ' + 
		                             left(convert(varchar,First_power_on_time,108),5) as First_power_on_time
		                            ,left(DATENAME(DW,Tapping_end_time),3) + ' ' + 
		                             CONVERT(varchar(11),Tapping_end_time,6) + ' ' + 
		                             left(convert(varchar,Tapping_end_time,108),5) as Tapping_end_time
		                            ,MeltingTime
		                            ,(case when nameDay = 'Sat' or nameDay = 'Sun' or TOUElcDay = 1
			                               then 660
			                               else  MeltingTime -
					                             ((case when First_power_on_time < StartTimeOffPeak 
						                              then cast(datediff(MINUTE,First_power_on_time,StartTimeOffPeak )as int)
						                              else 0
						                              end) +
					                             (case when Tapping_end_time > StartTimeOnPeak
						                              then cast(datediff(minute,StartTimeOnPeak,Tapping_end_time)as int)
						                              else 0
						                              end))
			                               end)as OffPeakTime
		                            ,(case when nameDay = 'Sat' or nameDay = 'Sun' or TOUElcDay = 1
			                               then 780
			                               else (case when First_power_on_time < StartTimeOffPeak 
						                              then cast(datediff(MINUTE,First_power_on_time,StartTimeOffPeak )as int)
						                              else 0
						                              end) +
					                             (case when Tapping_end_time > StartTimeOnPeak
						                              then cast(datediff(minute,StartTimeOnPeak,Tapping_end_time)as int)
						                              else 0
						                              end)
			                               end)as OnPeakTime
                            from 
	                            (
		                            select ProductDate
			                              ,left(DATENAME(DW,ProductDate),3) as nameDay
			                              ,case when isnull(PP_TOU_Elec_Calendar.GDate,0) = 0 then 0 else 1 end as TOUElcDay
			                              ,HeatStart
			                              ,HeatEnd
			                              ,First_power_on_time
			                              ,Tapping_end_time		  
			                              ,cast(datediff(MINUTE,First_power_on_time,Tapping_end_time)as int) as MeltingTime
			                              ,cast(convert(varchar,First_power_on_time,102) + ' 22:00' as datetime) as StartTimeOffPeak --22:00-09:00
			                              ,cast(convert(varchar,Tapping_end_time,102) + ' 09:00' as datetime) as StartTimeOnPeak --09:00-22:00 
		                              from GSUM.dbo.DailyPPEafArc left outer join PP_TOU_Elec_Calendar
												                               on GSUM.dbo.DailyPPEafArc.ProductDate = PP_TOU_Elec_Calendar.GDate ";
	                          sqlText += strCriteria + @" )v";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        //new SqlParameter("@sEndingBalanceDate", sEndingBalanceDate)
                                                       },
                                    this.TableNamePPElecArc);
            }
            return dataSet.Tables[0];
        }

        public DataSet GetCalendarTOU_ByYear(string Year)
        {
            DataSet dataSet = null;
            string sqlText = "";
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"SELECT GDate
                                  ,Remark
                                  ,CreatedBy
                                  ,CreatedTime
                                  ,UpdatedBy
                                  ,UpdatedTime
                              FROM PP_TOU_Elec_Calendar";
                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        //new SqlParameter("@sEndingBalanceDate", sEndingBalanceDate)
                                                       },
                                    this.TableName);
            }
            return dataSet;
        }

        #endregion Get data

        #region Update Data
        public DataSet SaveToDB(DataSet dataSet)
        {
            DataSet updateSet = dataSet.Copy();             
            DataTable dtName = updateSet.Tables[this.TableName];
            DateTime dtDataTime;
            DataRow dr;

            using (System.Transactions.TransactionScope scope = new TransactionScope())
            {
                using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                {
                    connect.Open();
                    dtDataTime = DataHelper.ExecuteServerDateTime(connect);
                     if (dtName.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtName.Rows.Count; i++)
                        {
                            dr = dtName.Rows[i];
                            if (dr.RowState != DataRowState.Deleted)
                            {
                                if (dr["UpdatedBy"] == DBNull.Value)
                                {
                                    dr["CreatedBy"] = _userID;
                                    dr["CreatedTime"] = dtDataTime;
                                    dr["UpdatedBy"] = _userID;
                                    dr["UpdatedTime"] = dtDataTime;

                                }
                                if (dr.RowState == DataRowState.Modified)
                                {
                                    dr["UpdatedBy"] = _userID;
                                    dr["UpdatedTime"] = dtDataTime;
                                }                              
                            }
                        }
                    }
                    //new PP_TOU_Elec_Calendar(connect).UpdateRecord(dtName);                    
                }
                scope.Complete();
            }

            return updateSet;
        }
        #endregion Update Data

        #region property
        public string TableName
        {
            get { return this._tableName; }
        }
        public string TableNamePPElecArc
        {
            get { return this._tableNamePPElecArc; }
        }
        public string TableNamePPElecArcReport
        {
            get { return this._tableNamePPElecArcReport; }
        }
        public string TableNamePPElecArcGrandTotalReport
        {
            get { return this._tableNamePPElecArcGrandTotalReport; }
        }
        #endregion property
    }
}
