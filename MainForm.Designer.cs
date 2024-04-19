namespace jordan_rowland_c969
{
    partial class MainForm
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
            this.dg_Customers = new System.Windows.Forms.DataGridView();
            this.dg_Appointments = new System.Windows.Forms.DataGridView();
            this.btn_DeleteCustomer = new System.Windows.Forms.Button();
            this.btn_UpdateCustomer = new System.Windows.Forms.Button();
            this.btn_AddCustomer = new System.Windows.Forms.Button();
            this.btn_AddAppointment = new System.Windows.Forms.Button();
            this.btn_UpdateAppointment = new System.Windows.Forms.Button();
            this.btn_DeleteAppointment = new System.Windows.Forms.Button();
            this.btn_Day = new System.Windows.Forms.Button();
            this.btn_Monthly = new System.Windows.Forms.Button();
            this.btn_All = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_User = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_Date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cbo_ReportType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Customers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Appointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Customers
            // 
            this.dg_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Customers.Location = new System.Drawing.Point(12, 114);
            this.dg_Customers.Name = "dg_Customers";
            this.dg_Customers.RowHeadersWidth = 51;
            this.dg_Customers.RowTemplate.Height = 24;
            this.dg_Customers.Size = new System.Drawing.Size(1049, 207);
            this.dg_Customers.TabIndex = 0;
            // 
            // dg_Appointments
            // 
            this.dg_Appointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Appointments.Location = new System.Drawing.Point(12, 436);
            this.dg_Appointments.Name = "dg_Appointments";
            this.dg_Appointments.RowHeadersWidth = 51;
            this.dg_Appointments.RowTemplate.Height = 24;
            this.dg_Appointments.Size = new System.Drawing.Size(1049, 207);
            this.dg_Appointments.TabIndex = 1;
            // 
            // btn_DeleteCustomer
            // 
            this.btn_DeleteCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteCustomer.Location = new System.Drawing.Point(917, 327);
            this.btn_DeleteCustomer.Name = "btn_DeleteCustomer";
            this.btn_DeleteCustomer.Size = new System.Drawing.Size(144, 40);
            this.btn_DeleteCustomer.TabIndex = 2;
            this.btn_DeleteCustomer.Text = "Delete";
            this.btn_DeleteCustomer.UseVisualStyleBackColor = true;
            this.btn_DeleteCustomer.Click += new System.EventHandler(this.btn_DeleteCustomer_Click);
            // 
            // btn_UpdateCustomer
            // 
            this.btn_UpdateCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateCustomer.Location = new System.Drawing.Point(767, 327);
            this.btn_UpdateCustomer.Name = "btn_UpdateCustomer";
            this.btn_UpdateCustomer.Size = new System.Drawing.Size(144, 40);
            this.btn_UpdateCustomer.TabIndex = 3;
            this.btn_UpdateCustomer.Text = "Update";
            this.btn_UpdateCustomer.UseVisualStyleBackColor = true;
            this.btn_UpdateCustomer.Click += new System.EventHandler(this.btn_UpdateCustomer_Click);
            // 
            // btn_AddCustomer
            // 
            this.btn_AddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddCustomer.Location = new System.Drawing.Point(617, 327);
            this.btn_AddCustomer.Name = "btn_AddCustomer";
            this.btn_AddCustomer.Size = new System.Drawing.Size(144, 40);
            this.btn_AddCustomer.TabIndex = 4;
            this.btn_AddCustomer.Text = "Add";
            this.btn_AddCustomer.UseVisualStyleBackColor = true;
            this.btn_AddCustomer.Click += new System.EventHandler(this.btn_AddCustomer_Click);
            // 
            // btn_AddAppointment
            // 
            this.btn_AddAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAppointment.Location = new System.Drawing.Point(617, 649);
            this.btn_AddAppointment.Name = "btn_AddAppointment";
            this.btn_AddAppointment.Size = new System.Drawing.Size(144, 40);
            this.btn_AddAppointment.TabIndex = 7;
            this.btn_AddAppointment.Text = "Add";
            this.btn_AddAppointment.UseVisualStyleBackColor = true;
            this.btn_AddAppointment.Click += new System.EventHandler(this.btn_AddAppointment_Click);
            // 
            // btn_UpdateAppointment
            // 
            this.btn_UpdateAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateAppointment.Location = new System.Drawing.Point(769, 649);
            this.btn_UpdateAppointment.Name = "btn_UpdateAppointment";
            this.btn_UpdateAppointment.Size = new System.Drawing.Size(142, 40);
            this.btn_UpdateAppointment.TabIndex = 6;
            this.btn_UpdateAppointment.Text = "Update";
            this.btn_UpdateAppointment.UseVisualStyleBackColor = true;
            this.btn_UpdateAppointment.Click += new System.EventHandler(this.btn_UpdateAppointment_Click);
            // 
            // btn_DeleteAppointment
            // 
            this.btn_DeleteAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteAppointment.Location = new System.Drawing.Point(917, 649);
            this.btn_DeleteAppointment.Name = "btn_DeleteAppointment";
            this.btn_DeleteAppointment.Size = new System.Drawing.Size(144, 40);
            this.btn_DeleteAppointment.TabIndex = 5;
            this.btn_DeleteAppointment.Text = "Delete";
            this.btn_DeleteAppointment.UseVisualStyleBackColor = true;
            this.btn_DeleteAppointment.Click += new System.EventHandler(this.btn_DeleteAppointment_Click);
            // 
            // btn_Day
            // 
            this.btn_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Day.Location = new System.Drawing.Point(12, 649);
            this.btn_Day.Name = "btn_Day";
            this.btn_Day.Size = new System.Drawing.Size(147, 40);
            this.btn_Day.TabIndex = 8;
            this.btn_Day.Text = "View Day";
            this.btn_Day.UseVisualStyleBackColor = true;
            this.btn_Day.Click += new System.EventHandler(this.btn_Day_Click);
            // 
            // btn_Monthly
            // 
            this.btn_Monthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Monthly.Location = new System.Drawing.Point(165, 649);
            this.btn_Monthly.Name = "btn_Monthly";
            this.btn_Monthly.Size = new System.Drawing.Size(147, 40);
            this.btn_Monthly.TabIndex = 9;
            this.btn_Monthly.Text = "View Monthly";
            this.btn_Monthly.UseVisualStyleBackColor = true;
            this.btn_Monthly.Click += new System.EventHandler(this.btn_Monthly_Click);
            // 
            // btn_All
            // 
            this.btn_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_All.Location = new System.Drawing.Point(318, 649);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(147, 40);
            this.btn_All.TabIndex = 10;
            this.btn_All.Text = "View All";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Customers";
            // 
            // txt_User
            // 
            this.txt_User.AutoSize = true;
            this.txt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_User.Location = new System.Drawing.Point(765, 9);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(115, 20);
            this.txt_User.TabIndex = 13;
            this.txt_User.Text = "Logged in as: ";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(917, 733);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(144, 40);
            this.btn_Exit.TabIndex = 14;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Appointments";
            // 
            // dt_Date
            // 
            this.dt_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Date.Location = new System.Drawing.Point(12, 695);
            this.dt_Date.Name = "dt_Date";
            this.dt_Date.Size = new System.Drawing.Size(147, 30);
            this.dt_Date.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(615, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 40);
            this.button1.TabIndex = 42;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_ReportType
            // 
            this.cbo_ReportType.DisplayMember = "Text";
            this.cbo_ReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_ReportType.FormattingEnabled = true;
            this.cbo_ReportType.Location = new System.Drawing.Point(234, 13);
            this.cbo_ReportType.Name = "cbo_ReportType";
            this.cbo_ReportType.Size = new System.Drawing.Size(375, 33);
            this.cbo_ReportType.TabIndex = 43;
            this.cbo_ReportType.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Generate Report";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 785);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_ReportType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dt_Date);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.txt_User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_All);
            this.Controls.Add(this.btn_Monthly);
            this.Controls.Add(this.btn_Day);
            this.Controls.Add(this.btn_AddAppointment);
            this.Controls.Add(this.btn_UpdateAppointment);
            this.Controls.Add(this.btn_DeleteAppointment);
            this.Controls.Add(this.btn_AddCustomer);
            this.Controls.Add(this.btn_UpdateCustomer);
            this.Controls.Add(this.btn_DeleteCustomer);
            this.Controls.Add(this.dg_Appointments);
            this.Controls.Add(this.dg_Customers);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Customers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Appointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Customers;
        private System.Windows.Forms.DataGridView dg_Appointments;
        private System.Windows.Forms.Button btn_DeleteCustomer;
        private System.Windows.Forms.Button btn_UpdateCustomer;
        private System.Windows.Forms.Button btn_AddCustomer;
        private System.Windows.Forms.Button btn_AddAppointment;
        private System.Windows.Forms.Button btn_UpdateAppointment;
        private System.Windows.Forms.Button btn_DeleteAppointment;
        private System.Windows.Forms.Button btn_Day;
        private System.Windows.Forms.Button btn_Monthly;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_User;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_Date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbo_ReportType;
        private System.Windows.Forms.Label label3;
    }
}

