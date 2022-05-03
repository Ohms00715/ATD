namespace ATD.Windows
{
    partial class TRN202DataFilesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TRN202DataFilesForm));
            this.G = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bdnImportFileView = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvImportFilesView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSHITF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTEAM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEMP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpWorkDayTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.checkBoxOT = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRemark = new System.Windows.Forms.ComboBox();
            this.comboBoxDAY = new System.Windows.Forms.ComboBox();
            this.dtpWorkDayForm = new System.Windows.Forms.DateTimePicker();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Refresh201 = new System.Windows.Forms.ToolStripButton();
            this.SelectALL = new System.Windows.Forms.ToolStripButton();
            this.Get = new System.Windows.Forms.ToolStripButton();
            this.bdsImportFileView = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdnImportFileView)).BeginInit();
            this.bdnImportFileView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportFilesView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsImportFileView)).BeginInit();
            this.SuspendLayout();
            // 
            // G
            // 
            this.G.BackColor = System.Drawing.Color.ForestGreen;
            this.G.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.G.Cursor = System.Windows.Forms.Cursors.Default;
            this.G.Dock = System.Windows.Forms.DockStyle.Top;
            this.G.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.G.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.G.Location = new System.Drawing.Point(0, 0);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(1924, 60);
            this.G.TabIndex = 6;
            this.G.Text = "Attendence Transaction Management";
            this.G.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // bdnImportFileView
            // 
            this.bdnImportFileView.AddNewItem = null;
            this.bdnImportFileView.CountItem = this.bindingNavigatorCountItem;
            this.bdnImportFileView.DeleteItem = null;
            this.bdnImportFileView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.Refresh201,
            this.toolStripSeparator1,
            this.SelectALL,
            this.toolStripSeparator2,
            this.Get});
            this.bdnImportFileView.Location = new System.Drawing.Point(0, 60);
            this.bdnImportFileView.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnImportFileView.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnImportFileView.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnImportFileView.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnImportFileView.Name = "bdnImportFileView";
            this.bdnImportFileView.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnImportFileView.Size = new System.Drawing.Size(1924, 31);
            this.bdnImportFileView.TabIndex = 93;
            this.bdnImportFileView.Text = "bindingNavigator1";
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
            this.label6.Location = new System.Drawing.Point(181, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 48);
            this.label6.TabIndex = 102;
            this.label6.Text = "วัน :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvImportFilesView
            // 
            this.dgvImportFilesView.AllowUserToAddRows = false;
            this.dgvImportFilesView.AllowUserToDeleteRows = false;
            this.dgvImportFilesView.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvImportFilesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvImportFilesView.Location = new System.Drawing.Point(0, 0);
            this.dgvImportFilesView.Name = "dgvImportFilesView";
            this.dgvImportFilesView.ReadOnly = true;
            this.dgvImportFilesView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvImportFilesView.RowTemplate.Height = 24;
            this.dgvImportFilesView.Size = new System.Drawing.Size(1924, 516);
            this.dgvImportFilesView.TabIndex = 23;
            this.dgvImportFilesView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportFiles_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvImportFilesView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 516);
            this.panel1.TabIndex = 107;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 501);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1924, 3);
            this.splitter1.TabIndex = 108;
            this.splitter1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(570, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 48);
            this.label2.TabIndex = 110;
            this.label2.Text = "วันที่ตั้งเเต่ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(981, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 48);
            this.label3.TabIndex = 112;
            this.label3.Text = "ถึง";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxSHITF
            // 
            this.comboBoxSHITF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSHITF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxSHITF.FormattingEnabled = true;
            this.comboBoxSHITF.Items.AddRange(new object[] {
            ""});
            this.comboBoxSHITF.Location = new System.Drawing.Point(1638, 136);
            this.comboBoxSHITF.Name = "comboBoxSHITF";
            this.comboBoxSHITF.Size = new System.Drawing.Size(139, 33);
            this.comboBoxSHITF.TabIndex = 115;
            this.comboBoxSHITF.SelectedValueChanged += new System.EventHandler(this.comboBoxSHITF_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(1474, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 48);
            this.label4.TabIndex = 114;
            this.label4.Text = "กะ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTEAM
            // 
            this.comboBoxTEAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTEAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxTEAM.FormattingEnabled = true;
            this.comboBoxTEAM.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxTEAM.Location = new System.Drawing.Point(275, 229);
            this.comboBoxTEAM.Name = "comboBoxTEAM";
            this.comboBoxTEAM.Size = new System.Drawing.Size(139, 33);
            this.comboBoxTEAM.TabIndex = 117;
            this.comboBoxTEAM.SelectedValueChanged += new System.EventHandler(this.comboBoxTEAM_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(147, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 48);
            this.label5.TabIndex = 116;
            this.label5.Text = "ทีม :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxEMP
            // 
            this.comboBoxEMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxEMP.FormattingEnabled = true;
            this.comboBoxEMP.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxEMP.Location = new System.Drawing.Point(741, 241);
            this.comboBoxEMP.Name = "comboBoxEMP";
            this.comboBoxEMP.Size = new System.Drawing.Size(139, 33);
            this.comboBoxEMP.TabIndex = 119;
            this.comboBoxEMP.SelectedValueChanged += new System.EventHandler(this.comboBoxEMP_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(570, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 48);
            this.label7.TabIndex = 118;
            this.label7.Text = "รหัส :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpWorkDayTo
            // 
            this.dtpWorkDayTo.CustomFormat = "dd/MMM/yyyy";
            this.dtpWorkDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpWorkDayTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWorkDayTo.Location = new System.Drawing.Point(1143, 136);
            this.dtpWorkDayTo.Name = "dtpWorkDayTo";
            this.dtpWorkDayTo.Size = new System.Drawing.Size(192, 30);
            this.dtpWorkDayTo.TabIndex = 123;
            this.dtpWorkDayTo.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            this.dtpWorkDayTo.CloseUp += new System.EventHandler(this.dtpWorkDayTo_CloseUp);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(984, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(257, 48);
            this.label9.TabIndex = 124;
            this.label9.Text = "สถานะ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxStatus.Location = new System.Drawing.Point(1171, 244);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(139, 33);
            this.comboBoxStatus.TabIndex = 125;
            this.comboBoxStatus.SelectedValueChanged += new System.EventHandler(this.comboBoxStatus_SelectedValueChanged);
            // 
            // checkBoxOT
            // 
            this.checkBoxOT.AutoSize = true;
            this.checkBoxOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxOT.Location = new System.Drawing.Point(1554, 241);
            this.checkBoxOT.Name = "checkBoxOT";
            this.checkBoxOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxOT.Size = new System.Drawing.Size(100, 36);
            this.checkBoxOT.TabIndex = 126;
            this.checkBoxOT.Text = ": โอที";
            this.checkBoxOT.UseVisualStyleBackColor = true;
            this.checkBoxOT.CheckedChanged += new System.EventHandler(this.checkBoxOT_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(77, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(259, 48);
            this.label8.TabIndex = 127;
            this.label8.Text = "หมายเหตุ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxRemark
            // 
            this.comboBoxRemark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxRemark.FormattingEnabled = true;
            this.comboBoxRemark.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxRemark.Location = new System.Drawing.Point(275, 320);
            this.comboBoxRemark.Name = "comboBoxRemark";
            this.comboBoxRemark.Size = new System.Drawing.Size(238, 33);
            this.comboBoxRemark.TabIndex = 128;
            this.comboBoxRemark.SelectedValueChanged += new System.EventHandler(this.comboBoxRemark_SelectedValueChanged);
            // 
            // comboBoxDAY
            // 
            this.comboBoxDAY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxDAY.FormattingEnabled = true;
            this.comboBoxDAY.Location = new System.Drawing.Point(275, 136);
            this.comboBoxDAY.Name = "comboBoxDAY";
            this.comboBoxDAY.Size = new System.Drawing.Size(139, 33);
            this.comboBoxDAY.TabIndex = 129;
            this.comboBoxDAY.SelectedValueChanged += new System.EventHandler(this.comboBoxDAY_SelectedValueChanged);
            // 
            // dtpWorkDayForm
            // 
            this.dtpWorkDayForm.CustomFormat = "dd/MMM/yyyy";
            this.dtpWorkDayForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpWorkDayForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWorkDayForm.Location = new System.Drawing.Point(774, 136);
            this.dtpWorkDayForm.Name = "dtpWorkDayForm";
            this.dtpWorkDayForm.Size = new System.Drawing.Size(192, 30);
            this.dtpWorkDayForm.TabIndex = 122;
            this.dtpWorkDayForm.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            this.dtpWorkDayForm.CloseUp += new System.EventHandler(this.dtpWorkDayForm_CloseUp);
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
            // SelectALL
            // 
            this.SelectALL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectALL.Image = global::ATD.Windows.Properties.Resources._001_copy;
            this.SelectALL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SelectALL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectALL.Name = "SelectALL";
            this.SelectALL.Size = new System.Drawing.Size(28, 28);
            this.SelectALL.Text = "Select ALL Filter";
            this.SelectALL.Click += new System.EventHandler(this.SelectALL_Click);
            // 
            // Get
            // 
            this.Get.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Get.Image = global::ATD.Windows.Properties.Resources._00Previewfile;
            this.Get.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Get.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Get.Name = "Get";
            this.Get.Size = new System.Drawing.Size(28, 28);
            this.Get.Text = "GetData";
            this.Get.Click += new System.EventHandler(this.Get_Click);
            // 
            // TRN202DataFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.comboBoxDAY);
            this.Controls.Add(this.comboBoxRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxOT);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.dtpWorkDayTo);
            this.Controls.Add(this.dtpWorkDayForm);
            this.Controls.Add(this.comboBoxEMP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxTEAM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxSHITF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bdnImportFileView);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.G);
            this.Controls.Add(this.label9);
            this.Name = "TRN202DataFilesForm";
            this.Text = "TRN201Import_FilesForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdnImportFileView)).EndInit();
            this.bdnImportFileView.ResumeLayout(false);
            this.bdnImportFileView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportFilesView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsImportFileView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label G;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingNavigator bdnImportFileView;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bdsImportFileView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvImportFilesView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton Refresh201;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSHITF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTEAM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxEMP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpWorkDayTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.CheckBox checkBoxOT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxRemark;
        private System.Windows.Forms.ToolStripButton SelectALL;
        private System.Windows.Forms.ComboBox comboBoxDAY;
        private System.Windows.Forms.DateTimePicker dtpWorkDayForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Get;
    }
}