namespace ATD.Windows
{
    partial class MAS105VacationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS105VacationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.bdnVacation = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Save4 = new System.Windows.Forms.ToolStripButton();
            this.Refresh4 = new System.Windows.Forms.ToolStripButton();
            this.textBoxVacationdesc = new System.Windows.Forms.TextBox();
            this.checkBoxActivated = new System.Windows.Forms.CheckBox();
            this.textBoxVacationID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVacation = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvVacation = new System.Windows.Forms.DataGridView();
            this.bdsVacation = new System.Windows.Forms.BindingSource(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.bdnVacation)).BeginInit();
            this.bdnVacation.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVacation)).BeginInit();
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
            this.label1.Text = "Vacation Data Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bdnVacation
            // 
            this.bdnVacation.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bdnVacation.CountItem = this.bindingNavigatorCountItem;
            this.bdnVacation.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdnVacation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.Save4,
            this.toolStripSeparator4,
            this.Refresh4});
            this.bdnVacation.Location = new System.Drawing.Point(0, 60);
            this.bdnVacation.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnVacation.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnVacation.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnVacation.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnVacation.Name = "bdnVacation";
            this.bdnVacation.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnVacation.Size = new System.Drawing.Size(1924, 27);
            this.bdnVacation.TabIndex = 95;
            this.bdnVacation.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // Save4
            // 
            this.Save4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save4.Image = global::ATD.Windows.Properties.Resources.Save;
            this.Save4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save4.Name = "Save4";
            this.Save4.Size = new System.Drawing.Size(23, 24);
            this.Save4.Text = "Save Data";
            this.Save4.Click += new System.EventHandler(this.Save4_Click);
            // 
            // Refresh4
            // 
            this.Refresh4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh4.Image = global::ATD.Windows.Properties.Resources.computer_icons_clip_art_png_favpng_M070FyPc8TCR8X7L1JpvGcVe3_t;
            this.Refresh4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh4.Name = "Refresh4";
            this.Refresh4.Size = new System.Drawing.Size(23, 24);
            this.Refresh4.Text = "Refresh";
            this.Refresh4.Click += new System.EventHandler(this.Refresh4_Click);
            // 
            // textBoxVacationdesc
            // 
            this.textBoxVacationdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxVacationdesc.Location = new System.Drawing.Point(1129, 182);
            this.textBoxVacationdesc.MaxLength = 100;
            this.textBoxVacationdesc.Multiline = true;
            this.textBoxVacationdesc.Name = "textBoxVacationdesc";
            this.textBoxVacationdesc.Size = new System.Drawing.Size(740, 30);
            this.textBoxVacationdesc.TabIndex = 108;
            // 
            // checkBoxActivated
            // 
            this.checkBoxActivated.AutoSize = true;
            this.checkBoxActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.checkBoxActivated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxActivated.Location = new System.Drawing.Point(771, 249);
            this.checkBoxActivated.Name = "checkBoxActivated";
            this.checkBoxActivated.Size = new System.Drawing.Size(155, 36);
            this.checkBoxActivated.TabIndex = 107;
            this.checkBoxActivated.Text = "Activated";
            this.checkBoxActivated.UseVisualStyleBackColor = true;
            // 
            // textBoxVacationID
            // 
            this.textBoxVacationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxVacationID.Location = new System.Drawing.Point(291, 182);
            this.textBoxVacationID.MaxLength = 50;
            this.textBoxVacationID.Multiline = true;
            this.textBoxVacationID.Name = "textBoxVacationID";
            this.textBoxVacationID.Size = new System.Drawing.Size(308, 30);
            this.textBoxVacationID.TabIndex = 106;
            this.textBoxVacationID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVacationID_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(676, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(489, 48);
            this.label3.TabIndex = 105;
            this.label3.Text = "Vacation Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(32, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 48);
            this.label2.TabIndex = 104;
            this.label2.Text = "Vacation ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(-95, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(499, 48);
            this.label4.TabIndex = 109;
            this.label4.Text = "Vacation Date ID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpVacation
            // 
            this.dtpVacation.CustomFormat = "dd/MMM/yyyy";
            this.dtpVacation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpVacation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVacation.Location = new System.Drawing.Point(291, 244);
            this.dtpVacation.Name = "dtpVacation";
            this.dtpVacation.Size = new System.Drawing.Size(192, 34);
            this.dtpVacation.TabIndex = 110;
            this.dtpVacation.Value = new System.DateTime(2020, 12, 25, 11, 10, 10, 0);
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
            this.label13.TabIndex = 111;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvVacation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 465);
            this.panel1.TabIndex = 112;
            // 
            // dgvVacation
            // 
            this.dgvVacation.AllowUserToAddRows = false;
            this.dgvVacation.AllowUserToDeleteRows = false;
            this.dgvVacation.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvVacation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVacation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVacation.Location = new System.Drawing.Point(0, 0);
            this.dgvVacation.Name = "dgvVacation";
            this.dgvVacation.ReadOnly = true;
            this.dgvVacation.RowTemplate.Height = 24;
            this.dgvVacation.Size = new System.Drawing.Size(1924, 465);
            this.dgvVacation.TabIndex = 25;
            this.dgvVacation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVacation_CellClick);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 552);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1924, 3);
            this.splitter1.TabIndex = 113;
            this.splitter1.TabStop = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // MAS105VacationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpVacation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxVacationdesc);
            this.Controls.Add(this.checkBoxActivated);
            this.Controls.Add(this.textBoxVacationID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bdnVacation);
            this.Controls.Add(this.label1);
            this.Name = "MAS105VacationForm";
            this.Text = "MAS105VacationForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bdnVacation)).EndInit();
            this.bdnVacation.ResumeLayout(false);
            this.bdnVacation.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVacation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVacation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator bdnVacation;
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
        private System.Windows.Forms.ToolStripButton Save4;
        private System.Windows.Forms.ToolStripButton Refresh4;
        private System.Windows.Forms.TextBox textBoxVacationdesc;
        private System.Windows.Forms.CheckBox checkBoxActivated;
        private System.Windows.Forms.TextBox textBoxVacationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpVacation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvVacation;
        private System.Windows.Forms.BindingSource bdsVacation;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}