namespace ATD.Windows
{
    partial class TRN201Import_FilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN201Import_FilesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bdnImportFile = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenImportFile = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEMPID = new System.Windows.Forms.TextBox();
            this.dgvImportFiles = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ImportFile = new System.Windows.Forms.ToolStripButton();
            this.SaveToDB = new System.Windows.Forms.ToolStripButton();
            this.Refresh201 = new System.Windows.Forms.ToolStripButton();
            this.bdsImportFile = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdnImportFile)).BeginInit();
            this.bdnImportFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportFiles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsImportFile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1924, 60);
            this.label1.TabIndex = 6;
            this.label1.Text = "Import Files Transaction Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.ForestGreen;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(0, 1020);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1924, 35);
            this.label13.TabIndex = 83;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bdnImportFile
            // 
            this.bdnImportFile.AddNewItem = null;
            this.bdnImportFile.CountItem = this.bindingNavigatorCountItem;
            this.bdnImportFile.DeleteItem = null;
            this.bdnImportFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.ImportFile,
            this.toolStripSeparator1,
            this.SaveToDB,
            this.toolStripSeparator2,
            this.Refresh201});
            this.bdnImportFile.Location = new System.Drawing.Point(0, 60);
            this.bdnImportFile.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnImportFile.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnImportFile.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnImportFile.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnImportFile.Name = "bdnImportFile";
            this.bdnImportFile.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnImportFile.Size = new System.Drawing.Size(1924, 31);
            this.bdnImportFile.TabIndex = 93;
            this.bdnImportFile.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(1453, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(385, 48);
            this.label6.TabIndex = 102;
            this.label6.Text = "Employee ID:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEMPID
            // 
            this.textBoxEMPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEMPID.Location = new System.Drawing.Point(1741, 137);
            this.textBoxEMPID.MaxLength = 7;
            this.textBoxEMPID.Multiline = true;
            this.textBoxEMPID.Name = "textBoxEMPID";
            this.textBoxEMPID.Size = new System.Drawing.Size(228, 30);
            this.textBoxEMPID.TabIndex = 106;
            // 
            // dgvImportFiles
            // 
            this.dgvImportFiles.AllowUserToAddRows = false;
            this.dgvImportFiles.AllowUserToDeleteRows = false;
            this.dgvImportFiles.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvImportFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvImportFiles.Name = "dgvImportFiles";
            this.dgvImportFiles.ReadOnly = true;
            this.dgvImportFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvImportFiles.RowTemplate.Height = 24;
            this.dgvImportFiles.Size = new System.Drawing.Size(1924, 929);
            this.dgvImportFiles.TabIndex = 23;
            this.dgvImportFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportFiles_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvImportFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 929);
            this.panel1.TabIndex = 107;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // ImportFile
            // 
            this.ImportFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ImportFile.Image = global::ATD.Windows.Properties.Resources._001_folder;
            this.ImportFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ImportFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportFile.Name = "ImportFile";
            this.ImportFile.Size = new System.Drawing.Size(28, 28);
            this.ImportFile.Text = "Import Files";
            this.ImportFile.Click += new System.EventHandler(this.ImportFile_Click);
            // 
            // SaveToDB
            // 
            this.SaveToDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToDB.Image = global::ATD.Windows.Properties.Resources._009_save;
            this.SaveToDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveToDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToDB.Name = "SaveToDB";
            this.SaveToDB.Size = new System.Drawing.Size(28, 28);
            this.SaveToDB.Text = "Save";
            this.SaveToDB.Click += new System.EventHandler(this.SaveToDB_Click);
            // 
            // Refresh201
            // 
            this.Refresh201.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh201.Image = global::ATD.Windows.Properties.Resources._003_refresh24x24;
            this.Refresh201.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Refresh201.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh201.Name = "Refresh201";
            this.Refresh201.Size = new System.Drawing.Size(28, 28);
            this.Refresh201.Text = "Refresh";
            this.Refresh201.Click += new System.EventHandler(this.Refresh201_Click);
            // 
            // TRN201Import_FilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxEMPID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bdnImportFile);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Name = "TRN201Import_FilesForm";
            this.Text = "TRN201Import_FilesForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdnImportFile)).EndInit();
            this.bdnImportFile.ResumeLayout(false);
            this.bdnImportFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsImportFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingNavigator bdnImportFile;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bdsImportFile;
        private System.Windows.Forms.ToolStripButton ImportFile;
        private System.Windows.Forms.OpenFileDialog OpenImportFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEMPID;
        private System.Windows.Forms.DataGridView dgvImportFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton SaveToDB;
        private System.Windows.Forms.ToolStripButton Refresh201;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}