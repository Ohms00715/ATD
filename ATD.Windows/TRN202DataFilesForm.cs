using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ATD.Management;

namespace ATD.Windows
{
    public partial class TRN202DataFilesForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlTransactionImportFilesViewsManager _SqlTransactionImportFilesViewsManager = null;
        SqlMasterManeger _SqlMasterManeger = null;
        SqlWorkCalendarManager _SqlWorkCalendarManager = null;
        DataTable _dtImportfileViews = null;
        DataTable _dtMasterDD = null;
        DataTable _dtDate = null;
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
         string SHITF = "";
        

        public TRN202DataFilesForm(string connStr, string userID)
        {
            InitializeComponent();
            _connStr = connStr;
            _userID = userID;
            this._SqlTransactionImportFilesViewsManager = new SqlTransactionImportFilesViewsManager(this._connStr, this._userID);
            this._SqlMasterManeger = new SqlMasterManeger(this._connStr, this._userID);
            this._SqlWorkCalendarManager = new SqlWorkCalendarManager(this._connStr, this._userID);
            this._dtImportfileViews = new DataTable();
            this._dtDate = new DataTable();
            this._dtDate = this._SqlTransactionImportFilesViewsManager.GetATD_WorkDateTimeList();
            this._dtMasterDD = new DataTable();
            this._dtMasterDD = this._SqlMasterManeger.GetATD_DayPerWeekList();
            this._dtMasterScanType = new DataTable();
            this._dtMasterScanType = _SqlMasterManeger.GetATD_TypeScanList("1");
            this._dtMasterShift_D_or_N = new DataTable();
            this._dtMasterShift_D_or_N = _SqlMasterManeger.GetATD_ShiftTypeList2();
            this._dtImportfileViews = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews("","","","","","","","","","");

            this.SetGrid();

            this.SetObject();
            if (_dtImportfileViews.Rows.Count > 0)
            {
                setValue();
            }
            foreach (DataRow drr in this._dtImportfileViews.Rows)
            {
                SetDTP();
            }

            SetComboBox();
            
        }
        private bool button1WasClicked = false;
        private bool button1WasClicked2 = false;
        private void SelectALL_Click(object sender, EventArgs e)
        {
            this.comboBoxSHITF.SelectedIndex = 0;
            this.comboBoxDAY.SelectedIndex = 0;
            this.comboBoxEMP.SelectedIndex = 0;
            this.comboBoxRemark.SelectedIndex = 0;
            this.comboBoxStatus.SelectedIndex = 0;
            this.comboBoxTEAM.SelectedIndex = 0;
            this.checkBoxOT.CheckState = 0;
            dtpWorkDayForm.Format = DateTimePickerFormat.Custom;
            dtpWorkDayForm.CustomFormat = " ";
            dtpWorkDayTo.Format = DateTimePickerFormat.Custom;
            dtpWorkDayTo.CustomFormat = " ";

            this.Get.Enabled = true; 
            DocumenKeyTimeFrom = "";
            DocumenKeyTimeTo = "";

            this.getData("", "", "", "", "", "", "", "", "","");

        }
        private void SetDTP()
        {
            this.dtpWorkDayForm.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.dtpWorkDayTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            dtpWorkDayForm.Format = DateTimePickerFormat.Custom;
            dtpWorkDayForm.CustomFormat = " ";
            dtpWorkDayTo.Format = DateTimePickerFormat.Custom;
            dtpWorkDayTo.CustomFormat = " ";
            foreach (DataRow drr3 in this._dtImportfileViews.Rows)
            {
                this.dgvImportFilesView.Columns["TimeFrom"].DefaultCellStyle.Format = "HH:mm";
                this.dgvImportFilesView.Columns["TimeTo"].DefaultCellStyle.Format = "HH:mm";
            }
        }
        #region Check DTP have Data ?

