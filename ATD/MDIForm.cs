using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATD.Windows;
using System.Configuration;

namespace ATD
{
    public partial class MDI : Form
    {

        string _connStr = "";
        string _userID = "";

        public MDI()
        {
            InitializeComponent();

            this._connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=ISIDB;Integrated Security=True";
            //this._connStr = "Persist Security Info=True;Data Source=12.168.35.32;Initial Catalog=GHRIS;User ID=hris;Password=hris2016;";
            this._userID = "ADMIN";
        }

        
        

      

        #region Method Service
        private System.Windows.Forms.Form GetExistingChildForm(string formName)
        {
            string formNameStr;
            int findInt;
            foreach (System.Windows.Forms.Form ChildForm in this.MdiChildren)
            {
                formNameStr = ChildForm.GetType().ToString().ToUpper();
                findInt = formNameStr.IndexOf(formName.ToUpper());
                if (findInt > 0)
                {
                    return ChildForm;
                }
            }
            return null;
        }

        private void SetFormOpen(Form form, string fName)
        {
            form.MdiParent = this;
            form.Text = fName;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
            form.Activate();
        }

        private void SetFormActivate(Form form)
        {
            form.Activate();
            if (form.WindowState != FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
        }
        #endregion Method Service



        public void callMdiChild(string menuCode)
        {
            switch (menuCode.ToUpper())
            {
                case "MAS100":
                    this.M_MAS101_Click(null, null);
                    break;

                case "MAS200":
                    this.M_MAS102_Click(null, null);
                    break;

                case "MAS300":
                    this.M_MAS103_Click(null, null);
                    break;

                case "MAS400":
                    this.M_MAS104_Click(null, null);
                    break;

                case "MAS500":
                    this.M_MAS105_Click(null, null);
                    break;

                case "MAS600":
                    this.M_MAS106_Click(null, null);
                    break;

                case "MAS700":
                    this.M_MAS110_Click(null, null);
                    break;

                case "MAS800":
                    this.M_MAS120_Click(null, null);
                    break;

                case "TRN100":
                    this.M_MAS130_Click(null, null);
                    break;
            }
        }

        #region Master  ATD
        private void M_MAS101_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS101EmployeeForm");
            if (form == null)
            {
                _MAS101EmployeeForm = new MAS101EmployeeForm(this._connStr, this._userID);
                SetFormOpen(_MAS101EmployeeForm, M_MAS101.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }
        
        
        private void M_MAS102_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS102Employee_TitleForm");
            if (form == null)
            {
                _MAS102Employee_TitleForm = new MAS102Employee_TitleForm(this._connStr, this._userID);
                SetFormOpen(_MAS102Employee_TitleForm, M_MAS102.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS103_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS103Employee_DepartmentForm");
            if (form == null)
            {
                _MAS103Employee_DepartmentForm = new MAS103Employee_DepartmentForm(this._connStr, this._userID);
                SetFormOpen(_MAS103Employee_DepartmentForm, M_MAS103.Text);
            }
            else
            {
                SetFormActivate(form);
            }

        }

        private void M_MAS104_Click(object sender, EventArgs e)
        {

            {
                System.Windows.Forms.Form form = this.GetExistingChildForm("MAS104Employee_TypeForm");
                if (form == null)
                {
                    _MAS104Employee_TypeForm = new MAS104Employee_TypeForm(this._connStr, this._userID);
                    SetFormOpen(_MAS104Employee_TypeForm, M_MAS104.Text);
                }
                else
                {
                    SetFormActivate(form);
                }
            }

        }
        
        private void M_MAS105_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS107VacationForm");
            if (form == null)
            {
                _MAS105VacationForm = new MAS105VacationForm(this._connStr, this._userID);
                SetFormOpen(_MAS105VacationForm, M_MAS105.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS106_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS106Work_DayForm");
            if (form == null)
            {
                _MAS106Work_DayForm = new MAS106Work_DayForm(this._connStr, this._userID);
                SetFormOpen(_MAS106Work_DayForm, M_MAS106.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS110_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS110SetShiftMasterForm");
            if (form == null)
            {
                _MAS110SetShiftMasterForm = new MAS110SetShiftMasterForm(this._connStr, this._userID);
                SetFormOpen(_MAS110SetShiftMasterForm, M_MAS110.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }
   
        private void M_MAS120_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("MAS120SetWorkCalendarForm");
            if (form == null)
            {
                _MAS120SetWorkCalendarForm = new MAS120SetWorkCalendarForm(this._connStr, this._userID);
                SetFormOpen(_MAS120SetWorkCalendarForm, M_MAS120.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void M_MAS130_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Form form = this.GetExistingChildForm("MAS110GenWrkDaysForm");
            //if (form == null)
            //{
            //    _INC110GenWrkDaysForm = new MAS110GenWrkDaysForm(this._connStr, this._userID);
            //    SetFormOpen(_MAS130SetWorkCalendarForm, M_MAS110.Text);
            //}
            //else
            //{
            //    SetFormActivate(form);
            //}
            //System.Windows.Forms.Form form = this.GetExistingChildForm("_INC150MasterPlanForm");
            //if (form == null)
            //{
            //    _INC150MasterPlanForm = new INC150MasterPlanForm(this._connStr, this._userID);
            //    SetFormOpen(_INC150MasterPlanForm, M_MAS130.Text);
            //}
            //else
            //{
            //    SetFormActivate(form);
            //}

        }

        #region Transaction
        private void TRN201_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("TRN201Import_FilesForm");
            if (form == null)
            {
                _TRN201Import_FilesForm = new TRN201Import_FilesForm(this._connStr, this._userID);
                SetFormOpen(_TRN201Import_FilesForm, TRN201.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }
        private void TRN202_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("TRN202DataFilesForm");
            if (form == null)
            {
                _TRN202DataFilesForm = new TRN202DataFilesForm(this._connStr, this._userID);
                SetFormOpen(_TRN202DataFilesForm, TRN202.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        #endregion

        #region Report

        private void REP301_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Form form = this.GetExistingChildForm("REP301");
            if (form == null)
            {
                _ReportEMP = new REP301ReportEmployeeForm(this._connStr, this._userID);
                SetFormOpen(_ReportEMP, REP301.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP302_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = this.GetExistingChildForm("REP302");
            if (form == null)
            {
                _ReportATD = new REP302AttendenceForm(this._connStr, this._userID);
                SetFormOpen(_ReportATD, REP302.Text);
            }
            else
            {
                SetFormActivate(form);
            }
        }

        private void REP303_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Form form = this.GetExistingChildForm("REP303");
            //if (form == null)
            //{
            //    _ReportVacation = new REP303ReportVacationForm(this._connStr, this._userID);
            //    SetFormOpen(_ReportVacation, REP303.Text);
            //}
            //else
            //{
            //    SetFormActivate(form);
            //}
        }
       






        #endregion

        #endregion

        #region Window ATD
     
       


        public MAS130GenWrkDaysForm _INC110GenWrkDaysForm;

        public MAS110SetShiftMasterForm _MAS110SetShiftMasterForm;

        public MAS120SetWorkCalendarForm _MAS120SetWorkCalendarForm;
       
        public INC150MasterPlanForm _INC150MasterPlanForm;

        public TRN202DataFilesForm _TRN202DataFilesForm { get; set; }
        
        public TRN201Import_FilesForm _TRN201Import_FilesForm { get; set; }

        //public MAS108Shift_TypeForm _MAS108Shift_Type { get; set; } No screen

        public MAS105VacationForm _MAS105VacationForm { get; set; }

        public MAS106Work_DayForm _MAS106Work_DayForm { get; set; }

        public MAS104Employee_TypeForm _MAS104Employee_TypeForm { get; set; }

        public MAS103Employee_DepartmentForm _MAS103Employee_DepartmentForm { get; set; }

        public MAS102Employee_TitleForm _MAS102Employee_TitleForm { get; set; }

        public MAS101EmployeeForm _MAS101EmployeeForm { get; set; }


        public REP301ReportEmployeeForm _ReportEMP { get; set; }

        public REP302AttendenceForm _ReportATD { get; set; }

        public REP303ReportVacationForm _ReportVacation { get; set; }

        #endregion 

       

     

        
    

        
      

        
      

     

      

    }
}


