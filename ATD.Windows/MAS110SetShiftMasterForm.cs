using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using ATD.Management;



namespace ATD.Windows
{
    public partial class MAS110SetShiftMasterForm : Form
    {
        #region variable declare
        private string _connStr = "";
        private string _userID = "";
        private SqlTeamAndTimeWorkManager _sqlManager = null;
        private DataSet _dsData = null;
        private DataSet _dsTemp = null;
        #endregion variable declare

        public MAS110SetShiftMasterForm(string connStr, string userID)
        {
            //set Culture Datetime 
            CultureInfo en = new CultureInfo("en-US", true);
            en.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            //en.DateTimeFormat.LongDatePattern = "dd/MM/yyyy HH:mm:ss";
            en.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = en;
            //Thread.CurrentThread.CurrentCulture = currentCulture;

            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._sqlManager = new SqlTeamAndTimeWorkManager(this._connStr, this._userID);
            this._dsData = new DataSet();
            this._dsData = this._sqlManager.GetRecordListTeamAndTime();
            this.SetInitDataGrid();
            this.setGridObject();            
         
        }

        #region Method Seveice

        private void RefreshTeam()
        {
            foreach (DataTable ldt in this._dsData.Tables)
            {
                if (ldt.TableName.ToUpper() == this._sqlManager.TablePPINCTTeam.ToUpper())
                {
                    ldt.Rows.Clear();
                }
            }         
        }

        private void RefreshTime()
        {
            foreach (DataTable ldt in this._dsData.Tables)
            {
                if (ldt.TableName.ToUpper() == this._sqlManager.TablePPINCTTimeWork.ToUpper())
                {
                    ldt.Rows.Clear();
                }
            }
        }

        private void setGridObject()
        {
            this.bdsTeam.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTTeam];
            this.bdnTeam.BindingSource = this.bdsTeam;
            this.dgvTeam.DataSource = this.bdsTeam;


