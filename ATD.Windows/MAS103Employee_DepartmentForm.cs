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
    public partial class MAS103Employee_DepartmentForm : Form
    {
        
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployee_Department = null;
        DataRow dr = null;
        public MAS103Employee_DepartmentForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployee_Department = new DataTable();
            this._dtEmployee_Department = this._SqlMasterManager.GetATD_EmployeeDepartmentList();
            this.SetGrid();
            this.SetObject();
            this.BindingSource();

        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvDEP.ReadOnly = true;
            this.dgvDEP.AutoGenerateColumns = false;
            this.dgvDEP.EnableHeadersVisualStyles = false;
            this.dgvDEP.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            ////EMP_Dep_ID
            ////                                      ,EMP_Dep_Desc
            //                                      ,Activated
            //                                      ,Created_by
            //                                      ,Created_Time
            //                                      ,Updated_by
            //                                      ,Updated_Time


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Dep_ID";
            ColumnText.DataPropertyName = "EMP_Dep_ID";
            ColumnText.HeaderText = "รหัสเเผนก";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvDEP.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Dep_Desc";
            ColumnText.DataPropertyName = "EMP_Dep_Desc";
            ColumnText.HeaderText = "คำอธิบายเเผนก";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvDEP.Columns.Add(ColumnText);

            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "EMP_Title_Activated";
            CheckColumn.DataPropertyName = "EMP_Title_Activated";
            CheckColumn.HeaderText = "สถานะการนำมาใช้งาน";
            CheckColumn.Width = 150;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvDEP.Columns.Add(CheckColumn);



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
            this.dgvDEP.Columns.Add(ColumnText);


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
            this.dgvDEP.Columns.Add(ColumnText);

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
            this.dgvDEP.Columns.Add(ColumnText);


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
            this.dgvDEP.Columns.Add(ColumnText);

            this.dgvDEP.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvDEP.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
        #region set Object

        private void SetObject()
        {
            bdsDEP.DataSource = _dtEmployee_Department;
            bdnDEP.BindingSource = bdsDEP;
            this.dgvDEP.DataSource = bdsDEP;
            dgvDEP.ReadOnly = true;
        }

        #endregion

        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsDEP, "EMP_Dep_ID", true);
            this.textBoxEMPID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsDEP, "EMP_Dep_Desc", true);
            this.textBoxEMPdesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsDEP, "Activated", true);
            br.NullValue = false;
            this.checkBoxActivated.DataBindings.Add(br);

        }
        #endregion

        private void Savve2_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvDEP.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvDEP.CurrentRow.Index < dgvDEP.Rows.Count)
                {
                    dgvDEP.FirstDisplayedScrollingRowIndex = er;
                    dgvDEP.Refresh();
                    dgvDEP.CurrentCell = dgvDEP.Rows[er].Cells[0];
                    dgvDEP.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh2_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            this.dgvDEP.CurrentRow.Selected = true;

        }
        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlMasterManager.SaveMastertoDB3(this._dtEmployee_Department, "103");

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

            bdsDEP.EndEdit();
            dgvDEP.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtEmployee_Department.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtEmployee_Department.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["EMP_Dep_ID"].ToString()))
                    {
                        dupicate.Add(dr["EMP_Dep_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["EMP_Dep_ID"].ToString();
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




            foreach (DataRow drr in _dtEmployee_Department.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["EMP_Dep_ID"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Employee Department ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["EMP_Dep_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["EMP_Dep_Desc"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }




            }


            return true;
        }




        private void refresh()
        {
            this._dtEmployee_Department.Rows.Clear();
            this._dtEmployee_Department.Merge(this._SqlMasterManager.GetATD_EmployeeDepartmentList());
        }
        private bool button1WasClicked = false;

        private void textBoxEMPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.dgvDEP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvDEP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvDEP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvDEP.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvDEP.CurrentRow.Selected = true;
        }

        private void dgvDEP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDEP.CurrentRow.Selected = true;
        }
    }
}
