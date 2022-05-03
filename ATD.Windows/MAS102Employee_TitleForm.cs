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
    public partial class MAS102Employee_TitleForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployeeTitle = null;
        DataRow dr = null;

        public MAS102Employee_TitleForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this.dgvTitle.AutoGenerateColumns = false;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployeeTitle = new DataTable();
            this._dtEmployeeTitle = this._SqlMasterManager.GetATD_EmployeeTitleList();
            this.SetObject();
            this.SetGrid();
            this.BindingSource();
            
        }
        #region set Object

        private void SetObject()
        {          
            bdsTitle.DataSource = _dtEmployeeTitle;
            bdnTitle.BindingSource = bdsTitle;
            this.dgvTitle.DataSource = bdsTitle;
            dgvTitle.ReadOnly = true;
        }

        #endregion
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvTitle.ReadOnly = true;
            this.dgvTitle.AutoGenerateColumns = false;
            this.dgvTitle.EnableHeadersVisualStyles = false;
            this.dgvTitle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            //EMP_Title_ID
            //                                      ,EMP_Title_Desc
            //                                      ,EMP_Title_Activated
            //                                      ,Created_by
            //                                      ,Created_Time
            //                                      ,Updated_by
            //                                      ,Updated_Time


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Title_ID";
            ColumnText.DataPropertyName = "EMP_Title_ID";
            ColumnText.HeaderText = "รหัสคำนำหน้า";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTitle.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Title_Desc";
            ColumnText.DataPropertyName = "EMP_Title_Desc";
            ColumnText.HeaderText = "คำอธิบายคำนำหน้า";
            ColumnText.Width = 150;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvTitle.Columns.Add(ColumnText);

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
            this.dgvTitle.Columns.Add(CheckColumn);



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
            this.dgvTitle.Columns.Add(ColumnText);


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
            this.dgvTitle.Columns.Add(ColumnText);

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
            this.dgvTitle.Columns.Add(ColumnText);


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
            this.dgvTitle.Columns.Add(ColumnText);

            this.dgvTitle.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvTitle.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsTitle, "EMP_Title_ID", true);
            this.textBoxTltleID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsTitle, "EMP_Title_Desc", true);
            this.textBoxTitledesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsTitle, "EMP_Title_Activated", true);
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

            int result = this._SqlMasterManager.SaveMastertoDB2(this._dtEmployeeTitle, "102");

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

            bdsTitle.EndEdit();
            dgvTitle.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtEmployeeTitle.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtEmployeeTitle.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["EMP_Title_ID"].ToString()))
                    {
                        dupicate.Add(dr["EMP_Title_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["EMP_Title_ID"].ToString();
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



            
            foreach (DataRow drr in _dtEmployeeTitle.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["EMP_Title_ID"].ToString().Length == 0  )
                {

                    MessageBox.Show("Not null Title ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }
                

                if (drr["EMP_Title_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["EMP_Title_Desc"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



               
            }


            return true;
        }




        private void refresh()
        {
            this._dtEmployeeTitle.Rows.Clear();
            this._dtEmployeeTitle.Merge(this._SqlMasterManager.GetATD_EmployeeTitleList());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvTitle.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvTitle.CurrentRow.Index < dgvTitle.Rows.Count)
                {
                    dgvTitle.FirstDisplayedScrollingRowIndex = er;
                    dgvTitle.Refresh();
                    dgvTitle.CurrentCell = dgvTitle.Rows[er].Cells[0];
                    dgvTitle.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else 
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void textBoxTltleID_KeyPress(object sender, KeyPressEventArgs e)
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
        private bool button1WasClicked = false;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            this.dgvTitle.CurrentRow.Selected = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
            button1WasClicked = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
        }

        private void dgvTitle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvTitle.CurrentRow.Selected = true;
        }
    }
}
