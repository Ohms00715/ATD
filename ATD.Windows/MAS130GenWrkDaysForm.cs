using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Gsteel.GAPP.Manager.SqlPPManager;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using ATD.Management;

namespace ATD.Windows
{
    public partial class MAS130GenWrkDaysForm : Form
    {
        public string _connStr = "";
        public string _userID = "";
        public string _year = "";
        public DataSet _dsData = null;
        public DataTable _dtData = null;
        private bool _updatedFlag = false;
        public SqlElectricalGenWrkDaysManager _sqlElecGenWrkDaysMgr = null;
        public DateTimePicker datePickerProductionDate;

        public MAS130GenWrkDaysForm(string connStr, string userID)
        {
            //set Culture Datetime 
            CultureInfo en = new CultureInfo("en-US", true);
            en.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            en.DateTimeFormat.LongDatePattern = "dd/MM/yyyy";
            en.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            en.DateTimeFormat.LongTimePattern  = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = en;
            //Thread.CurrentThread.CurrentCulture = currentCulture;

            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._dsData = new DataSet();
            this._dtData = new DataTable();
            this._sqlElecGenWrkDaysMgr = new SqlElectricalGenWrkDaysManager(this._connStr, this._userID);
           
            this._dsData = this._sqlElecGenWrkDaysMgr.GetElectricalList(System.DateTime.Now, System.DateTime.Now);           
            this.setObjectGridView();
            this.setBindingData();
        }
       

        #region security check
        public void SetSecurityForm(bool updatedFlag, bool deletedFlag, bool readFlag)
        {
            this._updatedFlag = updatedFlag;
            this.SaveToolStripButton.Enabled = updatedFlag;
        }
        #endregion security check

        #region method service
      
        public void setBindingData()
        {
            this.bdsGen.DataSource = this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableV_PPEventLogWrkDays];
            this.bdnGen.BindingSource = this.bdsGen;
            this.dgvGen.DataSource = this.bdsGen;

            //this.bdsGenD.DataSource = this.bdsGen;
            //this.bdsGenD.DataMember = this._sqlElecGenWrkDaysMgr._relationPPEventLogDetail;
            this.bdsGenD.DataSource = this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLogDetail];
            //this.bdsGenD.DataMember = this.bdsGenD;
            this.dgvGenD.DataSource = this.bdsGenD;

