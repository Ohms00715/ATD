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
    public partial class MAS106Work_DayForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtWorkDay = null;
        DataRow dr = null;
        public MAS106Work_DayForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this.dgvWorkDay.AutoGenerateColumns = false;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtWorkDay = new DataTable();
            this._dtWorkDay = this._SqlMasterManager.GetATD_WorkDayList();
            this.SetObject();
            this.SetGrid();
            this.BindingSource();
            this.SetCombobox();
        }

        private void SetCombobox()
        {
            #region DPW
            {
                DataTable dt =this._SqlMasterManager.GetATD_DayPerWeekList(); ;

                this.comboBoxWorkDayForm.DataSource = dt.Select(" DPW_Activated = 1").CopyToDataTable();
                this.comboBoxWorkDayForm.DisplayMember = "DPW_Desc";
                this.comboBoxWorkDayForm.ValueMember = "DPW_Desc";



                DataTable dt2 =this._SqlMasterManager.GetATD_DayPerWeekList(); ;

                this.comboBoxWorkDayTo.DataSource = dt2.Select(" DPW_Activated = 1").CopyToDataTable();
                this.comboBoxWorkDayTo.DisplayMember = "DPW_Desc";
                this.comboBoxWorkDayTo.ValueMember = "DPW_Desc";
                
            }
            #endregion
        }
        #region set Object

        private void SetObject()
        {
            bdsWorkDay.DataSource = _dtWorkDay;
            bdnWorkDay.BindingSource = bdsWorkDay;
            this.dgvWorkDay.DataSource = bdsWorkDay;
            dgvWorkDay.ReadOnly = true;
        }

        #endregion
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvWorkDay.ReadOnly = true;
            this.dgvWorkDay.AutoGenerateColumns = false;
            this.dgvWorkDay.EnableHeadersVisualStyles = false;
            this.dgvWorkDay.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

          //WorkDay_ID
          //                                    ,WorkDay_Activated
          //                                    ,Created_by
          //                                    ,Created_Time
          //                                    ,Updated_by
          //                                    ,Updated_Time
          //                                    ,WorkDay_From_Day_ID
          //                                    ,WorkDay_To_Day_ID


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WorkDay_ID";
            ColumnText.DataPropertyName = "WorkDay_ID";
            ColumnText.HeaderText = "รูปเเบบวันทำงานของพนักงานเเต่ละทีม";
            ColumnText.Width = 250;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvWorkDay.Columns.Add(ColumnText);


          

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WorkDay_From_Day_ID";
            ColumnText.DataPropertyName = "WorkDay_From_Day_ID";
            ColumnText.HeaderText = "วันทำงานของพนักงานเเต่ละทีมตั้งเเต่วัน";
            ColumnText.Width = 300;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvWorkDay.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "WorkDay_To_Day_ID";
            ColumnText.DataPropertyName = "WorkDay_To_Day_ID";
            ColumnText.HeaderText = "วันทำงานของพนักงานเเต่ละทีมถึงวัน";
            ColumnText.Width = 300;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvWorkDay.Columns.Add(ColumnText);

            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "WorkDay_Activated";
            CheckColumn.DataPropertyName = "WorkDay_Activated";
            CheckColumn.HeaderText = "สถานะการนำมาใช้งาน";
            CheckColumn.Width = 200;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvWorkDay.Columns.Add(CheckColumn);



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
            this.dgvWorkDay.Columns.Add(ColumnText);


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
            this.dgvWorkDay.Columns.Add(ColumnText);

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
            this.dgvWorkDay.Columns.Add(ColumnText);


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
            this.dgvWorkDay.Columns.Add(ColumnText);

            this.dgvWorkDay.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvWorkDay.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsWorkDay, "WorkDay_ID", true);
            this.textBoxWorkDayID.DataBindings.Add(br);

            br = null;
            br = new Binding("SelectedValue", bdsWorkDay, "WorkDay_From_Day_ID", true);
            br.NullValue = false;
            this.comboBoxWorkDayForm.DataBindings.Add(br);


            br = null;
            br = new Binding("SelectedValue", bdsWorkDay, "WorkDay_TO_Day_ID", true);
            br.NullValue = false;
            this.comboBoxWorkDayTo.DataBindings.Add(br);


            br = null;
            br = new Binding("Checked", bdsWorkDay, "WorkDay_Activated", true);
            br.NullValue = false;
            this.checkBoxActivated.DataBindings.Add(br);

        }
        #endregion
        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager.SaveMastertoDB6(this._dtWorkDay, "106");

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

            bdsWorkDay.EndEdit();
            dgvWorkDay.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtWorkDay.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtWorkDay.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["WorkDay_ID"].ToString()))
                    {
                        dupicate.Add(dr["WorkDay_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["WorkDay_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Employee Work Day ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }




            foreach (DataRow drr in _dtWorkDay.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["WorkDay_ID"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Employee Work Day ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["WorkDay_From_Day_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["WorkDay_From_Day_ID"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }
                if (drr["WorkDay_To_Day_ID"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["WorkDay_To_Day_ID"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



            }


            return true;
        }




        private void refresh()
        {
            this._dtWorkDay.Rows.Clear();
            this._dtWorkDay.Merge(this._SqlMasterManager.GetATD_WorkDayList());
        }
        private bool button1WasClicked = false;

        private void Save5_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvWorkDay.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvWorkDay.CurrentRow.Index < dgvWorkDay.Rows.Count)
                {
                    dgvWorkDay.FirstDisplayedScrollingRowIndex = er;
                    dgvWorkDay.Refresh();
                    dgvWorkDay.CurrentCell = dgvWorkDay.Rows[er].Cells[0];
                    dgvWorkDay.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh5_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvWorkDay.CurrentRow.Selected = true;
        }

        private void dgvWorkDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvWorkDay.CurrentRow.Selected = true;
        }
    }
}
