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
    public partial class REP301ReportEmployeeForm : Form
    {
        string _connStr = "";
        string _userID = "";
        
        DataRow dr;
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployee1 = null;
        DataTable _dtEmployee2 = null;
        
        
        public REP301ReportEmployeeForm(string connStr, string userID)
        {
            
         
            InitializeComponent();
            _connStr = connStr;
            _userID = userID;
            this.dgvEMPList.AutoGenerateColumns = false;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployee1 = new DataTable();
            this._dtEmployee1 = this._SqlMasterManager.GetATD_EmployeeList2();
            //this._dtEmployee2 = new DataTable();
            //this._dtEmployee2 = this._SqlMasterManager.GetATD_EmployeeList2();
            this.SetGrid();
            this.SetObject();
            setReport();
        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvEMPList.ReadOnly = true;
            this.dgvEMPList.AutoGenerateColumns = false;
            this.dgvEMPList.EnableHeadersVisualStyles = false;
            this.dgvEMPList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            //EMP_ID
            //                                    ,EMP_Title_ID
            //                                   ,EMP_FName
            //                                   ,EMP_LName
            //                                   , isnull(EMP_Register_Status,0) as EMP_Register_Status	  
            //                                   ,EMP_Register_Date
            //                                   , isnull(EMP_Resigned_Flag,0) as EMP_Resigned_Flag
            //                                   ,EMP_Resigned_Flag_Date
            //                                   ,isnull(EMP_vacation_Flag,0) as EMP_vacation_Flag
            //                                   ,EMP_Type_ID
            //                                   ,EMP_Dep_ID
            //                                   ,WorkDay_ID
            //                                   ,TeamCode
            //                                   ,Created_by
            //                                   ,Created_Time
            //                                   ,Updated_by
            //                                   ,Updated_Time
            //                                   ,Shitf_Type_ID  


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_ID";
            ColumnText.DataPropertyName = "EMP_ID";
            ColumnText.HeaderText = "หมายเลข";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);


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
            this.dgvEMPList.Columns.Add(ColumnText);

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

            this.dgvEMPList.Columns.Add(ColumnText);


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
            this.dgvEMPList.Columns.Add(ColumnText);




            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "EMP_Register_Status";
            CheckColumn.DataPropertyName = "EMP_Register_Status";
            CheckColumn.HeaderText = "สถานะการลงทะเบียน";
            CheckColumn.Width = 110;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(CheckColumn);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Register_Date";
            ColumnText.DataPropertyName = "EMP_Register_Date";
            ColumnText.HeaderText = "วันที่ลงทะเทียน";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvEMPList.Columns.Add(ColumnText);

            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "EMP_Resigned_Flag";
            CheckColumn.DataPropertyName = "EMP_Resigned_Flag";
            CheckColumn.HeaderText = "สถานะกาารลาออก";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(CheckColumn);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Resigned_Flag_Date";
            ColumnText.DataPropertyName = "EMP_Resigned_Flag_Date";
            ColumnText.HeaderText = "วันที่ลาออก";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_vacation_Flag";
            ColumnText.DataPropertyName = "EMP_vacation_Flag";
            ColumnText.HeaderText = "สถานะวันหยุดตามประเพณี";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Type_ID2";
            ColumnText.DataPropertyName = "EMP_Type_ID2";
            ColumnText.HeaderText = "ประเภทของพนักงาน";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Dep_ID";
            ColumnText.DataPropertyName = "EMP_Dep_ID";
            ColumnText.HeaderText = "เเผนก";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WorkDay_ID";
            ColumnText.DataPropertyName = "WorkDay_ID";
            ColumnText.HeaderText = "วันทำงานของเเต่ละทีม";
            ColumnText.Width = 200;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "TeamCode";
            ColumnText.DataPropertyName = "TeamCode";
            ColumnText.HeaderText = "ทีม";
            ColumnText.Width = 80;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Shitf_Type_ID";
            ColumnText.DataPropertyName = "Shitf_Type_ID";
            ColumnText.HeaderText = "กะ";
            ColumnText.Width = 80;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.Visible = false;
            this.dgvEMPList.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "Created_by";
            ColumnText.DataPropertyName = "Created_by";
            ColumnText.HeaderText = "Created_by";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "Created_Time";
            ColumnText.DataPropertyName = "Created_Time";
            ColumnText.HeaderText = "Created Time";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "Updated_by";
            ColumnText.DataPropertyName = "Updated_by";
            ColumnText.HeaderText = "Updated by";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Visible = false;
            ColumnText.Name = "Updated_Time";
            ColumnText.DataPropertyName = "Updated_Time";
            ColumnText.HeaderText = "Updated Time";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMPList.Columns.Add(ColumnText);

            this.dgvEMPList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvEMPList.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
          private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;

            ReportDataSource datasource3 = new ReportDataSource("DataSet1", _dtEmployee1);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(datasource3);




            reportViewer1.RefreshReport();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }
        private void REP301ReportEmployeeForm_Load(object sender, EventArgs e)
        {
            //reportViewer1.RefreshReport();
        }
        private void SetObject()
        {

            this.bdsReportListEMP.DataSource = _dtEmployee1;
            this.bdnReportList.BindingSource = bdsReportListEMP;
            this.dgvEMPList.DataSource = bdsReportListEMP;
            dgvEMPList.ReadOnly = true;
        }

     

       
    }
}
