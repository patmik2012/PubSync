
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtBxAuthor = new System.Windows.Forms.TextBox();
            this.dGVMTMT = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMTMTCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMTMT)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(279, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Keres";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAuthor.Location = new System.Drawing.Point(30, 31);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(63, 20);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Szerző:";
            // 
            // txtBxAuthor
            // 
            this.txtBxAuthor.Location = new System.Drawing.Point(113, 30);
            this.txtBxAuthor.Name = "txtBxAuthor";
            this.txtBxAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtBxAuthor.TabIndex = 3;
            // 
            // dGVMTMT
            // 
            this.dGVMTMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMTMT.Location = new System.Drawing.Point(37, 114);
            this.dGVMTMT.Name = "dGVMTMT";
            this.dGVMTMT.Size = new System.Drawing.Size(592, 268);
            this.dGVMTMT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MTMT művek:";
            // 
            // lblMTMTCount
            // 
            this.lblMTMTCount.AutoSize = true;
            this.lblMTMTCount.Location = new System.Drawing.Point(113, 75);
            this.lblMTMTCount.Name = "lblMTMTCount";
            this.lblMTMTCount.Size = new System.Drawing.Size(0, 13);
            this.lblMTMTCount.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMTMTCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.dGVMTMT);
            this.Controls.Add(this.btnSearch);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dGVMTMT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtBxAuthor;
        private System.Windows.Forms.DataGridView dGVMTMT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMTMTCount;
    }
}

