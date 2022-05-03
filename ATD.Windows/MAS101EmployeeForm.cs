using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATD.Management;

namespace ATD.Windows
{
    public partial class MAS101EmployeeForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        SqlWorkCalendarManager _SqlWorkCalendarManager = null;
        DataTable _dtEmployee = null;
    
        DataRow dr = null;
     
        public MAS101EmployeeForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
           
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._SqlWorkCalendarManager = new SqlWorkCalendarManager(this._connStr, this._userID);
            this._dtEmployee = new DataTable();

            this._dtEmployee = this._SqlMasterManager.GetATD_EmployeeList();
   
            this.dgvEMP.AutoGenerateColumns = false;
            this.SetCombobox();
            this.SetGrid();
            this.SetObject();
            this.BindingSource();



  
        }

        private void SetCombobox()
        {
            #region Title
            {
                DataTable dt = this._SqlMasterManager.GetATD_EmployeeTitleList();
                
             
                    this.comboBoxTitle.DataSource = dt.Select(" EMP_Title_Activated = 1").CopyToDataTable();
                    this.comboBoxTitle.DisplayMember = "EMP_Title_Desc";
                    this.comboBoxTitle.ValueMember = "EMP_Title_ID";
       
                
            }
            #endregion

            #region Type
            {
                DataTable dt2 = this._SqlMasterManager.GetATD_EmployeeTypeList(); ;

                this.comboBoxType.DataSource = dt2.Select(" EMP_Type_Activated = 1").CopyToDataTable();
                this.comboBoxType.DisplayMember = "EMP_Type_Desc";
                this.comboBoxType.ValueMember = "EMP_Type_ID";
            }
            #endregion

            #region Team

            DataTable dt3 = this._SqlWorkCalendarManager.GetRecordListTeamAndTime().Tables[this._SqlWorkCalendarManager.TablePPINCTTeam];

                this.comboBoxTeam.DataSource = dt3.Select(" Activated = 1").CopyToDataTable();
                this.comboBoxTeam.DisplayMember = "TeamDesc";
                this.comboBoxTeam.ValueMember = "TeamCode";
            
            #endregion

            #region Department
                {
                    DataTable dt4 = this._SqlMasterManager.GetATD_EmployeeDepartmentList();

                    this.comboBoxDep.DataSource = dt4.Select(" Activated = 1").CopyToDataTable();
                    this.comboBoxDep.DisplayMember = "EMP_Dep_Desc";
                    this.comboBoxDep.ValueMember = "EMP_Dep_ID";
                }
            #endregion

            #region Work Per Day
                {
                    DataTable dt5 = this._SqlMasterManager.GetATD_WorkDayList();

                    this.comboBoxWD.DataSource = dt5.Select(" WorkDay_Activated = 1").CopyToDataTable();
                    this.comboBoxWD.DisplayMember = "WorkDay_ID";
                    this.comboBoxWD.ValueMember = "WorkDay_ID";

                }
                #endregion
               
            
            #region  Shift Type
                {
                    DataTable dt6 = this._SqlMasterManager.GetATD_ShiftTypeList();

                    this.comboBoxShitfType.DataSource = dt6.Select(" Shift_Type_ID <> 3").CopyToDataTable();
                    this.comboBoxShitfType.DisplayMember = "Shift_Type_Desc";
                    this.comboBoxShitfType.ValueMember = "Shift_Type_ID";
                }
                #endregion








        }
        #region set Object

        private void SetObject()
        {

            bdsEMP.DataSource = _dtEmployee;
            bdnEMP.BindingSource = bdsEMP;
            this.dgvEMP.DataSource = bdsEMP;
            dgvEMP.ReadOnly = true;
        }

        #endregion

        #region Binding source
        private void BindingSource()
        {
            Binding br;


            br = null;
            br = new Binding("Text", bdsEMP, "EMP_ID", true);
            this.textBoxEMPID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsEMP, "EMP_FName", true);
            this.textBoxFName.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsEMP, "EMP_LName", true);
            this.textBoxLName.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsEMP, "EMP_Resigned_Flag", true);
            this.checkBoxResigned.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsEMP, "EMP_Resigned_Flag_Date", true);
            this.dtpResigned.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsEMP, "EMP_Register_Status", true);
            this.checkBoxRegister.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsEMP, "EMP_Register_Date", true);
            this.dtpRegisterd.DataBindings.Add(br);



            br = null;
            br = new Binding("Checked", bdsEMP, "EMP_vacation_Flag", true);
            this.checkBoxVA.DataBindings.Add(br);


            br = null;
            br = new Binding("SelectedValue", bdsEMP, "EMP_Title_ID", true);
            br.NullValue = false;

            this.comboBoxTitle.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsEMP, "EMP_Type_ID", true);
            br.NullValue = false;
            this.comboBoxType.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsEMP, "TeamCode", true);
            br.NullValue = false;
            this.comboBoxTeam.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsEMP, "EMP_Dep_ID", true);
            br.NullValue = false;
            this.comboBoxDep.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsEMP, "WorkDay_ID", true);
            br.NullValue = false;
            this.comboBoxWD.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsEMP, "Shitf_Type_ID", true);
            br.NullValue = false;
            this.comboBoxShitfType.DataBindings.Add(br);

        
          
            
            
            
            
            //      EMP_ID
      //,EMP_FName
      //,EMP_LName
      //,EMP_Register_Status
      //,EMP_Register_Date
      //,EMP_Resigned_Flag
      //,EMP_Resigned_Flag_Date
      //,Created_by
      //,Created_Time
      //,Updated_by
      //,Updated_Time
      //,EMP_vacation_Flag
      //,EMP_Title_ID
      //,EMP_Type_ID
      //,EMP_Dep_ID
      //,WorkDay_ID
      //,WorkTime_ID
      //,Shift_Team_ID
        }

        #endregion

        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvEMP.ReadOnly = true;
            this.dgvEMP.AutoGenerateColumns = false;
            this.dgvEMP.EnableHeadersVisualStyles = false;
            this.dgvEMP.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            this.dgvEMP.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Title_ID2";
            ColumnText.DataPropertyName = "EMP_Title_ID2";
            ColumnText.HeaderText = "คำนำหน้า";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMP.Columns.Add(ColumnText);
            

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
           
            this.dgvEMP.Columns.Add(ColumnText);


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
            this.dgvEMP.Columns.Add(ColumnText);

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
            this.dgvEMP.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Dep_ID2";
            ColumnText.DataPropertyName = "EMP_Dep_ID2";
            ColumnText.HeaderText = "เเผนก";
            ColumnText.Width = 100;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMP.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "TeamCode2";
            ColumnText.DataPropertyName = "TeamCode2";
            ColumnText.HeaderText = "ทีม";
            ColumnText.Width = 80;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMP.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "Shitf_Type_ID2";
            ColumnText.DataPropertyName = "Shitf_Type_ID2";
            ColumnText.HeaderText = "กะ";
            ColumnText.Width = 80;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMP.Columns.Add(ColumnText);

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
            this.dgvEMP.Columns.Add(ColumnText);


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
            this.dgvEMP.Columns.Add(CheckColumn);


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
            this.dgvEMP.Columns.Add(ColumnText);

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
            this.dgvEMP.Columns.Add(CheckColumn);

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
            this.dgvEMP.Columns.Add(ColumnText);


            CheckColumn = null;
            CheckColumn =  new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "EMP_vacation_Flag";
            CheckColumn.DataPropertyName = "EMP_vacation_Flag";
            CheckColumn.HeaderText = "สถานะวันหยุดตามประเพณี";
            CheckColumn.Width = 100;
            CheckColumn.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvEMP.Columns.Add(CheckColumn);


            

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
            this.dgvEMP.Columns.Add(ColumnText);


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
            this.dgvEMP.Columns.Add(ColumnText);

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
            this.dgvEMP.Columns.Add(ColumnText);


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
            this.dgvEMP.Columns.Add(ColumnText);

            this.dgvEMP.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvEMP.Columns)
           
                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

            }
            #endregion

        



      
        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager.SaveMastertoDB(this._dtEmployee, "101");

            if (result == 1)
            {
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh();


            }
            else
            {
                MessageBox.Show(this._SqlMasterManager.LastError, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            bdsEMP.EndEdit();
            dgvEMP.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtEmployee.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtEmployee.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["EMP_ID"].ToString()))
                    {
                        dupicate.Add(dr["EMP_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["EMP_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Employee ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }



            //
            foreach (DataRow drr in _dtEmployee.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["EMP_ID"].ToString().Length == 0 &&
                    drr["EMP_FName"].ToString().Length == 0 &&
                    drr["EMP_LName"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Employee ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["EMP_FName"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["EMP_FName"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



                if (drr["EMP_LName"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["EMP_LName"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }
                foreach (DataRow drrr in this._SqlMasterManager.GetATD_EmployeeList().Rows)
                {
                    if (drrr.RowState != DataRowState.Deleted)
                    {
                        if (checkBoxResigned.CheckState == 0)
                        {
                            drrr["EMP_Resigned_Flag"] = 0;
                            drrr["EMP_Resigned_Flag_Date"] = DBNull.Value;
                        }

                        if (checkBoxRegister.CheckState == 0)
                        {
                            drrr["EMP_Register_Status"] = 0;

                            drrr["EMP_Register_Date"] = DBNull.Value;


                        }
                        if (this.checkBoxVA.CheckState == 0)
                        {
                            drrr["EMP_vacation_Flag"] = 0;


                        }




                    }
                }
               

            }


            return true;
        }
      
        
        
        
        private void refresh()
        {
            this._dtEmployee.Rows.Clear();
            this._dtEmployee.Merge(this._SqlMasterManager.GetATD_EmployeeList());
           
        }

      
        
        
        
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dr = this._dtEmployee.NewRow();
            this._dtEmployee.Rows.Add(dr);

          
           
           
      
            
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvEMP.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvEMP.CurrentRow.Index < dgvEMP.Rows.Count)
                {
                    dgvEMP.FirstDisplayedScrollingRowIndex = er;
                    dgvEMP.Refresh();
                    dgvEMP.CurrentCell = dgvEMP.Rows[er].Cells[0];
                    dgvEMP.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh1_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            dgvEMP.CurrentRow.Selected = true;
        }
        private bool button1WasClicked = false;

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            dtpResigned.Format = DateTimePickerFormat.Custom;
            dtpResigned.CustomFormat = " ";
            dtpResigned.Enabled = false;
            dtpRegisterd.Format = DateTimePickerFormat.Custom;
            dtpRegisterd.CustomFormat = " ";
            dtpRegisterd.Enabled = false;
            checkBoxResigned.CheckState = 0;
            checkBoxRegister.CheckState = 0;
            checkBoxVA.CheckState = 0;




        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            dgvEMP.CurrentRow.Selected = true;
        }

        private void checkBoxResigned_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxResigned.Enabled = true;
           
            if (checkBoxResigned.CheckState == 0)
            {
                dtpResigned.Format = DateTimePickerFormat.Custom;
                dtpResigned.CustomFormat = " ";
                dtpResigned.Enabled = false;

            }
            else {
                dtpResigned.Format = DateTimePickerFormat.Custom;
                this.dtpResigned.CustomFormat = "dd/MMM/yyyy";
                dtpResigned.Enabled = true;
                
            }
        }

        private void dtpResigned_ValueChanged(object sender, EventArgs e)
        {
            
            if (checkBoxResigned.CheckState == 0)
            {
                dtpResigned.Format = DateTimePickerFormat.Custom;
                dtpResigned.CustomFormat = " ";

                
                


            }
            else
            {
                dtpResigned.Format = DateTimePickerFormat.Custom;
                this.dtpResigned.CustomFormat = "dd/MMM/yyyy";

            }
        }

        private void checkBoxRegister_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxRegister.Enabled = true;
           
            if (checkBoxRegister.CheckState == 0)
            {
                dtpRegisterd.Format = DateTimePickerFormat.Custom;
                dtpRegisterd.CustomFormat = " ";
                dtpRegisterd.Enabled = false;
                


            }
            else
            {
                dtpRegisterd.Format = DateTimePickerFormat.Custom;
                this.dtpRegisterd.CustomFormat = "dd/MMM/yyyy";
                dtpRegisterd.Enabled = true;
            }
        }

        private void textBoxEMPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dgvEMP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            dgvEMP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            dgvEMP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            dgvEMP.CurrentRow.Selected = true;
        }

        private void dgvEMP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            dgvEMP.CurrentRow.Selected = true;
        }

    }
}
