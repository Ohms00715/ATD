using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using ATD.Data;
namespace ATD.Management
{
    public class SqlWorkCalendarManager
    {
        #region Variable

        private string _connStr;
        private string _userID;    
        public string TablePPINCTTeam = "PPINCTTeam";
        public string TablePPINCTTimeWork = "PPINCTTimeWork";
        public string TablePPINCTWorkYear = "PPINCTWorkYear";
        public string TablePPINCTWorkDate = "PPINCTWorkDate";
        public string TablePPINCTWorkCal  = "PPINCTWorkCal";
        public string TablePPINCTWorkCalShift = "PPINCTWorkCalShift";
        public string TablePPINCTWorkCalMonth = "PPINCTWorkCalMonth";
        public string TablePPINCTWorkCalTable = "PPINCTWorkCalTable";        
        private string _lastError = "";
        #endregion Variable

        public SqlWorkCalendarManager(string connStr, string userID)
        {
            this._connStr = connStr;
            this._userID = userID;
            
        }

        #region Get data
        
        public void CalculateShift(DataRow xdr)
        {
            //1. 00-07
            //2. 07-19
            //3. 19-00

            // switch (ldtBeg.Hour)
            //    {
            //        case (0 - 6): //00.00 -06.59
            //            switch (ldtEnd.Hour)
            //            {
            //                #region Cal 
            //                case (0 - 6): //0.00 - 6.59
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    dr["ShiftFrom"] = ldr["TimeFrom"];
            //                    dr["ShiftTo"] = ldr["TimeTo"];
            //                    ldtShiftFr = (DateTime)dr["ShiftFrom"];
            //                    ldtShiftTo = (DateTime)dr["ShiftTo"];
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    break;
            //                case (7 - 18): // 7.00 - 18.59
            //                    // < 7.00 
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    ldtShiftFr = (DateTime)ldr["TimeFrom"];
            //                    iYY = ldtShiftFr.Year;
            //                    iMM = ldtShiftFr.Month;
            //                    iDD = ldtShiftFr.Day;
            //                    ldtShiftTo = new DateTime(iYY, iMM, iDD, 7, 0, 0);
            //                    ldtShiftTo = ldtShiftTo.AddSeconds(1);
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    // 7 - 18.59
            //                    ldtShiftFr = ldtShiftTo;
            //                    ldtShiftTo = (DateTime)ldr["TimeTo"];
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    break;
            //                default: // > 19 => 19.00 - 24.000

            //                    // < 7.00 
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    ldtShiftFr = (DateTime)ldr["TimeFrom"];
            //                    iYY = ldtShiftFr.Year;
            //                    iMM = ldtShiftFr.Month;
            //                    iDD = ldtShiftFr.Day;
            //                    ldtShiftTo = new DateTime(iYY, iMM, iDD, 7, 0, 0);
            //                    ldtShiftTo = ldtShiftTo.AddSeconds(1);
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);

            //                    // 7 - 18.59

            //                    ldtShiftFr = ldtShiftTo;
            //                    iYY = ldtShiftFr.Year;
            //                    iMM = ldtShiftFr.Month;
            //                    iDD = ldtShiftFr.Day;
            //                    ldtShiftTo = new DateTime(iYY, iMM, iDD, 19, 0, 0);
            //                    ldtShiftTo = ldtShiftTo.AddSeconds(1);
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    // > 19.01

            //                    ldtShiftFr = ldtShiftTo;
            //                    ldtShiftTo = (DateTime)ldr["TimeTo"];
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    break;
            //                #endregion 
            //            }
            //            break;
            //        case (7 - 18): //07-18
            //            switch (ldtEnd.Hour)
            //            {
            //                #region Cal
            //                case (0 - 6):
            //                    break;
            //                case (7 - 18): // 7.00 - 18.59                                
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    ldtShiftFr = (DateTime)ldr["TimeFrom"];
            //                    ldtShiftTo = (DateTime)ldr["TimeTo"];                                
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);                               
            //                    break;
            //                default: // > 19 => 19.00 - 24.000
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    ldtShiftFr = (DateTime)ldr["TimeFrom"];
            //                    iYY = ldtShiftFr.Year;
            //                    iMM = ldtShiftFr.Month;
            //                    iDD = ldtShiftFr.Day;
            //                    ldtShiftTo = new DateTime(iYY, iMM, iDD, 18,59,59);
            //                    ldtShiftTo = ldtShiftTo.AddSeconds(1);                                                               
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    // 7 - 18.59
            //                    ldtShiftFr = ldtShiftTo;
            //                    ldtShiftTo = (DateTime)ldr["TimeTo"];
            //                    dr = dtShift.NewRow();
            //                    dr["EventLogKey"] = ldr["EventLogKey"];
            //                    dr["Wrkday"] = ldr["Wrkday"];
            //                    dr["TimeFrom"] = ldr["TimeFrom"];
            //                    dr["TimeTo"] = ldr["TimeTo"];
            //                    dr["ShiftFrom"] = ldtShiftFr;
            //                    dr["ShiftTo"] = ldtShiftTo;
            //                    ts = ldtShiftTo - ldtShiftFr;
            //                    dr["TotalMin"] = ts.TotalMinutes;
            //                    dtShift.Rows.Add(dr);
            //                    break;

