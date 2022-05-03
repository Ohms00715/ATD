using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ATD.Management;



namespace ATD.Windows
{
    public partial class REP302AttendenceForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlTransactionImportFilesViewsManager _SqlTransactionImportFilesViewsManager = null;
        DataTable _dtATD = null;
        SqlMasterManeger _SqlMasterManeger = null;
        SqlTransactionImportFilesManager _SqlTransactionImportFilesManager = null;
        SqlWorkCalendarManager _SqlWorkCalendarManager = null;
        DataTable _dtImportfile = null;
        DataTable _dtImportfile2 = null;
        DataTable _dtMasterDD = null;
        DataTable _dtMasterShift_D_or_N = null;
        DataTable _dtMasterScanType = null;
        DataRow dr = null;
        string _documentKey1 = "";
        string _documentKey2 = "";
        string _documentKey3 = "";
        string _documentKey4 = "";
        string _documentKey6 = "";
        string _documentKey7 = "";
        string _documentKey9 = "";
        string _documentKey12 = "";
        string _documentDKey = "";
        string SHITF = "";
        string Type = "";
        DataTable _dtDate = null;

        public REP302AttendenceForm(string connStr, string userID)
        {


            InitializeComponent();
            _connStr = connStr;
            _userID = userID;
            this._SqlTransactionImportFilesViewsManager = new SqlTransactionImportFilesViewsManager(this._connStr, this._userID);
            this._SqlMasterManeger = new SqlMasterManeger(this._connStr, this._userID);
            this._SqlWorkCalendarManager = new SqlWorkCalendarManager(this._connStr, this._userID);
            this._SqlTransactionImportFilesManager = new SqlTransactionImportFilesManager(this._connStr, this._userID);
            //this._dtImportfileViews = new DataTable();
            this._dtMasterDD = new DataTable();
            this._dtMasterDD = this._SqlMasterManeger.GetATD_DayPerWeekList();
            this._dtMasterScanType = new DataTable();
            this._dtMasterScanType = _SqlMasterManeger.GetATD_TypeScanList("1");
            this._dtDate = new DataTable();
            this._dtDate = this._SqlTransactionImportFilesViewsManager.GetATD_WorkDateTimeList();
            this._dtMasterShift_D_or_N = new DataTable();
            string expressionTimeIN_OT = "IOMd = 0 or IOMd = 2";
            string expressionTimeOUT = "IOMd = 1";
            this._dtMasterShift_D_or_N = _SqlMasterManeger.GetATD_ShiftTypeList2();
            this._dtImportfile = this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeIN_OT).CopyToDataTable();
            this._dtImportfile2 = this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeOUT).CopyToDataTable(); 
            this._dtATD = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews("", "", "", "", "", "", "", "", "", "");
            this.SetObject();
            
            setReport();
            {
                if (this._dtATD.Rows.Count > 0)
                    SetDTP();
            }
          
            SetGrid();
            SetGrid2();
            setValue();
            
            SetComboBox();

             

        }

         private bool button1WasClicked = false;
        private bool button1WasClicked2 = false;
        public bool button3WasClicked = false;

        private void setReport()
        {
            
            ReportDataSource datasource3 = new ReportDataSource("DataSet1", _dtATD);


            

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(datasource3);

            reportViewer1.RefreshReport();


            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }
      
        private void SetObject()
        {
            this.dgvATD.AutoGenerateColumns = false;
            this.bdsReportATD.DataSource = _dtATD;
            this.bdnATD.BindingSource = bdsReportATD;
            this.dgvATD.DataSource = bdsReportATD;
            this.dgvATD.ReadOnly = true;

            this.dgvTimeIN.AutoGenerateColumns = false;
            this.bdsTimeIN.DataSource = _dtImportfile;
            this.bdnTimeIN.BindingSource = bdsTimeIN;
            this.dgvTimeIN.DataSource = bdsTimeIN;
            this.dgvTimeIN.ReadOnly = true;



            this.dgvTimeOUT.AutoGenerateColumns = false;
            this.bdsTimeOUT.DataSource = _dtImportfile2;
            this.bdnTimeOUT.BindingSource = bdsTimeOUT;
            this.dgvTimeOUT.DataSource = bdsTimeOUT;
            this.dgvTimeOUT.ReadOnly = true;
        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvATD.ReadOnly = true;
            this.dgvATD.AutoGenerateColumns = false;
            this.dgvATD.EnableHeadersVisualStyles = false;
            this.dgvATD.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WRK_NAME";
            ColumnText.DataPropertyName = "WRK_NAME";
            ColumnText.HeaderText = "วัน";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WrkDay";
            ColumnText.DataPropertyName = "WrkDay";
            ColumnText.HeaderText = "วันที่";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_ID";
            ColumnText.DataPropertyName = "EMP_ID";
            ColumnText.HeaderText = "รหัส";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Title";
            ColumnText.DataPropertyName = "Title";
            ColumnText.HeaderText = "คำนำหน้า";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_FName";
            ColumnText.DataPropertyName = "EMP_FName";
            ColumnText.HeaderText = "ชื่อ";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_LName";
            ColumnText.DataPropertyName = "EMP_LName";
            ColumnText.HeaderText = "นามสกุล";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Day_or_Night";
            ColumnText.DataPropertyName = "Day_or_Night";
            ColumnText.HeaderText = "กะ";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WorkTIME";
            ColumnText.DataPropertyName = "WorkTIME";
            ColumnText.HeaderText = "เวลาปกติ";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "TimeIn_";
            ColumnText.DataPropertyName = "TimeIn_";
            ColumnText.HeaderText = "เวลาเข้า";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "TimeOut_";
            ColumnText.DataPropertyName = "TimeOut_";
            ColumnText.HeaderText = "เวลาออก";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "TotalHours";
            ColumnText.DataPropertyName = "TotalHours";
            ColumnText.HeaderText = "รวมเวลา(ชม.)";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "OTDay";
            ColumnText.DataPropertyName = "OTDay";
            ColumnText.HeaderText = "โอที";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Status";
            ColumnText.DataPropertyName = "Status";
            ColumnText.HeaderText = "สถานะ";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Remarks";
            ColumnText.DataPropertyName = "Remarks";
            ColumnText.HeaderText = "หมายเหตุ";
            ColumnText.Width = 173;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "TimeFrom";
            ColumnText.DataPropertyName = "TimeFrom";
            ColumnText.HeaderText = "TimeFrom";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "TimeTo";
            ColumnText.DataPropertyName = "TimeTo";
            ColumnText.HeaderText = "TimeTo";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvATD.Columns.Add(ColumnText);



           
            this.dgvATD.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvATD.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        }
        private void SetGrid2()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvTimeIN.ReadOnly = true;
            this.dgvTimeIN.AutoGenerateColumns = false;
            this.dgvTimeIN.EnableHeadersVisualStyles = false;
            this.dgvTimeIN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "NO";
            ColumnText.DataPropertyName = "NO";
            ColumnText.HeaderText = "NO";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Mchn";
            ColumnText.DataPropertyName = "Mchn";
            ColumnText.HeaderText = "Mchn";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EnNo";
            ColumnText.DataPropertyName = "EnNo";
            ColumnText.HeaderText = "EnNo";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Name";
            ColumnText.DataPropertyName = "Name";
            ColumnText.HeaderText = "Name";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Mode";
            ColumnText.DataPropertyName = "Mode";
            ColumnText.HeaderText = "Mode";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "IOMd";
            ColumnText.DataPropertyName = "IOMd";
            ColumnText.HeaderText = "IOMd";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Datetime";
            ColumnText.DataPropertyName = "Datetime";
            ColumnText.HeaderText = "Datetime";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeIN.Columns.Add(ColumnText);


            this.dgvTimeIN.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvTimeIN.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion
            #region Pattern 2
            this.dgvTimeOUT.ReadOnly = true;
            this.dgvTimeOUT.AutoGenerateColumns = false;
            this.dgvTimeOUT.EnableHeadersVisualStyles = false;
            this.dgvTimeOUT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "NO";
            ColumnText.DataPropertyName = "NO";
            ColumnText.HeaderText = "NO";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);



            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Mchn";
            ColumnText.DataPropertyName = "Mchn";
            ColumnText.HeaderText = "Mchn";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EnNo";
            ColumnText.DataPropertyName = "EnNo";
            ColumnText.HeaderText = "EnNo";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Name";
            ColumnText.DataPropertyName = "Name";
            ColumnText.HeaderText = "Name";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Mode";
            ColumnText.DataPropertyName = "Mode";
            ColumnText.HeaderText = "Mode";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "IOMd";
            ColumnText.DataPropertyName = "IOMd";
            ColumnText.HeaderText = "IOMd";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Datetime";
            ColumnText.DataPropertyName = "Datetime";
            ColumnText.HeaderText = "Datetime";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTimeOUT.Columns.Add(ColumnText);


            this.dgvTimeOUT.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvTimeOUT.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        }


        private void setValue()
        {
            
            
            foreach (DataRow drr in this._dtATD.Rows)
            {

              

                if (drr["WrkCode"].ToString() == "H")
                {
                    drr["Status"] = "วันหยุด";
                }
             

                if (drr["TimeOut_"].ToString() != "" && drr["TimeIn_"].ToString() != "")
                {
                    TimeSpan span = (DateTime)drr["TimeOut_"] - (DateTime)drr["TimeIn_"];
                    double totalMinutes = span.TotalMinutes;


                    drr["TotalMinActual"] = totalMinutes;
                    int hours = Convert.ToInt32(totalMinutes / 60);
                    int min = Convert.ToInt32(totalMinutes % 60);

                    drr["TotalHours"] = hours + ":" + min;
                }

                if (drr["EMP_Register_Status"].ToString() != "True")
                {
                    drr["Status"] = "ยังไม่ลงทะเบียน";


                }
               



            }
        }
     

        private void buttonViewALL_Click(object sender, EventArgs e)
        {
            this.setReport();
        }
      

    
          private void SetDTP()
        {
           this.dtpWorkDayForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpWorkDayTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtpWorkDayForm.Format = DateTimePickerFormat.Custom;
            dtpWorkDayForm.CustomFormat = " ";
            dtpWorkDayTo.Format = DateTimePickerFormat.Custom;
            dtpWorkDayTo.CustomFormat = " ";
        }

       


        private void Filter_Data_Click(object sender, EventArgs e)
        {
            if (!button3WasClicked)
            {
                this._dtATD = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(DocumenKeysEMPID, "", DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, DocumenShift,Type);
                //(paraEMPID, paraTeamCode, paraDay, paraOT, paraRemark, paraStatus, paraTimeFrom, paraTimeTo, paraSHITF)
                this._dtATD = setShiftOT();
                setValue();
                setReport();
               
                button3WasClicked = true;
            }
            else
            {
                this._dtATD = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(DocumenKeysEMPID, "", DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, DocumenShift, Type);
                this._dtATD = setShiftOT();
                setValue();
                SetObject();
              
                button3WasClicked = false;
            }
          
        }
        private void btALL_Click(object sender, EventArgs e)
        {
            if (button3WasClicked)
            {
                this.comboBoxSHITF.SelectedIndex = 0;
                this.comboBoxDAY.SelectedIndex = 0;
                this.comboBoxEMP.SelectedIndex = 0;
                this.comboBoxRemark.SelectedIndex = 0;
                this.comboBoxStatus.SelectedIndex = 0;
                this.checkBoxOT.CheckState = 0;
                this._dtATD = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews("", "", "", "", "", "", "", "", "","");
                setReport();
                SetDTP();

            }
            else
            {
                
                this.comboBoxSHITF.SelectedIndex = 0;
                this.comboBoxDAY.SelectedIndex = 0;
                this.comboBoxEMP.SelectedIndex = 0;
                this.comboBoxRemark.SelectedIndex = 0;
                this.comboBoxStatus.SelectedIndex = 0;
                this.checkBoxOT.CheckState = 0;
                this._dtATD = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews("", "", "", "", "", "", "", "", "","");
                SetObject();
                SetDTP();
            }
        }
        private DataTable setShiftOT()
        {
            string[] dayEng = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            string[] dayThai = { "วันอาทิตย์", "วันจันทร์", "วันอังคาร", "วันพุธ", "วันพฤหัสบดี", "วันศุกร์", "วันเสาร์" };
            try
            {
                string[] array = { "", "" };

                DataRow dr;
                DataTable dtstandard = this._SqlTransactionImportFilesViewsManager.GetATD_WorkDateTimeList();
                DataTable dtCopy = _dtATD.Copy();
                DataTable dtForAdd = _dtATD.Copy();
                dtCopy.Rows.Clear();
                dtForAdd.Rows.Clear();

                foreach (DataRow drr in _dtATD.Rows)
                {
                    //if (drr["OTDay"].ToString() == "โอที")
                    //{
                    DateTime dtOutActual = (DateTime)drr["TimeOut_"];
                    DateTime dtOut = (DateTime)drr["TimeTo"];





                    if (drr["TeamCode"].ToString() == "B" || drr["TeamCode"].ToString() == "C")
                    {
                        if (drr["WrkCode"].ToString() == "N")
                        {
                            //กลางคืนควบกะ
                            drr["TimeOut_"] = dtOut;

                            DataRow drDs = dtstandard.Select("WrkCode = 'M' ").FirstOrDefault();
                            if (drDs != null)
                            {
                                TimeSpan ts = new TimeSpan(ConverttoInt(drDs["EndHour"].ToString()), ConverttoInt(drDs["EndMinute"].ToString()), 0);
                                dtOut = dtOut.Date + ts;
                            }

                            if (dtOut <= dtOutActual)
                            {
                                dtCopy.Rows.Add(drr.ItemArray);

                                DataRow drC = dtCopy.Rows[0];

                                // chang time in
                                TimeSpan tI = new TimeSpan(ConverttoInt(drDs["StartHour"].ToString()), ConverttoInt(drDs["StartMinute"].ToString()), 0);
                                dtOut = dtOut.Date + tI;
                                drC["TimeIn_"] = dtOut;

                                // change time out
                                //TimeSpan tO = new TimeSpan(ConverttoInt(drDs["EndHour"].ToString()), ConverttoInt(drDs["EndMinute"].ToString()), 0);
                                //dtOut = dtOut.Date + tO;
                                drC["TimeOut_"] = dtOutActual;

                                // OT and Status
                                drC["WrkDay"] = dtOut.Date;
                                drC["OTDay"] = "";
                                drC["Status"] = "ควบกะ";

                                string daycurr = dtOut.DayOfWeek.ToString();
                                var index = Array.FindIndex(dayEng, row => row.Contains(daycurr));
                                drC["WRK_NAME"] = dayThai[index];


                                dtForAdd.Rows.Add(drC.ItemArray);
                                dtCopy.Rows.Clear();

                            }
                        }
                        else
                        {
                            //กลางวันควบกะ

                            drr["TimeOut_"] = dtOut;

                            DataRow drDs = dtstandard.Select("WrkCode = 'N' ").FirstOrDefault();
                            if (drDs != null)
                            {
                                TimeSpan ts = new TimeSpan(ConverttoInt(drDs["EndHour"].ToString()), ConverttoInt(drDs["EndMinute"].ToString()), 0);
                                dtOut = dtOut.AddDays(1).Date + ts;
                            }


                            if (dtOut <= dtOutActual)
                            {
                                dtCopy.Rows.Add(drr.ItemArray);

                                DataRow drC = dtCopy.Rows[0];

                                // change time in
                                TimeSpan tI = new TimeSpan(ConverttoInt(drDs["StartHour"].ToString()), ConverttoInt(drDs["StartMinute"].ToString()), 0);
                                dtOut = dtOut.Date + tI;
                                drC["TimeIn_"] = dtOut;

                                // change time out
                                TimeSpan tO = new TimeSpan(ConverttoInt(drDs["EndHour"].ToString()), ConverttoInt(drDs["EndMinute"].ToString()), 0);
                                dtOut = dtOut.Date + tO;
                                drC["TimeOut_"] = dtOut;


                                // OT and Status
                                drC["WrkDay"] = dtOut.Date;
                                drC["OTDay"] = "";
                                drC["Status"] = "ควบกะ";
                                //drC["TotalHours"] = dtOutActual - dtOut;


                                string daycurr = dtOut.DayOfWeek.ToString();
                                var index = Array.FindIndex(dayEng, row => row.Contains(daycurr));
                                drC["WRK_NAME"] = dayThai[index];


                                dtForAdd.Rows.Add(drC.ItemArray);
                                dtCopy.Rows.Clear();
                            }




                        }
                        drr["Status"] = "ปกติ";
                        drr["OTDay"] = "";



                    }
                }
                foreach (DataRow drr in dtForAdd.Rows)
                {
                    _dtATD.Rows.Add(drr.ItemArray);
                }
                return _dtATD;
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _dtATD;
            }
        }






        #region DTP have value ?
        private void dtpWorkDayTo_CloseUp_1(object sender, EventArgs e)
        {
            Filter_Data.Enabled = true;
            string WorkDayToSTR = null;
            string i = "";
            this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
            WorkDayToSTR = dtpWorkDayTo.Value.ToString();
            foreach (DataRow drr3 in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayTo.Value;
                DateTime dtWrk = (DateTime)drr3["WrkDay"];
                if (i == "ไม่ว่าง")
                {
                    this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
                    WorkDayToSTR = dtpWorkDayTo.Value.ToString();
                    button1WasClicked2 = true;
                    if (WorkDayToSTR != null && button1WasClicked2)
                    {

                        DocumenKeyTimeTo = WorkDayToSTR;
                    }
                    
                    break;
                }

                if (dtpWorkDayForm.Value > dtpWorkDayTo.Value)
                {
                    MessageBox.Show(" Your selected Date Day form is incorect cause day from value must have less value than day to ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtpWorkDayTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                    return;
                }

                if (drr3["WrkDay"] != null)
                {

                    if (dtWD == (DateTime)drr3["WrkDay"])
                    {
                        MessageBox.Show(" Your selected Date is OK ", "Correct", MessageBoxButtons.OK, MessageBoxIcon.None);
                        i = "ไม่ว่าง";
                    }
                    continue;

                }

            }
            if (i == "ไม่ว่าง")
            {
                return;
            }
            foreach (DataRow drr in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayTo.Value;
                DateTime dtWrk = (DateTime)drr["WrkDay"];

                if (drr["WrkDay"] != null)
                {

                    if (dtWD == (DateTime)drr["WrkDay"])
                    {
                        continue;
                    }
                    else
                    {
                        button1WasClicked2 = true;
                        MessageBox.Show(" Your select Date was out of range ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dtpWorkDayTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                        //this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
                        WorkDayToSTR = dtpWorkDayTo.Value.ToString();
                        if (WorkDayToSTR != null && button1WasClicked2)
                        {
                            dtpWorkDayTo.Format = DateTimePickerFormat.Custom;
                            dtpWorkDayTo.CustomFormat = " ";
                            DocumenKeyTimeTo = "";
                        }
                        break;
                    }
                }


            }
            
        }
                #endregion

        private void dtpWorkDayForm_CloseUp(object sender, EventArgs e)
        {
            Filter_Data.Enabled = true;
            string WorkDayFromSTR = null;
            string i = "";
            this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
            WorkDayFromSTR = dtpWorkDayForm.Value.ToString();
            foreach (DataRow drr2 in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayForm.Value;
                DateTime dtWrk = (DateTime)drr2["WrkDay"];
               
                this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
                WorkDayFromSTR = dtpWorkDayForm.Value.ToString();

                if (i == "ไม่ว่าง")
                {
                    button1WasClicked = true;
                    

                    if (WorkDayFromSTR != null && button1WasClicked)
                    {
                        DocumenKeyTimeFrom = WorkDayFromSTR;
                    }
                    break;
                }

                if (dtpWorkDayForm.Value > dtpWorkDayTo.Value)
                {
                    MessageBox.Show(" Your selected Date Day form is incorect cause day from value must have less value than day to ", "Incorect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dtpWorkDayForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    return;
                }


                if (drr2["WrkDay"] != null)
                {

                    if (dtWD == (DateTime)drr2["WrkDay"])
                    {

                        MessageBox.Show(" Your selected Date is OK ", "Correct", MessageBoxButtons.OK, MessageBoxIcon.None);
                        i = "ไม่ว่าง";
                    }
                    continue;

                }

            }
            if (i == "ไม่ว่าง")
            {
                return;
            }
            foreach (DataRow drr in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayForm.Value;
                DateTime dtWrk = (DateTime)drr["WrkDay"];

                if (drr["WrkDay"] != null)
                {

                    if (dtWD == (DateTime)drr["WrkDay"])
                    {
                        continue;
                    }
                    else
                    {
                        MessageBox.Show(" Your select Date was out of range ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dtpWorkDayForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        button1WasClicked = true;
                        if (WorkDayFromSTR != null && button1WasClicked)
                        {
                            dtpWorkDayForm.Format = DateTimePickerFormat.Custom;
                            dtpWorkDayForm.CustomFormat = " ";
                          
                            DocumenKeyTimeFrom = "";
                        }
                        break;
                    }
                }

            }
            
        }
    




        #region All Combobox SelectedValue

        private void comboBoxEMP_SelectedValueChanged(object sender, EventArgs e)
        {
            string EMP_IDSTR = null;
            EMP_IDSTR = comboBoxEMP.SelectedValue.ToString();
            if (comboBoxEMP.Text == "System.Data.DataRowView")
            {
                EMP_IDSTR = "";
            }
            if (EMP_IDSTR == comboBoxEMP.SelectedValue.ToString())
            {
                button1WasClicked = true;
                if (EMP_IDSTR == "0")
                {
                    EMP_IDSTR = "";
                }
                Filter_Data.Enabled = true;
                DocumenKeysEMPID = EMP_IDSTR.ToString();
            }
        }

     

        private void comboBoxDAY_SelectedValueChanged(object sender, EventArgs e)
        {
            string DaySTR = null;
            DaySTR = comboBoxDAY.Text;
            if (comboBoxDAY.Text != "System.Data.DataRowView")
            {
                button1WasClicked = true;
                Filter_Data.Enabled = true;

                if (comboBoxDAY.Text == "วันจันทร์")
                {
                    DocumenKeyDay = "MON";
                }
                if (comboBoxDAY.Text == "วันอังคาร")
                {
                    DocumenKeyDay = "TUE";
                }
                if (comboBoxDAY.Text == "วันพุธ")
                {
                    DocumenKeyDay = "WED";
                }
                if (comboBoxDAY.Text == "วันพฤหัสบดี")
                {
                    DocumenKeyDay = "THU";
                }
                if (comboBoxDAY.Text == "วันศุกร์")
                {
                    DocumenKeyDay = "FRI";
                }
                if (comboBoxDAY.Text == "วันเสาร์")
                {
                    DocumenKeyDay = "SAT";
                }
                if (comboBoxDAY.Text == "วันอาทิตย์")
                {
                    DocumenKeyDay = "SUN";
                }
                if (comboBoxDAY.Text == "- All -")
                {
                    DocumenKeyDay = "";
                }
            }

        }
        private void comboBoxRemark_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string RemarkSTR = null;
            RemarkSTR = comboBoxRemark.Text;
            if (comboBoxRemark.Text != "System.Data.DataRowView")
            {
                button1WasClicked = true;
                Filter_Data.Enabled = true;
                if (RemarkSTR == comboBoxRemark.Text)
                {
                    if (comboBoxRemark.Text == "ไม่มีเวลาเข้า")
                    {
                        RemarkSTR = "ไม่มีเวลาเข้า";
                    }
                    if (comboBoxRemark.Text == "ไม่มีเวลาออก")
                    {
                        RemarkSTR = "ไม่มีเวลาออก";
                    }
                    if (comboBoxRemark.Text == "ไม่มีเวลาเข้า,ไม่มีเวลาออก")
                    {
                        RemarkSTR = "ไม่มีเวลาเข้า,ไม่มีเวลาออก";
                    }
                    if (comboBoxRemark.Text == "ลาออก")
                    {
                        RemarkSTR = "ลาออก";
                    }
                    if (comboBoxRemark.Text == "- All -")
                    {
                        RemarkSTR = "";
                    }
                    DocumenKeyRemark = RemarkSTR;
                }
            }
        }

       
        private void comboBoxStatus_SelectedValueChanged_1(object sender, EventArgs e)
        {
            string StatusSTR1 = "";
            StatusSTR1 = comboBoxStatus.Text;
            if (comboBoxStatus.Text != "System.Data.DataRowView")
            {
                button1WasClicked = true;
                Filter_Data.Enabled = true;
                if (comboBoxStatus.Text == "วันหยุด")
                {
                    StatusSTR1 = "H";
                }
                if (comboBoxStatus.Text == "ขาดงาน")
                {
                    StatusSTR1 = "ขาดงาน";
                }

                if (comboBoxStatus.Text == "สาย")
                {
                    StatusSTR1 = "สาย";
                }
                if (comboBoxStatus.Text == "ออกก่อน")
                {
                    StatusSTR1 = "ออกก่อน";
                }
                if (comboBoxStatus.Text == "ปกติ")
                {
                    StatusSTR1 = "ปกติ";
                }
                if (comboBoxStatus.Text == "สาย,ออกก่อน")
                {
                    StatusSTR1 = "สาย,ออกก่อน";
                }
                if (comboBoxStatus.Text == "ยังไม่ลงทะเบียน")
                {
                    StatusSTR1 = "ยังไม่ลงทะเบียน";
                }
                if (comboBoxStatus.Text == "- All -")
                {
                    StatusSTR1 = "";
                    DocumenKeyStatus1 = StatusSTR1;

                }
                if (comboBoxStatus.Text == "ควบกะ")
                {
                   
                    StatusSTR1 = "ควบกะ";
                    
                    DocumenKeyStatus1 = StatusSTR1;

                }
              
                if (StatusSTR1 != "")
                {
                    DocumenKeyStatus1 = StatusSTR1;
                }


            }
        }
     

        private void checkBoxOT_CheckedChanged(object sender, EventArgs e)
        {
            string OTSTR = null;

            if (checkBoxOT.Checked == true)
            {
                button1WasClicked = true;
                Filter_Data.Enabled = true;
                OTSTR = "โอที";
                DocumenKeyOT = OTSTR;
            }
            else
            {
                button1WasClicked = true;
                Filter_Data.Enabled = true;

                OTSTR = "";
                DocumenKeyOT = OTSTR;
            }

        }

        private void comboBoxSHITF_SelectedValueChanged(object sender, EventArgs e)
        {
            string a = comboBoxSHITF.SelectedValue.ToString();
            if (comboBoxSHITF.Text != "System.Data.DataRowView")
            {
                button1WasClicked = true;
                if (comboBoxSHITF.SelectedValue != null)
                {
                    Filter_Data.Enabled = true;
                    if (comboBoxSHITF.SelectedValue.ToString() == "- All -")
                    {
                        a = "";
                        DocumenShift = a;
                        return;
                    }
                    a = comboBoxSHITF.Text;
                    DocumenShift = a;

                }
            }
        }
        private void comboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            string b = comboBoxType.SelectedValue.ToString();
            if (comboBoxType.Text != "System.Data.DataRowView")
            {
                button1WasClicked = true;
                if (comboBoxType.SelectedValue != null)
                {
                    Filter_Data.Enabled = true;
                    if (comboBoxType.Text.ToString() == "- All -")
                    {
                        b = "";
                        Type = b;
                        return;
                    }
                    b = comboBoxType.SelectedValue.ToString();
                    if (b == "1")
                    {
                        b = "'Cleaner A' and 'Cleaner C'";
                    }
                    if (b == "2")
                    {
                        b = "Kumku";
                    } 
                    if (b == "3")
                    {
                        b = "Trinee";
                    } 
                    if (b == "4")
                    {
                        b = "'Nurse 1' and 'Nurse 2'";
                    }
                    
                    Type = b;

                }
            }
        }
         
      
        #endregion
        private void SetComboBox()
        {

            #region Day
            {
                DataView dv;
                DataTable dt = this._SqlMasterManeger.GetATD_DayPerWeekList2();
                DataRow dr = dt.NewRow();
                dr["DPW_ID"] = "0";
                dr["DPW_Desc"] = "- All -";
                dt.Rows.Add(dr);
                dv = dt.DefaultView;
                dv.Sort = "DPW_ID  asc";
               
                this.comboBoxDAY.DataSource = dt;
                this.comboBoxDAY.DisplayMember = "DPW_Desc";
              
            }
            #endregion

            #region Shift Type
            {
                DataView dv;
                DataTable dt4 = this._SqlMasterManeger.GetATD_ShiftTypeList2();
                DataRow dr = dt4.NewRow();
                dt4.Rows.Add(dr);
                dv = dt4.DefaultView;
                dv.Sort = "Day_or_Night asc";
                dr["Day_or_Night"] = "- All -";
                this.comboBoxSHITF.DataSource = dv;
                this.comboBoxSHITF.DisplayMember = "Day_or_Night";
                this.comboBoxSHITF.ValueMember = "Day_or_Night";
            }
            #endregion

     


            #region  Employee ID
            {

                DataTable dt6 = this._SqlMasterManeger.GetATD_EmployeeList2();
                DataRow dr = dt6.NewRow();
                dr["EMP_ID"] = 0;
                dr["EMP_FName2"] = "- All -";
                dt6.Rows.Add(dr);
                DataView dv;
                dv = dt6.DefaultView;
                dv.Sort = "EMP_ID asc";
                this.comboBoxEMP.DataSource = dv;
                this.comboBoxEMP.DisplayMember = "EMP_FName2";
                this.comboBoxEMP.ValueMember = "EMP_ID";

            }
            #endregion

            #region Status
            {
                DataView dv2;
                DataTable dt7 = this._SqlMasterManeger.GetATD_TypeScanList("1");
                DataRow dr = dt7.NewRow();
                dr["Type_Scan_Desc"] = "-";
                dr["Type_Scan_Desc"] = "- All -";
                dt7.Rows.Add(dr);
                dv2 = dt7.DefaultView;
                dv2.Sort = "Type_Scan_ID";
                this.comboBoxStatus.DataSource = dv2;
                this.comboBoxStatus.DisplayMember = "Type_Scan_Desc";
                this.comboBoxStatus.ValueMember = "Type_Scan_Desc";
            }
            #endregion



            #region Remark
            {
                DataTable dt8 = this._SqlMasterManeger.GetATD_RemarkScanList();
                DataView dv2;
                DataRow dr = dt8.NewRow();
                dr["Scan_Remark_ID"] = "0";
                dr["Scan_Remark_Desc"] = "- All -";
                dt8.Rows.Add(dr);
                dv2 = dt8.DefaultView;
                dv2.Sort = "Scan_Remark_ID";
                this.comboBoxRemark.DataSource = dv2;
                this.comboBoxRemark.DisplayMember = "Scan_Remark_Desc";
                this.comboBoxRemark.ValueMember = "Scan_Remark_ID";
            }
            #endregion

            #region Type
            {
                DataTable dt9 = this._SqlMasterManeger.GetATD_EmployeeTypeList();
                DataView dv2;
                DataRow dr = dt9.NewRow();
                dr["EMP_Type_Desc"] = "0";
                dr["EMP_Type_Desc"] = "- All -";
                dt9.Rows.Add(dr);
                dv2 = dt9.DefaultView;
                dv2.Sort = "EMP_Type_Desc";
                this.comboBoxType.DataSource = dv2;
                this.comboBoxType.DisplayMember = "EMP_Type_Desc";
                this.comboBoxType.ValueMember = "EMP_Type_ID";
            }
            #endregion

        }

       

        #region propotile
        public string DocumenKeysEMPID
        {
            get { return _documentKey1; }
            set { _documentKey1 = value; }
        }
        public string DocumenKeyTeamCode
        {
            get { return _documentKey2; }
            set { _documentKey2 = value; }
        }
        public string DocumenKeyDay
        {
            get { return _documentKey3; }
            set { _documentKey3 = value; }
        }
        public string DocumenKeyOT
        {
            get { return _documentKey4; }
            set { _documentKey4 = value; }
        }

        public string DocumenKeyRemark
        {
            get { return _documentKey6; }
            set { _documentKey6 = value; }
        }
        public string DocumenKeyStatus1
        {
            get { return _documentKey7; }
            set { _documentKey7 = value; }
        }

        public string DocumenKeyTimeFrom
        {
            get { return _documentKey12; }
            set { _documentKey12 = value; }
        }
        public string DocumenKeyTimeTo
        {
            get { return _documentKey9; }
            set { _documentKey9 = value; }
        }

        public string DocumenKeys
        {
            get { return _documentDKey; }
            set { _documentDKey = value; }

        }

        public string DocumenShift
        {
            get { return SHITF; }
            set { SHITF = value; }

        }
        public string DocumenType
        {
            get { return SHITF; }
            set { SHITF = value; }

        }
        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            button3WasClicked = true;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            string expressionTimeIN_OT = "IOMd = 0 or IOMd = 2";
            string expressionTimeOUT = "IOMd = 1";
            this._dtATD.Rows.Clear();
            this._dtATD.Merge(this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(DocumenKeysEMPID, "", DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, DocumenShift,Type));
            this._dtImportfile.Rows.Clear();
            this._dtImportfile2.Rows.Clear();
            this._dtImportfile.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeIN_OT).CopyToDataTable());
            this._dtImportfile2.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeOUT).CopyToDataTable());
            if (_dtATD.Rows.Count > 0)
            {
                setValue();
            }
            setReport();
            
          
        }
        private int ConverttoInt(string Value)
        {
            int result = 0;
            bool fack;

            fack = int.TryParse(Value, out result);

            return result;

        }
        #region CurrentRow selected
        private void dgvATD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvATD.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvATD.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvATD.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvATD.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvATD.CurrentRow.Selected = true;
        }
        #endregion

        private void dgvTimeIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvTimeIN.CurrentRow.Selected = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.dgvTimeIN.CurrentRow.Selected = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.dgvTimeIN.CurrentRow.Selected = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.dgvTimeIN.CurrentRow.Selected = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.dgvTimeIN.CurrentRow.Selected = true;
        }

        private void dgvTimeOUT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvTimeOUT.CurrentRow.Selected = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.dgvTimeOUT.CurrentRow.Selected = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.dgvTimeOUT.CurrentRow.Selected = true;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.dgvTimeOUT.CurrentRow.Selected = true;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.dgvTimeOUT.CurrentRow.Selected = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2||tabControl1.SelectedIndex == 3)
            {
                groupBox1.Enabled = false;
               
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void TSBRefreshIN_Click(object sender, EventArgs e)
        {
            string expressionTimeIN_OT = "IOMd = 0 or IOMd = 2";
            string expressionTimeOUT = "IOMd = 1";
            this._dtATD.Rows.Clear();
            this._dtATD.Merge(this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(DocumenKeysEMPID, "", DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, DocumenShift, Type));
            this._dtImportfile.Rows.Clear();
            this._dtImportfile2.Rows.Clear();
            this._dtImportfile.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeIN_OT).CopyToDataTable());
            this._dtImportfile2.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeOUT).CopyToDataTable());
            if (_dtATD.Rows.Count > 0)
            {
                setValue();
            }
            setReport();
        }

        private void TSBRefreshOUT_Click(object sender, EventArgs e)
        {
            string expressionTimeIN_OT = "IOMd = 0 or IOMd = 2";
            string expressionTimeOUT = "IOMd = 1";
            this._dtATD.Rows.Clear();
            this._dtATD.Merge(this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(DocumenKeysEMPID, "", DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, DocumenShift, Type));
            this._dtImportfile.Rows.Clear();
            this._dtImportfile2.Rows.Clear();
            this._dtImportfile.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeIN_OT).CopyToDataTable());
            this._dtImportfile2.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL().Select(expressionTimeOUT).CopyToDataTable());
            if (_dtATD.Rows.Count > 0)
            {
                setValue();
            }
            setReport();
        }













    }
}

