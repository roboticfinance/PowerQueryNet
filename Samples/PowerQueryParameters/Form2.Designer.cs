namespace PowerQuery.Samples2
{
    partial class Form2
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
            this.dgvResult2 = new System.Windows.Forms.DataGridView();
            this.BtnList2 = new System.Windows.Forms.Button();
            this.txtPara1 = new System.Windows.Forms.TextBox();
            this.txtPara2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult2
            // 
            this.dgvResult2.AllowUserToAddRows = false;
            this.dgvResult2.AllowUserToDeleteRows = false;
            this.dgvResult2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult2.Location = new System.Drawing.Point(24, 79);
            this.dgvResult2.Margin = new System.Windows.Forms.Padding(6);
            this.dgvResult2.Name = "dgvResult2";
            this.dgvResult2.ReadOnly = true;
            this.dgvResult2.RowHeadersWidth = 82;
            this.dgvResult2.Size = new System.Drawing.Size(986, 856);
            this.dgvResult2.TabIndex = 100;
            // 
            // BtnList2
            // 
            this.BtnList2.Location = new System.Drawing.Point(822, 23);
            this.BtnList2.Margin = new System.Windows.Forms.Padding(6);
            this.BtnList2.Name = "BtnList2";
            this.BtnList2.Size = new System.Drawing.Size(188, 44);
            this.BtnList2.TabIndex = 102;
            this.BtnList2.Text = "Go";
            this.BtnList2.UseVisualStyleBackColor = true;
            this.BtnList2.Click += new System.EventHandler(this.BtnList2_Click);
            // 
            // txtPara1
            // 
            this.txtPara1.Location = new System.Drawing.Point(24, 23);
            this.txtPara1.Name = "txtPara1";
            this.txtPara1.Size = new System.Drawing.Size(298, 31);
            this.txtPara1.TabIndex = 103;
            this.txtPara1.Text = "FinXlsx";
            // 
            // txtPara2
            // 
            this.txtPara2.Location = new System.Drawing.Point(348, 23);
            this.txtPara2.Name = "txtPara2";
            this.txtPara2.Size = new System.Drawing.Size(271, 31);
            this.txtPara2.TabIndex = 104;
            this.txtPara2.Text = "Table1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 958);
            this.Controls.Add(this.txtPara2);
            this.Controls.Add(this.txtPara1);
            this.Controls.Add(this.BtnList2);
            this.Controls.Add(this.dgvResult2);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1040, 959);
            this.Name = "Form2";
            this.Text = "PowerQuery.Samples";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult2;
        private System.Windows.Forms.Button BtnList2;
        private System.Windows.Forms.TextBox txtPara1;
        private System.Windows.Forms.TextBox txtPara2;
    }
}