            this.bdsTime.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTTimeWork];
            this.bdnTime.BindingSource = this.bdsTime;
            this.dgvTime.DataSource = this.bdsTime;
        }

        private void SetInitDataGrid()
        {
            DataGridViewTextBoxColumn colTxt  = null;
            DataGridViewCheckBoxColumn colChk = null;
            #region Team
            this.dgvTeam.AutoGenerateColumns = false;

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "TeamCode";
            colTxt.DataPropertyName = "TeamCode";
            colTxt.HeaderText = "Team";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;   
            colTxt.Width = 100;
            colTxt.MaxInputLength = 1 ;     
            colTxt.ReadOnly = false ;            
            this.dgvTeam.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "TeamDesc";
            colTxt.DataPropertyName = "TeamDesc";
            colTxt.HeaderText = "Desc";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;   
            colTxt.Width = 150;
            colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = false ;
            this.dgvTeam.Columns.Add(colTxt);

            colChk = null ;
            colChk = new DataGridViewCheckBoxColumn() ;
            colChk.Name = "ShiftFlag";
            colChk.DataPropertyName = "ShiftFlag";
            colChk.HeaderText = "Shift Flag";
            colChk.SortMode = DataGridViewColumnSortMode.NotSortable;
            colChk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colChk.HeaderCell.Style.BackColor = Color.LightGray;
            colChk.HeaderCell.Style.ForeColor = Color.Blue;
            colChk.Width = 100;  
            colTxt.ReadOnly = false;
            this.dgvTeam.Columns.Add(colChk);

            colChk = null ;
            colChk = new DataGridViewCheckBoxColumn() ;
            colChk.Name = "Activated";
            colChk.DataPropertyName = "Activated";
            colChk.HeaderText = "Activated";
            colChk.SortMode = DataGridViewColumnSortMode.NotSortable;
            colChk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colChk.HeaderCell.Style.BackColor = Color.LightGray;
            colChk.HeaderCell.Style.ForeColor = Color.Blue;
            colChk.Width = 100;     
            colTxt.ReadOnly = false;
            this.dgvTeam.Columns.Add(colChk);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "CreateBy";
            colTxt.DataPropertyName = "CreateBy";
            colTxt.HeaderText = "CreateBy";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 150;
            colTxt.ReadOnly = true ;                        
            this.dgvTeam.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "CreateTime";
            colTxt.DataPropertyName = "CreateTime";
            colTxt.HeaderText = "CreateTime";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 150;
            colTxt.ReadOnly = true ;            
            colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";            
            this.dgvTeam.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "UpdateBy";
            colTxt.DataPropertyName = "UpdateBy";
            colTxt.HeaderText = "UpdateBy";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 150;
            colTxt.ReadOnly = true ;                        
            this.dgvTeam.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "UpdateTime";
            colTxt.DataPropertyName = "UpdateTime";
            colTxt.HeaderText = "UpdateTime";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 150;
            colTxt.ReadOnly = true ;            
            colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";            
            this.dgvTeam.Columns.Add(colTxt);   

            #endregion 

            #region Time
            this.dgvTime.AutoGenerateColumns = false;

             colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "WrkCode";
            colTxt.DataPropertyName = "WrkCode";
            colTxt.HeaderText = "WrkCode";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 80;
            colTxt.MaxInputLength = 1 ;     
            colTxt.ReadOnly = false ;            
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "WrkDesc";
            colTxt.DataPropertyName = "WrkDesc";
            colTxt.HeaderText = "Desc";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 110;
            colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = false ;
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "StartTime";
            colTxt.DataPropertyName = "StartTime";
            colTxt.HeaderText = "Start (HH:MM)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = false;
            colTxt.DefaultCellStyle.Format = "HH:mm";
            colTxt.Width = 140;
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "EndTime";
            colTxt.DataPropertyName = "EndTime";
            colTxt.HeaderText = "End (HH:MM)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = false;
            colTxt.DefaultCellStyle.Format = "HH:mm";
            colTxt.Width = 150;
            this.dgvTime.Columns.Add(colTxt);
            
      
            colChk = null ;
            colChk = new DataGridViewCheckBoxColumn() ;
            colChk.Name = "ShiftFlag";
            colChk.DataPropertyName = "ShiftFlag";
            colChk.HeaderText = "Shift Flag";
            colChk.SortMode = DataGridViewColumnSortMode.NotSortable;
            colChk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colChk.HeaderCell.Style.BackColor = Color.LightGray;
            colChk.HeaderCell.Style.ForeColor = Color.Blue;
            colChk.Width = 100;      
            colTxt.ReadOnly = false;
            this.dgvTime.Columns.Add(colChk);

            colChk = null ;
            colChk = new DataGridViewCheckBoxColumn() ;
            colChk.Name = "Activated";
            colChk.DataPropertyName = "Activated";
            colChk.HeaderText = "Activated";
            colChk.SortMode = DataGridViewColumnSortMode.NotSortable;
            colChk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colChk.HeaderCell.Style.BackColor = Color.LightGray;
            colChk.HeaderCell.Style.ForeColor = Color.Blue;
            colChk.Width = 100; 
            colTxt.ReadOnly = false;
            this.dgvTime.Columns.Add(colChk);


            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "StartHour";
            colTxt.DataPropertyName = "StartHour";
            colTxt.HeaderText = "Start (HH)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 100;
            colTxt.MaxInputLength = 2;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "0#";
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "StartMinute";
            colTxt.DataPropertyName = "StartMinute";
            colTxt.HeaderText = "Start (MM)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 100;
            colTxt.MaxInputLength = 2;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "0#";
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "EndHour";
            colTxt.DataPropertyName = "EndHour";
            colTxt.HeaderText = "End (HH)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 100;
            colTxt.MaxInputLength = 2;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "0#";
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "EndMinute";
            colTxt.DataPropertyName = "EndMinute";
            colTxt.HeaderText = "End (MM)";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.Width = 100;
            colTxt.MaxInputLength = 2;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "0#";
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "CreateBy";
            colTxt.DataPropertyName = "CreateBy";
            colTxt.HeaderText = "CreateBy";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = true;
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "CreateTime";
            colTxt.DataPropertyName = "CreateTime";
            colTxt.HeaderText = "CreateTime";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "UpdateBy";
            colTxt.DataPropertyName = "UpdateBy";
            colTxt.HeaderText = "UpdateBy";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = true;
            this.dgvTime.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "UpdateTime";
            colTxt.DataPropertyName = "UpdateTime";
            colTxt.HeaderText = "UpdateTime";
            colTxt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTxt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTxt.HeaderCell.Style.BackColor = Color.LightGray;
            colTxt.HeaderCell.Style.ForeColor = Color.Blue;
            colTxt.ReadOnly = true;
            colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            this.dgvTime.Columns.Add(colTxt); 
            #endregion 

        }

        #endregion

       

        #region event

        private void textBoxGYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.KeyChar = Convert.ToChar(Keys.None);
            }
        }

        #endregion

        #region Team
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshTeam();
            this._dsData.Merge(this._sqlManager.GetRecordListTeamAndTime().Tables[this._sqlManager.TablePPINCTTeam]);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            this.saveTeamToDB();
        }

        #region Save To DB
        private bool validateSaveTeam()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string TeamCode;
                ArrayList arrTeam = new ArrayList();
                this.dgvTeam.Update();
                this.dgvTeam.EndEdit();
                this.bdsTeam.EndEdit();

                foreach (DataGridViewRow dgv in this.dgvTeam.Rows)
                {
                    TeamCode = dgv.Cells["TeamCode"].Value.ToString().ToUpper();
                    dgv.Cells["TeamCode"].Value = TeamCode;

                    if (TeamCode.Length > 0)
                    {
                        if (!arrTeam.Contains(TeamCode))
                        {
                            arrTeam.Add(TeamCode);
                        }
                        else
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(string.Format(",{0}", TeamCode));
                            }
                            else
                            {
                                sb.AppendLine(string.Format(" พบข้อมูล Team ซ้ำ {0}", TeamCode));
                            }
                        }
                    }
                    else
                    {
                        sb.AppendLine(" พบข้อมูล Team  ต้องไม่ว่าง ");
                    }
                }


                if (sb.Length > 0)
                {
                    MessageBox.Show("Call method :: validateSaveTeam()\n\r" + sb.ToString(), "Validate Team error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call method :: validateSaveTeam()" +
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

        private int saveTeamToDB()
        {
            if (!this.validateSaveTeam())
            {

                return -1;
            }

            try
            {
                if (this._sqlManager.SaveTeamToDB(ref this._dsData) < 0)
                {
                    MessageBox.Show(this._sqlManager.LastError, "Save team fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                {

                    MessageBox.Show(" Save team data to database completed.. ",
                                       "Save completed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                }
                return 1;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: saveTeamToDB()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                return -1;
            }
        }
        #endregion

        #endregion         

        #region Time 
        private void tsbRefreshTime_Click(object sender, EventArgs e)
        {
            this.RefreshTime();
            this._dsData.Merge(this._sqlManager.GetRecordListTeamAndTime().Tables[this._sqlManager.TablePPINCTTimeWork]);
        }

        private void tsbSaveTime_Click(object sender, EventArgs e)
        {
            this.saveTimeToDB();
        }
        #endregion 

        
        #region Save To DB
        private bool validateSaveTime()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string TeamCode;
                ArrayList arrTeam = new ArrayList();
                this.dgvTime.Update();
                this.dgvTime.EndEdit();
                this.bdsTime.EndEdit();

                foreach (DataGridViewRow dgv in this.dgvTime.Rows)
                {
                    #region Coue dupplicate 
                    TeamCode = dgv.Cells["WrkCode"].Value.ToString().ToUpper();
                    dgv.Cells["WrkCode"].Value = TeamCode;

                    if (TeamCode.Length > 0)
                    {
                        if (!arrTeam.Contains(TeamCode))
                        {
                            arrTeam.Add(TeamCode);
                        }
                        else
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(string.Format(",{0}", TeamCode));
                            }
                            else
                            {
                                sb.AppendLine(string.Format(" พบข้อมูล Work Time ซ้ำ {0}", TeamCode));
                            }
                        }
                    }
                    else
                    {
                        sb.AppendLine(" พบข้อมูล Work Time  ต้องไม่ว่าง ");
                    }

                    #endregion 

                    #region Set Time 
                    int intYY = 2000, intMM = 1, intDD = 1;
                    DateTime StartTime, EndTime ,stdDate;
                    int begHH, begmm,endHH,endmm;
                    stdDate = new DateTime(intYY, intMM, intDD);
                    if (dgv.Cells["StartTime"].Value == null)
                    {
                        dgv.Cells["StartTime"].Value = stdDate;
                    }

                    if (dgv.Cells["EndTime"].Value == null)
                    {
                        dgv.Cells["EndTime"].Value = stdDate;

                    }

                    StartTime = (DateTime)dgv.Cells["StartTime"].Value;
                    begHH = StartTime.Hour;
                    begmm = StartTime.Minute;

                    StartTime = new DateTime(intYY, intMM, intDD , begHH,begmm,0);
                    dgv.Cells["StartTime"].Value = StartTime;
                    dgv.Cells["StartHour"].Value  = begHH ;
                    dgv.Cells["StartMinute"].Value  = begmm ;

                    EndTime = (DateTime)dgv.Cells["EndTime"].Value;
                    endHH = EndTime.Hour;
                    endmm = EndTime.Minute;
                    EndTime = new DateTime(intYY, intMM, intDD, endHH, endmm, 0);
                    dgv.Cells["EndTime"].Value = EndTime;
                    if (endHH < begHH)
                    {
                        EndTime = EndTime.AddDays(1);
                        dgv.Cells["EndTime"].Value = EndTime;
                    }
                    dgv.Cells["EndHour"].Value  = endHH ;
                    dgv.Cells["EndMinute"].Value  = endmm ;


                    #endregion 
                }


                if (sb.Length > 0)
                {
                    MessageBox.Show("Call method :: validateSaveTime()\n\r" + sb.ToString(), "Validate Time error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call method :: validateSaveTime()" +
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

        private int saveTimeToDB()
        {
            if (!this.validateSaveTime())
            {

                return -1;
            }

            try
            {
                if (this._sqlManager.SaveTimeToDB(ref this._dsData) < 0)
                {
                    MessageBox.Show(this._sqlManager.LastError, "Save working time fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                {

                    MessageBox.Show(" Save working time data to database completed.. ",
                                       "Save completed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);
                }
                return 1;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: saveTimeToDB()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                return -1;
            }
        }
        #endregion


    }
}
