using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace ATD.Management
{
    public class SqlTransactionImportFilesManager
    {
        string _connStr = "";
        string _userID = "";
        string _lastError = "";
        public SqlTransactionImportFilesManager(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        public DataTable GetATD_ImportFiles()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT  '' as NORun
                                          ,Mchn
                                          ,EnNo
                                          ,Name
                                          ,Mode
                                          ,IOMd
                                          ,Datetime
                                          ,Created_by
                                          ,Created_Time
                                      FROM ATD_Machine_Import where NO = 0";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Machine_Import");

            }
            return dataSet.Tables[0];
        }
        public DataTable GetATD_ImportFilesALL()
        {
            DataSet dataSet = null;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string sqlText = @"SELECT  NO
                                          ,Mchn
                                          ,EnNo
                                          ,Name
                                          ,Mode
                                          ,IOMd
                                          ,(SELECT CONVERT(VARCHAR(10), Datetime, 103) + ' '  + convert(VARCHAR(5), Datetime, 14)) as Datetime
                                          ,Created_by
                                          ,Created_Time
                                      FROM ATD_Machine_Import";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                    null,
                                                    "ATD_Machine_Import");

            }
            return dataSet.Tables[0];
        }
        public int SaveTransactiontoDB(DataTable dt, string Tcode)
        {
            this.LastError = "";
            StringBuilder sb = new StringBuilder();

            foreach (DataRow drr in dt.Rows)
            {
                if (drr.RowState == DataRowState.Added)
                {
                    drr["Created_by"] = this._userID;
                   
                }
                
            }

            try
            {
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();

                        new ATD.Data.DataAdopterTransaction.ATD_ImportFiles_TRN(connect).UpdateRecord(dt);


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

        #region properties

        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion

    }
    public class SqlTransactionImportFilesViewsManager
    {
        string _connStr = "";
        string _userID = "";
        string _lastError = "";
        public SqlTransactionImportFilesViewsManager(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
        }
        public DataTable GetATD_ImportFilesViews(string EMP_ID, string TeamCode, string WRK_NAME, string OTDay, string Remarks, string Status, string TimeFrom, string TimeTo, string SHITF ,string Type) 
        {
            DataSet dataSet = null;
            string strWhere = "";
            string strWhereRemark = "";
            string strWhereShift = "";
            string strWhereStatus = "";
            string strWhereOT = "";
            string strWhereType = "";
            string CheckAND = "";
            string strV = "";
            string strForWhere = "";
            string Order_By = "";
          
            # region Where only
            if (EMP_ID != "")
            {
                strWhere += " and (EMP_ID = @EMP_ID)";
               
            }
            if (WRK_NAME != "")
            {
                strWhere += "  and (LEFT(UPPER(DATENAME (WEEKDAY,[WrkDay])) ,3) = @WRK_NAME)";
             
            }
            if (TeamCode != "")
            {
                strWhere += " and (ATD_Employee.TeamCode = @TeamCode)";

            }
            if (TimeFrom != "" && TimeTo != "")
            {
                strWhere += " and (ShiftWrkDay between  @TimeFrom  ";
                 strWhere += " and  @TimeTo)";
            }
           
                

            
            if (TimeFrom != "" && TimeTo == "")
            {
                strWhere += " and (ShiftWrkDay =  @TimeFrom ) ";

            }
            if (TimeTo != "" && TimeFrom == "")
            {
                strWhere += " and (ShiftWrkDay =  @TimeTo)";

            }

           
           
           
            #endregion

            #region Status
            if (Status != "")
            {
                if (Status == "H")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += "\t";
                    strWhereStatus += "v.WrkCode = 'H'";
                }
                if (Status == "ขาดงาน")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += "  v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.WrkCode != 'H'and EMP_Register_Status ='1' and v.EMP_Resigned_Flag  != '1'";
                }
                if (Status == "สาย")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += @"   convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL  
                                    and v.WrkCode != 'H'
                                    and  convert(varchar, v.TimeTo- v.TimeOut_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H' ";
                }
                if (Status == "ออกก่อน")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += @" convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)
                                        and v.TimeOut_ IS NOT NULL 
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.WrkCode != 'H'
                                        and convert(varchar, v.TimeFrom- v.TimeIn_, 108) < convert(varchar,v.TimeFrom, 108)
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'";
                }
                if (Status == "ปกติ")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += @" convert(varchar, v.TimeFrom- v.TimeIn_, 108) <= convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and convert(varchar, v.TimeTo- v.TimeOut_, 108) >= convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H'  
                                    and v.TimeOut_ IS NOT NULL";
                }
                if (Status == "สาย,ออกก่อน")
                {
                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereStatus += strForWhere;
                    strWhereStatus += @" convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL  
                                    and v.WrkCode != 'H'
                                    and convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H'";
                }
//                if (Status == "ควบกะ")
//                {
//                    if (Status != "" && strWhere == "" && OTDay == "" && Remarks == "" && Type == "" && SHITF == "")
//                    {
//                        strForWhere += "where";
//                    }
//                    strWhereStatus += strForWhere;
//                    strWhereStatus += @" convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) >= convert(VARCHAR(8),@thetimeOT, 108) 
//                                        and v.TimeIn_ IS NOT NULL 
//                                        and v.TimeOut_ > v.TimeTo";
                 
//                }
                if (Status == "ยังไม่ลงทะเบียน")
                {
                    strWhere += "and EMP_Register_Status ='0'";
                }
              
            }
            else
            {
                strWhereStatus += "";
            }
