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
    public partial class MAS105VacationForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployee_Vacation = null;
        DataRow dr = null;
        public MAS105VacationForm(string connStr, string userID)
        {
            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployee_Vacation = new DataTable();
            this._dtEmployee_Vacation = this._SqlMasterManager.GetATD_VacationList();
            this.dgvVacation.AutoGenerateColumns = false;
            this.SetObject();
            this.SetGrid();
            this.BindingSource();
        }
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvVacation.ReadOnly = true;
            this.dgvVacation.AutoGenerateColumns = false;
            this.dgvVacation.EnableHeadersVisualStyles = false;
            this.dgvVacation.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            ///////VA_ID
            //                                  ,VA_Desc
            //                                  ,VA_Date
            //                                  ,VA_Activated
            //                                      ,Created_by
            //                                      ,Created_Time
            //                                      ,Updated_by
            //                                      ,Updated_Time


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "VA_ID";
            ColumnText.DataPropertyName = "VA_ID";
            ColumnText.HeaderText = "รหัสวันหยุดตามประเพณีของพนักงาน";
            ColumnText.Width = 250;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvVacation.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "VA_Desc";
            ColumnText.DataPropertyName = "VA_Desc";
            ColumnText.HeaderText = "คำอธิบายวันหยุดตามประเพณีของพนักงาน";
            ColumnText.Width = 550;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvVacation.Columns.Add(ColumnText);

            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "VA_Date";
            ColumnText.DataPropertyName = "VA_Date";
            ColumnText.HeaderText = "วันที่ของวันหยุดตามประเพณีของพนักงาน";
            ColumnText.Width = 300;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            ColumnText.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dgvVacation.Columns.Add(ColumnText);

            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "VA_Activated";
            CheckColumn.DataPropertyName = "VA_Activated";
            CheckColumn.HeaderText = "สถานะการนำมาใช้งาน";
            CheckColumn.Width = 200;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvVacation.Columns.Add(CheckColumn);



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
            this.dgvVacation.Columns.Add(ColumnText);


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
            this.dgvVacation.Columns.Add(ColumnText);

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
            this.dgvVacation.Columns.Add(ColumnText);


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
            this.dgvVacation.Columns.Add(ColumnText);

            this.dgvVacation.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvVacation.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
        #region set Object

        private void SetObject()
        {
            bdsVacation.DataSource = _dtEmployee_Vacation;
            bdnVacation.BindingSource = bdsVacation;
            this.dgvVacation.DataSource = bdsVacation;
            dgvVacation.ReadOnly = true;
        }

        #endregion

        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsVacation, "VA_ID", true);
            this.textBoxVacationID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsVacation, "VA_Desc", true);
            this.textBoxVacationdesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Value", bdsVacation, "VA_Date", true);
            dtpVacation.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsVacation, "VA_Activated", true);
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

            int result = this._SqlMasterManager.SaveMastertoDB5(this._dtEmployee_Vacation, "105");

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

            bdsVacation.EndEdit();
            dgvVacation.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtEmployee_Vacation.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtEmployee_Vacation.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["VA_ID"].ToString()))
                    {
                        dupicate.Add(dr["VA_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["VA_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Employee Vacation ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }




            foreach (DataRow drr in _dtEmployee_Vacation.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["VA_ID"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Vacation ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["VA_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["VA_Desc"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }
                if (drr["VA_Date"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["VA_Date"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }



            }


            return true;
        }




        private void refresh()
        {
            this._dtEmployee_Vacation.Rows.Clear();
            this._dtEmployee_Vacation.Merge(this._SqlMasterManager.GetATD_VacationList());
        }
        private bool button1WasClicked = false;

        private void Save4_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvVacation.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvVacation.CurrentRow.Index < dgvVacation.Rows.Count)
                {
                    dgvVacation.FirstDisplayedScrollingRowIndex = er;
                    dgvVacation.Refresh();
                    dgvVacation.CurrentCell = dgvVacation.Rows[er].Cells[0];
                    dgvVacation.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh4_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
        }

        private void textBoxVacationID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvVacation.CurrentRow.Selected = true;
        }

        private void dgvVacation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvVacation.CurrentRow.Selected = true;
        }
    }
}
