
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
            this.lblMTMTCount = new System.Windows.Forms.Label();
            this.lblMTMTBooks = new System.Windows.Forms.Label();
            this.txtBxAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGVMTMT = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMTMT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblMTMTCount);
            this.groupBox1.Controls.Add(this.lblMTMTBooks);
            this.groupBox1.Controls.Add(this.txtBxAuthor);
            this.groupBox1.Controls.Add(this.lblAuthor);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 105);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblMTMTCount
            // 
            this.lblMTMTCount.AutoSize = true;
            this.lblMTMTCount.Location = new System.Drawing.Point(111, 75);
            this.lblMTMTCount.Name = "lblMTMTCount";
            this.lblMTMTCount.Size = new System.Drawing.Size(0, 13);
            this.lblMTMTCount.TabIndex = 10;
            // 
            // lblMTMTBooks
            // 
            this.lblMTMTBooks.AutoSize = true;
            this.lblMTMTBooks.Location = new System.Drawing.Point(32, 76);
            this.lblMTMTBooks.Name = "lblMTMTBooks";
            this.lblMTMTBooks.Size = new System.Drawing.Size(77, 13);
            this.lblMTMTBooks.TabIndex = 9;
            this.lblMTMTBooks.Text = "MTMT művek:";
            // 
            // txtBxAuthor
            // 
            this.txtBxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBxAuthor.Location = new System.Drawing.Point(111, 30);
            this.txtBxAuthor.Name = "txtBxAuthor";
            this.txtBxAuthor.Size = new System.Drawing.Size(147, 26);
            this.txtBxAuthor.TabIndex = 0;
            this.txtBxAuthor.Text = "Süle Zoltán";
            this.txtBxAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBxAuthor_KeyDown);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAuthor.Location = new System.Drawing.Point(28, 31);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(63, 20);
            this.lblAuthor.TabIndex = 7;
            this.lblAuthor.Text = "Szerző:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSearch.Location = new System.Drawing.Point(313, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 41);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Keres";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.dGVMTMT);
            this.groupBox2.Location = new System.Drawing.Point(0, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 433);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // dGVMTMT
            // 
            this.dGVMTMT.AllowUserToAddRows = false;
            this.dGVMTMT.AllowUserToDeleteRows = false;
            this.dGVMTMT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dGVMTMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMTMT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVMTMT.Location = new System.Drawing.Point(3, 16);
            this.dGVMTMT.Name = "dGVMTMT";
            this.dGVMTMT.ReadOnly = true;
            this.dGVMTMT.Size = new System.Drawing.Size(771, 414);
            this.dGVMTMT.TabIndex = 2;
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
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVMTMT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMTMTCount;
        private System.Windows.Forms.Label lblMTMTBooks;
        private System.Windows.Forms.TextBox txtBxAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGVMTMT;
    }
}

