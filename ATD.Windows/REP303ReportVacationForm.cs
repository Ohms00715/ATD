using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ATD.Management;



namespace ATD.Windows
{
    public partial class REP303ReportVacationForm : Form
    {
        string _connStr = "";
        string _userID = "";
        
        DataRow dr;
        SqlMasterManeger _SqlMasterManager = null;
        DataTable _dtEmployee_Vacation = null;


        public REP303ReportVacationForm(string connStr, string userID)
        {
            
         
            InitializeComponent();
            _connStr = connStr;
            _userID = userID;
            this._SqlMasterManager = new SqlMasterManeger(this._connStr, this._userID);
            this._dtEmployee_Vacation = new DataTable();
            this._dtEmployee_Vacation = this._SqlMasterManager.GetATD_VacationList();
            this.SetObject();
            setReport();
        }

        
       
          private void setReport()
        {
            //this.bdsRpt100.DataSource = _dtSuppiler;

            ReportDataSource datasource3 = new ReportDataSource("DataSet1", _dtEmployee_Vacation);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(datasource3);




            reportViewer1.RefreshReport();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


        }
      
        private void SetObject()
        {

            this.bdsReportListVA.DataSource = _dtEmployee_Vacation;
            this.bdnVAList.BindingSource = bdsReportListVA;
            this.dgvVAList.DataSource = bdsReportListVA;
            dgvVAList.ReadOnly = true;
        }

        private void dgvEMPList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

       
    }
}