#endregion

            #region Remarks
            if (Remarks != "" )
            {
                if (Remarks == "ไม่มีเวลาเข้า")
                {
                    if (Remarks != "" && strWhere == "" && OTDay == "" && Status == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereRemark += strForWhere;
                    strWhereRemark += " (v.TimeIn_ IS NULL and v.TimeOut_ IS NOT NULL)";
                }
                if (Remarks == "ไม่มีเวลาออก")
                {
                    if (Remarks != "" && strWhere == "" && OTDay == "" && Status == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereRemark += strForWhere;
                    strWhereRemark += " (v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NULL)";
                }
                if (Remarks == "ไม่มีเวลาเข้า,ไม่มีเวลาออก")
                {
                    if (Remarks != "" && strWhere == "" && OTDay == "" && Status == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereRemark += strForWhere;
                    strWhereRemark += "  (v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.EMP_Register_Status  != '0'and v.EMP_Register_Status  IS NOT NULL and v.EMP_Resigned_Flag !='1' and v.WrkCode != 'H')";
                }
                if (Remarks == "ลาออก")
                {
                    if (Remarks != "" && strWhere == "" && OTDay == "" && Status == "" &&Type == ""&&SHITF=="")
                    {
                        strForWhere += "where";
                    }
                    strWhereRemark += strForWhere;
                    strWhereRemark += " (v.EMP_Resigned_Flag  = '1')";
                }
                if (Remarks == "-")
                {
                    if (Remarks != "" && strWhere == "" && OTDay == "" && Status == "" && Type == "" && SHITF == "")
                    {
                        strForWhere += "where";
                    }
                    strWhereRemark += strForWhere;
                    strWhereRemark += " (v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL)";
                }
                else
                {
                    strWhereRemark += "";
                }

            }
            #endregion

            #region OT
            if (OTDay != "")
            {
                if (Remarks == "" && strWhere == "" && OTDay != "" && Status == "" &&Type ==""&&SHITF =="")
                {
                    strForWhere += "where";
                }
                strWhereOT += strForWhere;
                strWhereOT += @" convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) >= convert(VARCHAR(8),@thetime, 108) and v.TimeIn_ IS NOT NULL and v.TimeOut_ > v.TimeTo and convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) <= convert(VARCHAR(8),@thetimeOT, 108) 
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.TimeOut_ > v.TimeTo";
            }
          
            #endregion
            
            #region Type
            if (Type != "")
            {
                if (Remarks == "" && strWhere == "" && OTDay == "" && Status == "" && @Type != "" && SHITF == "")
                {
                    strForWhere += "where";                   
                    strWhereType += strForWhere;
                    strWhereType += @" where v.TeamDesc BETWEEN	@Type";
                }
                else
                {
                    strWhereType += "v.TeamDesc BETWEEN";
                    strWhereType += @Type;
                }
            }
            #endregion
    
            #region SHIFT
            if (SHITF != "")
            {
                if (Remarks == "" && strWhere == "" && OTDay == "" && Status == "" && @Type == "")
                {
                    strWhereShift += "where ";
                }
                    strWhereShift += "v.Day_or_Night  =";
                    strWhereShift += "'";
                    strWhereShift += @SHITF;
                    strWhereShift += "'";
                // and (ShiftWrkDay IN '(O,M,D)' 
                // and (ShiftWrkDay IN '(N)' 
            }
            #endregion

            Order_By = " ORDER BY WrkDay asc,EMP_ID asc";

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlText = @"DECLARE @thetime time = '01:00:00'
                                   DECLARE @thetimeOT time = '12:00:00'
                                select *
	                          , (case when v.EMP_Resigned_Flag  = '1'THEN 'ลาออก'
                                      when v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.EMP_Register_Status  != '0'and v.EMP_Register_Status  IS NOT NULL and v.EMP_Resigned_Flag !='1' and v.WrkCode != 'H'  THEN 'ไม่มีเวลาเข้า,ไม่มีเวลาออก'
	                                  when v.TimeIn_ IS NULL and v.TimeOut_ IS NOT NULL THEN 'ไม่มีเวลาเข้า'
	                                  when v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NULL THEN 'ไม่มีเวลาออก'
			                         else '' end) as Remarks 
		                         ,  convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) as CheckOT
		                        -- , (case when convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) >= convert(VARCHAR(8),@thetime, 108) and v.TimeIn_ IS NOT NULL and v.TimeOut_ > v.TimeTo and convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) <= convert(VARCHAR(8),@thetimeOT, 108) 
                                        --and v.TimeIn_ IS NOT NULL 
                                        --and v.TimeOut_ > v.TimeTo THEN 'โอที'
			                         --else '' end) as OTDay 
		                        , (case when v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.WrkCode != 'H' and v.EMP_Resigned_Flag  != '1' THEN 'ขาดงาน'
	                               when convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'and  convert(varchar, v.TimeTo- v.TimeOut_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'  THEN 'สาย'
			                        when convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'and convert(varchar, v.TimeFrom- v.TimeIn_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'  THEN 'ออกก่อน'
									when convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'and convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H' THEN 'สาย,ออกก่อน'
		                            when convert(varchar, v.TimeFrom- v.TimeIn_, 108) <= convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and convert(varchar, v.TimeTo- v.TimeOut_, 108) >= convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'  and v.TimeOut_ IS NOT NULL and v.WrkCode != 'H' THEN 'ปกติ'
			                         when v.WrkCode = 'H' then 'วันหยุด'
                                        else '-' end) as Status
                                        , (case when v.TeamDesc  = 'Kumku' THEN 'พนักงานค้ำคูน'
										when v.TeamDesc  = 'Nurse 1' THEN 'เจ้าหน้าที่พยาบาล'
										when v.TeamDesc  = 'Nurse 2' THEN 'เจ้าหน้าที่พยาบาล'
										when v.TeamDesc  = 'Trinee' THEN 'นักศึกษาฝึกงาน'
										when v.TeamDesc  = 'Cleaner A' THEN 'เเม่บ้าน'
										when v.TeamDesc  = 'Cleaner B' THEN 'เเม่บ้าน'
										when v.TeamDesc  = 'Cleaner C' THEN 'เเม่บ้าน'
										 else 'EROR' end) as EMP_Type_Desc    
	
                            from

	                            (
	                            SELECT CASE  LEFT(UPPER(DATENAME (WEEKDAY,[WrkDay])) ,3) 
			                            WHEN 'MON' Then 'วันจันทร์'
			                            WHEN 'TUE' Then 'วันอังคาร'
			                            WHEN 'WED' Then 'วันพุธ'
			                            WHEN 'THU' Then 'วันพฤหัสบดี'
			                            WHEN 'FRI' Then 'วันศุกร์'
			                            WHEN 'SAT' Then 'วันเสาร์'
			                            WHEN 'SUN' Then 'วันอาทิตย์'
			                            ELSE 'ERROR' END AS WRK_NAME
			                            ,PPINCTWorkCalShift.ShiftWrkDay
	                             , EMP_ID
	                            ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
	                            --,isnull(ATD_Employee_Title.EMP_Title_Desc,'ERROR') as Title
	                            ,ATD_Employee.EMP_FName
	                            ,ATD_Employee.EMP_LName
	                            --,(SELECT ISNULL(WrkDescThai,'ERROR') FROM PPINCTTimeWork WHERE PPINCTTimeWork.WrkCode = PPINCTWorkCal.WrkCode) AS Day_or_Night
	                            ,ISNULL(PPINCTTimeWork.WrkDescThai,'ERROR') as Day_or_Night
	                            ,ATD_Employee.EMP_Register_Status    
	                            ,ATD_Employee.TeamCode
                               												
	                            ,PPINCTTeam.TeamDesc
	                            ,PPINCTWorkCal.WrkDay
	                            ,PPINCTWorkCal.WrkCode
                                ,ATD_Employee.EMP_Resigned_Flag
	                            ,(CASE WHEN PPINCTWorkCal.WrkCode = 'H' THEN PPINCTTimeWork.WrkDescThai
											                            ELSE Convert(varchar(5),PPINCTTimeWork.StartTime,108)+'-'+Convert(varchar(5),PPINCTTimeWork.EndTime,108) 
											                            END) as WorkTIME
	
	                            ,PPINCTWorkCalShift.TimeFrom
	                            ,PPINCTWorkCalShift.TimeTo
	                            ,PPINCTWorkCalShift.TotalMin
	                            , (SELECT Top 1 ATD_Machine_Import.Datetime
												   FROM ATD_Machine_Import
												  WHERE EnNo = ATD_Employee.EMP_ID
												    and IOMd BETWEEN 0 and 2 and IOMd != 1
												    and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
													and EMP_Resigned_Flag  != '1'
													 
												  ORDER BY EnNo asc , Datetime)  as TimeIn_
                                
								,(SELECT Top 1 NO as itemNo
		                    FROM ATD_Machine_Import
	                        WHERE EnNo = ATD_Employee.EMP_ID
		                        and IOMd = 0 
		                        and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
		                    ORDER BY EnNo asc , Datetime ) as ItemNo
	,Case when PPINCTWorkCal.WrkCode = 'N' then ISNULL((SELECT Top 1 ATD_Machine_Import.Datetime
														  FROM ATD_Machine_Import
														 WHERE EnNo = ATD_Employee.EMP_ID
														   and IOMd = 1
														   and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
														   and ATD_Machine_Import.NO > (SELECT Top 1  NO
																						  FROM ATD_Machine_Import
																						 WHERE EnNo = ATD_Employee.EMP_ID
																						   and IOMd = 0
																						   and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
																						 ORDER BY EnNo asc , Datetime))
														,(SELECT Top 1 ATD_Machine_Import.Datetime
															FROM ATD_Machine_Import
														   WHERE EnNo = ATD_Employee.EMP_ID
															 and IOMd = 1
															 and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),DATEADD(DD,1,PPINCTWorkCalShift.ShiftWrkDay),112)
														   ORDER BY EnNo asc , Datetime ))
											else 
												(SELECT Top 1 ATD_Machine_Import.Datetime
												   FROM ATD_Machine_Import
												  WHERE EnNo = ATD_Employee.EMP_ID
												    and IOMd = 1
												    and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
													and EMP_Resigned_Flag  != '1'
												  ORDER BY EnNo asc , Datetime)   
												        end as TimeOut_


	                                                    ,0 as TotalMinActual
	                                                    ,'' as TotalHours
		
                                FROM  PPINCTWorkCal 
                                LEFT OUTER JOIN  PPINCTWorkCalShift ON PPINCTWorkCal.WrkCalKey  = PPINCTWorkCalShift.WrkCalKey
                                LEFT OUTER JOIN  ATD_Employee ON   ATD_Employee.TeamCode  = PPINCTWorkCal.TeamCode 
                                INNER JOIN  PPINCTTeam  ON   ATD_Employee.TeamCode  = PPINCTTeam.TeamCode       
                                LEFT OUTER JOIN PPINCTTimeWork ON PPINCTWorkCal.WrkCode = PPINCTTimeWork.WrkCode
      
                                WHERE  1 = 1";
                   


                #region Filter Where
                if (strWhere != "" && strWhereRemark == "" && strWhereStatus == "" && strWhereOT == "" && strWhereShift == "" && Type == "")
                {
                    sqlText += strWhere;
                }
                #endregion
                
                #region Filter Shift
                if (strWhereRemark == "" && strWhere == "" && strWhereOT == "" && strWhereStatus == "" && strWhereShift != "" &&@Type =="")
                {
                    
                    if (strWhereShift != "")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereShift;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                }