        private void dtpWorkDayForm_CloseUp(object sender, EventArgs e)
        {
            this.Get.Enabled = true; 
            button1WasClicked = true;
            string WorkDayFromSTR = null;
            string i = "";
            this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
            WorkDayFromSTR = dtpWorkDayForm.Value.ToString();
            foreach (DataRow drr2 in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayForm.Value;
                DateTime dtWrk = (DateTime)drr2["WrkDay"];

                if (i == "ไม่ว่าง")
                {
                    button1WasClicked = true;
                    this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
                    WorkDayFromSTR = dtpWorkDayForm.Value.ToString();

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
                    dtpWorkDayForm.Format = DateTimePickerFormat.Custom;
                    dtpWorkDayForm.CustomFormat = " ";
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
                button1WasClicked = true;
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
                        this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
                        WorkDayFromSTR = dtpWorkDayForm.Value.ToString();

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

        private void dtpWorkDayTo_CloseUp(object sender, EventArgs e)
        {

            string WorkDayToSTR = null;
            string i = "";
            this.Get.Enabled = true; 
            this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
            WorkDayToSTR = dtpWorkDayTo.Value.ToString();
            foreach (DataRow drr3 in this._dtDate.Rows)
            {
                DateTime dtWD = (DateTime)dtpWorkDayTo.Value;
                DateTime dtWrk = (DateTime)drr3["WrkDay"];
                if (i == "ไม่ว่าง")
                {
                    button1WasClicked2 = true;
                    this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
                    WorkDayToSTR = dtpWorkDayTo.Value.ToString();
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
                    dtpWorkDayTo.CustomFormat = " ";
                    DocumenKeyTimeTo = "";
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
                button1WasClicked2 = true;
                return;
            }
            foreach (DataRow drr in this._dtImportfileViews.Rows)
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
                        MessageBox.Show(" Your select Date was out of range ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dtpWorkDayTo.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                        button1WasClicked2 = true;
                        this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
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
        private void Refresh201_Click(object sender, EventArgs e)
        {
            this.comboBoxSHITF.SelectedIndex = 0;
            this.comboBoxDAY.SelectedIndex = 0;
            this.comboBoxEMP.SelectedIndex = 0;
            this.comboBoxRemark.SelectedIndex = 0;
            this.comboBoxStatus.SelectedIndex = 0;
            this.comboBoxTEAM.SelectedIndex = 0;
            this.checkBoxOT.CheckState = 0;
            refresh();
        }
   
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
                this.comboBoxStatus.DataSource = dv;
                this.comboBoxDAY.DataSource = dt;
                this.comboBoxDAY.DisplayMember = "DPW_Desc";
                this.comboBoxStatus.ValueMember = "DPW_Desc";                            
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

            #region Team Code
            {
                DataView dv;              
                DataTable dt5 = this._SqlWorkCalendarManager.GetRecordListTeamAndTime().Tables[this._SqlWorkCalendarManager.TablePPINCTTeam];
                DataRow dr = dt5.NewRow();
                dt5.Rows.Add(dr);
                dv = dt5.DefaultView;
                dv.Sort = "TeamCode asc";
                dr["TeamCode"] = "- All -";
                this.comboBoxTEAM.DataSource = dv;               
                this.comboBoxTEAM.DisplayMember = "TeamCode";
                this.comboBoxTEAM.ValueMember = "TeamCode";

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

        }


        #region set Object

        private void SetObject()
        {

            bdsImportFileView.DataSource = _dtImportfileViews;
            bdnImportFileView.BindingSource = this.bdsImportFileView;
            this.dgvImportFilesView.DataSource = bdsImportFileView;
            dgvImportFilesView.ReadOnly = true;
        }

        #endregion
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvImportFilesView.ReadOnly = true;
            this.dgvImportFilesView.AutoGenerateColumns = false;
            this.dgvImportFilesView.EnableHeadersVisualStyles = false;
            this.dgvImportFilesView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;



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
            this.dgvImportFilesView.Columns.Add(ColumnText);

         

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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);

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
            this.dgvImportFilesView.Columns.Add(ColumnText);


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
            this.dgvImportFilesView.Columns.Add(ColumnText);








            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "ScoreFull";
            //ColumnText.DataPropertyName = "ScoreFull";
            //ColumnText.HeaderText = "��ṹ���";
            //ColumnText.Width = 130;
            //ColumnText.ReadOnly = true;
            //ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            //ColumnText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ////ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //cobColumn = null;
            //cobColumn = new DataGridViewComboBoxColumn();
            //cobColumn.Name = "Score";
            //cobColumn.DataPropertyName = "Score";
            //cobColumn.HeaderText = "�ѹ�֡\n��ṹ";
            //cobColumn.Width = 130;
            //cobColumn.DefaultCellStyle.Format = "#,###";
            //cobColumn.FlatStyle = FlatStyle.Standard;
            //cobColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //cobColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //cobColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //cobColumn.DefaultCellStyle.BackColor = Color.LightCyan;
            //cobColumn.HeaderCell.Style.BackColor = Color.LightCyan;
            //cobColumn.DefaultCellStyle.ForeColor = Color.Blue;
            //cobColumn.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(cobColumn);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "Remarks";
            //ColumnText.DataPropertyName = "Remarks";
            //ColumnText.HeaderText = "�����˵�";
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.ToolTipText = ColumnText.HeaderText;
            //ColumnText.Width = 220;
            //ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            //ColumnText.DefaultCellStyle.BackColor = Color.LightCyan;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightCyan;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "HeadKey";
            //ColumnText.DataPropertyName = "HeadKey";
            //ColumnText.HeaderText = "HeadKey";
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnText.ToolTipText = ColumnText.HeaderText;
            //ColumnText.Width = 1;
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "TitleKey";
            //ColumnText.DataPropertyName = "TitleKey";
            //ColumnText.HeaderText = "TitleKey";
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnText.ToolTipText = ColumnText.HeaderText;
            //ColumnText.Width = 50;
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "TopicKey";
            //ColumnText.DataPropertyName = "TopicKey";
            //ColumnText.HeaderText = "TopicKey";
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnText.ToolTipText = ColumnText.HeaderText;
            //ColumnText.Width = 50;
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "TopicName";
            //ColumnText.DataPropertyName = "TopicName";
            //ColumnText.HeaderText = "TopicName";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "ItemNoDisplay";
            //ColumnText.DataPropertyName = "ItemNoDisplay";
            //ColumnText.HeaderText = "ItemNoDisplay";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "ScoreUseFlag";
            //ColumnText.DataPropertyName = "ScoreUseFlag";
            //ColumnText.HeaderText = "ScoreUseFlag";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "ScoreFixFlag";
            //ColumnText.DataPropertyName = "ScoreFixFlag";
            //ColumnText.HeaderText = "ScoreFixFlag";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "TopicHeadFlag";
            //ColumnText.DataPropertyName = "TopicHeadFlag";
            //ColumnText.HeaderText = "TopicHeadFlag";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);

            //ColumnText = null;
            //ColumnText = new DataGridViewTextBoxColumn();
            //ColumnText.Name = "TopicTitleFlag";
            //ColumnText.DataPropertyName = "TopicTitleFlag";
            //ColumnText.HeaderText = "TopicTitleFlag";
            //ColumnText.ReadOnly = true;
            //ColumnText.Visible = false;
            //ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnText.DefaultCellStyle.BackColor = Color.Gainsboro;
            //ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            //ColumnText.DefaultCellStyle.ForeColor = Color.Blue;
            //ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            //this.dgvImportFilesView.Columns.Add(ColumnText);


            //
            this.dgvImportFilesView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvImportFilesView.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        }
   
        private void refresh()
        {
            this._dtImportfileViews.Rows.Clear();
            this._dtImportfileViews.Merge(this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews("","","","","","","","","",""));
            if (_dtImportfileViews.Rows.Count > 0)
            {
                setValue();
            }

        }

        private void setValue()
        {
            int TotalMin = 0;
            DateTime d1, d2;
            foreach (DataRow drr in this._dtImportfileViews.Rows)
            {


                /*
                ,0 as TotalMinActual
                ,0.0 as TotalHours
                ,'' as OTDay
                ,'' as Status
                ,'' as Remarks
                 * ,PPINCTWorkCalShift.TimeFrom
                ,PPINCTWorkCalShift.TimeTo
                ,PPINCTWorkCalShift.TotalMin
                 * 
                 */
                TotalMin = 0;

                if (drr["WrkCode"].ToString() == "H")
                {
                    drr["Status"] = "วันหยุด";
                }
                //else
                //{
                //    //if (drr["TimeIn_"].ToString() == "")
                //    //{
                //    //    drr["Remarks"] = "ไม่มีเวลาเข้า";
                //    //}

                //    //if (drr["TimeOut_"].ToString() == "")
                //    //{
                //    //    if (drr["Remarks"].ToString().Length > 0)
                //    //    {
                //    //        drr["Remarks"] += ",";
                //    //    }
                //    //drr["Remarks"] += "ไม่มีเวลาออก";
                //    //}

                if (drr["TimeOut_"].ToString() != "" && drr["TimeIn_"].ToString() != "")
                {
                    TimeSpan span = (DateTime)drr["TimeOut_"] - (DateTime)drr["TimeIn_"];
                    double totalMinutes = span.TotalMinutes;


                    drr["TotalMinActual"] = totalMinutes;
                    int hours = Convert.ToInt32(totalMinutes / 60);
                    int min = Convert.ToInt32(totalMinutes % 60);

                    drr["TotalHours"] = hours + ":" + min;
                }


                //    //    DateTime dtOut = (DateTime)drr["TimeOut_"];
                //    //    DateTime dtOutS = (DateTime)drr["TimeTo"];

                //    //    TimeSpan totalH = new TimeSpan(dtOut.Hour, dtOut.Minute, 0) - new TimeSpan(dtOutS.Hour, dtOutS.Minute, 0);
                //    //    double totalMinutesx = totalH.TotalMinutes;


                //        //drr["OTDay"] = totalMinutesx > 60 ? "โอที" : "";
                //        //drr["Status"] = "ปกติ";
                //    }

                    //if (drr["TimeIn_"].ToString() != "")
                    //{
                    //    DateTime dtOut = (DateTime)drr["TimeIn_"];
                    //    DateTime dtOutS = (DateTime)drr["TimeFrom"];

                    //    TimeSpan totalH = new TimeSpan(dtOut.Hour, dtOut.Minute, 0) - new TimeSpan(dtOutS.Hour, dtOutS.Minute, 0);
                    //    double totalMinutesx = totalH.TotalMinutes;
                    //    if (totalMinutesx > 0)
                    //    {
                    //        //drr["Status"] = "สาย";
                    //    }
                    //}
                    //if (drr["TimeOut_"].ToString() != "")
                    //{
                    //    //DateTime dtOut = (DateTime)drr["TimeOut_"];
                    //    //DateTime dtOutS = (DateTime)drr["TimeTo"];

                    //    //TimeSpan totalH = new TimeSpan(dtOut.Hour, dtOut.Minute, 0) - new TimeSpan(dtOutS.Hour, dtOutS.Minute, 0);
                    //    //double totalMinutesx = totalH.TotalMinutes;
                    //    //if (totalMinutesx < 0)
                    //    //{
                    //    //    //    if (drr["Status"].ToString().Length > 0)
                    //    //    //    {
                    //    //    //        drr["Status"] += ",";
                    //    //    //    }
                    //    //    //    drr["Status"] += "ออกก่อน";
                    //    //    //}
                    //    //}

                    //    //if (drr["TimeOut_"].ToString() == "" && drr["TimeIn_"].ToString() == "" && drr["EMP_Register_Status"] != null && drr["EMP_Register_Status"].ToString() == "True")
                    //    //{
                    //    //    //drr["Status"] = "ขาดงาน";

                    //    //}

                        
                    //    //if (drr["Day_or_Night"].ToString() == "" && drr["WrkCode"].ToString() == "N")
                    //    //{
                    //    //    drr["Day_or_Night"] = "ดึก";
                    //    //}
                    //    //if (drr["Day_or_Night"].ToString() == "" && drr["WrkCode"].ToString() == "M")
                    //    //{
                    //    //    drr["Day_or_Night"] = "เช้า";
                    //    //}


                    //}
                    if (drr["EMP_Register_Status"].ToString() != "True")
                    {
                        //if (drr["Status"].ToString().Length > 0)
                        //{
                        //    drr["Status"] += ",";
                        //}
                        drr["Status"] = "ยังไม่ลงทะเบียน";


                    }


                }
            }
        
        #region bdn cilck
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dgvImportFilesView.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            dgvImportFilesView.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            dgvImportFilesView.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            dgvImportFilesView.CurrentRow.Selected = true;
        }
        private void dgvImportFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImportFilesView.RowCount != 0)
            {
                this.dgvImportFilesView.CurrentRow.Selected = true;
            }
        }

        #endregion


        //private void GETDATA_Click(object sender, EventArgs e)
        //{
           
        //    SelectALL.Enabled = true;
        //    this.getData(DocumenKeysEMPID, DocumenKeyTeamCode, DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, SHITF,"");
        //}

        private void Get_Click(object sender, EventArgs e)
        {
            SelectALL.Enabled = true;
            this.getData(DocumenKeysEMPID, DocumenKeyTeamCode, DocumenKeyDay, DocumenKeyOT, DocumenKeyRemark, DocumenKeyStatus1, DocumenKeyTimeFrom, DocumenKeyTimeTo, SHITF, "");
        }
        private void RefreshData()
        {
         
            if (this._dtImportfileViews != null)
            {
                this._dtImportfileViews.Rows.Clear();
               
            }
        }

        private void getData(string paraEMPID, string paraTeamCode, string paraDay, string paraOT, string paraRemark, string paraStatus, string paraTimeFrom, string paraTimeTo, string paraSHITF, string paraType)
        {
            RefreshData();
            this._dtImportfileViews = this._SqlTransactionImportFilesViewsManager.GetATD_ImportFilesViews(paraEMPID, paraTeamCode, paraDay, paraOT, paraRemark, paraStatus, paraTimeFrom, paraTimeTo, paraSHITF,paraType);

            this._dtImportfileViews = setShiftOT();
            DataView dv;

            dv = this._dtImportfileViews.DefaultView;
            dv.Sort = "ShiftWrkDay asc";


            bdsImportFileView.DataSource = dv;
            bdnImportFileView.BindingSource = this.bdsImportFileView;
            this.dgvImportFilesView.DataSource = bdsImportFileView;
            setValue();
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
                DataTable dtCopy = _dtImportfileViews.Copy();
                DataTable dtForAdd = _dtImportfileViews.Copy();
                dtCopy.Rows.Clear();
                dtForAdd.Rows.Clear();

                foreach (DataRow drr in _dtImportfileViews.Rows)
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
                    _dtImportfileViews.Rows.Add(drr.ItemArray);
	            }
                return _dtImportfileViews;
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return _dtImportfileViews;
            }
        }

        private int ConverttoInt(string Value) 
        {
            int result = 0;
            bool fack;

            fack = int.TryParse(Value,out result);

            return result;

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
                 if (EMP_IDSTR=="0")
                 {
                     EMP_IDSTR = "";
                 }
                 this.Get.Enabled = true;             
                DocumenKeysEMPID = EMP_IDSTR.ToString();
            }
        }
            
        private void comboBoxTEAM_SelectedValueChanged(object sender, EventArgs e)
        {
            string TeamCodeSTR = null;
            TeamCodeSTR = comboBoxTEAM.Text;
            if (comboBoxTEAM.Text == "System.Data.DataRowView")
            {
                TeamCodeSTR = "";
            }
            if (comboBoxTEAM.Text == "- All -")
            {
                TeamCodeSTR = "";
            }
            if (TeamCodeSTR == comboBoxTEAM.SelectedValue.ToString())
            {
                this.Get.Enabled = true;  
                DocumenKeyTeamCode = TeamCodeSTR.ToString();
            }
            if (TeamCodeSTR == "")
            {
                this.Get.Enabled = true;  
                DocumenKeyTeamCode = TeamCodeSTR.ToString();
            }
        }

        private void comboBoxDAY_SelectedValueChanged(object sender, EventArgs e)
        {
            string DaySTR = null;  
            DaySTR = comboBoxDAY.Text;  
            if (comboBoxDAY.Text != "System.Data.DataRowView")
       {
           this.Get.Enabled = true;  

            if (comboBoxDAY.Text =="วันจันทร์")
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

        private void checkBoxOT_CheckedChanged(object sender, EventArgs e)
        {
            string OTSTR = null;

            if (checkBoxOT.Checked == true)
            {
                this.Get.Enabled = true;  
                OTSTR = "โอที";
                DocumenKeyOT = OTSTR;
            }
            else 
            {
                this.Get.Enabled = true;  
                OTSTR = "";
                DocumenKeyOT = OTSTR;
            }
            if (DocumenKeysEMPID != "" || DocumenKeyTeamCode != "" || DocumenKeyDay != "" || DocumenKeyRemark != "" || DocumenKeyStatus1 != "" || DocumenKeyTimeFrom != "" || DocumenKeyTimeTo != "" || SHITF != "" && DocumenKeyOT =="")
            {
                this.Get.Enabled = true;  
                SelectALL.Enabled = false;

            }
        }

        private void comboBoxRemark_SelectedValueChanged(object sender, EventArgs e)
        {   
            string RemarkSTR = null;
            RemarkSTR = comboBoxRemark.Text;
            if (comboBoxRemark.Text != "System.Data.DataRowView")
            {
                this.Get.Enabled = true;  
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

        private void comboBoxStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            string StatusSTR1 = "";
            StatusSTR1 = comboBoxStatus.Text;
            if (comboBoxStatus.Text != "System.Data.DataRowView")
            {
                this.Get.Enabled = true;  
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

        private void comboBoxSHITF_SelectedValueChanged(object sender, EventArgs e)
        {
            string a = comboBoxSHITF.SelectedValue.ToString();
            if (comboBoxSHITF.Text != "System.Data.DataRowView")
            {
                if (comboBoxSHITF.SelectedValue != null)
                {
                    this.Get.Enabled = true;  
                    if (comboBoxSHITF.SelectedValue.ToString() == "- All -")
                    {
                        a = "";
                        SHITF = a;
                        return;
                    }
                    a = comboBoxSHITF.Text;
                    SHITF = a;

                }
            }
        }         

      
        #endregion
       
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
        #endregion

        







    }
    }

