namespace ATD.Windows
{
    partial class MAS101EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS101EmployeeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEMPID = new System.Windows.Forms.TextBox();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.checkBoxResigned = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpResigned = new System.Windows.Forms.DateTimePicker();
            this.checkBoxRegister = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpRegisterd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxVA = new System.Windows.Forms.CheckBox();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDep = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxWD = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bdnEMP = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvEMP = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxShitfType = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelDgv = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.Save1 = new System.Windows.Forms.ToolStripButton();
            this.Refresh1 = new System.Windows.Forms.ToolStripButton();
            this.bdsEMP = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdnEMP)).BeginInit();
            this.bdnEMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMP)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEMP)).BeginInit();
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
            this.label1.Text = "Employee Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(-24, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 48);
            this.label2.TabIndex = 9;
            this.label2.Text = "รหัส :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(771, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 48);
            this.label3.TabIndex = 10;
            this.label3.Text = "ชื่อ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(1286, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 48);
            this.label4.TabIndex = 11;
            this.label4.Text = "นามสกุล :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxEMPID
            // 
            this.textBoxEMPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEMPID.Location = new System.Drawing.Point(286, 32);
            this.textBoxEMPID.MaxLength = 7;
            this.textBoxEMPID.Multiline = true;
            this.textBoxEMPID.Name = "textBoxEMPID";
            this.textBoxEMPID.Size = new System.Drawing.Size(186, 30);
            this.textBoxEMPID.TabIndex = 12;
            this.textBoxEMPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEMPID_KeyPress);
            // 
            // textBoxFName
            // 
            this.textBoxFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxFName.Location = new System.Drawing.Point(1004, 38);
            this.textBoxFName.MaxLength = 50;
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.Size = new System.Drawing.Size(359, 30);
            this.textBoxFName.TabIndex = 13;
            // 
            // textBoxLName
            // 
            this.textBoxLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxLName.Location = new System.Drawing.Point(1503, 38);
            this.textBoxLName.MaxLength = 50;
            this.textBoxLName.Multiline = true;
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(418, 30);
            this.textBoxLName.TabIndex = 14;
            // 
            // checkBoxResigned
            // 
            this.checkBoxResigned.AutoSize = true;
            this.checkBoxResigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxResigned.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxResigned.Location = new System.Drawing.Point(14, 213);
            this.checkBoxResigned.Name = "checkBoxResigned";
            this.checkBoxResigned.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxResigned.Size = new System.Drawing.Size(293, 36);
            this.checkBoxResigned.TabIndex = 15;
            this.checkBoxResigned.Text = ": สถานะการลงทะเบียน";
            this.checkBoxResigned.UseVisualStyleBackColor = true;
            this.checkBoxResigned.CheckedChanged += new System.EventHandler(this.checkBoxResigned_CheckedChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(283, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 48);
            this.label5.TabIndex = 63;
            this.label5.Text = "วันที่ลงทะเบียน :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpResigned
            // 
            this.dtpResigned.CustomFormat = "dd/MMM/yyyy";
            this.dtpResigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpResigned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpResigned.Location = new System.Drawing.Point(552, 217);
            this.dtpResigned.Name = "dtpResigned";
            this.dtpResigned.Size = new System.Drawing.Size(192, 30);
            this.dtpResigned.TabIndex = 64;
            this.dtpResigned.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            this.dtpResigned.ValueChanged += new System.EventHandler(this.dtpResigned_ValueChanged);
            // 
            // checkBoxRegister
            // 
            this.checkBoxRegister.AutoSize = true;
            this.checkBoxRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRegister.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxRegister.Location = new System.Drawing.Point(777, 213);
            this.checkBoxRegister.Name = "checkBoxRegister";
            this.checkBoxRegister.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxRegister.Size = new System.Drawing.Size(251, 36);
            this.checkBoxRegister.TabIndex = 66;
            this.checkBoxRegister.Text = ": สถานะการลาออก";
            this.checkBoxRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRegister.UseVisualStyleBackColor = true;
            this.checkBoxRegister.CheckedChanged += new System.EventHandler(this.checkBoxRegister_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(954, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 48);
            this.label6.TabIndex = 67;
            this.label6.Text = "วันที่ลาออก :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpRegisterd
            // 
            this.dtpRegisterd.CustomFormat = "dd/MMM/yyyy";
            this.dtpRegisterd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpRegisterd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegisterd.Location = new System.Drawing.Point(1215, 217);
            this.dtpRegisterd.Name = "dtpRegisterd";
            this.dtpRegisterd.Size = new System.Drawing.Size(192, 30);
            this.dtpRegisterd.TabIndex = 68;
            this.dtpRegisterd.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(564, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 48);
            this.label7.TabIndex = 69;
            this.label7.Text = "คำนำหน้า :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(-28, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(309, 48);
            this.label8.TabIndex = 70;
            this.label8.Text = "ประเภทของพนักงาน :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxVA
            // 
            this.checkBoxVA.AutoSize = true;
            this.checkBoxVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxVA.Location = new System.Drawing.Point(1151, 154);
            this.checkBoxVA.Name = "checkBoxVA";
            this.checkBoxVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxVA.Size = new System.Drawing.Size(363, 36);
            this.checkBoxVA.TabIndex = 71;
            this.checkBoxVA.Text = ": กำหนดวันหยุดตามประเพณี";
            this.checkBoxVA.UseVisualStyleBackColor = true;
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxTitle.Location = new System.Drawing.Point(777, 35);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(139, 33);
            this.comboBoxTitle.TabIndex = 72;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxType.Location = new System.Drawing.Point(286, 90);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(283, 33);
            this.comboBoxType.TabIndex = 73;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(564, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 48);
            this.label9.TabIndex = 74;
            this.label9.Text = "เเผนก :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDep
            // 
            this.comboBoxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxDep.FormattingEnabled = true;
            this.comboBoxDep.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxDep.Location = new System.Drawing.Point(777, 99);
            this.comboBoxDep.Name = "comboBoxDep";
            this.comboBoxDep.Size = new System.Drawing.Size(304, 33);
            this.comboBoxDep.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(403, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(369, 48);
            this.label10.TabIndex = 76;
            this.label10.Text = "วันทำงาน :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxWD
            // 
            this.comboBoxWD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxWD.FormattingEnabled = true;
            this.comboBoxWD.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxWD.Location = new System.Drawing.Point(777, 154);
            this.comboBoxWD.Name = "comboBoxWD";
            this.comboBoxWD.Size = new System.Drawing.Size(304, 33);
            this.comboBoxWD.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(1109, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 48);
            this.label12.TabIndex = 80;
            this.label12.Text = "ทีม :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxTeam.Location = new System.Drawing.Point(1206, 102);
            this.comboBoxTeam.MaxDropDownItems = 9;
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(308, 33);
            this.comboBoxTeam.TabIndex = 81;
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
            this.label13.TabIndex = 82;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bdnEMP
            // 
            this.bdnEMP.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bdnEMP.CountItem = this.bindingNavigatorCountItem;
            this.bdnEMP.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdnEMP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorMoveNextItem,
            this.toolStripSeparator1,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator4,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator2,
            this.Save1,
            this.toolStripSeparator3,
            this.Refresh1});
            this.bdnEMP.Location = new System.Drawing.Point(0, 60);
            this.bdnEMP.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnEMP.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnEMP.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnEMP.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnEMP.Name = "bdnEMP";
            this.bdnEMP.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnEMP.Size = new System.Drawing.Size(1924, 31);
            this.bdnEMP.TabIndex = 85;
            this.bdnEMP.Text = "bindingNavigator1";
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // dgvEMP
            // 
            this.dgvEMP.AllowUserToAddRows = false;
            this.dgvEMP.AllowUserToDeleteRows = false;
            this.dgvEMP.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvEMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEMP.Location = new System.Drawing.Point(0, 0);
            this.dgvEMP.Name = "dgvEMP";
            this.dgvEMP.ReadOnly = true;
            this.dgvEMP.RowTemplate.Height = 24;
            this.dgvEMP.Size = new System.Drawing.Size(1924, 649);
            this.dgvEMP.TabIndex = 21;
            this.dgvEMP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEMP_CellClick);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(-6, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 48);
            this.label11.TabIndex = 87;
            this.label11.Text = "รูปเเบบการทำงาน :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxShitfType
            // 
            this.comboBoxShitfType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShitfType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxShitfType.FormattingEnabled = true;
            this.comboBoxShitfType.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxShitfType.Location = new System.Drawing.Point(286, 151);
            this.comboBoxShitfType.Name = "comboBoxShitfType";
            this.comboBoxShitfType.Size = new System.Drawing.Size(201, 33);
            this.comboBoxShitfType.TabIndex = 88;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 1017);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1924, 3);
            this.splitter1.TabIndex = 89;
            this.splitter1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.textBoxFName);
            this.panelMenu.Controls.Add(this.checkBoxRegister);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.label4);
            this.panelMenu.Controls.Add(this.checkBoxResigned);
            this.panelMenu.Controls.Add(this.comboBoxTitle);
            this.panelMenu.Controls.Add(this.textBoxLName);
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Controls.Add(this.label5);
            this.panelMenu.Controls.Add(this.textBoxEMPID);
            this.panelMenu.Controls.Add(this.dtpResigned);
            this.panelMenu.Controls.Add(this.label6);
            this.panelMenu.Controls.Add(this.comboBoxShitfType);
            this.panelMenu.Controls.Add(this.dtpRegisterd);
            this.panelMenu.Controls.Add(this.label11);
            this.panelMenu.Controls.Add(this.label7);
            this.panelMenu.Controls.Add(this.label8);
            this.panelMenu.Controls.Add(this.checkBoxVA);
            this.panelMenu.Controls.Add(this.comboBoxWD);
            this.panelMenu.Controls.Add(this.comboBoxType);
            this.panelMenu.Controls.Add(this.comboBoxTeam);
            this.panelMenu.Controls.Add(this.label9);
            this.panelMenu.Controls.Add(this.label12);
            this.panelMenu.Controls.Add(this.comboBoxDep);
            this.panelMenu.Controls.Add(this.label10);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 91);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1924, 277);
            this.panelMenu.TabIndex = 90;
            // 
            // panelDgv
            // 
            this.panelDgv.Controls.Add(this.dgvEMP);
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 368);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1924, 649);
            this.panelDgv.TabIndex = 91;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 368);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1924, 3);
            this.splitter2.TabIndex = 92;
            this.splitter2.TabStop = false;
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::ATD.Windows.Properties.Resources._003_add24x24;
            this.bindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::ATD.Windows.Properties.Resources._005_remove_24x24;
            this.bindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            // Save1
            // 
            this.Save1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save1.Image = global::ATD.Windows.Properties.Resources._009_save;
            this.Save1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Save1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save1.Name = "Save1";
            this.Save1.Size = new System.Drawing.Size(28, 28);
            this.Save1.Text = "Save";
            this.Save1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Refresh1
            // 
            this.Refresh1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh1.Image = global::ATD.Windows.Properties.Resources._003_refresh24x24;
            this.Refresh1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Refresh1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh1.Name = "Refresh1";
            this.Refresh1.Size = new System.Drawing.Size(28, 28);
            this.Refresh1.Text = "Refresh";
            this.Refresh1.Click += new System.EventHandler(this.Refresh1_Click);
            // 
            // MAS101EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panelDgv);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.bdnEMP);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Name = "MAS101EmployeeForm";
            this.Text = "MAS101EmployeeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdnEMP)).EndInit();
            this.bdnEMP.ResumeLayout(false);
            this.bdnEMP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMP)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsEMP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEMPID;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.CheckBox checkBoxResigned;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpResigned;
        private System.Windows.Forms.CheckBox checkBoxRegister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpRegisterd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxVA;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxWD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource bdsEMP;
        private System.Windows.Forms.BindingNavigator bdnEMP;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton Save1;
        private System.Windows.Forms.DataGridView dgvEMP;
        private System.Windows.Forms.ToolStripButton Refresh1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxShitfType;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelDgv;
        private System.Windows.Forms.Splitter splitter2;


    }
}