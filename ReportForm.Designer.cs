namespace jordan_rowland_c969
{
    partial class ReportForm
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
            this.dg_Report = new System.Windows.Forms.DataGridView();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_SelectUser = new System.Windows.Forms.Label();
            this.cbo_User = new System.Windows.Forms.ComboBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Report
            // 
            this.dg_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Report.Location = new System.Drawing.Point(12, 151);
            this.dg_Report.Name = "dg_Report";
            this.dg_Report.RowHeadersWidth = 51;
            this.dg_Report.RowTemplate.Height = 24;
            this.dg_Report.Size = new System.Drawing.Size(776, 549);
            this.dg_Report.TabIndex = 1;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(9, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(111, 31);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "Report: ";
            // 
            // lbl_SelectUser
            // 
            this.lbl_SelectUser.AutoSize = true;
            this.lbl_SelectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectUser.Location = new System.Drawing.Point(196, 73);
            this.lbl_SelectUser.Name = "lbl_SelectUser";
            this.lbl_SelectUser.Size = new System.Drawing.Size(119, 25);
            this.lbl_SelectUser.TabIndex = 4;
            this.lbl_SelectUser.Text = "Select User:";
            this.lbl_SelectUser.Visible = false;
            // 
            // cbo_User
            // 
            this.cbo_User.DisplayMember = "Text";
            this.cbo_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_User.FormattingEnabled = true;
            this.cbo_User.Location = new System.Drawing.Point(334, 70);
            this.cbo_User.Name = "cbo_User";
            this.cbo_User.Size = new System.Drawing.Size(248, 33);
            this.cbo_User.TabIndex = 5;
            this.cbo_User.ValueMember = "Id";
            this.cbo_User.Visible = false;
            this.cbo_User.SelectionChangeCommitted += new System.EventHandler(this.cbo_User_SelectionChangeCommitted);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(644, 715);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(144, 40);
            this.btn_Exit.TabIndex = 15;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 767);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.cbo_User);
            this.Controls.Add(this.lbl_SelectUser);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.dg_Report);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_Report;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_SelectUser;
        private System.Windows.Forms.ComboBox cbo_User;
        private System.Windows.Forms.Button btn_Exit;
    }
}