            //                #endregion 
            //            }
            //            break;
            //        default: // > 19
            //            #region Cal 
            //            dr = dtShift.NewRow();
            //            dr["EventLogKey"] = ldr["EventLogKey"];
            //            dr["Wrkday"] = ldr["Wrkday"];
            //            dr["TimeFrom"] = ldr["TimeFrom"];
            //            dr["TimeTo"] = ldr["TimeTo"];
            //            ldtShiftFr = (DateTime)ldr["TimeFrom"];
            //            ldtShiftTo = (DateTime)ldr["TimeTo"];                                
            //            dr["ShiftFrom"] = ldtShiftFr;
            //            dr["ShiftTo"] = ldtShiftTo;
            //            ts = ldtShiftTo - ldtShiftFr;
            //            dr["TotalMin"] = ts.TotalMinutes;
            //            dtShift.Rows.Add(dr);   
            //            #endregion 
            //            break;
            //    }
            //} 
            //#endregion 
        }

        public DataSet GetElectricalList(DateTime begDate, DateTime endDate)
        {
            DataSet dataSet = null;
//            string sqlText = "";
//            string sbegDate = string.Format("{0}{1}{2}", begDate.Year.ToString("0000"), begDate.Month.ToString("00"),begDate.Day.ToString("00"));
//            string sendDate = string.Format("{0}{1}{2}", endDate.Year.ToString("0000"), endDate.Month.ToString("00"), endDate.Day.ToString("00"));

//            using (SqlConnection connection = new SqlConnection(_connStr))
//            {
//                connection.Open();
//                sqlText = @"SELECT  V_PPEventLogWrkDays.*
//                            FROM  V_PPEventLogWrkDays  
//                            WHERE  Convert(varchar(8), V_PPEventLogWrkDays.WrkDate ,112)  BETWEEN  @BegDate And  @EndDate 
//                            ORDER BY V_PPEventLogWrkDays.WrkDate  , V_PPEventLogWrkDays.TimeFrom ";
//                dataSet = DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                    new SqlParameter[] { 
//                                                        new SqlParameter("@BegDate", sbegDate),
//                                                        new SqlParameter("@EndDate", sendDate) ,
//                                                       },
                    
//                this.TableV_PPEventLogWrkDays);

//                sqlText = @"SELECT PPEventLogDetail.*
//                            FROM PPEventLogDetail 
//                            WHERE  PPEventLogDetail.EventLogDKey  = 0 
//                                     ";
//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                    new SqlParameter[] { 
//                                                        new SqlParameter("@BegDate", ""),
//                                                        new SqlParameter("@EndDate", "") ,
//                                                       },

//                this.TablePPEventLogDetail));

//                sqlText = @"SELECT PPEventLogShift.*
//                            FROM PPEventLogShift 
//                            WHERE  PPEventLogShift.EventLogDShiftKey  = 0 
//                                     ";
//                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                    new SqlParameter[] { 
//                                                        new SqlParameter("@BegDate", ""),
//                                                        new SqlParameter("@EndDate", "") ,
//                                                       },

//                this.TablePPEventLogShift));

//            }

//            //dataSet.Tables[this.TablePPEventLogDetail].Columns["EventLogDetailKey"].AutoIncrement = true;
//            //dataSet.Tables[this.TablePPEventLogDetail].Columns["EventLogDetailKey"].AutoIncrementSeed = 1;
//            #region Gen detail work day
//            #region Generate detail
//            DataRow dr;
//            int ChkDiffDay,iYY,iMM,iDD , iLoop;
//            DateTime ldtBeg, ldtEnd ,ldtWrk;
           
//            foreach (DataRow ldr in dataSet.Tables[this.TableV_PPEventLogWrkDays].Rows)
//            {
//                ChkDiffDay = (int)ldr["ChkDiffDay"];
//                if (ChkDiffDay == 0)
//                {
//                    dr = dataSet.Tables[this.TablePPEventLogDetail].NewRow();
//                    dr["EventLogKey"] = ldr["EventLogKey"];
//                    dr["Wrkday"] = ldr["WrkDate"];
//                    dr["TimeFrom"] = ldr["TimeFrom"];
//                    dr["TimeTo"] = ldr["TimeTo"];
//                    dataSet.Tables[this.TablePPEventLogDetail].Rows.Add(dr);
//                }
//                else
//                {
//                    if (ChkDiffDay > 0)
//                    {
//                        iLoop = ChkDiffDay + 1;
//                        for (int i = 0; i < iLoop; i++)
//                        {
//                            ldtBeg = (DateTime)ldr["TimeFrom"];
//                            ldtEnd = (DateTime)ldr["TimeTo"];
//                            ldtWrk = (DateTime)ldr["WrkDate"];                        
//                            if (i == 0)
//                            {
//                                dr = dataSet.Tables[this.TablePPEventLogDetail].NewRow();
//                                dr["EventLogKey"] = ldr["EventLogKey"];
//                                dr["Wrkday"] = ldr["WrkDate"];
//                                dr["TimeFrom"] = ldr["TimeFrom"];
//                                ldtBeg = (DateTime)dr["TimeFrom"];
//                                iYY = ldtBeg.Year;
//                                iMM = ldtBeg.Month;
//                                iDD = ldtBeg.Day;
//                                ldtEnd = new DateTime(iYY, iMM, iDD, 23, 59, 59);
//                                ldtEnd = ldtEnd.AddSeconds(1);
//                                dr["TimeTo"] = ldtEnd;

//                                ldtBeg = (DateTime)dr["TimeFrom"];
//                                ldtEnd = (DateTime)dr["TimeTo"];
//                                ldtWrk = (DateTime)dr["Wrkday"];
//                                dataSet.Tables[this.TablePPEventLogDetail].Rows.Add(dr);


//                            }
//                            else
//                            {
//                                if (i == ChkDiffDay)
//                                {
//                                    dr = dataSet.Tables[this.TablePPEventLogDetail].NewRow();
//                                    dr["EventLogKey"] = ldr["EventLogKey"];
//                                    dr["TimeTo"] = ldr["TimeTo"];
//                                    ldtEnd = (DateTime)ldr["TimeTo"];
//                                    iYY = ldtEnd.Year;
//                                    iMM = ldtEnd.Month;
//                                    iDD = ldtEnd.Day;
//                                    ldtWrk = new DateTime(iYY, iMM, iDD);
//                                    ldtBeg = new DateTime(iYY, iMM, iDD, 0, 0, 0);
//                                    dr["Wrkday"] = ldtWrk;
//                                    dr["TimeFrom"] = ldtBeg;
                                  
//                                    dataSet.Tables[this.TablePPEventLogDetail].Rows.Add(dr);
//                                }
//                                else
//                                {
//                                    ldtWrk = ldtWrk.AddDays(1);
//                                    iYY = ldtWrk.Year;
//                                    iMM = ldtWrk.Month;
//                                    iDD = ldtWrk.Day;

//                                    dr = dataSet.Tables[this.TablePPEventLogDetail].NewRow();
//                                    dr["EventLogKey"] = ldr["EventLogKey"];
//                                    dr["Wrkday"] = ldtWrk;
//                                    ldtBeg = new DateTime(iYY, iMM, iDD, 0, 0, 0);
//                                    dr["TimeFrom"] = ldtBeg;                                   
//                                    ldtEnd = new DateTime(iYY, iMM, iDD, 23, 59, 59);
//                                    ldtEnd = ldtEnd.AddSeconds(1);
//                                    dr["TimeTo"] = ldtEnd;
//                                    dataSet.Tables[this.TablePPEventLogDetail].Rows.Add(dr);
//                                }
//                            }
//                        }
//                    }
//                }            

//            }
//            #endregion 
//            #region Calculate mintue
//            TimeSpan ts ;
//            //int totMin ;
//            //bool lbConv ;
//            foreach (DataRow ldr in dataSet.Tables[this.TablePPEventLogDetail].Rows)
//            {
//                ldtBeg = (DateTime)ldr["TimeFrom"];
//                ldtEnd = (DateTime)ldr["TimeTo"];                
//                ts = ldtEnd - ldtBeg;
//                ldr["TotalMin"] = ts.TotalMinutes;
//            }
//            #endregion 
//            #endregion 

//            #region Gen deteil work day for shift
           

//            DateTime ldtShiftFr, ldtShiftTo;

//            //1. 00-07
//            //2. 07-19
//            //3. 19-00
//            DataTable dtShift = dataSet.Tables[this.TablePPEventLogShift] ;

//            foreach (DataRow ldr in dataSet.Tables[this.TablePPEventLogDetail].Rows)
//            {
//                ldtBeg = (DateTime)ldr["TimeFrom"];
//                ldtEnd = (DateTime)ldr["TimeTo"];
//                if (ldtEnd.Day > ldtBeg.Day)
//                {
//                    ldtEnd = ldtEnd.AddSeconds(-1);
//                }

//                #region  Time begin  00.00 -06.59
//                if (ldtBeg.Hour >= 0 && ldtBeg.Hour < 7)
//                {
//                    if (ldtEnd.Hour >= 0 && ldtEnd.Hour < 7)
//                    {
//                        dr = dtShift.NewRow();
//                        dr["EventLogKey"] = ldr["EventLogKey"];
//                        dr["Wrkday"] = ldr["Wrkday"];
//                        dr["TimeFrom"] = ldr["TimeFrom"];
//                        dr["TimeTo"] = ldr["TimeTo"];
//                        dr["ShiftFrom"] = ldr["TimeFrom"];
//                        dr["ShiftTo"] = ldr["TimeTo"];
//                        ldtShiftFr = (DateTime)dr["ShiftFrom"];
//                        ldtShiftTo = (DateTime)dr["ShiftTo"];
//                        ts = ldtShiftTo - ldtShiftFr;
//                        dr["TotalMin"] = ts.TotalMinutes;
//                        dtShift.Rows.Add(dr);
//                    }
//                    else
//                    {
//                        if (ldtEnd.Hour >= 7 && ldtEnd.Hour < 19)
//                        {
//                            // < 7.00 
//                            dr = dtShift.NewRow();
//                            dr["EventLogKey"] = ldr["EventLogKey"];
//                            dr["Wrkday"] = ldr["Wrkday"];
//                            dr["TimeFrom"] = ldr["TimeFrom"];
//                            dr["TimeTo"] = ldr["TimeTo"];
//                            ldtShiftFr = (DateTime)ldr["TimeFrom"];
//                            iYY = ldtShiftFr.Year;
//                            iMM = ldtShiftFr.Month;
//                            iDD = ldtShiftFr.Day;
//                            ldtShiftTo = new DateTime(iYY, iMM, iDD, 6, 59, 59);
//                            ldtShiftTo = ldtShiftTo.AddSeconds(1);
//                            dr["ShiftFrom"] = ldtShiftFr;
//                            dr["ShiftTo"] = ldtShiftTo;
//                            ts = ldtShiftTo - ldtShiftFr;
//                            dr["TotalMin"] = ts.TotalMinutes;
//                            dtShift.Rows.Add(dr);

//                            // 7 - 18.59
//                            ldtShiftFr = ldtShiftTo;
//                            ldtShiftTo = (DateTime)ldr["TimeTo"];
//                            dr = dtShift.NewRow();
//                            dr["EventLogKey"] = ldr["EventLogKey"];
//                            dr["Wrkday"] = ldr["Wrkday"];
//                            dr["TimeFrom"] = ldr["TimeFrom"];
//                            dr["TimeTo"] = ldr["TimeTo"];
//                            dr["ShiftFrom"] = ldtShiftFr;
//                            dr["ShiftTo"] = ldtShiftTo;
//                            ts = ldtShiftTo - ldtShiftFr;
//                            dr["TotalMin"] = ts.TotalMinutes;
//                            dtShift.Rows.Add(dr);
//                        }
//                        else
//                        {

//                            // < 7.00 
//                            dr = dtShift.NewRow();
//                            dr["EventLogKey"] = ldr["EventLogKey"];
//                            dr["Wrkday"] = ldr["Wrkday"];
//                            dr["TimeFrom"] = ldr["TimeFrom"];
//                            dr["TimeTo"] = ldr["TimeTo"];
//                            ldtShiftFr = (DateTime)ldr["TimeFrom"];
//                            iYY = ldtShiftFr.Year;
//                            iMM = ldtShiftFr.Month;
//                            iDD = ldtShiftFr.Day;
//                            ldtShiftTo = new DateTime(iYY, iMM, iDD, 6, 59, 59);
//                            ldtShiftTo = ldtShiftTo.AddSeconds(1);
//                            dr["ShiftFrom"] = ldtShiftFr;
//                            dr["ShiftTo"] = ldtShiftTo;
//                            ts = ldtShiftTo - ldtShiftFr;
//                            dr["TotalMin"] = ts.TotalMinutes;
//                            dtShift.Rows.Add(dr);

//                            // 7 - 18.59

//                            ldtShiftFr = ldtShiftTo;
//                            iYY = ldtShiftFr.Year;
//                            iMM = ldtShiftFr.Month;
//                            iDD = ldtShiftFr.Day;
//                            ldtShiftTo = new DateTime(iYY, iMM, iDD, 18, 59, 59);
//                            ldtShiftTo = ldtShiftTo.AddSeconds(1);
//                            dr = dtShift.NewRow();
//                            dr["EventLogKey"] = ldr["EventLogKey"];
//                            dr["Wrkday"] = ldr["Wrkday"];
//                            dr["TimeFrom"] = ldr["TimeFrom"];
//                            dr["TimeTo"] = ldr["TimeTo"];
//                            dr["ShiftFrom"] = ldtShiftFr;
//                            dr["ShiftTo"] = ldtShiftTo;
//                            ts = ldtShiftTo - ldtShiftFr;
//                            dr["TotalMin"] = ts.TotalMinutes;
//                            dtShift.Rows.Add(dr);

//                            // > 19.01

//                            ldtShiftFr = ldtShiftTo;
//                            ldtShiftTo = (DateTime)ldr["TimeTo"];
//                            dr = dtShift.NewRow();
//                            dr["EventLogKey"] = ldr["EventLogKey"];
//                            dr["Wrkday"] = ldr["Wrkday"];
//                            dr["TimeFrom"] = ldr["TimeFrom"];
//                            dr["TimeTo"] = ldr["TimeTo"];
//                            dr["ShiftFrom"] = ldtShiftFr;
//                            dr["ShiftTo"] = ldtShiftTo;
//                            ts = ldtShiftTo - ldtShiftFr;
//                            dr["TotalMin"] = ts.TotalMinutes;
//                            dtShift.Rows.Add(dr);
//                        }
//                    }
//                }

//                #endregion

//                #region  Time Begin 7- 18.59

//                if (ldtBeg.Hour >= 7 && ldtBeg.Hour < 19)
//                {
//                    if (ldtEnd.Hour < 19)
//                    {
//                        // 7 - 18.59
//                        ldtShiftFr = (DateTime)ldr["TimeFrom"];
//                        ldtShiftTo = (DateTime)ldr["TimeTo"];
//                        dr = dtShift.NewRow();
//                        dr["EventLogKey"] = ldr["EventLogKey"];
//                        dr["Wrkday"] = ldr["Wrkday"];
//                        dr["TimeFrom"] = ldr["TimeFrom"];
//                        dr["TimeTo"] = ldr["TimeTo"];
//                        dr["ShiftFrom"] = ldtShiftFr;
//                        dr["ShiftTo"] = ldtShiftTo;
//                        ts = ldtShiftTo - ldtShiftFr;
//                        dr["TotalMin"] = ts.TotalMinutes;
//                        dtShift.Rows.Add(dr);
//                    }
//                    else
//                    {
//                        // 7 - 18.59
//                        ldtShiftFr = (DateTime)ldr["TimeFrom"];
//                        iYY = ldtShiftFr.Year;
//                        iMM = ldtShiftFr.Month;
//                        iDD = ldtShiftFr.Day;
//                        ldtShiftTo = new DateTime(iYY, iMM, iDD, 18, 59, 59);
//                        ldtShiftTo = ldtShiftTo.AddSeconds(1);
//                        dr = dtShift.NewRow();
//                        dr["EventLogKey"] = ldr["EventLogKey"];
//                        dr["Wrkday"] = ldr["Wrkday"];
//                        dr["TimeFrom"] = ldr["TimeFrom"];
//                        dr["TimeTo"] = ldr["TimeTo"];
//                        dr["ShiftFrom"] = ldtShiftFr;
//                        dr["ShiftTo"] = ldtShiftTo;
//                        ts = ldtShiftTo - ldtShiftFr;
//                        dr["TotalMin"] = ts.TotalMinutes;
//                        dtShift.Rows.Add(dr);

//                        // > 19.00

//                        ldtShiftFr = ldtShiftTo;
//                        ldtShiftTo = (DateTime)ldr["TimeTo"];
//                        dr = dtShift.NewRow();
//                        dr["EventLogKey"] = ldr["EventLogKey"];
//                        dr["Wrkday"] = ldr["Wrkday"];
//                        dr["TimeFrom"] = ldr["TimeFrom"];
//                        dr["TimeTo"] = ldr["TimeTo"];
//                        dr["ShiftFrom"] = ldtShiftFr;
//                        dr["ShiftTo"] = ldtShiftTo;
//                        ts = ldtShiftTo - ldtShiftFr;
//                        dr["TotalMin"] = ts.TotalMinutes;
//                        dtShift.Rows.Add(dr);
//                    }
//                }


//                #endregion  Time begin 7-19

//                #region  Time begin >= 19

//                if (ldtBeg.Hour >= 19)
//                {
//                    dr = dtShift.NewRow();
//                    dr["EventLogKey"] = ldr["EventLogKey"];
//                    dr["Wrkday"] = ldr["Wrkday"];
//                    dr["TimeFrom"] = ldr["TimeFrom"];
//                    dr["TimeTo"] = ldr["TimeTo"];
//                    ldtShiftFr = (DateTime)ldr["TimeFrom"];
//                    ldtShiftTo = (DateTime)ldr["TimeTo"];
//                    dr["ShiftFrom"] = ldtShiftFr;
//                    dr["ShiftTo"] = ldtShiftTo;
//                    ts = ldtShiftTo - ldtShiftFr;
//                    dr["TotalMin"] = ts.TotalMinutes;
//                    dtShift.Rows.Add(dr);
//                }
//                #endregion  Time begin >= 19
//            }

          
//            #endregion
//            //DataRelation _reGenLogDetail = new DataRelation(this._relationPPEventLogDetail,
//            //    dataSet.Tables[this.TableV_PPEventLogWrkDays].Columns["EventLogKey"], dataSet.Tables[this.TablePPEventLogDetail].Columns["EventLogKey"]);
//            //dataSet.Relations.Add(_reGenLogDetail) ;
                                   
            return dataSet;//.Tables[this.TableV_PPEventLogWrkDays];
        }

        public DataSet GetRecordListTeamAndTime()
        {
            DataSet dataSet = null;          
            string sqlText = "";
        
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"select  PPINCTTeam.*
                            FROM PPINCTTeam 
                            Order By  1 ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@Code", "")
                                                       },
                                    this.TablePPINCTTeam);


                sqlText = @"select  PPINCTTimeWork.*
                            FROM PPINCTTimeWork 
                            Order By  1 ";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@Code", "")
                                                       },
                                    this.TablePPINCTTimeWork));

            }



            return dataSet;
        }
        public DataSet GetRecordListCalendar(string byYear)
        {
            DataSet dataSet = null;
            string sqlText = "";

            #region get data
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"select  PPINCTWorkYear.*
                            FROM    PPINCTWorkYear
                            WHERE  PPINCTWorkYear.WrkYearKey  =@byYear ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@byYear", byYear)
                                                       },
                                    this.TablePPINCTWorkYear);


                sqlText = @"select PPINCTWorkDate.*
                            FROM   PPINCTWorkDate 
                            WHERE  PPINCTWorkDate.WrkYearKey  =@byYear ";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@byYear", byYear)
                                                       },
                                    this.TablePPINCTWorkDate));                                    
                                    
                sqlText = @"select PPINCTTeam.*      
                          FROM    PPINCTTeam                    
                          WHERE   ISNULL(Activated ,0) = 1
                           AND    ISNULL(ShiftFlag ,0) = 1";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        new SqlParameter("@byYear", "")
                                                        },
                                    this.TablePPINCTTeam) )    ;



                sqlText = @"select PPINCTTimeWork.*      
                          FROM    PPINCTTimeWork                    
                          WHERE   ISNULL(Activated ,0) = 1
                           AND    ISNULL(ShiftFlag ,0) = 1";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        new SqlParameter("@byYear", "")
                                                        },
                                    this.TablePPINCTTimeWork));


                sqlText = @"SELECT  TeamCode
                            , TeamDesc
                            , CONVERT(char(1),null) AS  DAY_01
	                        , CONVERT(char(1),null) AS  DAY_02
	                        , CONVERT(char(1),null) AS  DAY_03
	                        , CONVERT(char(1),null) AS  DAY_04
	                        , CONVERT(char(1),null) AS  DAY_05
	                        , CONVERT(char(1),null) AS  DAY_06
	                        , CONVERT(char(1),null) AS  DAY_07
	                        , CONVERT(char(1),null) AS  DAY_08
	                        , CONVERT(char(1),null) AS  DAY_09
	                        , CONVERT(char(1),null) AS  DAY_10
	                        , CONVERT(char(1),null) AS  DAY_11
	                        , CONVERT(char(1),null) AS  DAY_12
	                        , CONVERT(char(1),null) AS  DAY_13
	                        , CONVERT(char(1),null) AS  DAY_14
	                        , CONVERT(char(1),null) AS  DAY_15
	                        , CONVERT(char(1),null) AS  DAY_16
	                        , CONVERT(char(1),null) AS  DAY_17
	                        , CONVERT(char(1),null) AS  DAY_18
	                        , CONVERT(char(1),null) AS  DAY_19
	                        , CONVERT(char(1),null) AS  DAY_20
	                        , CONVERT(char(1),null) AS  DAY_21
	                        , CONVERT(char(1),null) AS  DAY_22
	                        , CONVERT(char(1),null) AS  DAY_23
	                        , CONVERT(char(1),null) AS  DAY_24
	                        , CONVERT(char(1),null) AS  DAY_25
	                        , CONVERT(char(1),null) AS  DAY_26
	                        , CONVERT(char(1),null) AS  DAY_27
	                        , CONVERT(char(1),null) AS  DAY_28
	                        , CONVERT(char(1),null) AS  DAY_29
	                        , CONVERT(char(1),null) AS  DAY_30
	                        , CONVERT(char(1),null) AS  DAY_31
	  
                        FROM  PPINCTTeam
                        WHERE   ISNULL(Activated ,0) = 1
                        AND      ISNULL(ShiftFlag ,0) = 1";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                        new SqlParameter("@Code", "")
                                                        },
                                    this.TablePPINCTWorkCalTable));



                sqlText = @"select DISTINCT PPINCTWorkDate.WrkYearKey  AS COL_YYYY
                            ,MONTH(WrkDay) AS COL_MM
                            ,'' AS  COL_MMNAME
                            FROM   PPINCTWorkDate 
                            WHERE  PPINCTWorkDate.WrkYearKey  =@byYear ";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@byYear", byYear)
                                                       },
                                    this.TablePPINCTWorkCalMonth));

            }
            

            #endregion 

            #region Gen Table calendar
             
            int COL_YYYY = 0 ,  COL_MM ;            
            DateTime dtDate;           
            DataTable dtCalendar  =  dataSet.Tables[this.TablePPINCTWorkCalMonth] ;

            foreach (DataRow ldr in dtCalendar.Rows)
            {
                COL_YYYY = (int)ldr["COL_YYYY"];
                COL_MM = (int)ldr["COL_MM"];
                dtDate = new DateTime(COL_YYYY, COL_MM, 1);
                ldr["COL_MMNAME"] = dtDate.ToString("MMMM");
            }
            #endregion 
            //dataSet.Merge(dtCalendar);

            return dataSet;
        }
        public DataSet GetRecordListWorkingDateAndYear(string byYear)
        {
            DataSet dataSet = null;
            string sqlText = "";

            #region get data
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();
                sqlText = @"select  PPINCTWorkYear.*
                            FROM    PPINCTWorkYear
                            WHERE  PPINCTWorkYear.WrkYearKey  =@byYear ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@byYear", byYear)
                                                       },
                                    this.TablePPINCTWorkYear);


                sqlText = @"select PPINCTWorkDate.*
                                   ,MONTH(PPINCTWorkDate.WrkDay)  As CMM
                                   ,DAY(PPINCTWorkDate.WrkDay)  As CDD
                            FROM   PPINCTWorkDate 
                            WHERE  PPINCTWorkDate.WrkYearKey  =@byYear ";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@byYear", byYear)
                                                       },
                                    this.TablePPINCTWorkDate));            

            }


            #endregion           

            return dataSet;
        }
        public DataSet GetRecordListPPINCTWorkCalByYearMonth(string paYear, string paMM)
        {
            DataSet dataSet = null;
            string sqlText = "";

            #region get data
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                sqlText = @"SELECT PPINCTWorkCal.*                                  
                                  , YEAR(PPINCTWorkCal.WrkDay)  AS  CYYYY
                                  , Month(PPINCTWorkCal.WrkDay ) AS  CMM
                                  , Day(PPINCTWorkCal.WrkDay )   AS  CDD
                            FROM   PPINCTWorkCal 
                            WHERE     YEAR(PPINCTWorkCal.WrkDay)  =@byYear  
                                 AND Month(PPINCTWorkCal.WrkDay ) =@byMM  ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] 
                                    { 
                                        new SqlParameter("@byYear",paYear),
                                        new SqlParameter("@byMM",paMM),
                                    },
                                    this.TablePPINCTWorkCal);