            this.bdsShift.DataSource = this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLogShift];            
            this.dgvShift.DataSource = this.bdsShift;


        }
        public void setObjectGridView()
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            #region dataGrid Calendar
            //this.CalendarTOUDataGridView.AutoGenerateColumns = false;

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "Date";
            //col.DataPropertyName = "GDate";
            //col.HeaderText = "Date (dd/MM/yyyy)";
            //col.Width = 140;
            //col.ValueType = typeof(DateTime);
            //col.DefaultCellStyle.Format = "dd/MM/yyyy";
            //col.DefaultCellStyle.BackColor = System.Drawing.Color.Honeydew;
            //this.CalendarTOUDataGridView.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "Remark";
            //col.DataPropertyName = "Remark";
            //col.HeaderText = "Remark";
            //col.Width = 300;
            //col.MaxInputLength = 255;
            //col.ValueType = typeof(string);
            //this.CalendarTOUDataGridView.Columns.Add(col);
            #endregion datagrid Calendar

            #region dataGird Elec Report
            this.dgvGen.AutoGenerateColumns = false;        
     
            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "EventLogKey";
            col.DataPropertyName = "EventLogKey";
            col.HeaderText = "EventLogKey";
            col.Width = 20;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "EventCode";
            col.DataPropertyName = "EventCode";
            col.HeaderText = "Event Code";
            col.Width = 40;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "EventDesc";
            col.DataPropertyName = "EventDesc";
            col.HeaderText = "EventDesc";
            col.Width = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);            

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "ChkDiffDay";
            col.DataPropertyName = "ChkDiffDay";
            col.HeaderText = "Diff Days";
            col.Width = 40;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvGen.Columns.Add(col);
 

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "WrkDate";
            col.DataPropertyName = "WrkDate";
            col.HeaderText = "Work Date";
            col.DefaultCellStyle.Format = "dd/MM/yyyy";
            col.Width = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "TimeFrom";
            col.DataPropertyName = "TimeFrom";
            col.HeaderText = "Time From";
            col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col.Width = 170;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);

            col = null;
            col = new DataGridViewTextBoxColumn();
            col.Name = "TimeTo";
            col.DataPropertyName = "TimeTo";
            col.HeaderText = "Time To";
            col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col.Width = 170;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvGen.Columns.Add(col);

            for (int i = 0; i < this.dgvGen.ColumnCount; i++)
            {
                this.dgvGen.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
          
            #endregion dataGrid Elec Report

            #region dataGird Elec Grand Total Report
            //this.dgvGenD.AutoGenerateColumns = false;

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "ProductionDate";
            //col.DataPropertyName = "ProductionDate";
            //col.HeaderText = "Production Date";
            //col.Width = 120;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "HeatStart";
            //col.DataPropertyName = "HeatStart";
            //col.HeaderText = "Heat Start";
            //col.Width = 90;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "HeatEnd";
            //col.DataPropertyName = "HeatEnd";
            //col.HeaderText = "Heat End";
            //col.Width = 90;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "First_power_on_time";
            //col.DataPropertyName = "First_power_on_time";
            //col.HeaderText = "First Heat Power On";
            //col.Width = 170;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "Tapping_end_time";
            //col.DataPropertyName = "Tapping_end_time";
            //col.HeaderText = "Last Heat Tapp End";
            //col.Width = 170;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "MeltingTime";
            //col.DataPropertyName = "MeltingTime";
            //col.HeaderText = "Melting Time";
            //col.Width = 90;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "OffPeakTime";
            //col.DataPropertyName = "OffPeakTime";
            //col.HeaderText = "Off-Peak=11hrs (22:00-09:00)";
            //col.Width = 120;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "OnPeakTime";
            //col.DataPropertyName = "OnPeakTime";
            //col.HeaderText = "On-Peak=13hrs (09:00-22:00)";
            //col.Width = 120;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "OffPeakTimePerc";
            //col.DataPropertyName = "OffPeakTimePerc";
            //col.HeaderText = "% Off-Peak";
            //col.Width = 100;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvGenD.Columns.Add(col);

            //col = null;
            //col = new DataGridViewTextBoxColumn();
            //col.Name = "OnPeakTimePerc";
            //col.DataPropertyName = "OnPeakTimePerc";
            //col.HeaderText = "% On-Peak";
            //col.Width = 100;
            //col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.dgvGenD.Columns.Add(col);

            #endregion dataGrid Elec Geand Total Report
        }       
        private void Hourglass(bool Show)
        {
            if (Show == true)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            }
            else
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
            return;
        }
        private void RefreshData()
        {
            foreach (DataRelation rel in this._dsData.Relations)
            {
                rel.ChildTable.Rows.Clear();
            }
            foreach (DataTable ldr in _dsData.Tables)
            {
                ldr.Rows.Clear();
            }            
        }
      
        private void setDataElecArcForDisplay(DataTable dtElec)
        {
            if (this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcReport] != null)
            {
                this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcReport].Rows.Clear();
            }
            if (this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcGrandTotalReport] != null)
            {
                this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcGrandTotalReport].Rows.Clear();
            }

            DataTable dtDisplay = new DataTable();
            DataTable dtGrandTotal = new DataTable();
            DataRow dr;
            dtDisplay = dtElec.Clone();
            dtDisplay.Columns["MeltingTime"].DataType = typeof(string);
            dtDisplay.Columns["OffPeakTime"].DataType = typeof(string);
            dtDisplay.Columns["OnPeakTime"].DataType = typeof(string);
            dtDisplay.Columns.Add("OffPeakTimePerc", typeof(string));
            dtDisplay.Columns.Add("OnPeakTimePerc", typeof(string));

            #region create column table dtGrandTotal
            dtGrandTotal.Columns.Add("ProductionDate");
            dtGrandTotal.Columns.Add("HeatStart");
            dtGrandTotal.Columns.Add("HeatEnd");
            dtGrandTotal.Columns.Add("MeltingTime",typeof(string));
            dtGrandTotal.Columns.Add("OffPeakTime", typeof(string));
            dtGrandTotal.Columns.Add("OnPeakTime", typeof(string));
            dtGrandTotal.Columns.Add("OffPeakTimePerc", typeof(string));
            dtGrandTotal.Columns.Add("OnPeakTimePerc", typeof(string));
            #endregion create column table dtGrandTotal

            int iRow = 0;
            TimeSpan tsTime;
            decimal decMeltingTime = 0;
            decimal decOffPeakTime = 0;
            decimal decOnPeakTime = 0;
            decimal decOffPeakTimePerc = 0;
            decimal decOnPeakTimePerc = 0;

            decimal decSumMeltingTime = 0;
            decimal decSumOffPeakTime = 0;
            decimal decSumOnPeakTime = 0;
            decimal decSumOffPeakTimePerc = 0;
            decimal decSumOnPeakTimePerc = 0;
            decimal decSumTime = 0;

            string strMeltingTime = "";
            string strOffPeakTime = "";
            string strOnPeakTime = "";
            string strOffPeakTimePerc = "";
            string strOnPeakTimePerc = "";

            foreach (DataRow ldr in dtElec.Rows)
            {
                dtDisplay.ImportRow(ldr);
                // MeltingTime
                decMeltingTime = (ldr["MeltingTime"] != DBNull.Value) ? Convert.ToDecimal(ldr["MeltingTime"].ToString()) : 0;
                decSumMeltingTime += decMeltingTime;
                tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decMeltingTime));
                strMeltingTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
                dtDisplay.Rows[iRow]["MeltingTime"] = (decMeltingTime != 0) ? strMeltingTime : "";

                //OffPeakTime
                decOffPeakTime = (ldr["OffPeakTime"] != DBNull.Value) ? Convert.ToDecimal(ldr["OffPeakTime"].ToString()) : 0;
                decSumOffPeakTime += decOffPeakTime;
                tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decOffPeakTime));
                strOffPeakTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
                dtDisplay.Rows[iRow]["OffPeakTime"] = (decOffPeakTime != 0) ? strOffPeakTime : "";

                //OnPeakTime
                decOnPeakTime = (ldr["OnPeakTime"] != DBNull.Value) ? Convert.ToDecimal(ldr["OnPeakTime"].ToString()) : 0;
                decSumOnPeakTime += decOnPeakTime;
                tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decOnPeakTime));
                strOnPeakTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
                dtDisplay.Rows[iRow]["OnPeakTime"] = (decOnPeakTime != 0) ? strOnPeakTime : "";

                //OffPeakTimePerc
                decOffPeakTimePerc = (decOffPeakTime != 0) ? (decOffPeakTime/660)*100 : 0; //660 Min = 11Hr.
                strOffPeakTimePerc = string.Format("{0:N2}", decOffPeakTimePerc);
                dtDisplay.Rows[iRow]["OffPeakTimePerc"] = (decOffPeakTimePerc != 0) ? strOffPeakTimePerc + "%" : "";

                //OnPeakTimePerc
                decOnPeakTimePerc = (decOnPeakTime != 0) ? (decOnPeakTime/780)*100 : 0; //780 Min = 13Hr.                
                strOnPeakTimePerc = string.Format("{0:N2}", decOnPeakTimePerc);
                dtDisplay.Rows[iRow]["OnPeakTimePerc"] = (decMeltingTime != 0) ? strOnPeakTimePerc + "%" : "";

                iRow++;
            }

            //Grand Total
            //Melting Time
            tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decSumMeltingTime));
            strMeltingTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
            //strMeltingTime += "(" + decSumMeltingTime.ToString("N0") + ")";
            
            //Off Peak Time
            tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decSumOffPeakTime));
            strOffPeakTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
            //strOffPeakTime += "(" + decSumOffPeakTime.ToString("N0") + ")";
            
            //On Peak Time
            tsTime = TimeSpan.FromMinutes(Convert.ToDouble(decSumOnPeakTime));
            strOnPeakTime = string.Format("{00:00}:{01:00}", (int)tsTime.TotalHours, tsTime.Minutes);
            //strOnPeakTime += "(" + decSumOnPeakTime.ToString("N0") + ")";.

            decSumTime = decSumOffPeakTime + decSumOnPeakTime;
            decOffPeakTimePerc = (decSumTime != 0 && decSumOffPeakTime != 0) ? (decSumOffPeakTime / decSumTime) * 100 : 0;
            strOffPeakTimePerc = string.Format("{0:N2}", decOffPeakTimePerc);

            decOnPeakTimePerc = (decSumTime != 0 && decSumOnPeakTime != 0) ? (decSumOnPeakTime / decSumTime) * 100 : 0;
            strOnPeakTimePerc = string.Format("{0:N2}", decOnPeakTimePerc);

            dr = dtGrandTotal.NewRow();
            dr["ProductionDate"] = "Grand Total";
            dr["MeltingTime"] = strMeltingTime;
            dr["OffPeakTime"] = strOffPeakTime;
            dr["OnPeakTime"] = strOnPeakTime;
            dr["OffPeakTimePerc"] = strOffPeakTimePerc + "%";
            dr["OnPeakTimePerc"] = strOnPeakTimePerc + "%";
            dtGrandTotal.Rows.Add(dr);

            dtDisplay.TableName = this._sqlElecGenWrkDaysMgr.TableNamePPElecArcReport;
            dtGrandTotal.TableName = this._sqlElecGenWrkDaysMgr.TableNamePPElecArcGrandTotalReport;
            this._dsData.Merge(dtDisplay);
            this._dsData.Merge(dtGrandTotal);

            this.bdsGen.DataSource = dtDisplay;
            this.bdnGen.BindingSource = this.bdsGen;
            this.dgvGen.DataSource = this.bdsGen;

            //grand total
            this.bdsGenD.DataSource = dtGrandTotal;
            this.dgvGenD.DataSource = this.bdsGenD;
        }
        #endregion method service

        #region get data 
        private void getDataElecArcByDate()
        {
            DateTime DateFrom = System.DateTime.Now;
            DateTime DateTo = System.DateTime.Now;

            if (this.dtpBegDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                DateTime date = dtpBegDate.Value.Date;
                this.dtpBegDate.Value = this.dtpEndDate.Value.Date;
                this.dtpEndDate.Value = date;
            }
            DateFrom = dtpBegDate.Value;
            DateTo = dtpEndDate.Value;
            this.RefreshData();

            this._dsData.Merge(this._sqlElecGenWrkDaysMgr.GetElectricalList(DateFrom, DateTo));       
        }

        #endregion 
        #region save data
        private bool validateSave()
        {
            try
            {
                this.bdsGenD.EndEdit();
                this.dgvGenD.EndEdit();                

                StringBuilder sb = new StringBuilder();
                DataRow dr;
                if (_dsData.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLogDetail].Rows.Count > 0)
                {
                    
                }
                else
                {
                    sb.AppendLine("Method : validateSave()");
                    sb.AppendLine(" Data not found check and try again.");
                }
                if (sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString(),
                                "Validate Error value not null , please check try again..",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    return false;
                }
            }

            catch (System.Exception exp)
            {
                MessageBox.Show("  validateSave Data error :validateSave()" +
                                     "\n\r Message:" + exp.Message.ToString() +
                                     "\n\r Source: " + exp.Source.ToString() +
                                     "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private int saveToDB()
        {
            if (!this.validateSave() )
            {
                return -1;
            }

            try
            {
                int intReturn = this._sqlElecGenWrkDaysMgr.SaveToDB(ref this._dsData);
                if ( intReturn > 0 )
                {
                    MessageBox.Show(" Save data to database completed.. ",
                                    "Save data",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show( this._sqlElecGenWrkDaysMgr.LastError,
                                   "Save data fail",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return intReturn ;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  saveToDB() Data error :saveToDB()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                return -1;
            }
        }
        private int DeleteFromDB()
        {
            try
            {
                int intReturn = this._sqlElecGenWrkDaysMgr.SaveClearByParameterWrkDate(this.dtpBegDate.Value,
                    this.dtpEndDate.Value);
                if (intReturn > 0)
                {
                    MessageBox.Show(" Delete data from database completed.. ",
                                    "Delete data",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this._sqlElecGenWrkDaysMgr.LastError,
                                   "Delete data fail",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception exp)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Method :DeleteFromDB()");
                sb.AppendLine(string.Format("Message {0} > ", exp.Message.ToString()));
                sb.AppendLine(string.Format("Source {0} > ", exp.Source.ToString()));
                sb.AppendLine(string.Format("StackTrace {0} > ", exp.StackTrace.ToString()));
                sb.AppendLine(string.Format("TargetSite {0} > ", exp.TargetSite.ToString()));
                MessageBox.Show(sb.ToString(),
                                 "Delete data fail",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return 1;
        }
        #endregion save data

        #region get report
        private void ExportToExcel(string ExcelVersion)
        {
            
            //if (this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcReport] != null &&
            //    this._dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcGrandTotalReport] != null)
            //{
            //    DataTable dtData = _dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcReport];
            //    DataTable dtDataTotal = _dsData.Tables[this._sqlElecGenWrkDaysMgr.TableNamePPElecArcGrandTotalReport];

            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    if (ExcelVersion == "2003")
            //    {
            //        saveFileDialog.Filter = "Microsoft Excel 2003 (*.xls)|*.xls|All Files (*.*)|*.*";
            //    }
            //    else
            //    {
            //        saveFileDialog.Filter = "Microsoft Excel 2007-2010(*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            //    }
            //    saveFileDialog.FilterIndex = 0;
            //    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        // creating Excel Application 
            //        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            //        // creating new WorkBook within Excel application 
            //        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            //        // creating new Excelsheet in workbook 
            //        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //        // see the excel sheet behind the program
            //        app.ActiveWindow.Zoom = 100;
            //        app.Visible = true;

            //        // get the reference of first sheet. By default its name is Sheet1. 
            //        // store its reference to worksheet 
            //        worksheet = workbook.Sheets[1];
            //        worksheet = workbook.ActiveSheet;

            //        // changing the name of active sheet 
            //        worksheet.Name = "Electrical ARC EAF";

            //        //Set global attributes
            //        app.StandardFont = "Tahoma";
            //        app.StandardFontSize = 9;

            //        //storing header main
            //        worksheet.get_Range("A2", "J2").Font.Name = "Tahoma";
            //        worksheet.get_Range("A2", "J2").Font.Size = "10";
            //        worksheet.get_Range("A2", "J2").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        worksheet.get_Range("A2", "J2").RowHeight = 20;

            //        Excel.Range col;

            //        col = null;
            //        col = worksheet.get_Range("A2", "J2");
            //        col.Font.Size = "12";
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(true);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    
            //        col.Value2 = "Electrical ARC EAF Report";

            //        worksheet.get_Range("A3", "J3").Font.Name = "Tahoma";
            //        worksheet.get_Range("A3", "J3").Font.Size = "9";
            //        worksheet.get_Range("A3", "J3").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        //worksheet.get_Range("A3", "J3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue);
            //        worksheet.get_Range("A3", "J3").RowHeight = 40.50;

            //        col = null;
            //        col = worksheet.get_Range("A3", "A3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 15;
            //        col.Value2 = "Production Date";

            //        col = null;
            //        col = worksheet.get_Range("B3", "B3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 10;
                    
            //        col.Value2 = "Heat Strat";

            //        col = null;
            //        col = worksheet.get_Range("C3", "C3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 10;
            //        col.Value2 = "Heat Stop";

            //        col = null;
            //        col = worksheet.get_Range("D3", "D3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 18.20;
            //        col.Value2 = "First Heat Power On";

            //        col = null;
            //        col = worksheet.get_Range("E3", "E3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 18.20;
            //        col.Value2 = "Lat Heat Tapp End";
                    
            //        col = null;
            //        col = worksheet.get_Range("F3", "F3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 12;
            //        col.Value2 = "Melting Time";

            //        col = null;
            //        col = worksheet.get_Range("G3", "G3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.WrapText = true;
            //        col.ColumnWidth = 15;
            //        col.Value2 = "Off-Peak=11hrs (22:00 - 09:00)";

            //        col = null;
            //        col = worksheet.get_Range("H3", "H3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.WrapText = true;
            //        col.ColumnWidth = 15;
            //        col.Value2 = "On-Peak=13hrs (09:00 - 22:00)";

            //        col = null;
            //        col = worksheet.get_Range("I3", "I3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 10.50;
            //        col.Value2 = "% Off-Peak";

            //        col = null;
            //        col = worksheet.get_Range("J3", "J3");
            //        col.Font.Bold = true;
            //        col.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //        col.Merge(Type.Missing);
            //        col.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //        col.Style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //        col.ColumnWidth = 10.50;
            //        col.Value2 = "% On-Peak";


            //        //insert data to excel
            //        for (int i = 0; i < dtData.Rows.Count;i++ )
            //        {
            //            //strat row 4
            //            worksheet.Cells[4 + i, "A"] = dtData.Rows[i]["ProductionDate"].ToString();
            //            worksheet.Cells[4 + i, "B"] = dtData.Rows[i]["HeatStart"].ToString();
            //            worksheet.Cells[4 + i, "C"] = dtData.Rows[i]["HeatEnd"].ToString();
            //            worksheet.Cells[4 + i, "D"] = dtData.Rows[i]["First_power_on_time"].ToString();
            //            worksheet.Cells[4 + i, "E"] = dtData.Rows[i]["Tapping_end_time"].ToString();
            //            worksheet.Cells[4 + i, "F"] = dtData.Rows[i]["MeltingTime"].ToString();
            //            worksheet.Cells[4 + i, "G"] = dtData.Rows[i]["OffPeakTime"].ToString();
            //            worksheet.Cells[4 + i, "H"] = dtData.Rows[i]["OnPeakTime"].ToString();
            //            worksheet.Cells[4 + i, "I"] = dtData.Rows[i]["OffPeakTimePerc"].ToString();
            //            worksheet.Cells[4 + i, "J"] = dtData.Rows[i]["OnPeakTimePerc"].ToString();
                        
            //            worksheet.get_Range("A" + (i + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //            worksheet.get_Range("D" + (i + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //            worksheet.get_Range("E" + (i + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //            worksheet.get_Range("I" + (i + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //            worksheet.get_Range("J" + (i + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            //            worksheet.get_Range("F" + (i + 4)).NumberFormat = "[HH]:mm";
            //            worksheet.get_Range("G" + (i + 4)).NumberFormat = "[HH]:mm";
            //            worksheet.get_Range("H" + (i + 4)).NumberFormat = "[HH]:mm";
            //        }

            //        int iRowData = 0;
            //        iRowData = dtData.Rows.Count;
            //        //Grand Total
            //        for (int j = 0; j < dtDataTotal.Rows.Count; j++)
            //        {
            //            worksheet.Cells[4 + j + iRowData, "A"] = dtDataTotal.Rows[j]["ProductionDate"].ToString();
            //            worksheet.Cells[4 + j + iRowData, "F"] = dtDataTotal.Rows[j]["MeltingTime"].ToString();
            //            worksheet.Cells[4 + j + iRowData, "G"] = dtDataTotal.Rows[j]["OffPeakTime"].ToString();
            //            worksheet.Cells[4 + j + iRowData, "H"] = dtDataTotal.Rows[j]["OnPeakTime"].ToString();
            //            worksheet.Cells[4 + j + iRowData, "I"] = dtDataTotal.Rows[j]["OffPeakTimePerc"].ToString();
            //            worksheet.Cells[4 + j + iRowData, "J"] = dtDataTotal.Rows[j]["OnPeakTimePerc"].ToString();

            //            worksheet.get_Range("I" + (4 + j + iRowData)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //            worksheet.get_Range("J" + (4 + j + iRowData)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            //            worksheet.get_Range("A" + (4 + j + iRowData)).Font.Bold = true;
            //            worksheet.get_Range("F" + (4 + j + iRowData)).Font.Bold = true;
            //            worksheet.get_Range("G" + (4 + j + iRowData)).Font.Bold = true;
            //            worksheet.get_Range("H" + (4 + j + iRowData)).Font.Bold = true;
            //            worksheet.get_Range("I" + (4 + j + iRowData)).Font.Bold = true;
            //            worksheet.get_Range("J" + (4 + j + iRowData)).Font.Bold = true;

            //            worksheet.get_Range("F" + (4 + j + iRowData)).NumberFormat = "[HH]:mm";
            //            worksheet.get_Range("G" + (4 + j + iRowData)).NumberFormat = "[HH]:mm";
            //            worksheet.get_Range("H" + (4 + j + iRowData)).NumberFormat = "[HH]:mm";
            //        }

            //        // save the application 
            //        //workbook.SaveAs(saveFileDialog.FileName);
            //        workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
            //                , Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing
            //                , Type.Missing);
            //        // Exit from the application 
            //        app.Quit();
            //        MessageBox.Show("Export to Microsoft Excel 2003 completed. \r\n" +
            //                    "Export to:..\r\n" + saveFileDialog.FileName, "Export to EXCEL 2003");
            //    }             
            //}
            //else
            //{
            //    MessageBox.Show("ไม่พบข้อมูลที่ต้องการจะ export", "Error");
            //    return;
            //}
        }
        #endregion get report

        #region event

        private void btSave_Click(object sender, EventArgs e)
        {
            this.saveToDB();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            this.DeleteFromDB();
        }

        #region Old 
        private void datePickerProductionDate_ValueChanged(object sender, EventArgs e)
        {
            dgvData.CurrentCell.Value = datePickerProductionDate.Text;
        }       

        private void CalendarTOUDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((dgvData.Focused) && (dgvData.CurrentCell.ColumnIndex == 0))
                {
                    datePickerProductionDate.Location = dgvData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    datePickerProductionDate.Visible = true;
                    if (dgvData.CurrentCell.Value != DBNull.Value)
                    {
                        datePickerProductionDate.Value = (DateTime)dgvData.CurrentCell.Value;
                    }
                    else
                    {
                        datePickerProductionDate.Value = DateTime.Today;
                    }
                }
                else
                {
                    datePickerProductionDate.Visible = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void CalendarTOUDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((dgvData.Focused) && (dgvData.CurrentCell.ColumnIndex == 0))
                {
                    dgvData.CurrentCell.Value = datePickerProductionDate.Value.Date;
                    datePickerProductionDate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Hourglass(true);
            this.saveToDB();
            this.Hourglass(false);
        }
        
        private void RefreshToolStripButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }
        private void btnGetDataElec_Click(object sender, EventArgs e)
        {
            this.getDataElecArcByDate();
        }

        private void SumExportExcel2003ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExportToExcel("2003");
        }

        private void SumExportExcel2007ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExportToExcel("2010");
        }


        #endregion   
        #endregion event

        #region Tab by day

        #region Get data 

        public void getDataByDay()
        {
            #region  Tab Incentive data
            DataSet dsData = this._sqlElecGenWrkDaysMgr.GetElectricalListByWorkingDate(this.dtpByDay.Value);
            this.bdsData.DataSource = dsData.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLogShift];
            //TableV_PPEventLogWrkDays
            this.bdnData.BindingSource = this.bdsData;
            this.dgvData.DataSource = this.bdsData;
            this.dgvDataView.DataSource = dsData.Tables[this._sqlElecGenWrkDaysMgr.TableV_PPEventLogWrkDays];
            #endregion 

            #region Tab PPEvLog
            DataSet dsDataPPEv = this._sqlElecGenWrkDaysMgr.GetElectricalExistsWrkDate(this.dtpByDay.Value, this.dtpByDay.Value);
            this.dgvPPEvLog.DataSource = dsDataPPEv.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLog];
            this.dgvPPELogShift.DataSource = dsDataPPEv.Tables[this._sqlElecGenWrkDaysMgr.TablePPEventLogShift];
            #endregion 
        }
        private void btnGetDataTOU_Click(object sender, EventArgs e)
        {
            this.getDataByDay();
        }
        #endregion 
        #region Gen date
        private void SaveGenerateByDate()
        {
            string currDate = this.dtpByDay.Value.ToString("dd/MM/yyyy");
            string msgQ = string.Format("  ยืนยันบันทึกข้อมูล {0} หรือไม่  Y/N ?", currDate);
            if (MessageBox.Show(msgQ, "Confirm generate data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            if (this._sqlElecGenWrkDaysMgr.SaveToDBByDate(this.dtpByDay.Value) < 0)
            {
                MessageBox.Show("Generate ข้อมูลไม่สำเร็จ \n\r" + this._sqlElecGenWrkDaysMgr.LastError,
                    "Update fail.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Generate ข้อมูลสำเร็จ", "Update completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnGetDataTOU_Click(null, null);
            }
        }
        private void btGenByDay_Click(object sender, EventArgs e)
        {
            this.SaveGenerateByDate();
        }
        #endregion 
        #region clear
        private void ClearByDate()
        {
            string currDate = this.dtpByDay.Value.ToString("dd/MM/yyyy");
            string msgQ = string.Format("  ยืนยันลบข้อมูล {0} หรือไม่  Y/N ?", currDate);
            if (MessageBox.Show(msgQ, "Confirm delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (this._sqlElecGenWrkDaysMgr.SaveClearByParameterWrkDate(this.dtpByDay.Value,
                    this.dtpByDay.Value) < 0)
            {
                MessageBox.Show("ลบข้อมูลไม่สำเร็จ \n\r" + this._sqlElecGenWrkDaysMgr.LastError,
                    "Clear fail.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ", "Clear completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnGetDataTOU_Click(null, null);
            }
        }
        private void btClsByDate_Click(object sender, EventArgs e)
        {
            this.ClearByDate();
        }
        #endregion

        #endregion

    }
}