#endregion

                #region Filter Remark
                if (strWhereRemark != "" && strWhere == "" && strWhereOT == "" && strWhereStatus == "" && strWhereShift == "" && Type == "")
                {
                    //'ไม่มีเวลาเข้า'
                    if (strWhereRemark == "where (v.TimeIn_ IS NULL and v.TimeOut_ IS NOT NULL)")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereRemark;
                        if (strWhereStatus=="")
                        {
                            strV = " ) v";
                        }
                    }
                    //'ไม่มีเวลาออก'
                    if (strWhereRemark == "where (v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NULL)")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereRemark;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //ไม่มีเวลาเข้า,ไม่มีเวลาออก
                    if (strWhereRemark == "where  (v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.EMP_Register_Status  != '0'and v.EMP_Register_Status  IS NOT NULL and v.EMP_Resigned_Flag !='1' and v.WrkCode != 'H')")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereRemark;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                    // -
                    if (strWhereRemark == "where (v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL)")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereRemark;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //ลาออก
                    if (strWhereRemark == "where (v.EMP_Resigned_Flag  = '1')")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereRemark;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                }
                #endregion

                #region Filter Status
                if (strWhereStatus != "" && strWhere == "" && strWhereOT == "" && strWhereRemark == "" && strWhereShift == "" && Type== "")
                {//'วันหยุด'
                    if (Status == "H")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //'สาย'
                    if (strWhereStatus == @"where   convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL  
                                    and v.WrkCode != 'H'
                                    and  convert(varchar, v.TimeTo- v.TimeOut_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H' ")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }
                    // ขาดงาน
                    if (strWhereStatus == "where  v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.WrkCode != 'H'and EMP_Register_Status ='1' and v.EMP_Resigned_Flag  != '1'")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }

                    //"ออกก่อน"
                    if (strWhereStatus == @"where convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)
                                        and v.TimeOut_ IS NOT NULL 
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.WrkCode != 'H'
                                        and convert(varchar, v.TimeFrom- v.TimeIn_, 108) < convert(varchar,v.TimeFrom, 108)
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //ปกติ
                    if (strWhereStatus == @"where convert(varchar, v.TimeFrom- v.TimeIn_, 108) <= convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and convert(varchar, v.TimeTo- v.TimeOut_, 108) >= convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H'  
                                    and v.TimeOut_ IS NOT NULL")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //สาย,ออกก่อน
                    if (strWhereStatus == @"where convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.TimeOut_ IS NOT NULL  
                                    and v.WrkCode != 'H'
                                    and convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)
                                    and v.TimeOut_ IS NOT NULL 
                                    and v.TimeIn_ IS NOT NULL 
                                    and v.WrkCode != 'H'")
                    {
                        sqlText += " ) v ";
                        sqlText += strWhereStatus;
                        if (strWhereRemark == "")
                        {
                            strV = " ) v";
                        }
                    }
                    //ควบกะ
//                    if (strWhereStatus == @"where convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) >= convert(VARCHAR(8),@thetimeOT, 108) 
//                                        and v.TimeIn_ IS NOT NULL 
//                                        and v.TimeOut_ > v.TimeTo")
//                    {
//                        sqlText += " ) v ";
//                        sqlText += strWhereStatus;
//                        if (strWhereRemark == "")
//                        {
//                            strV = " ) v";
//                        }
//                    }

                }
                #endregion

                #region Filter Type
                if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift == "")
                {
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                   
                    
                    if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion
               
                #region Filter OT
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && strWhereShift == ""&& Type =="")
                 {
                     sqlText += " ) v ";
                     //sqlText += strWhereOT;
                     sqlText += "";
                     if (strWhereRemark == "" && strWhereStatus == "")
                     {
                         strV = " ) v";
                     }
                 }
                #endregion

                #region Filter Remark + OT
                if (strWhere == "" && strWhereRemark != "" && strWhereStatus == "" && strWhereOT != "" && strWhereShift == "")
                {
                    sqlText += " ) v ";
                    sqlText += "\t";
                    sqlText += " where ";
                    sqlText += strWhereRemark;
                    strV += " ) v";
                    CheckAND += "and";
                    sqlText += CheckAND;
                    sqlText += "\t";
                    sqlText += strWhereOT;

                }
                #endregion

                #region Filter Remark + Status 
                if (strWhere == "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT == "" && strWhereShift == "")
                {
                    sqlText += " ) v ";
                    sqlText += "where";
                    sqlText += "\t";
                    sqlText += strWhereRemark;
                    strV += " ) v";
                    CheckAND += "and";
                    sqlText += CheckAND;
                    sqlText += "\t";
                    strWhereStatus += "";
                    sqlText += strWhereStatus;
             
                }
                #endregion

                #region  Filter Shift + Remark
                if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion
             
                #region Filter Remark + Status + OT
                if (strWhere == "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift == "")
                {
                    sqlText += " )v";
                    sqlText += "\t";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereStatus;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereOT;
                    strV = " ) v";

                }
                #endregion

                #region  Filter Shift + Remark + Type
                if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                        
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + Remark + Status
                if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        

                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    
                }
                #endregion

                #region  Filter Shift + Remark + OT
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;


                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                   
                }
                #endregion

                #region  Filter Shift + Remark + OT + Type
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }


                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }



                }
                #endregion

                #region  Filter Shift  + OT + Type
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";
                       
                    }


                    if (strWhereShift != "")
                    {
                       
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }


                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }



                }
                #endregion

                #region  Filter Shift  + OT + Status
                if (strWhereOT != "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where";
                        sqlText += "\t";

                    }


                    if (strWhereShift != "")
                    {

                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereStatus;
                       


                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }



                }
                #endregion

                #region Filter Remark + Status + OT + Shifft
                if (strWhere == "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift != "" && strWhereType == "")
                {
                    sqlText += " )v";
                    sqlText += "\t";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereStatus;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereOT;
                    strV = " ) v";
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;

                }
                #endregion

                #region Filter Remark + Status + OT + Shifft + Type
                if (strWhere == "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift != "" &&strWhereType !="")
                {
                    sqlText += " )v";
                    sqlText += "\t";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereStatus;
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereOT;
                    strV = " ) v";
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += " and";
                    sqlText += "\t";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                    }
                    else
                    {
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                   

                }
                #endregion
              
                #region Filter Status + OT
                if (strWhere == "" && strWhereRemark == "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift == "")
                {
                    sqlText += " ) v ";
                    sqlText += "\t";
                    sqlText += " where ";
                    sqlText += strWhereStatus;
                    strV += " ) v";
                    sqlText += "\t";
                    CheckAND += "and";
                    sqlText += CheckAND;
                    sqlText += "\t";
                    strWhereStatus += "";
                    sqlText += strWhereOT;

                }
                #endregion

                #region  Filter Where + Remark
                if (strWhere != "" && strWhereRemark != "" && strWhereStatus == "" && strWhereOT == "" && strWhereShift == "" && Type =="")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    strV = " ) v";
                }
                #endregion

                #region Filter Where + Status
                if (strWhere != "" && strWhereRemark == "" && strWhereStatus != "" && strWhereOT == "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereStatus;
                    strV += " ) v";                              
                }
                #endregion

                #region Filter Where + OT
                if (strWhere != "" && strWhereRemark == "" && strWhereStatus == "" && strWhereOT != "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereOT;
                    strV += " ) v";
                }
                #endregion
                 
                #region  Filter Where + Remark + Status + OT
                if (strWhere != "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }

                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += strWhereStatus;
                    sqlText += " and";
                    sqlText += strWhereOT;

                    strV = " ) v";
                }
                #endregion

                #region  Filter Where + Remark + Status
                if (strWhere != "" && strWhereRemark != "" && strWhereStatus != "" && strWhereOT == "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += strWhereStatus;
                    strV = " ) v";

                }
                #endregion

                #region  Filter Where + Remark + OT
                if (strWhere != "" && strWhereRemark != "" && strWhereStatus == "" && strWhereOT != "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereRemark;
                    sqlText += " and";
                    sqlText += strWhereOT;
                    strV = " ) v";

                }
                #endregion

                #region  Filter Where + Status + OT
                if (strWhere != "" && strWhereRemark == "" && strWhereStatus != "" && strWhereOT != "" && strWhereShift == "" && Type == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += ")v";
                    sqlText += " where";
                    sqlText += strWhereStatus;
                    sqlText += " and";
                    sqlText += strWhereOT;
                    strV = " ) v";

                }
                #endregion
               
                #region  Filter Where + Type 
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                 
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                   
                  
                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + Remark
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && strWhereRemark != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                   

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + Shift
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;

                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + Shift + Status
                if (strWhereOT == "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += "\t";
                    sqlText += "and ";
                    sqlText += "\t";
                    sqlText += strWhereStatus;
                     strV = " ) v";
                    
                }
                #endregion

                #region  Filter Where + Type + Shift + Status + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += "\t";
                    sqlText += "and ";
                    sqlText += "\t";
                    sqlText += strWhereStatus;
                    sqlText += "\t";
                    sqlText += "and ";
                    sqlText += "\t";
                    sqlText += strWhereOT;
                    strV = " ) v";

                }
                #endregion             

                #region  Filter Where + Type + Shift + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += "\t";
             
                    sqlText += strWhereStatus;
                    sqlText += "\t";
                    sqlText += " and";
                    sqlText += strWhereOT;

                    if ( strWhere != "" )
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + Shift + Remark
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += "\t";

                    sqlText += strWhereStatus;
                    sqlText += "\t";
                    sqlText += " and";
                    sqlText += strWhereRemark;

                    if (strWhere != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion
               
                #region  Filter Where + Type + Shift + Remark + Status
                if (strWhereOT == "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }

                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";

                    }
                    else
                    {
                        sqlText += "where v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += " and";
                    sqlText += "\t";
                    sqlText += strWhereShift;
                    sqlText += "\t";
                    sqlText += " and";
                    sqlText += strWhereStatus;
                    sqlText += "\t";
                    sqlText += " and";
                    sqlText += strWhereRemark;
                    sqlText += "and ";
                    sqlText += "\t";
                    sqlText += strWhereStatus;

                    if (strWhere != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + Status
                if (strWhereOT == "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && SHITF == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'"; 
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                    }
                    else
                    {
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;             
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                    }


                   
                        strV = " ) v";
                    
                }
                #endregion

                #region  Filter Where + Shift
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }
                   

                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Shift + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Shift + Remark
                if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }


                    if ( strWhere != "" )
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Shift + Status
                if (strWhereOT == "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        if (strWhere != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Shift + Status + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        if (strWhere != "")
                        {
                            strV = " ) v";
                        }
                    }


                   
                }
                #endregion

                #region  Filter Where + Shift + Status + Remark
                if (strWhereOT == "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        if (strWhere != "")
                        {
                            strV = " ) v";
                        }
                    }


                    
                }
                #endregion

                #region  Filter Where + Shift + Status + Remark + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        if (strWhere != "")
                        {
                            strV = " ) v";
                        }
                    }



                }
                #endregion

                #region  Filter Where + Shift + Remark + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (strWhereShift != "")
                    {
                        sqlText += "where ";
                        sqlText += strWhereShift;
                        sqlText += "and";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereOT;
                        if (strWhereStatus == "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhere != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + OT
                if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && SHITF == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";

                    sqlText += "\t";
                    sqlText += "where ";

                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                    }
                    else
                    {
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                    }
                    sqlText += "and ";
                    sqlText += "\t";
                    sqlText += strWhereOT;

                    if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + OT + Status
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && SHITF == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                    }
                    else
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                    }


                 
                    
                        strV = " ) v";
                    
                }
                #endregion

                #region  Filter Where + Type + OT + Status + Remark
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }
                    else
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }


                    if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + OT + Status + Remark +Shift
                if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                        sqlText += " ) v ";
                    }
                    else
                    {
                        sqlText += strWhere;
                        sqlText += " ) v ";
                    }
                    //sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereShift;
                    }
                    else
                    {
                        sqlText += "where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereShift;
                    }


                    if (strWhereOT != "" && strWhere != "" && strWhereStatus != "" && strWhereRemark != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Where + Type + OT  + Remark
                if (strWhereOT != "" && strWhere != "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" && SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += strWhere;
                    }
                    else
                    {
                        sqlText += strWhere;
                    }
                    sqlText += " ) v ";
                    if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                    {
                        sqlText += "Where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc =";
                        sqlText += "\t";
                        sqlText += "'";
                        sqlText += @Type;
                        sqlText += "'";
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }
                    else
                    {
                        sqlText += "Where ";
                        sqlText += "\t";
                        sqlText += "v.TeamDesc BETWEEN ";
                        sqlText += "\t";
                        sqlText += @Type;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereRemark;
                    }
                    strV = " ) v";

                }
                #endregion

                #region  Filter Shift + Status
                if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";

                        sqlText += "\t";
                        sqlText += "where";
                        sqlText += "\t";
                        sqlText += strWhereStatus;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + OT
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && Type == "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        sqlText += " where ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + Type
                if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                   
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + Type + Status
                if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + Type + Status + Remark
                if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark != "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += strWhereStatus;
                        sqlText += "\t";

                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += strWhereRemark;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereRemark != "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Shift + Type + Status + OT
                if (strWhereOT != "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && strWhereShift != "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "")
                    {
                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                        sqlText += "\t";
                        sqlText += "and";
                        sqlText += strWhereStatus;
                        sqlText += "\t";
                    }


                    if (strWhereShift != "")
                    {
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += strWhereShift;
                        sqlText += "\t";
                        sqlText += "and ";
                        sqlText += "\t";
                        sqlText += strWhereOT;
                        if (strWhereShift != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region  Filter Type + OT
                if (strWhereOT != "" && strWhere == "" && strWhereStatus == "" && strWhereRemark == "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "" || Type != "")
                    {
                        sqlText += " ) v ";

                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                            if (@Type != "'Nurse 1' and 'Nurse 2'")
                            {
                                sqlText += "where v.TeamDesc =";
                                sqlText += "\t";
                                sqlText += "'";
                                sqlText += @Type;
                                sqlText += "'";
                               
                            }
                            else
                            {
                                sqlText += "where v.TeamDesc BETWEEN ";
                                sqlText += "\t";
                                sqlText += @Type;
                            }
                    }


                    if (strWhereOT != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereOT;
                        if (strWhereOT != "")
                        {
                            strV = " ) v";
                        }
                    }


                   
                }
                #endregion

                #region  Filter Type + Status
                if (strWhereOT == "" && strWhere == "" && strWhereStatus != "" && strWhereRemark == "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "" || Type != "")
                    {
                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                            sqlText += "\t";
                            sqlText += "and ";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                            sqlText += "\t";
                            sqlText += "and ";
                        }
                    }


                    if (strWhereStatus != "")
                    {
                       
                        sqlText += strWhereStatus;
                        if (strWhereStatus != "")
                        {
                            strV = " ) v";
                        }
                    }



                }
                #endregion

                #region  Filter Type + Remark
                if (strWhereOT == "" && strWhere == "" && strWhereStatus == "" && strWhereRemark != "" && Type != "" && strWhereShift == "")
                {
                    if (EMP_ID != "" || TeamCode != "" || WRK_NAME != "" || SHITF != "" || TimeFrom != "" || TimeTo != "" || Type != "")
                    {

                        sqlText += " ) v ";
                        if (@Type != "'Nurse 1' and 'Nurse 2'" && @Type != "'Cleaner A' and 'Cleaner C'")
                        {
                            sqlText += "where v.TeamDesc =";
                            sqlText += "\t";
                            sqlText += "'";
                            sqlText += @Type;
                            sqlText += "'";
                        }
                        else
                        {
                            sqlText += "where v.TeamDesc BETWEEN ";
                            sqlText += "\t";
                            sqlText += @Type;
                        }
                    }


                    if (strWhereRemark != "")
                    {
                        sqlText += "and ";
                        sqlText += strWhereRemark;
                        if (strWhereRemark != "")
                        {
                            strV = " ) v";
                        }
                    }


                    if (strWhereOT == "" && strWhere != "" && strWhereStatus == "" && strWhereRemark == "")
                    {
                        strV = " ) v";
                    }
                }
                #endregion

                #region Check Where only or Not
                if (strV == "")
                 {
                     sqlText += " ) v ";
                 }
                #endregion
                
                sqlText += Order_By;                                                                                                                                                                     
                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                     new SqlParameter[]
                                                   {
                                                        new SqlParameter("@EMP_ID",EMP_ID),
                                                        new SqlParameter("@TeamCode",TeamCode),
                                                        new SqlParameter("@WRK_NAME",WRK_NAME),
                                                        new SqlParameter("@OTDay",OTDay),
                                                        new SqlParameter("@SHITF",SHITF),
                                                        new SqlParameter("@Remarks",Remarks),
                                                        new SqlParameter("@Status",Status),
                                                        new SqlParameter("@TimeFrom",TimeFrom),
                                                        new SqlParameter("@TimeTo",TimeTo),
                                                        new SqlParameter("@EMP_Type_Desc",Type),
                                                    },
                                                    "ATD_ImportFilesViews");

               
            }
            return dataSet.Tables[0];
        }
        
        public DataTable GetATD_WorkDateTimeList()
        {
            DataSet dataSet;
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlText = @"DECLARE @thetime time = '01:00:00'
                                   DECLARE @thetimeOT time = '12:00:00'
                                select *
	                          , (case when v.EMP_Resigned_Flag  = '1'THEN 'ลาออก'
                                      when v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.EMP_Register_Status  != '0'and v.EMP_Register_Status  IS NOT NULL and v.EMP_Resigned_Flag !='1' and v.WrkCode != 'H'  THEN 'ไม่มีเวลาเข้า,ไม่มีเวลาออก'
	                                  when v.TimeIn_ IS NULL and v.TimeOut_ IS NOT NULL THEN 'ไม่มีเวลาเข้า'
	                                  when v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NULL THEN 'ไม่มีเวลาออก'
			                         else '' end) as Remarks 
		                         ,  convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) as CheckOT
		                         , (case when convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) >= convert(VARCHAR(8),@thetime, 108) and v.TimeIn_ IS NOT NULL and v.TimeOut_ > v.TimeTo and convert(VARCHAR(8), v.TimeOut_- v.TimeTo, 108) <= convert(VARCHAR(8),@thetimeOT, 108) 
                                        and v.TimeIn_ IS NOT NULL 
                                        and v.TimeOut_ > v.TimeTo THEN 'โอที'
			                         else '' end) as OTDay 
		                        , (case when v.TimeIn_ IS NULL and v.TimeOut_ IS NULL and v.WrkCode != 'H' and v.EMP_Resigned_Flag  != '1' THEN 'ขาดงาน'
	                               when convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'and  convert(varchar, v.TimeTo- v.TimeOut_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'  THEN 'สาย'
			                        when convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'and convert(varchar, v.TimeFrom- v.TimeIn_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'  THEN 'ออกก่อน'
									when convert(varchar, v.TimeFrom- v.TimeIn_, 108) > convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL  and v.WrkCode != 'H'and convert(varchar, v.TimeTo- v.TimeOut_, 108) < convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H' THEN 'สาย,ออกก่อน'
		                            when convert(varchar, v.TimeFrom- v.TimeIn_, 108) <= convert(varchar,v.TimeFrom, 108)and v.TimeIn_ IS NOT NULL and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and convert(varchar, v.TimeTo- v.TimeOut_, 108) >= convert(varchar,v.TimeFrom, 108)and v.TimeOut_ IS NOT NULL and v.TimeIn_ IS NOT NULL and v.WrkCode != 'H'  and v.TimeOut_ IS NOT NULL and v.WrkCode != 'H' THEN 'ปกติ'
			                         when v.WrkCode = 'H' then 'วันหยุด'
                                        else '-' end) as Status
                                        , (case when v.TeamDesc  = 'Kumku' THEN 'พนักงานค้ำคูน'
										when v.TeamDesc  = 'Nurse 1' THEN 'เจ้าหน้าที่พยาบาล'
										when v.TeamDesc  = 'Nurse 2' THEN 'เจ้าหน้าที่พยาบาล'
										when v.TeamDesc  = 'Trinee' THEN 'นักศึกษาฝึกงาน'
										when v.TeamDesc  = 'Cleaner A' THEN 'เเม่บ้าน'
										when v.TeamDesc  = 'Cleaner B' THEN 'เเม่บ้าน'
										when v.TeamDesc  = 'Cleaner C' THEN 'เเม่บ้าน'
										 else 'EROR' end) as EMP_Type_Desc    
	
                            from

	                            (
	                            SELECT CASE  LEFT(UPPER(DATENAME (WEEKDAY,[WrkDay])) ,3) 
			                            WHEN 'MON' Then 'วันจันทร์'
			                            WHEN 'TUE' Then 'วันอังคาร'
			                            WHEN 'WED' Then 'วันพุธ'
			                            WHEN 'THU' Then 'วันพฤหัสบดี'
			                            WHEN 'FRI' Then 'วันศุกร์'
			                            WHEN 'SAT' Then 'วันเสาร์'
			                            WHEN 'SUN' Then 'วันอาทิตย์'
			                            ELSE 'ERROR' END AS WRK_NAME
			                            ,PPINCTWorkCalShift.ShiftWrkDay
	                             , EMP_ID
	                            ,(select isnull(EMP_Title_Desc,'ERROR') from ATD_Employee_Title where ATD_Employee_Title.EMP_Title_ID = ATD_Employee.EMP_Title_ID) AS Title
	                            --,isnull(ATD_Employee_Title.EMP_Title_Desc,'ERROR') as Title
	                            ,ATD_Employee.EMP_FName
	                            ,ATD_Employee.EMP_LName
	                            --,(SELECT ISNULL(WrkDescThai,'ERROR') FROM PPINCTTimeWork WHERE PPINCTTimeWork.WrkCode = PPINCTWorkCal.WrkCode) AS Day_or_Night
	                            ,ISNULL(PPINCTTimeWork.WrkDescThai,'ERROR') as Day_or_Night
	                            ,ATD_Employee.EMP_Register_Status    
	                            ,ATD_Employee.TeamCode
                               												
	                            ,PPINCTTeam.TeamDesc
	                            ,PPINCTWorkCal.WrkDay
	                            ,PPINCTWorkCal.WrkCode
                                ,ATD_Employee.EMP_Resigned_Flag
	                            ,(CASE WHEN PPINCTWorkCal.WrkCode = 'H' THEN PPINCTTimeWork.WrkDescThai
											                            ELSE Convert(varchar(5),PPINCTTimeWork.StartTime,108)+'-'+Convert(varchar(5),PPINCTTimeWork.EndTime,108) 
											                            END) as WorkTIME
	
	                            ,PPINCTWorkCalShift.TimeFrom
	                            ,PPINCTWorkCalShift.TimeTo
	                            ,PPINCTWorkCalShift.TotalMin
	                            , (SELECT Top 1 ATD_Machine_Import.Datetime
												   FROM ATD_Machine_Import
												  WHERE EnNo = ATD_Employee.EMP_ID
												    and IOMd BETWEEN 0 and 2 and IOMd != 1
												    and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
													and EMP_Resigned_Flag  != '1'
													 
												  ORDER BY EnNo asc , Datetime)  as TimeIn_
                                
								,(SELECT Top 1 NO as itemNo
		                    FROM ATD_Machine_Import
	                        WHERE EnNo = ATD_Employee.EMP_ID
		                        and IOMd = 0 
		                        and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
		                    ORDER BY EnNo asc , Datetime ) as ItemNo
	,Case when PPINCTWorkCal.WrkCode = 'N' then ISNULL((SELECT Top 1 ATD_Machine_Import.Datetime
														  FROM ATD_Machine_Import
														 WHERE EnNo = ATD_Employee.EMP_ID
														   and IOMd = 1
														   and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
														   and ATD_Machine_Import.NO > (SELECT Top 1  NO
																						  FROM ATD_Machine_Import
																						 WHERE EnNo = ATD_Employee.EMP_ID
																						   and IOMd = 0
																						   and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
																						 ORDER BY EnNo asc , Datetime))
														,(SELECT Top 1 ATD_Machine_Import.Datetime
															FROM ATD_Machine_Import
														   WHERE EnNo = ATD_Employee.EMP_ID
															 and IOMd = 1
															 and Convert(varchar(8),Datetime,112) =  Convert(varchar(8),DATEADD(DD,1,PPINCTWorkCalShift.ShiftWrkDay),112)
														   ORDER BY EnNo asc , Datetime ))
											else 
												(SELECT Top 1 ATD_Machine_Import.Datetime
												   FROM ATD_Machine_Import
												  WHERE EnNo = ATD_Employee.EMP_ID
												    and IOMd = 1
												    and Convert(varchar(8),Datetime,112) = Convert(varchar(8),PPINCTWorkCalShift.ShiftWrkDay,112)
													and EMP_Resigned_Flag  != '1'
												  ORDER BY EnNo asc , Datetime)   
												        end as TimeOut_


	                                                    ,0 as TotalMinActual
	                                                    ,'' as TotalHours
		
                                FROM  PPINCTWorkCal 
                                LEFT OUTER JOIN  PPINCTWorkCalShift ON PPINCTWorkCal.WrkCalKey  = PPINCTWorkCalShift.WrkCalKey
                                LEFT OUTER JOIN  ATD_Employee ON   ATD_Employee.TeamCode  = PPINCTWorkCal.TeamCode 
                                INNER JOIN  PPINCTTeam  ON   ATD_Employee.TeamCode  = PPINCTTeam.TeamCode       
                                LEFT OUTER JOIN PPINCTTimeWork ON PPINCTWorkCal.WrkCode = PPINCTTimeWork.WrkCode
      
                                WHERE  1 = 1)V";
                   

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,                                                    
                                                    CommandType.Text,
                                                    null,
                                                    "PPINCTTimeWork");


            }
            return dataSet.Tables[0];
        }


        public DataTable GetATD_DateTimeList()
        {
            DataSet dataSet;
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                string sqlText = @"SELECT WrkCode
                                          ,WrkDesc
                                          ,WrkDescThai
                                          ,StartHour
                                          ,StartMinute
                                          ,EndHour
                                          ,EndMinute
                                          ,StartTime
                                          ,EndTime
                                          ,Activated
                                      FROM PPINCTTimeWork
                                      WHERE ISNULL(Activated,0) = 1";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                                    sqlText,
                                                    CommandType.Text,
                                                     new SqlParameter[]
                                                   {
                                                    },
                                                    "PPINCTTimeWork");


            }
            return dataSet.Tables[0];
        }
        


        #region properties

        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; }
        }
        #endregion

        
    }
}
                                                                                                                                                                                                                                                                                                                                                                                           