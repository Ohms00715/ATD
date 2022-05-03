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
    public partial class MAS104Employee_TypeForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployee_Type = null;
        DataRow dr = null;
        public MAS104Employee_TypeForm(string connStr, string userID)
        {
            InitializeComponent();
            this.dgvType.AutoGenerateColumns = false;
            this._connStr = connStr;
            this._userID = userID;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployee_Type = new DataTable();
            this._dtEmployee_Type = this._SqlMasterManager.GetATD_EmployeeTypeList();
            this.SetObject();
            this.SetGrid();
            this.BindingSource();
        }
        #region set Object

        private void SetObject()
        {
            bdsType.DataSource = _dtEmployee_Type;
            bdnType.BindingSource = bdsType;
            this.dgvType.DataSource = bdsType;
            dgvType.ReadOnly = true;
        }

        #endregion
        private void SetGrid()
        {

            DataGridViewCheckBoxColumn CheckColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn ColumnText = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn cobColumn = new DataGridViewComboBoxColumn();

            #region Pattern 1
            this.dgvType.ReadOnly = true;
            this.dgvType.AutoGenerateColumns = false;
            this.dgvType.EnableHeadersVisualStyles = false;
            this.dgvType.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            /////EMP_Type_ID
            //                                          ,EMP_Type_Desc
            //                                          ,EMP_Type_Activated
            //                                      ,Created_by
            //                                      ,Created_Time
            //                                      ,Updated_by
            //                                      ,Updated_Time


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Type_ID";
            ColumnText.DataPropertyName = "EMP_Type_ID";
            ColumnText.HeaderText = "รหัสประเภทของพนักงาน";
            ColumnText.Width = 200;
            ColumnText.ReadOnly = true;
            //ColumnText.DefaultCellStyle.Format = "HH:mm";

            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvType.Columns.Add(ColumnText);


            ColumnText = null;
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnText.Name = "EMP_Type_Desc";
            ColumnText.DataPropertyName = "EMP_Type_Desc";
            ColumnText.HeaderText = "คำอธิบายประเภทของพนักงาน";
            ColumnText.Width = 200;
            ColumnText.ReadOnly = true;
            ColumnText.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColumnText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnText.HeaderCell.Style.BackColor = Color.LightGray;
            ColumnText.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvType.Columns.Add(ColumnText);

            CheckColumn = null;
            CheckColumn = new DataGridViewCheckBoxColumn();
            CheckColumn.Name = "EMP_Type_Activated";
            CheckColumn.DataPropertyName = "EMP_Type_Activated";
            CheckColumn.HeaderText = "สถานะการนำมาใช้งาน";
            CheckColumn.Width = 200;
            CheckColumn.ReadOnly = true;
            CheckColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            CheckColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CheckColumn.HeaderCell.Style.BackColor = Color.LightGray;
            CheckColumn.HeaderCell.Style.ForeColor = Color.Blue;
            this.dgvType.Columns.Add(CheckColumn);



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
            this.dgvType.Columns.Add(ColumnText);


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
            this.dgvType.Columns.Add(ColumnText);

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
            this.dgvType.Columns.Add(ColumnText);


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
            this.dgvType.Columns.Add(ColumnText);

            this.dgvType.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
            foreach (DataGridViewColumn c in dgvType.Columns)

                c.DefaultCellStyle.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);

        }
            #endregion
        #region Binding source
        private void BindingSource()
        {
            Binding br;

            br = null;
            br = new Binding("Text", bdsType, "EMP_Type_ID", true);
            this.textBoxTypeID.DataBindings.Add(br);

            br = null;
            br = new Binding("Text", bdsType, "EMP_Type_Desc", true);
            this.textBoxTypedesc.DataBindings.Add(br);

            br = null;
            br = new Binding("Checked", bdsType, "EMP_Type_Activated", true);
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

            int result = this._SqlMasterManager.SaveMastertoDB4(this._dtEmployee_Type, "104");

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

            bdsType.EndEdit();
            dgvType.EndEdit();

            List<string> dupicate = new List<string>();
            bool dup = false;
            string valueDup = "";


            // check dupicate 
            for (int i = _dtEmployee_Type.Rows.Count - 1; i >= 0; i--)
            {
                dr = _dtEmployee_Type.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (!dupicate.Contains(dr["EMP_Type_ID"].ToString()))
                    {
                        dupicate.Add(dr["EMP_Type_ID"].ToString());
                    }
                    else
                    {
                        dup = true;
                        valueDup = dr["EMP_Type_ID"].ToString();
                        break;
                    }
                }

            }
            if (dup)
            {
                MessageBox.Show("Employee Type ID Dupicate : " + valueDup, "Check data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                refresh();
                return false;
            }




            foreach (DataRow drr in _dtEmployee_Type.Rows)
            {
                if (drr.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drr["EMP_Type_ID"].ToString().Length == 0)
                {

                    MessageBox.Show("Not null Employee Type ID", "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();

                    return false;
                }


                if (drr["EMP_Type_Desc"].ToString().Length == 0)
                {
                    MessageBox.Show("Not null : " + drr["EMP_Type_Desc"].ToString(), "Check Null ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    refresh();
                    return false;
                }




            }


            return true;
        }




        private void refresh()
        {
            this._dtEmployee_Type.Rows.Clear();
            this._dtEmployee_Type.Merge(this._SqlMasterManager.GetATD_EmployeeTypeList());
        }
        private bool button1WasClicked = false;

        private void textBoxTypeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Refresh3_Click(object sender, EventArgs e)
        {
            refresh();
            button1WasClicked = true;
            this.dgvType.CurrentRow.Selected = true;
        }

        private void Save3_Click(object sender, EventArgs e)
        {
            if (button1WasClicked)
            {
                SaveDB();
                button1WasClicked = false;
                int er = this.dgvType.Rows.GetLastRow(DataGridViewElementStates.None);
                er += 0;
                if (this.dgvType.CurrentRow.Index < dgvType.Rows.Count)
                {
                    dgvType.FirstDisplayedScrollingRowIndex = er;
                    dgvType.Refresh();
                    dgvType.CurrentCell = dgvType.Rows[er].Cells[0];
                    dgvType.Rows[er].Selected = true;
                    er += 1;

                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.dgvType.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.dgvType.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.dgvType.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.dgvType.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.dgvType.CurrentRow.Selected = true;
        }

        private void dgvType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvType.CurrentRow.Selected = true;
        }
    }
}