//                sqlText = @"select PPINCTWorkCalShift.*                                  
//                                  , YEAR(PPINCTWorkCal.WrkDay)  AS  CYYYY
//                                  , Month(PPINCTWorkCal.WrkDay ) AS  CMM
//                                  , Day(PPINCTWorkCal.WrkDay )   AS  CDD
//                            FROM   PPINCTWorkCalShift INNER JOIN PPINCTWorkCal   ON 
//                                   PPINCTWorkCalShift.WrkCalKey  = PPINCTWorkCal.WrkCalKey
//                            WHERE     YEAR(PPINCTWorkCal.WrkDay)  =@byYear  
//                                 AND Month(PPINCTWorkCal.WrkDay ) =@byMM  ";

//                dataSet = DataHelper.ExecuteDataSet(connection,
//                                    sqlText,
//                                    CommandType.Text,
//                                    new SqlParameter[] 
//                                    { 
//                                        new SqlParameter("@byYear",paYear),
//                                        new SqlParameter("@byMM",paMM),
//                                    },
//                                    this.TablePPINCTWorkCalShift);

                sqlText = @"SELECT  TeamCode
                            , TeamDesc
                            , CONVERT(char(1),null) AS  DAY_01
	                        , CONVERT(char(1),null) AS  DAY_02
	                        , CONVERT(char(1),null) AS  DAY_03
	                        , CONVERT(char(1),null) AS  DAY_04
	                        , CONVERT(char(1),null) AS  DAY_05
	                        , CONVERT(char(1),null) AS  DAY_06
	                        , CONVERT(char(1),null) AS  DAY_07
	                        , CONVERT(char(1),null) AS  DAY_08
	                        , CONVERT(char(1),null) AS  DAY_09
	                        , CONVERT(char(1),null) AS  DAY_10
	                        , CONVERT(char(1),null) AS  DAY_11
	                        , CONVERT(char(1),null) AS  DAY_12
	                        , CONVERT(char(1),null) AS  DAY_13
	                        , CONVERT(char(1),null) AS  DAY_14
	                        , CONVERT(char(1),null) AS  DAY_15
	                        , CONVERT(char(1),null) AS  DAY_16
	                        , CONVERT(char(1),null) AS  DAY_17
	                        , CONVERT(char(1),null) AS  DAY_18
	                        , CONVERT(char(1),null) AS  DAY_19
	                        , CONVERT(char(1),null) AS  DAY_20
	                        , CONVERT(char(1),null) AS  DAY_21
	                        , CONVERT(char(1),null) AS  DAY_22
	                        , CONVERT(char(1),null) AS  DAY_23
	                        , CONVERT(char(1),null) AS  DAY_24
	                        , CONVERT(char(1),null) AS  DAY_25
	                        , CONVERT(char(1),null) AS  DAY_26
	                        , CONVERT(char(1),null) AS  DAY_27
	                        , CONVERT(char(1),null) AS  DAY_28
	                        , CONVERT(char(1),null) AS  DAY_29
	                        , CONVERT(char(1),null) AS  DAY_30
	                        , CONVERT(char(1),null) AS  DAY_31
	  
                        FROM  PPINCTTeam
                        WHERE   ISNULL(Activated ,0) = 1
                        AND      ISNULL(ShiftFlag ,0) = 1";

                dataSet.Merge(DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] 
                                    { 
                                        new SqlParameter("@Code", "")
                                    },
                                    this.TablePPINCTWorkCalTable));


                 
            }


            #endregion

            #region Gen Table calendar
            
            DataTable dtCalendar = dataSet.Tables[this.TablePPINCTWorkCalTable];
            DataTable dtWorkCal = dataSet.Tables[this.TablePPINCTWorkCal];
            string strSelect = "";
            DataRow[] arrCale;
            string col = "DAY_", colName = "", wrkCode = "";
            int intCDD;
            foreach (DataRow dr in dtCalendar.Rows)
            {
                strSelect = string.Format(" TeamCode  = '{0}'",  dr["TeamCode"].ToString());
                arrCale = dtWorkCal.Select(strSelect, " CDD ");
                foreach (DataRow ldr in arrCale)
                {
                    intCDD = (int)ldr["CDD"];
                    colName = string.Format("{0}{1}", col, intCDD.ToString("00"));
                    wrkCode = ldr["WrkCode"].ToString().ToUpper();
                    dr[colName] = wrkCode;
                }
            }

            #endregion
           

            return dataSet;
        }
        public DataSet GetRecordListPPINCTWorkCalShiftByYearMonth(string paYear, string paMM)
        {
            DataSet dataSet = null;
            string sqlText = "";

            #region get data
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                sqlText = @" SELECT  PPINCTWorkCal.WrkCalKey
                            ,PPINCTWorkCal.WrkDay
                            ,PPINCTWorkCal.TeamCode
                            ,PPINCTWorkCal.WrkCode
                            ,YEAR(PPINCTWorkCal.WrkDay) AS CYYYY
                            ,MONTH(PPINCTWorkCal.WrkDay) AS CMM
                            ,DAY(PPINCTWorkCal.WrkDay) AS CDD
                            ,PPINCTTimeWork.StartHour
                            ,PPINCTTimeWork.StartMinute
                            ,PPINCTTimeWork.EndHour
                            ,PPINCTTimeWork.EndMinute      
                            ,DATEDIFF(HH,PPINCTTimeWork.StartTime,PPINCTTimeWork.EndTime) AS DIFF_HR
                            ,DATEDIFF(DD,PPINCTTimeWork.StartTime,PPINCTTimeWork.EndTime) AS DIFF_DD		  
                            FROM  PPINCTWorkCal   INNER JOIN  PPINCTTimeWork  ON 
                            PPINCTWorkCal.WrkCode  = PPINCTTimeWork.WrkCode
                            WHERE YEAR(PPINCTWorkCal.WrkDay)  = @byYear
                            AND   MONTH(PPINCTWorkCal.WrkDay) = @byMM
                            AND   DATEDIFF(HH,PPINCTTimeWork.StartTime,PPINCTTimeWork.EndTime) > 0                        
                            ORDER  BY  PPINCTWorkCal.WrkDay,PPINCTWorkCal.TeamCode  ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] 
                                    { 
                                        new SqlParameter("@byYear",paYear),
                                        new SqlParameter("@byMM",paMM),
                                    },
                                    this.TablePPINCTWorkCal);

                sqlText = @"select PPINCTWorkCalShift.*                                  
                                  , YEAR(PPINCTWorkCal.WrkDay)  AS  CYYYY
                                  , Month(PPINCTWorkCal.WrkDay ) AS  CMM
                                  , Day(PPINCTWorkCal.WrkDay )   AS  CDD
                            FROM   PPINCTWorkCalShift INNER JOIN PPINCTWorkCal   ON 
                                   PPINCTWorkCalShift.WrkCalKey  = PPINCTWorkCal.WrkCalKey
                            WHERE     YEAR(PPINCTWorkCal.WrkDay)  =@byYear  
                                 AND Month(PPINCTWorkCal.WrkDay ) =@byMM  ";

                dataSet.Merge( DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] 
                                    { 
                                        new SqlParameter("@byYear",paYear),
                                        new SqlParameter("@byMM",paMM),
                                    },
                                    this.TablePPINCTWorkCalShift));        

            }


            #endregion

            #region Gen Table calendar

            //DataTable dtWorkCalShift = dataSet.Tables[this.TablePPINCTWorkCalShift];
            //DataTable dtWorkCalShiftCls = dtWorkCalShift.Copy();// dataSet.Tables[this.TablePPINCTWorkCalShift];
            //DataTable dtWorkCal      = dataSet.Tables[this.TablePPINCTWorkCal];
            //string strSelect = "";
            //DataRow[] arrCale;
            //string col = "DAY_", colName = "", wrkCode = "";
            //int intCDD;
            //foreach (DataRow dr in dtWorkCal.Rows)
            //{
            //    strSelect = string.Format(" TeamCode  = '{0}'", dr["TeamCode"].ToString());
            //    arrCale = dtWorkCal.Select(strSelect, " CDD ");
            //    foreach (DataRow ldr in arrCale)
            //    {
            //        intCDD = (int)ldr["CDD"];
            //        colName = string.Format("{0}{1}", col, intCDD.ToString("00"));
            //        wrkCode = ldr["WrkCode"].ToString().ToUpper();
            //        dr[colName] = wrkCode;
            //    }
            //}

            #endregion


            return dataSet;
        }
        public DataSet GetRecordLDailyByMonthYear(string paMonth , string paYear)
        {
            DataSet dataSet = null;
            string sqlText = "";

            #region get data
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();  
                sqlText = @"select PPINCTWorkDate.*
                            , 0.001 * 1  AS  TotalMonthQty
                            , 0.001 * 1  AS  TotalMonthQtyFM
                            FROM   PPINCTWorkDate 
                            WHERE  PPINCTWorkDate.WrkYearKey  =@paYear 
                                 AND MONTH( PPINCTWorkDate.WrkDay) =@paMonth";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@paYear", paYear),
                                                       new SqlParameter("@paMonth", paMonth)
                                                       },
                                    this.TablePPINCTWorkDate);               

            }


            #endregion

            dataSet.Tables[this.TablePPINCTWorkDate].Columns["TotalMonthQty"].Expression = "SUM( PlanQty ) ";
            dataSet.Tables[this.TablePPINCTWorkDate].Columns["TotalMonthQtyFM"].Expression = "SUM( FMPlanQty  ) ";
            return dataSet;
        }
        #endregion Get data

        #region Update Data
        public int SaveTeamToDB(DataSet dataSet, string paYYYY, string paMM)
        {
            #region Generate Team by HR  Wirking date
            if (this.SaveGenTeamByHRToDB(dataSet, paYYYY, paMM) < 1)
            {
                return -1;
            }
            #endregion 

            #region Generate Team by shift  Wirking date
            if (this.SaveGenTeamByShiftToDB(paYYYY, paMM) < 1)
            {
                return -1;
            }
            #endregion 

            return 1;
        }
        public int SaveGenTeamByHRToDB(DataSet dataSet , string paYYYY , string paMM)
        {
            //new PPINCTWorkCalShift(connect).UpdateRecord(dtData);
            this.LastError =  "" ;
            try
            {
                #region declare value
                bool lbConv  ;
                int iYYYY , iMM ,iDD , iDay;
                lbConv  =int.TryParse( paYYYY , out iYYYY) ;
                lbConv  =int.TryParse(  paMM  , out iMM) ;
                if( ( iYYYY < 2020 )  || ( iMM < 0 || iMM > 12 )) 
                {
                    this.LastError = " กำหนด ปี/เดือน ไม่ถูกต้อง \n\rSaveGenTeamByHRToDB()";
                    return -1 ;
                }
                string col = "DAY_" ,colName = "" ,TeamCode , strSelect;
                string dayValue;
                DataRow dr;
                DataRow[] arrDr;
                DateTime dtDate  = new DateTime(iYYYY ,iMM,1) ;
                DateTime WrkDay ;
                dtDate = dtDate.AddMonths(1) ;
                dtDate = dtDate.AddDays(-1) ;
                iDD  = dtDate.Day;
                #endregion 
                #region Set data
                DataSet dsData = this.GetRecordListPPINCTWorkCalByYearMonth(paYYYY, paMM);
                DataTable dtData  = dsData.Tables[this.TablePPINCTWorkCal] ;  
                DataTable dtCalTable = dataSet.Tables[this.TablePPINCTWorkCalTable];

                foreach (DataRow ldr in dtCalTable.Rows)
                {
                    TeamCode  = ldr["TeamCode"].ToString().ToUpper() ;
                    for (int i = 0; i < iDD; i++)
                    {                        
                        iDay = i + 1;
                        WrkDay =  new DateTime(iYYYY , iMM ,iDay) ;
                        colName = string.Format("{0}{1}", col, iDay.ToString("00"));
                        dayValue = ldr[colName].ToString();
                        strSelect  = string.Format(" TeamCode = '{0}'  AND  CDD = {1} " ,TeamCode , iDay) ;
                        arrDr = dtData.Select(strSelect) ;
                        if( arrDr.Length ==  0  ) 
                        {
                            dr = dtData.NewRow();
                            dr["TeamCode"] = TeamCode.ToUpper();
                            dr["WrkCode"]  = dayValue ;
                            dr["WrkDay"]   = WrkDay  ;
                            dr["CreateBy"] = this._userID ;
                            dr["UpdateBy"] = this._userID ;
                            dtData.Rows.Add(dr) ;

                        }
                        else
                        {                            
                            arrDr[0]["WrkCode"] = dayValue;                            
                            arrDr[0]["UpdateBy"] = this._userID;
                        }
                    }
                }

               

                #endregion
                #region Update Data
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();
                        new PPINCTWorkCal(connect).UpdateRecord(dtData);
                    }
                    scope.Complete();
                }
                #endregion
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :SaveTeamToDB()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                this.LastError = sb.ToString();
                return -1;
            }
            return 1;
        }
        public int SaveGenTeamByShiftToDB( string paYYYY, string paMM)
        {
            
            this.LastError = "";
            try
            {
                #region declare value

                bool lbConv;
                int iYYYY, iMM, iDD, iDay;
                lbConv = int.TryParse(paYYYY, out iYYYY);
                lbConv = int.TryParse(paMM, out iMM);
                if ((iYYYY < 2020) || (iMM < 0 || iMM > 12))
                {
                    this.LastError = " กำหนด ปี/เดือน ไม่ถูกต้อง \n\rSaveGenTeamByShiftToDB()";
                    return -1;
                }               
                #endregion
                #region Set data

                DataSet dsData = this.GetRecordListPPINCTWorkCalShiftByYearMonth(paYYYY, paMM);
                DataTable dtData = dsData.Tables[this.TablePPINCTWorkCal];
                DataTable dtDataShift = dsData.Tables[this.TablePPINCTWorkCalShift];
                DataTable dtDataShiftCls = dtDataShift.Copy();
                DataRow dr;
                DateTime ShiftWrkDay, TimeFrom,TimeTo ;
                int StartHour, StartMinute, EndHour, EndMinute, DIFF_HR, DIFF_DD;
                int CYYYY, CMM, CDD;
                dtDataShift.Rows.Clear();
                TimeSpan ts;                

                foreach (DataRow ldr in dtData.Rows)
                {
                    StartHour = (int)ldr["StartHour"];
                    StartMinute = (int)ldr["StartMinute"];
                    EndHour = (int)ldr["EndHour"];
                    EndMinute = (int)ldr["EndMinute"];
                    DIFF_HR = (int)ldr["DIFF_HR"];
                    DIFF_DD = (int)ldr["DIFF_DD"];
                    CYYYY = (int)ldr["CYYYY"];
                    CMM = (int)ldr["CMM"];
                    CDD = (int)ldr["CDD"];                 

                    if (StartHour > EndHour)
                    {
                        ShiftWrkDay = new DateTime(CYYYY, CMM, CDD);
                        TimeFrom = new DateTime(CYYYY, CMM, CDD, StartHour, StartMinute, 0);
                        TimeTo = new DateTime(CYYYY, CMM, CDD, EndHour, EndMinute, 0).AddDays(1);
                        dr = dtDataShift.NewRow();
                        dr["WrkCalKey"] = ldr["WrkCalKey"];
                        dr["ShiftWrkDay"] = ShiftWrkDay;
                        dr["TimeFrom"] = TimeFrom;
                        dr["TimeTo"] = TimeTo;
                        dr["CreateBy"] = this._userID;
                        dr["UpdateBy"] = this._userID;
                        ts = TimeTo - TimeFrom;
                        if (ts.TotalMinutes > 0)
                        {
                            dr["TotalMin"] = ts.TotalMinutes;
                        }
                        else
                        {
                            dr["TotalMin"] = 0;
                        }
                        dtDataShift.Rows.Add(dr);

                        //TimeFrom = TimeTo;
                        //ShiftWrkDay = TimeTo;// new DateTime(CYYYY, CMM, CDD);
                        //TimeTo = new DateTime(CYYYY, CMM, CDD, EndHour, EndMinute, 0).AddDays(1);
                        //dr = dtDataShift.NewRow();
                        //dr["WrkCalKey"] = ldr["WrkCalKey"];
                        //dr["ShiftWrkDay"] = ShiftWrkDay;
                        //dr["TimeFrom"] = TimeFrom;
                        //dr["TimeTo"] = TimeTo;
                        //dr["CreateBy"] = this._userID;
                        //dr["UpdateBy"] = this._userID;
                        //ts = TimeTo - TimeFrom;
                        //if (ts.TotalMinutes > 0)
                        //{
                        //    dr["TotalMin"] = ts.TotalMinutes;
                        //}
                        //else
                        //{
                        //    dr["TotalMin"] = 0;
                        //}

                        ////dr["TotalMin"] = 0;
                        //dtDataShift.Rows.Add(dr);
                    }
                    else
                    {
                        ShiftWrkDay = new DateTime( CYYYY, CMM,CDD ) ;
                        TimeFrom = new DateTime(CYYYY, CMM, CDD, StartHour, StartMinute,0);
                        TimeTo = new DateTime(CYYYY, CMM, CDD, EndHour, EndMinute, 0);
                        dr = dtDataShift.NewRow();
                        dr["WrkCalKey"] = ldr["WrkCalKey"];
                        dr["ShiftWrkDay"] = ShiftWrkDay;
                        dr["TimeFrom"] = TimeFrom;
                        dr["TimeTo"] = TimeTo;
                        dr["CreateBy"] = this._userID;
                        dr["UpdateBy"] = this._userID;
                        ts = TimeTo - TimeFrom;
                        if (ts.TotalMinutes > 0)
                        {
                            dr["TotalMin"] = ts.TotalMinutes;
                        }
                        else
                        {
                            dr["TotalMin"] = 0;
                        }
                        //dr["TotalMin"] = 0;
                        dtDataShift.Rows.Add(dr); 
                    }                     
                }



                #endregion
                #region Clear Old data 
                foreach (DataRow ldr in dtDataShiftCls.Rows)
                {
                    ldr.Delete();
                }
                #endregion 

                #region Update Data
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();
                        new PPINCTWorkCalShift(connect).UpdateRecord(dtDataShiftCls);
                        new PPINCTWorkCalShift(connect).UpdateRecord(dtDataShift);
                    }
                    scope.Complete();
                }
                #endregion
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :SaveGenTeamByShiftToDB()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                this.LastError = sb.ToString();
                return -1;
            }
            return 1;
        }
        public int SaveTimeToDB(ref DataSet dataSet)
        {
            this.LastError = "";
            try
            {
                DataTable dtData = dataSet.Tables[this.TablePPINCTTimeWork];

                #region Set data
                foreach (DataRow dr in dtData.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            dr["CreateBy"] = _userID;
                            dr["UpdateBy"] = _userID;
                            break;
                        case DataRowState.Modified:
                            dr["UpdateBy"] = _userID;
                            break;
                        default:
                            break;
                    }
                }

                #endregion
                #region Update Data
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();                      
                        new PPINCTTimeWork(connect).UpdateRecord(dtData);
                    }
                    scope.Complete();
                }
                #endregion
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :SaveTimeToDB()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                this.LastError = sb.ToString();
                return -1;
            }
            return 1;
        }
        public int SaveGenYearAndWorkingDate(string byYear)
        {
            this.LastError = "";
            int intYYYY,intMM,intDD;
            DateTime dtWrkDate;
            bool lbChk = int.TryParse(byYear, out intYYYY);
            if (intYYYY <  2020)
            {
                this.LastError = "ปี Program incentive ต้องเริ่มตั้งแต่ 2020";
                return 0;
            }

           
            try
            {

                DataSet dsData = this.GetRecordListWorkingDateAndYear(byYear);
                DataTable ldtYear     = dsData.Tables[this.TablePPINCTWorkYear];
                DataTable ldtWorkDate = dsData.Tables[this.TablePPINCTWorkDate];
                DataRow dr;
                

                #region Set data
                if (ldtYear.Rows.Count == 0)
                {
                    dr = ldtYear.NewRow();
                    dr["WrkYearKey"] = intYYYY;
                    dr["CreateBy"] = _userID;
                    dr["UpdateBy"] = _userID;
                    ldtYear.Rows.Add(dr);
                }

                DataRow[] arrMonth; 
                int  intEndDD  ,intCalYear;
                DateTime dtFirstDate, dtEndDate;
                string strSelect = "" ;
                for (int i = 1; i < 13; i++)
                {
                    if (i == 12)
                    {
                        intCalYear = intYYYY + 1;
                        dtFirstDate = new DateTime(intCalYear, 1, 1);
                    }
                    else
                    {
                        intCalYear = intYYYY ;
                        dtFirstDate = new DateTime(intCalYear, i + 1, 1);
                    }
                    dtEndDate = dtFirstDate.AddDays(-1) ;
                    intEndDD = dtEndDate.Day;
                    strSelect = string.Format(" CMM = {0} ", i.ToString());
                    arrMonth = ldtWorkDate.Select(strSelect,"CDD");
                    if (arrMonth.Length == 0)
                    {
                        for(int j =  0 ; j < intEndDD ;j++ )
                        {
                            intDD = j + 1 ;
                            dtWrkDate = new DateTime(intYYYY , i,intDD ) ;                            
                            dr = ldtWorkDate.NewRow() ;
                            dr["WrkYearKey"] = intYYYY ;
                            dr["WrkDay"] = dtWrkDate ;
                            dr["CreateBy"] = _userID;
                            dr["UpdateBy"] = _userID;
                            ldtWorkDate.Rows.Add(dr);
                        }                         
                    }
                    else
                    {
                        for (int j = 0; j < intEndDD; j++)
                        {
                            intDD = j + 1;
                            dtWrkDate = new DateTime(intYYYY, i, intDD);
                            strSelect = string.Format(" CMM = {0} AND  CDD = {2}", i.ToString(),intDD.ToString());
                            arrMonth = ldtWorkDate.Select(strSelect,"CDD");
                            if (arrMonth.Length == 0)
                            {
                                dr = ldtWorkDate.NewRow();
                                dr["WrkYearKey"] = intYYYY;
                                dr["WrkDay"] = dtWrkDate;
                                dr["CreateBy"] = _userID;
                                dr["UpdateBy"] = _userID;
                                ldtWorkDate.Rows.Add(dr);
                            }
                        }       
                    }
                }

                #endregion
                #region Update Data
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();
                        new PPINCTWorkYear(connect).UpdateRecord(ldtYear);
                        new PPINCTWorkDate(connect).UpdateRecord(ldtWorkDate);
                    }
                    scope.Complete();
                }
                #endregion
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :SaveGenYearAndWorkingDate()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                this.LastError = sb.ToString();
                return -1;
            }
            return 1;
        }
        public int SaveDailyPlanToDB(ref DataSet dataSet)
        {
            this.LastError = "";
            try
            {
                DataTable dtData = dataSet.Tables[this.TablePPINCTWorkDate];

                #region Set data
                foreach (DataRow dr in dtData.Rows)
                {
                    switch (dr.RowState)
                    {                      
                        case DataRowState.Modified:
                            dr["UpdateBy"] = _userID;
                            break;
                        default:
                            break;
                    }
                }

                #endregion
                #region Update Data
                using (System.Transactions.TransactionScope scope = new TransactionScope())
                {
                    using (System.Data.SqlClient.SqlConnection connect = new System.Data.SqlClient.SqlConnection(_connStr))
                    {
                        connect.Open();
                        new PPINCTWorkDate(connect).UpdateRecord(dtData);
                    }
                    scope.Complete();
                }
                #endregion
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :SaveDailyPlanToDB()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                this.LastError = sb.ToString();
                return -1;
            }
            return 1;
        }
        #endregion Update Data

        #region property
         

        public string LastError
        {
            set { this._lastError = value ; }
            get { return this._lastError; }
        }
        #endregion property
    }
}
