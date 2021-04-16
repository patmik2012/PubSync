
namespace PubSync
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gBSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTxtBDelay = new System.Windows.Forms.MaskedTextBox();
            this.lblGSBooks = new System.Windows.Forms.Label();
            this.cBSettings = new System.Windows.Forms.CheckBox();
            this.lblMTMTCount = new System.Windows.Forms.Label();
            this.LblMTMTBooks = new System.Windows.Forms.Label();
            this.TxtBxAuthor = new System.Windows.Forms.TextBox();
            this.LblAuthor = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVMTMT = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gBSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMTMT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.gBSettings);
            this.groupBox1.Controls.Add(this.lblGSBooks);
            this.groupBox1.Controls.Add(this.cBSettings);
            this.groupBox1.Controls.Add(this.lblMTMTCount);
            this.groupBox1.Controls.Add(this.LblMTMTBooks);
            this.groupBox1.Controls.Add(this.TxtBxAuthor);
            this.groupBox1.Controls.Add(this.LblAuthor);
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 124);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // gBSettings
            // 
            this.gBSettings.Controls.Add(this.label1);
            this.gBSettings.Controls.Add(this.mTxtBDelay);
            this.gBSettings.Location = new System.Drawing.Point(613, 12);
            this.gBSettings.Name = "gBSettings";
            this.gBSettings.Size = new System.Drawing.Size(152, 93);
            this.gBSettings.TabIndex = 14;
            this.gBSettings.TabStop = false;
            this.gBSettings.Text = "Beállítások";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Késleltetés:";
            // 
            // mTxtBDelay
            // 
            this.mTxtBDelay.Location = new System.Drawing.Point(73, 19);
            this.mTxtBDelay.Mask = "000";
            this.mTxtBDelay.Name = "mTxtBDelay";
            this.mTxtBDelay.Size = new System.Drawing.Size(36, 20);
            this.mTxtBDelay.TabIndex = 14;
            this.mTxtBDelay.Text = "250";
            this.mTxtBDelay.ValidatingType = typeof(int);
            // 
            // lblGSBooks
            // 
            this.lblGSBooks.AutoSize = true;
            this.lblGSBooks.Location = new System.Drawing.Point(229, 75);
            this.lblGSBooks.Name = "lblGSBooks";
            this.lblGSBooks.Size = new System.Drawing.Size(118, 13);
            this.lblGSBooks.TabIndex = 12;
            this.lblGSBooks.Text = "Google Scholar művek:";
            // 
            // cBSettings
            // 
            this.cBSettings.AutoSize = true;
            this.cBSettings.Location = new System.Drawing.Point(528, 75);
            this.cBSettings.Name = "cBSettings";
            this.cBSettings.Size = new System.Drawing.Size(79, 17);
            this.cBSettings.TabIndex = 11;
            this.cBSettings.Text = "Beállítások";
            this.cBSettings.UseVisualStyleBackColor = true;
            this.cBSettings.CheckedChanged += new System.EventHandler(this.cBSettings_CheckedChanged);
            // 
            // lblMTMTCount
            // 
            this.lblMTMTCount.AutoSize = true;
            this.lblMTMTCount.Location = new System.Drawing.Point(111, 75);
            this.lblMTMTCount.Name = "lblMTMTCount";
            this.lblMTMTCount.Size = new System.Drawing.Size(0, 13);
            this.lblMTMTCount.TabIndex = 10;
            // 
            // LblMTMTBooks
            // 
            this.LblMTMTBooks.AutoSize = true;
            this.LblMTMTBooks.Location = new System.Drawing.Point(32, 76);
            this.LblMTMTBooks.Name = "LblMTMTBooks";
            this.LblMTMTBooks.Size = new System.Drawing.Size(77, 13);
            this.LblMTMTBooks.TabIndex = 9;
            this.LblMTMTBooks.Text = "MTMT művek:";
            // 
            // TxtBxAuthor
            // 
            this.TxtBxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TxtBxAuthor.Location = new System.Drawing.Point(111, 30);
            this.TxtBxAuthor.Name = "TxtBxAuthor";
            this.TxtBxAuthor.Size = new System.Drawing.Size(375, 26);
            this.TxtBxAuthor.TabIndex = 0;
            this.TxtBxAuthor.Text = "Süle Zoltán";
            this.TxtBxAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBxAuthor_KeyDown);
            // 
            // LblAuthor
            // 
            this.LblAuthor.AutoSize = true;
            this.LblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LblAuthor.Location = new System.Drawing.Point(28, 31);
            this.LblAuthor.Name = "LblAuthor";
            this.LblAuthor.Size = new System.Drawing.Size(63, 20);
            this.LblAuthor.TabIndex = 7;
            this.LblAuthor.Text = "Szerző:";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnSearch.Location = new System.Drawing.Point(505, 23);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(102, 41);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "&Keres";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.DGVMTMT);
            this.groupBox2.Location = new System.Drawing.Point(0, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 433);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // DGVMTMT
            // 
            this.DGVMTMT.AllowUserToAddRows = false;
            this.DGVMTMT.AllowUserToDeleteRows = false;
            this.DGVMTMT.AllowUserToOrderColumns = true;
            this.DGVMTMT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMTMT.Location = new System.Drawing.Point(3, 16);
            this.DGVMTMT.Name = "DGVMTMT";
            this.DGVMTMT.ReadOnly = true;
            this.DGVMTMT.Size = new System.Drawing.Size(771, 414);
            this.DGVMTMT.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 544);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "PubSync";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBSettings.ResumeLayout(false);
            this.gBSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVMTMT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMTMTCount;
        private System.Windows.Forms.Label LblMTMTBooks;
        private System.Windows.Forms.TextBox TxtBxAuthor;
        private System.Windows.Forms.Label LblAuthor;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGVMTMT;
        private System.Windows.Forms.Label lblGSBooks;
        private System.Windows.Forms.CheckBox cBSettings;
        private System.Windows.Forms.GroupBox gBSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mTxtBDelay;
    }
}

