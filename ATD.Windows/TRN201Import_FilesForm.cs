using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ATD.Management;

namespace ATD.Windows
{
    public partial class TRN201Import_FilesForm : Form
    {
        string _connStr = "";
        string _userID = "";
        SqlTransactionImportFilesManager _SqlTransactionImportFilesManager = null;
        DataTable _dtImportfile = null;
        DataRow dr = null;

        public TRN201Import_FilesForm(string connStr, string userID)
        {
            InitializeComponent();
            _connStr = connStr;
            _userID = userID;
            this._SqlTransactionImportFilesManager = new SqlTransactionImportFilesManager(this._connStr, this._userID);
            this._dtImportfile = new DataTable();
            this._dtImportfile = this._SqlTransactionImportFilesManager.GetATD_ImportFiles();
            this.SetObject();

        }


        #region set Object

        private void SetObject()
        {

            bdsImportFile.DataSource = _dtImportfile;
            bdnImportFile.BindingSource = this.bdsImportFile;
            this.dgvImportFiles.DataSource = bdsImportFile;
            dgvImportFiles.ReadOnly = true;
        }

        #endregion
        private void SaveDB()
        {
            if (!varidate())
            {
                return;
            }

            int result = this._SqlTransactionImportFilesManager.SaveTransactiontoDB(this._dtImportfile, "201");

            if (result == 1)

            {
                
                MessageBox.Show("Save to database completed...", "Save data", MessageBoxButtons.OK, MessageBoxIcon.Information);

              //  refresh();


            }
            else
            {
                MessageBox.Show(this._SqlTransactionImportFilesManager.LastError, "Fail Save data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private bool varidate()
        {

            this.bdsImportFile.EndEdit();
            this.dgvImportFiles.EndEdit();

            return true;
        }
        private void refresh()
        {
            this._dtImportfile.Rows.Clear();
            this._dtImportfile.Merge(this._SqlTransactionImportFilesManager.GetATD_ImportFiles());
        }




        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            dgvImportFiles.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            dgvImportFiles.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            dgvImportFiles.CurrentRow.Selected = true;
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            dgvImportFiles.CurrentRow.Selected = true;
        }

        private void SaveToDB_Click(object sender, EventArgs e)
        {

            if (dgvImportFiles.RowCount != 0)
            {
                SaveDB();
                this.SaveToDB.Enabled = false;
                
                
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Add Data before Save", "Warning)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       

        private void Refresh201_Click(object sender, EventArgs e)
        {
            Refresh();
            refresh();
            this.SaveToDB.Enabled = true;
           
        }

        private void ImportFile_Click(object sender, EventArgs e)
        {
           
            //this.dgvImportFiles.AutoGenerateColumns = false;
            this.OpenImportFile.Filter = "Text Files|*.txt;";
            OpenImportFile.FilterIndex = 2;
            var fileContent = string.Empty;
            var filePath = string.Empty;
            //OpenImportFile.ShowDialog();
            OpenImportFile.Title = "Browse Text Files";
            OpenImportFile.CheckFileExists = true;
            OpenImportFile.CheckPathExists = true;

            //OpenImportFile.InitialDirectory = "c:\\";
            //OpenImportFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //OpenImportFile.FilterIndex = 2;
            OpenImportFile.RestoreDirectory = true;

            if (OpenImportFile.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = OpenImportFile.FileName;

                //Read the contents of the file into a stream
                var fileStream = OpenImportFile.OpenFile();

                //StreamReader readerx = new StreamReader(fileStream);

                //DataTable dt = new DataTable();
                //string line = readerx.ReadLine();
                ////string[] fields = line.Split('\t');
                //if (dt.Columns.Count == 0)
                //{
                //    foreach (string field in fields)
                //    {
                //        // will add default names like "Column1", "Column2", and so on
                //        dt.Columns.Add();
                //    }
                //}
                //dt.Rows.Add(fields);
                //DataTable tbl = new DataTable();

                //for (int col = 0; col < numberOfColumns; col++)
                //    tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


                string[] lines = System.IO.File.ReadAllLines(filePath);

                _dtImportfile.Rows.Clear();
                DataTable dt = this._SqlTransactionImportFilesManager.GetATD_ImportFilesALL();
               

                bool frist = false;
                foreach (string line in lines)
                {
                    if (!frist)
                    {
                        frist = true;
                        continue;
                    }



                    
                    
                    var cols = line.Split('\t');
                    DateTime dtDate = Convert.ToDateTime(cols[6]);
                    if (dt.Rows.Count > 0)
                    {
                       
                        DataRow drCheck = dt.Select(string.Format(@" Mchn = {0} 
                                                                and EnNo = {1} 
                                                                and Name = '{2}' 
                                                                and Mode = '{3}' 
                                                                and IOMd = {4} 
                                                                and Datetime = '{5}' "
                        , cols[1], Convert.ToInt32(cols[2]), cols[3], cols[4], cols[5], dtDate.ToString("dd/MM/yyyy HH:mm"))).FirstOrDefault();

                        if (drCheck != null)
                        {
                          
                            continue;
                           
                        }
                       
                       
                    }
                    if (this.dgvImportFiles.RowCount == 0)
                    {
                        DialogResult dialog = MessageBox.Show("Add Document can do Onec a Day", "แจ้งตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    DataRow dr = _dtImportfile.NewRow();
                    dr["NORun"] = cols[0];
                    dr["Mchn"] = cols[1];
                    dr["EnNo"] = cols[2];
                    dr["Name"] = cols[3];
                    dr["Mode"] = cols[4];
                    dr["IOMd"] = cols[5];
                    dr["Datetime"] = cols[6];
                    cols[5] = _userID.ToString();
                    dr["Created_by"] = cols[5];
                    cols[6] = DateTime.Now.ToString();
                    dr["Created_Time"] = cols[6];
                    _dtImportfile.Rows.Add(dr);
                }
  //              SELECT  NO
  //    ,Mchn
  //    ,EnNo
  //    ,Name
  //    ,Mode
  //    ,IOMd
  //    ,Datetime
  //    ,Created_by
  //    ,Created_Time
  //FROM ATD_Machine_Import
                //return tbl;



                //using (StreamReader reader = new StreamReader(fileStream))
                //{
                //    fileContent = reader.ReadToEnd();


                //    for (int i = 0; i < fileContent.Length; i++)
                //    {
                //        string[] fields = fileContent[i].ToString().Split('\t');


                //    }


                //    //DataTable dt = new DataTable();
                //    //while (reader.Peek() >= 0)
                //    //{
                //    //    string line = reader.ReadLine();
                //    //    string[] fields = line.Split('\t');
                //    //    if (dt.Columns.Count == 0)
                //    //    {
                //    //        foreach (string field in fields)
                //    //        {
                //    //            // will add default names like "Column1", "Column2", and so on
                //    //            dt.Columns.Add();
                //    //        }
                //    //    }
                //    //    dt.Rows.Add(fields);
                //    //}

                //}

            }


        }

        private void dgvImportFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImportFiles.RowCount != 0)
            {
                this.dgvImportFiles.CurrentRow.Selected = true;
            }
        }
    }
}
