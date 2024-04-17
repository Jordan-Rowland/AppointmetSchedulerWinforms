using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jordan_rowland_c969.Database;
using jordan_rowland_c969.Services;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace jordan_rowland_c969
{
    public partial class MainForm : Form
    {

        Global Global { get; set; } = new Global() { User = (9, "test 5") };
        //Global Global { get; set; }  // Keep this

        public MainForm(Global global)
        {
            //CultureInfo.CurrentCulture

            //// DO NOT DELETE, NEED ALL THIS
            //Global = global;
            //using (LoginForm loginForm = new LoginForm(DBConnection.Conn, Global))
            //{
            //    loginForm.ShowDialog();
            //    if (!loginForm.LoginSuccessful) Environment.Exit(0);
            //    Global = loginForm.Global;
            //}
            InitializeComponent();
            txt_User.Text = $"Logged in as: {Global.User.Username}";

            FillDataGrid(dg_Customers, "customer");
            FillDataGrid(dg_Appointments, "appointment");

            dg_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_Appointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_Customers.AllowUserToAddRows = false;
            dg_Appointments.AllowUserToAddRows = false;
            dg_Customers.ReadOnly = true;
            dg_Appointments.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillDataGrid(DataGridView dataGrid, string table)
        {
            MySqlDataAdapter adp;
            DataTable dt;
            adp = new MySqlDataAdapter(new MySqlCommand($"SELECT * FROM {table}", DBConnection.Conn));
            dt = new DataTable();
            adp.Fill(dt);
            dataGrid.DataSource = dt;
        }

        private void btn_Exit_Click(object sender, EventArgs e) => Close();

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            // phone number should only have digits and dashes
            AddEditCustomer addEditCustomer = new AddEditCustomer(Global);
            addEditCustomer.ShowDialog();
            FillDataGrid(dg_Customers, "customer");
        }

        private void btn_UpdateCustomer_Click(object sender, EventArgs e)
        {
            // Get customer and pass in to form
            // phone number should only have digits and dashes
            int id = (int)dg_Customers.SelectedRows[0].Cells["customerId"].Value;
            Services.Customer customer = Services.Customer.GetCustomer(id);
            AddEditCustomer addEditCustomer = new AddEditCustomer(Global, customer);
            addEditCustomer.ShowDialog();
            FillDataGrid(dg_Customers, "customer");
        }

        private void btn_DeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dg_Customers.SelectedRows[0].Cells["CustomerId"].Value;
                string message = "Delete customer?";
                string caption = "Click Yes or No to confirm";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes) Services.Customer.Delete(id);
                FillDataGrid(dg_Customers, "customer");
            }
            catch
            {
                // Probably need to account for other errors
                MessageBox.Show("No Customer selected");
            }
        }

        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            AddEditAppointment addEditAppointment = new AddEditAppointment(Global);
            addEditAppointment.ShowDialog();
            FillDataGrid(dg_Appointments, "appointment");
        }

        private void btn_UpdateAppointment_Click(object sender, EventArgs e)
        {
            // Get appointment and pass in to form
            int id = (int)dg_Appointments.SelectedRows[0].Cells["appointmentId"].Value;
            Services.Appointment appointment = Services.Appointment.GetAppointment(id);
            AddEditAppointment addEditAppointment = new AddEditAppointment(Global, appointment);
            addEditAppointment.ShowDialog();
            FillDataGrid(dg_Appointments, "appointment");
        }

        private void btn_DeleteAppointment_Click(object sender, EventArgs e)
        {

            try
            {
                int id = (int)dg_Appointments.SelectedRows[0].Cells["AppointmentId"].Value;
                string message = "Delete Apointment?";
                string caption = "Click Yes or No to confirm";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes) Services.Appointment.Delete(id);
                FillDataGrid(dg_Customers, "customer");
            }
            catch
            {
                // Probably need to account for other errors
                MessageBox.Show("No Customer selected");
            }

            FillDataGrid(dg_Appointments, "appointment");
        }

        private void btn_All_Click(object sender, EventArgs e)
        {

        }

        private void btn_Monthly_Click(object sender, EventArgs e)
        {

        }

        private void btn_Weekly_Click(object sender, EventArgs e)
        {

        }
    }
}
