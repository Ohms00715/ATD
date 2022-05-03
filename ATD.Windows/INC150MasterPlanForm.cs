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
    public partial class INC150MasterPlanForm : Form
    {
        #region variable declare
        private string _connStr = "";
        private string _userID = "";
        private SqlWorkCalendarManager _sqlManager = null;
        private DataSet _dsData = null;
        private DataSet _dsWrkCale = null;
        #endregion variable declare

        public INC150MasterPlanForm(string connStr, string userID)
        {
            //set Culture Datetime 
            CultureInfo en = new CultureInfo("en-US", true);
            en.DateTimeFormat.ShortDatePattern  = "dd/MM/yyyy";
            en.DateTimeFormat.LongDatePattern   = "dd/MM/yyyy";
            en.DateTimeFormat.ShortTimePattern  = "HH:mm:ss";
            en.DateTimeFormat.LongTimePattern   = "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = en;
            //Thread.CurrentThread.CurrentCulture = currentCulture;

            InitializeComponent();
            this._connStr = connStr;
            this._userID = userID;
            this._sqlManager = new SqlWorkCalendarManager(this._connStr, this._userID);
            this._dsData = new DataSet();
            this._dsData = this._sqlManager.GetRecordListCalendar("0000");
            this.SetInitDataGrid();
            this.setGridObject();            
         
        }

        #region Method Seveice
        private void Hourglass(bool Show)
        {
            if (Show == true)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            }
            else
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
            return;
        }
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
        private void refreshAlls()
        {
            foreach (DataTable ldt in this._dsData.Tables)
            {
                ldt.Rows.Clear();
            }
        }
        private void setGridObject()
        {
            this.bdsYear.DataSource    = this._dsData.Tables[this._sqlManager.TablePPINCTWorkYear];
           

            this.bdsMonth.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTWorkCalMonth];
            this.dgvMonth.DataSource = this.bdsMonth;

            this.bdsCale.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTWorkCalTable];
            this.bdnCale.BindingSource = this.bdsCale;
            this.dgvCale.DataSource = this.bdsCale;
            //this.bdsTime.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTTimeWork];
            //this.bdnTime.BindingSource = this.bdsTime;
            //this.dgvTime.DataSource = this.bdsTime;

            this.dgvWork.DataSource = this._dsData.Tables[this._sqlManager.TablePPINCTTimeWork];

            #region Binding Year 
            Binding cb;
            cb = null;
            cb = new System.Windows.Forms.Binding("Text", this.bdsYear, "WrkYearKey", true);            
            this.txtYearCale.DataBindings.Add(cb);

            cb = null;
            cb = new System.Windows.Forms.Binding("Text", this.bdsYear, "CreateBy", true);            
            this.txtCreateBy.DataBindings.Add(cb);

            cb = null;
            cb = new System.Windows.Forms.Binding("Text", this.bdsYear, "CreateTime", true);            
            cb.FormatString = "dd/MM/yy HH:mm:ss" ;
            this.txtCreateTime.DataBindings.Add(cb);

            cb = null;
            cb = new System.Windows.Forms.Binding("Text", this.bdsYear, "UpdateBy", true);            
            this.txtUpdateBy.DataBindings.Add(cb);

            cb = null;
            cb = new System.Windows.Forms.Binding("Text", this.bdsYear, "UpdateTime", true);            
            cb.FormatString = "dd/MM/yy HH:mm:ss" ;
            this.txtUpdateTime.DataBindings.Add(cb);
 
            #endregion 
        }
        private void SetInitDataGrid()
        {
            DataGridViewTextBoxColumn colTxt  = null;
            DataGridViewCheckBoxColumn colChk = null;
            DataGridViewButtonColumn colBt = null;

            #region Calendar
            string col = "DAY_";
            string colName = "";
            this.dgvCale.AutoGenerateColumns = false;
            this.dgvCale.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ;
            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "TeamCode";
            colTxt.DataPropertyName = "TeamCode";
            colTxt.HeaderText = "Date/ Team";
            colTxt.Width = 50;            
            colTxt.ReadOnly = true;
            this.dgvCale.Columns.Add(colTxt);
            
            for(int i = 1 ; i < 32 ; i ++ ) 
            {
                colName  = string.Format("{0}{1}",col  , i.ToString("00"));
                colTxt = null;
                colTxt = new DataGridViewTextBoxColumn();
                colTxt.Name = colName;
                colTxt.DataPropertyName = colTxt.Name;
                colTxt.HeaderText = i.ToString("00");
                colTxt.Width = 35;
                colTxt.MaxInputLength = 1;
                colTxt.ReadOnly = false;
                colTxt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                this.dgvCale.Columns.Add(colTxt);
            }

            for (int i = 0; i < this.dgvCale.ColumnCount; i++)
            {
                this.dgvCale.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                //if (i == 0)
                //{
                //    this.dgvCale.Columns[i].Width = 50;
                //}
                //else
                //{                    
                //    this.dgvCale.Columns[i].Width = 50;
                //}
            }


            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "TeamCode";
            //colTxt.DataPropertyName = "TeamCode";
            //colTxt.HeaderText = "Team";
            //colTxt.Width = 50;
            //colTxt.MaxInputLength = 1 ;     
            //colTxt.ReadOnly = false ;            
            //this.dgvCale.Columns.Add(colTxt);

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "TeamDesc";
            //colTxt.DataPropertyName = "TeamDesc";
            //colTxt.HeaderText = "Desc";
            //colTxt.Width = 150;
            //colTxt.MaxInputLength = 50 ;
            //colTxt.ReadOnly = false ;
            //this.dgvCale.Columns.Add(colTxt);

            //colChk = null ;
            //colChk = new DataGridViewCheckBoxColumn() ;
            //colChk.Name = "ShiftFlag";
            //colChk.DataPropertyName = "ShiftFlag";
            //colChk.HeaderText = "Shift Flag";
            //colChk.Width = 100;  
            //colTxt.ReadOnly = false;
            //this.dgvCale.Columns.Add(colChk);

            //colChk = null ;
            //colChk = new DataGridViewCheckBoxColumn() ;
            //colChk.Name = "Activated";
            //colChk.DataPropertyName = "Activated";
            //colChk.HeaderText = "Activated";
            //colChk.Width = 100;     
            //colTxt.ReadOnly = false;
            //this.dgvCale.Columns.Add(colChk);

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "CreateBy";
            //colTxt.DataPropertyName = "CreateBy";
            //colTxt.HeaderText = "CreateBy";             
            //colTxt.ReadOnly = true ;                        
            //this.dgvCale.Columns.Add(colTxt);

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "CreateTime";
            //colTxt.DataPropertyName = "CreateTime";
            //colTxt.HeaderText = "CreateTime";             
            //colTxt.ReadOnly = true ;            
            //colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";            
            //this.dgvCale.Columns.Add(colTxt);

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "UpdateBy";
            //colTxt.DataPropertyName = "UpdateBy";
            //colTxt.HeaderText = "UpdateBy";             
            //colTxt.ReadOnly = true ;                        
            //this.dgvCale.Columns.Add(colTxt);

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "UpdateTime";
            //colTxt.DataPropertyName = "UpdateTime";
            //colTxt.HeaderText = "UpdateTime";             
            //colTxt.ReadOnly = true ;            
            //colTxt.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";            
            //this.dgvCale.Columns.Add(colTxt);   

            #endregion 

            #region  Month
            this.dgvMonth.AutoGenerateColumns = false;

            //dtCalendar.Columns.Add("COL_YYYY", typeof(int));
            //dtCalendar.Columns.Add("COL_MM", typeof(int));
            //dtCalendar.Columns.Add("COL_MMNAME", typeof(string));

            //colTxt = null;
            //colTxt = new DataGridViewTextBoxColumn();
            //colTxt.Name = "COL_MM";
            //colTxt.DataPropertyName = "COL_MM";
            //colTxt.HeaderText = "Month";
            //colTxt.Width = 30;
            ////colTxt.MaxInputLength = 1 ;     
            //colTxt.ReadOnly = true ;            
            //this.dgvMonth.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "COL_MMNAME";
            colTxt.DataPropertyName = "COL_MMNAME";
            colTxt.HeaderText = "Name";
            colTxt.Width = 50;
            //colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = true ;
            this.dgvMonth.Columns.Add(colTxt);

            colBt = null;
            colBt = new DataGridViewButtonColumn();
            colBt.Name = "COL_MM";
            colBt.DataPropertyName = "COL_MM";
            colBt.HeaderText = "Month";
            colBt.Width = 50;
            //colTxt.MaxInputLength = 50 ;            
            this.dgvMonth.Columns.Add(colBt);  
            

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "COL_YYYY";
            colTxt.DataPropertyName = "COL_YYYY";
            colTxt.HeaderText = "Y";
            colTxt.Width = 1;
            //colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = true;
            this.dgvMonth.Columns.Add(colTxt);

            for (int i = 0; i < this.dgvMonth.ColumnCount; i++)
            {
                this.dgvMonth.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            #endregion 

            #region Working
            this.dgvWork.AutoGenerateColumns = false;
            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "WrkCode";
            colTxt.DataPropertyName = "WrkCode";
            colTxt.HeaderText = "Name";
            colTxt.Width = 30;
            //colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = true ;
            this.dgvWork.Columns.Add(colTxt);

            colTxt = null;
            colTxt = new DataGridViewTextBoxColumn();
            colTxt.Name = "WrkDesc";
            colTxt.DataPropertyName = "WrkDesc";
            colTxt.HeaderText = "Name";
            //colTxt.Width = 50;
            //colTxt.MaxInputLength = 50 ;
            colTxt.ReadOnly = true;
            this.dgvWork.Columns.Add(colTxt);

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
            this.Hourglass(true);
            this.saveTeamToDB();
            this.Hourglass(false);
        }

        #region Save To DB
        private bool validateSaveTeam()
        {
            try
            {
                StringBuilder sb = new StringBuilder();             
                ArrayList arrWrk = new ArrayList();
                //DateTime dtpDate, dtpNextDate;
                //int intYear, intMonth;
                this.dgvCale.Update();
                this.dgvCale.EndEdit();
                this.bdsCale.EndEdit();
                int colCnt = this.dgvCale.Columns.Count;
                 bool lbConv  ;
                int iYYYY , iMM ;
                lbConv  =int.TryParse(  this.stxtYear.Text , out iYYYY) ;
                lbConv  =int.TryParse(  this.txtMonth.Text  , out iMM) ;
                if( ( iYYYY < 2020 )  || ( iMM < 0 || iMM > 12 )) 
                {
                    MessageBox.Show("  กรุณาเลือก  ปี/เดือน ก่อน "  ,"Check Month/Year ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false ;
                }              

                foreach (DataRow dr in this._dsData.Tables[this._sqlManager.TablePPINCTTimeWork].Rows)
                {
                    if (!arrWrk.Contains(dr["WrkCode"].ToString().ToUpper()))
                    {
                        arrWrk.Add(dr["WrkCode"].ToString().ToUpper());
                    }
                }

                foreach (DataGridViewRow dgv in this.dgvCale.Rows)
                {
                    for (int i = 0; i < colCnt; i++)
                    {
                        dgv.Cells[i].Value = dgv.Cells[i].Value.ToString().ToUpper();
                        if (this.dgvCale.Columns[i].Name.ToString().ToUpper().Substring(0, 4) == "DAY_")
                        {
                            if (this.dgvCale.Columns[i].HeaderText.Trim().Length > 0)
                            {                                
                                if (dgv.Cells[i].Value == DBNull.Value)
                                {
                                    //if( !lbChknull )
                                    //{
                                    //    if( MessageBox.Show(" พบข้อมูลตารางการทำงานเป็นค่าว่างต้องการให้ระบบ default"
                                    //}
                                    //if( lbChknull ) 
                                    //{
                                    dgv.Cells[i].Value = "H";
                                    //}
                                }

                                if (dgv.Cells[i].Value.ToString().ToUpper().Length > 0)
                                {
                                    if (!arrWrk.Contains(dgv.Cells[i].Value.ToString().ToUpper()))
                                    {
                                        if (sb.Length == 0)
                                        {
                                            sb.AppendLine(" พบข้อมูล รหัสการทำงาน ไม่มีในฐานข้อมูลดังนี้ ");
                                        }
                                        sb.AppendLine(string.Format("{0}", dgv.Cells[i].Value.ToString().ToUpper()));
                                    }
                                }
                            }
                        }
                    }                    
                }



                if (sb.Length > 0)
                {
                    sb.AppendLine(" กรุณาตรวจสอบความถูกต้องด้วย...");
                    MessageBox.Show("Call method :: validateSaveTeam()\n\r" + sb.ToString(), "Validate Team error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string  msgQest  = string.Format(" เดือน/ปี ({0}) {1}/{2} ", this.txtMonthName.Text , this.txtMonth.Text , this.stxtYear.Text ) ;

                sb.AppendLine(string.Format("  บันทึกข้อมูล {0} " , msgQest) )  ;
                sb.AppendLine("  ยืนยันบันทึกข้อมูลหรือไม่ Y/N ?" )  ;
                
                if (MessageBox.Show(sb.ToString(), "Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else
                {
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
        }

        private int saveTeamToDB()
        {
            if (!this.validateSaveTeam())
            {

                return -1;
            }

            try
            {
                if (this._sqlManager.SaveTeamToDB(this._dsData , this.stxtYear.Text , this.txtMonth.Text) < 0)
                {
                    MessageBox.Show(this._sqlManager.LastError, "Save team fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                {

                    MessageBox.Show(" Save team  and working period data completed.. ",
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
                this.dgvMonth.Update();
                this.dgvMonth.EndEdit();
                this.bdsCale.EndEdit();

                foreach (DataGridViewRow dgv in this.dgvMonth.Rows)
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
        #region Get Year 
        private void getDataByYear()
        {
            try
            {                
                int intYYYY;
                bool lbChk;
                lbChk = int.TryParse(this.txtYear.Text, out intYYYY);
                if (intYYYY > 2000)
                {
                    this.refreshAlls();
                    this._dsData.Merge(this._sqlManager.GetRecordListCalendar(intYYYY.ToString()));

                    if (this._dsData.Tables[this._sqlManager.TablePPINCTWorkYear].Rows.Count > 0)
                    {
                        // Do somtthing.
                    }
                    else
                    {
                        DataRow dr = this._dsData.Tables[this._sqlManager.TablePPINCTWorkYear].NewRow();
                        dr["WrkYearKey"] = intYYYY;
                        this._dsData.Tables[this._sqlManager.TablePPINCTWorkYear].Rows.Add(dr);
                    }
                    #region Clear Text
                    this.txtMonth.Text = "";
                    this.txtMonthName.Text = "";
                    this.stxtYear.Text = "";
                    #endregion 
                }
                else
                {
                    MessageBox.Show(" กรุณาบันทึก ปี คศ. ใหม่ ", "Period Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtYear.Focus();
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: getDataByYear()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                
            }

        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            this.getDataByYear();
        }

        private void SetMonth(int YYYY, int MM)
        {
            try
            {
                string col = "DAY_";
                string colName = "" ,colHeader;

                DateTime dtDate = new DateTime(YYYY, MM, 1);
                for (int i = 1; i < 32; i++)
                {
                    colName = string.Format("{0}{1}", col, i.ToString("00"));
                    if (i > 1)
                    {                    
                        dtDate  = dtDate.AddDays(1);
                    }

                    if (dtDate.Month == MM)
                    {
                        colHeader = string.Format("{0}  {1}",dtDate.DayOfWeek.ToString().Substring(0,3).ToUpper() , i.ToString());
                        this.dgvCale.Columns[colName].HeaderText = colHeader;
                    }
                    else
                    {
                        this.dgvCale.Columns[colName].HeaderText = "";
                    }
                }

                this.SetMonthTeamWorking(YYYY, MM);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: SetMonth()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);

            }
        }
        private void SetMonthTeamWorking(int paYYYY, int paMM)
        {
            try
            {
                if (paYYYY == null) { paYYYY = 0; }
                if (paMM == null) { paMM = 0; }
                DataSet dsData = this._sqlManager.GetRecordListPPINCTWorkCalByYearMonth(paYYYY.ToString(), paMM.ToString());
                if (this._dsData.Tables[this._sqlManager.TablePPINCTWorkCalTable] != null)
                {
                    this._dsData.Tables[this._sqlManager.TablePPINCTWorkCalTable].Rows.Clear();
                    this._dsData.Merge(dsData.Tables[this._sqlManager.TablePPINCTWorkCalTable]);
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: SetMonthWorkingDate()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);

            }
        }
        #endregion 
        #region Month generate

        private void dgvMonth_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private void dgvMonth_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //e.ColumnIndex
        }
        private void dgvMonth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMonth.Columns[e.ColumnIndex].Name.ToUpper() == "COL_MM")
            {
                int yyyy, mm;               
                int.TryParse(this.dgvMonth.Rows[e.RowIndex].Cells["COL_YYYY"].Value.ToString() , out yyyy) ;
                int.TryParse(this.dgvMonth.Rows[e.RowIndex].Cells["COL_MM"].Value.ToString() , out mm) ;
                this.SetMonth(yyyy, mm);
               
                this.txtMonth.Text = this.dgvMonth.Rows[e.RowIndex].Cells["COL_MM"].Value.ToString();
                this.txtMonthName.Text = this.dgvMonth.Rows[e.RowIndex].Cells["COL_MMNAME"].Value.ToString();
                this.stxtYear.Text = this.dgvMonth.Rows[e.RowIndex].Cells["COL_YYYY"].Value.ToString();
                for (int i = 0; i < this.dgvMonth.RowCount; i++)
                {
                    this.dgvMonth.Rows[i].Selected = false;
                }

                this.dgvMonth.Rows[e.RowIndex].Selected = true;

            }
        }

        #endregion 
        #region Generate Year
        private void SaveGenYearAndWorkingDate()
        {
            int intYYYY;
            bool lbChk = int.TryParse(this.txtYear.Text, out intYYYY);
            string msg = "";
            if (intYYYY < 2020)
            {
                msg = "ปี Program incentive ต้องเริ่มตั้งแต่ 2020";
                MessageBox.Show(msg, "Check Year ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (this._sqlManager.SaveGenYearAndWorkingDate(intYYYY.ToString()) < 1)
            {
                MessageBox.Show(this._sqlManager.LastError, "Gen data fail.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                msg = "สร้าง ปี Program incentive สำเร็จ";
                MessageBox.Show(msg, "Generate Year ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.getDataByYear();
            }
        }
        private void btGenCal_Click(object sender, EventArgs e)
        {
            this.Hourglass(true);
            this.SaveGenYearAndWorkingDate();
            this.Hourglass(false);
        }
        #endregion 

        #region Paste work code 

        private void PasteClipboard()
        {
            try
            {

                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                string[] sCells;
                string colName = this.dgvCale.Columns[this.dgvCale.CurrentCell.ColumnIndex].Name;
                string firstCol ,wrkCode ,colId;
                int startCol ,currCol;
                bool lbChk;

                if (colName.Length > 3)
                {
                    if (colName.Substring(0, 3).ToUpper() == "DAY")
                    {
                        firstCol = colName.Substring(colName.Length - 2, 2);
                        lbChk = int.TryParse(firstCol, out startCol);
                        if (startCol > 0)
                        {
                            for (int i = 0; i < lines.Length; i++)
                            {
                                sCells = lines[i].Split('\t');
                                if (sCells.Length > 0)
                                {
                                    for (int j = 0; j < sCells.Length; j++)
                                    {
                                        wrkCode = sCells[j].ToString().Trim().ToUpper();
                                        if (wrkCode.Length > 0)
                                        {
                                            currCol = startCol + j;
                                            if (currCol <= 31)
                                            {
                                                colId = string.Format("DAY_{0}", currCol.ToString("00"));
                                                this.dgvCale.CurrentRow.Cells[colId].Value = wrkCode;
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }

                this.dgvCale.Update();
                this.bdsCale.EndEdit();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("  Call Method :: PasteClipboard()" +
                                       "\n\r Message:" + exp.Message.ToString() +
                                       "\n\r Source: " + exp.Source.ToString() +
                                       "\n\r StackTrace: " + exp.StackTrace.ToString(),
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
            }
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            if (this.stxtYear.Text.Length == 0 || this.txtMonth.Text.Length == 0)
            {
                MessageBox.Show(" กรุณาเลือก เดือน/ปี ก่อน.. ", "Check parameter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (this.dgvCale.Rows.Count > 0)
            {
                this.PasteClipboard();                
            }
        }

        #endregion 
    }
}
