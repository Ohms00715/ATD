namespace ATD.Windows
{
    partial class MAS103Employee_DepartmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAS103Employee_DepartmentForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDEP = new System.Windows.Forms.DataGridView();
            this.bdnDEP = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.textBoxEMPdesc = new System.Windows.Forms.TextBox();
            this.checkBoxActivated = new System.Windows.Forms.CheckBox();
            this.textBoxEMPID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Save2 = new System.Windows.Forms.ToolStripButton();
            this.Refresh2 = new System.Windows.Forms.ToolStripButton();
            this.bdsDEP = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnDEP)).BeginInit();
            this.bdnDEP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDEP)).BeginInit();
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
            this.label1.Text = "Department Data Management";
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
            this.label13.TabIndex = 84;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDEP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 706);
            this.panel1.TabIndex = 85;
            // 
            // dgvDEP
            // 
            this.dgvDEP.AllowUserToAddRows = false;
            this.dgvDEP.AllowUserToDeleteRows = false;
            this.dgvDEP.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvDEP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDEP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDEP.Location = new System.Drawing.Point(0, 0);
            this.dgvDEP.Name = "dgvDEP";
            this.dgvDEP.ReadOnly = true;
            this.dgvDEP.RowTemplate.Height = 24;
            this.dgvDEP.Size = new System.Drawing.Size(1924, 706);
            this.dgvDEP.TabIndex = 23;
            this.dgvDEP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDEP_CellClick);
            // 
            // bdnDEP
            // 
            this.bdnDEP.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bdnDEP.CountItem = this.bindingNavigatorCountItem;
            this.bdnDEP.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bdnDEP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.Save2,
            this.toolStripSeparator4,
            this.Refresh2});
            this.bdnDEP.Location = new System.Drawing.Point(0, 60);
            this.bdnDEP.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdnDEP.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdnDEP.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdnDEP.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdnDEP.Name = "bdnDEP";
            this.bdnDEP.PositionItem = this.bindingNavigatorPositionItem;
            this.bdnDEP.Size = new System.Drawing.Size(1924, 31);
            this.bdnDEP.TabIndex = 93;
            this.bdnDEP.Text = "bindingNavigator1";
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
            // textBoxEMPdesc
            // 
            this.textBoxEMPdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEMPdesc.Location = new System.Drawing.Point(752, 137);
            this.textBoxEMPdesc.MaxLength = 50;
            this.textBoxEMPdesc.Multiline = true;
            this.textBoxEMPdesc.Name = "textBoxEMPdesc";
            this.textBoxEMPdesc.Size = new System.Drawing.Size(308, 30);
            this.textBoxEMPdesc.TabIndex = 98;
            // 
            // checkBoxActivated
            // 
            this.checkBoxActivated.AutoSize = true;
            this.checkBoxActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActivated.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxActivated.Location = new System.Drawing.Point(1091, 134);
            this.checkBoxActivated.Name = "checkBoxActivated";
            this.checkBoxActivated.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxActivated.Size = new System.Drawing.Size(129, 36);
            this.checkBoxActivated.TabIndex = 97;
            this.checkBoxActivated.Text = ": ใช้งาน";
            this.checkBoxActivated.UseVisualStyleBackColor = true;
            // 
            // textBoxEMPID
            // 
            this.textBoxEMPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEMPID.Location = new System.Drawing.Point(192, 137);
            this.textBoxEMPID.MaxLength = 7;
            this.textBoxEMPID.Multiline = true;
            this.textBoxEMPID.Name = "textBoxEMPID";
            this.textBoxEMPID.Size = new System.Drawing.Size(308, 30);
            this.textBoxEMPID.TabIndex = 96;
            this.textBoxEMPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEMPID_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(397, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(489, 48);
            this.label3.TabIndex = 95;
            this.label3.Text = "คำอธิบายเเผนก :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(-135, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(499, 48);
            this.label2.TabIndex = 94;
            this.label2.Text = "รห้สเเผนก :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 311);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1924, 3);
            this.splitter1.TabIndex = 99;
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
            // Save2
            // 
            this.Save2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save2.Image = global::ATD.Windows.Properties.Resources._009_save;
            this.Save2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Save2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save2.Name = "Save2";
            this.Save2.Size = new System.Drawing.Size(28, 28);
            this.Save2.Text = "Save Data";
            this.Save2.Click += new System.EventHandler(this.Savve2_Click);
            // 
            // Refresh2
            // 
            this.Refresh2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Refresh2.Image = global::ATD.Windows.Properties.Resources._003_refresh24x24;
            this.Refresh2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Refresh2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Refresh2.Name = "Refresh2";
            this.Refresh2.Size = new System.Drawing.Size(28, 28);
            this.Refresh2.Text = "Refresh";
            this.Refresh2.Click += new System.EventHandler(this.Refresh2_Click);
            // 
            // MAS103Employee_DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.textBoxEMPdesc);
            this.Controls.Add(this.checkBoxActivated);
            this.Controls.Add(this.textBoxEMPID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bdnDEP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Name = "MAS103Employee_DepartmentForm";
            this.Text = "MAS103Employee_DepartmentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnDEP)).EndInit();
            this.bdnDEP.ResumeLayout(false);
            this.bdnDEP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDEP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDEP;
        private System.Windows.Forms.BindingNavigator bdnDEP;
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
        private System.Windows.Forms.ToolStripButton Save2;
        private System.Windows.Forms.ToolStripButton Refresh2;
        private System.Windows.Forms.BindingSource bdsDEP;
        private System.Windows.Forms.TextBox textBoxEMPdesc;
        private System.Windows.Forms.CheckBox checkBoxActivated;
        private System.Windows.Forms.TextBox textBoxEMPID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}