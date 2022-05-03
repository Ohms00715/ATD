namespace ATD.Windows
{
    partial class MAS106Work_DayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS106Work_DayForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxActivated = new System.Windows.Forms.CheckBox();
            this.textBoxWorkDayID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bdnWorkDay = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvWorkDay = new System.Windows.Forms.DataGridView();
            this.comboBoxWorkDayForm = new System.Windows.Forms.ComboBox();
            this.comboBoxWorkDayTo = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Save5 = new System.Windows.Forms.ToolStripButton();
            this.Refresh5 = new System.Windows.Forms.ToolStripButton();
            this.bdsWorkDay = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdnWorkDay)).BeginInit();
            this.bdnWorkDay.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkDay)).BeginInit();
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
            this.label1.Text = "Work Day Data Management";
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
            this.label13.TabIndex = 112;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxActivated
            // 
            this.checkBoxActivated.AutoSize = true;
            this.checkBoxActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActivated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxActivated.Location = new System.Drawing.Point(47, 211);
            this.checkBoxActivated.Name = "checkBoxActivated";
            this.checkBoxActivated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxActivated.Size = new System.Drawing.Size(121, 36);
            this.checkBoxActivated.TabIndex = 116;
            this.checkBoxActivated.Text = ":ใช้งาน";
            this.checkBoxActivated.UseVisualStyleBackColor = true;
            // 
            // textBoxWorkDayID
            // 
            this.textBoxWorkDayID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxWorkDayID.Location = new System.Drawing.Point(418, 151);
            this.textBoxWorkDayID.MaxLength = 50;
            this.textBoxWorkDayID.Multiline = true;
            this.textBoxWorkDayID.Name = "textBoxWorkDayID";
            this.textBoxWorkDayID.Size = new System.Drawing.Size(308, 30);
            this.textBoxWorkDayID.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(-6, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(477, 48);
            this.label2.TabIndex = 113;
            this.label2.Text = "รูปเเบบการทำงานของเเต่ละทีม :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bdnWorkDay
            // 
            this.bdnWorkDay.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bdnWorkDay.CountItem = this.bindingNavigatorCountItem;
            this.bdnWorkDay.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdnWorkDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.toolStripSeparator1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator2,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator3,
            this.Save5,
            this.toolStripSeparator4,
            this.Refresh5});
            this.bdnWorkDay.Location = new System.Drawing.Point(0, 60);
            this.bdnWorkDay.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnWorkDay.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnWorkDay.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnWorkDay.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnWorkDay.Name = "bdnWorkDay";
            this.bdnWorkDay.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnWorkDay.Size = new System.Drawing.Size(1924, 31);
            this.bdnWorkDay.TabIndex = 118;
            this.bdnWorkDay.Text = "bindingNavigator1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(639, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(593, 48);
            this.label4.TabIndex = 119;
            this.label4.Text = "วันทำงานของเเต่ละทีมตั้งเเต่วัน :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(1217, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(599, 48);
            this.label5.TabIndex = 121;
            this.label5.Text = "วันทำงานของเเต่ละทีมถึงวัน :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvWorkDay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 619);
            this.panel1.TabIndex = 123;
            // 
            // dgvWorkDay
            // 
            this.dgvWorkDay.AllowUserToAddRows = false;
            this.dgvWorkDay.AllowUserToDeleteRows = false;
            this.dgvWorkDay.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvWorkDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkDay.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkDay.Name = "dgvWorkDay";
            this.dgvWorkDay.ReadOnly = true;
            this.dgvWorkDay.RowTemplate.Height = 24;
            this.dgvWorkDay.Size = new System.Drawing.Size(1924, 619);
            this.dgvWorkDay.TabIndex = 26;
            this.dgvWorkDay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkDay_CellClick);
            // 
            // comboBoxWorkDayForm
            // 
            this.comboBoxWorkDayForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkDayForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxWorkDayForm.FormattingEnabled = true;
            this.comboBoxWorkDayForm.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxWorkDayForm.Location = new System.Drawing.Point(1134, 150);
            this.comboBoxWorkDayForm.Name = "comboBoxWorkDayForm";
            this.comboBoxWorkDayForm.Size = new System.Drawing.Size(185, 33);
            this.comboBoxWorkDayForm.TabIndex = 124;
            // 
            // comboBoxWorkDayTo
            // 
            this.comboBoxWorkDayTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkDayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.comboBoxWorkDayTo.FormattingEnabled = true;
            this.comboBoxWorkDayTo.Items.AddRange(new object[] {
            "jk",
            "[p[",
            "iop",
            "iop"});
            this.comboBoxWorkDayTo.Location = new System.Drawing.Point(1694, 150);
            this.comboBoxWorkDayTo.Name = "comboBoxWorkDayTo";
            this.comboBoxWorkDayTo.Size = new System.Drawing.Size(185, 33);
            this.comboBoxWorkDayTo.TabIndex = 125;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 398);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1924, 3);
            this.splitter1.TabIndex = 126;
            this.splitter1.TabStop = false;
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
            // Save5
            // 
            this.Save5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save5.Image = global::ATD.Windows.Properties.Resources._009_save;
            this.Save5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Save5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save5.Name = "Save5";
            this.Save5.Size = new System.Drawing.Size(28, 28);
            this.Save5.Text = "Save Data";
            this.Save5.Click += new System.EventHandler(this.Save5_Click);
            // 
            // Refresh5
            // 
            this.Refresh5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh5.Image = global::ATD.Windows.Properties.Resources._003_refresh24x24;
            this.Refresh5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Refresh5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh5.Name = "Refresh5";
            this.Refresh5.Size = new System.Drawing.Size(28, 28);
            this.Refresh5.Text = "Refresh";
            this.Refresh5.Click += new System.EventHandler(this.Refresh5_Click);
            // 
            // MAS106Work_DayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.comboBoxWorkDayTo);
            this.Controls.Add(this.comboBoxWorkDayForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bdnWorkDay);
            this.Controls.Add(this.checkBoxActivated);
            this.Controls.Add(this.textBoxWorkDayID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "MAS106Work_DayForm";
            this.Text = "MAS106Work_DayForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdnWorkDay)).EndInit();
            this.bdnWorkDay.ResumeLayout(false);
            this.bdnWorkDay.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxActivated;
        private System.Windows.Forms.TextBox textBoxWorkDayID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bdnWorkDay;
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
        private System.Windows.Forms.ToolStripButton Save5;
        private System.Windows.Forms.ToolStripButton Refresh5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWorkDay;
        private System.Windows.Forms.BindingSource bdsWorkDay;
        private System.Windows.Forms.ComboBox comboBoxWorkDayForm;
        private System.Windows.Forms.ComboBox comboBoxWorkDayTo;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}