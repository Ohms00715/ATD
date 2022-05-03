using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using ATD.Data;

namespace ATD.Management
{
    public class SqlTeamAndTimeWorkManager
    {
        #region Variable

        private string _connStr;
        private string _userID;    
        public string TablePPINCTTeam = "PPINCTTeam";
        public string TablePPINCTTimeWork = "PPINCTTimeWork";
        private string _lastError = "";
        #endregion Variable

        public SqlTeamAndTimeWorkManager(string connStr, string userID)
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
                            FROM PPINCTTeam ";

                dataSet = DataHelper.ExecuteDataSet(connection,
                                    sqlText,
                                    CommandType.Text,
                                    new SqlParameter[] { 
                                                       new SqlParameter("@Code", "")
                                                       },
                                    this.TablePPINCTTeam);


                sqlText = @"select  PPINCTTimeWork.*
                            FROM PPINCTTimeWork ";

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

        #endregion Get data

        #region Update Data
        public int SaveTeamToDB(ref DataSet dataSet)
        {
            this.LastError =  "" ;
            try
            {                
                DataTable dtData = dataSet.Tables[this.TablePPINCTTeam];
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
                        new PPINCTTeam(connect).UpdateRecord(dtData);
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
