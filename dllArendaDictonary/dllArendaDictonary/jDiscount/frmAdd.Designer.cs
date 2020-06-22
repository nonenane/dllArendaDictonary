namespace dllArendaDictonary.jDiscount
{
    partial class frmAdd
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
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lTypeDiscont = new System.Windows.Forms.Label();
            this.cmbTypeDicount = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.rbStab = new System.Windows.Forms.RadioButton();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lStart = new System.Windows.Forms.Label();
            this.lEnd = new System.Windows.Forms.Label();
            this.lTypeTenant = new System.Windows.Forms.Label();
            this.cmbTypeTenant = new System.Windows.Forms.ComboBox();
            this.lTypeAgreements = new System.Windows.Forms.Label();
            this.cmbTypeAgreements = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::dllArendaDictonary.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(456, 435);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 2;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::dllArendaDictonary.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(494, 435);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 3;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lTypeDiscont
            // 
            this.lTypeDiscont.AutoSize = true;
            this.lTypeDiscont.Location = new System.Drawing.Point(40, 70);
            this.lTypeDiscont.Name = "lTypeDiscont";
            this.lTypeDiscont.Size = new System.Drawing.Size(65, 13);
            this.lTypeDiscont.TabIndex = 6;
            this.lTypeDiscont.Text = "Тип скидки";
            // 
            // cmbTypeDicount
            // 
            this.cmbTypeDicount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDicount.FormattingEnabled = true;
            this.cmbTypeDicount.Location = new System.Drawing.Point(117, 66);
            this.cmbTypeDicount.Name = "cmbTypeDicount";
            this.cmbTypeDicount.Size = new System.Drawing.Size(413, 21);
            this.cmbTypeDicount.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbStab);
            this.groupBox1.Controls.Add(this.rbTime);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 48);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Временной тип скидки";
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Checked = true;
            this.rbTime.Location = new System.Drawing.Point(6, 19);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(121, 17);
            this.rbTime.TabIndex = 9;
            this.rbTime.TabStop = true;
            this.rbTime.Text = "Временная скидка";
            this.rbTime.UseVisualStyleBackColor = true;
            this.rbTime.Click += new System.EventHandler(this.rbTime_Click);
            // 
            // rbStab
            // 
            this.rbStab.AutoSize = true;
            this.rbStab.Location = new System.Drawing.Point(136, 19);
            this.rbStab.Name = "rbStab";
            this.rbStab.Size = new System.Drawing.Size(125, 17);
            this.rbStab.TabIndex = 9;
            this.rbStab.Text = "Постоянная скидка";
            this.rbStab.UseVisualStyleBackColor = true;
            this.rbStab.Click += new System.EventHandler(this.rbTime_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(323, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(88, 20);
            this.dtpStart.TabIndex = 9;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(442, 27);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(88, 20);
            this.dtpEnd.TabIndex = 9;
            // 
            // lStart
            // 
            this.lStart.AutoSize = true;
            this.lStart.Location = new System.Drawing.Point(304, 31);
            this.lStart.Name = "lStart";
            this.lStart.Size = new System.Drawing.Size(13, 13);
            this.lStart.TabIndex = 10;
            this.lStart.Text = "с";
            // 
            // lEnd
            // 
            this.lEnd.AutoSize = true;
            this.lEnd.Location = new System.Drawing.Point(417, 31);
            this.lEnd.Name = "lEnd";
            this.lEnd.Size = new System.Drawing.Size(19, 13);
            this.lEnd.TabIndex = 10;
            this.lEnd.Text = "по";
            // 
            // lTypeTenant
            // 
            this.lTypeTenant.AutoSize = true;
            this.lTypeTenant.Location = new System.Drawing.Point(17, 97);
            this.lTypeTenant.Name = "lTypeTenant";
            this.lTypeTenant.Size = new System.Drawing.Size(88, 13);
            this.lTypeTenant.TabIndex = 6;
            this.lTypeTenant.Text = "Тип арендатора";
            // 
            // cmbTypeTenant
            // 
            this.cmbTypeTenant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeTenant.FormattingEnabled = true;
            this.cmbTypeTenant.Location = new System.Drawing.Point(117, 93);
            this.cmbTypeTenant.Name = "cmbTypeTenant";
            this.cmbTypeTenant.Size = new System.Drawing.Size(413, 21);
            this.cmbTypeTenant.TabIndex = 7;
            // 
            // lTypeAgreements
            // 
            this.lTypeAgreements.AutoSize = true;
            this.lTypeAgreements.Location = new System.Drawing.Point(29, 124);
            this.lTypeAgreements.Name = "lTypeAgreements";
            this.lTypeAgreements.Size = new System.Drawing.Size(76, 13);
            this.lTypeAgreements.TabIndex = 6;
            this.lTypeAgreements.Text = "Тип договора";
            // 
            // cmbTypeAgreements
            // 
            this.cmbTypeAgreements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeAgreements.FormattingEnabled = true;
            this.cmbTypeAgreements.Location = new System.Drawing.Point(117, 120);
            this.cmbTypeAgreements.Name = "cmbTypeAgreements";
            this.cmbTypeAgreements.Size = new System.Drawing.Size(413, 21);
            this.cmbTypeAgreements.TabIndex = 7;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 479);
            this.Controls.Add(this.lEnd);
            this.Controls.Add(this.lStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTypeAgreements);
            this.Controls.Add(this.lTypeAgreements);
            this.Controls.Add(this.cmbTypeTenant);
            this.Controls.Add(this.lTypeTenant);
            this.Controls.Add(this.cmbTypeDicount);
            this.Controls.Add(this.lTypeDiscont);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lTypeDiscont;
        private System.Windows.Forms.ComboBox cmbTypeDicount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbStab;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lStart;
        private System.Windows.Forms.Label lEnd;
        private System.Windows.Forms.Label lTypeTenant;
        private System.Windows.Forms.ComboBox cmbTypeTenant;
        private System.Windows.Forms.Label lTypeAgreements;
        private System.Windows.Forms.ComboBox cmbTypeAgreements;
    }
}