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


namespace jordan_rowland_c969
{
    public partial class MainForm : Form
    {

        User CurrentUser { get; set; } = new User() { Id = 1, Username = "test" };

        public MainForm(MySqlConnection conn)
        {
            //using (LoginForm loginForm = new LoginForm(conn))
            //{
            //    loginForm.ShowDialog();
            //    if (!loginForm.LoginSuccessful) Environment.Exit(0);
            //    CurrentUser = loginForm.CurrentUser;
            //}
            InitializeComponent();
            txt_User.Text = $"Logged in as: {CurrentUser.Username}";

            FillCustomerDataGrid();
            FillAppointmentDataGrid();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillCustomerDataGrid()
        {
            MySqlDataAdapter adp;
            DataTable dt;
            adp = new MySqlDataAdapter(
                new MySqlCommand("SELECT * FROM customer", DBConnection.Conn));
            dt = new DataTable();
            adp.Fill(dt);
            dg_Customers.DataSource = dt;
        }

        private void FillAppointmentDataGrid()
        {
            MySqlDataAdapter adp;
            DataTable dt;
            adp = new MySqlDataAdapter(
                new MySqlCommand("SELECT * FROM appointment", DBConnection.Conn));
            dt = new DataTable();
            adp.Fill(dt);
            dg_Appointments.DataSource = dt;
        }

        private void btn_Exit_Click(object sender, EventArgs e) => Close();

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            AddEditCustomer addEditCustomer = new AddEditCustomer();
            addEditCustomer.ShowDialog();
            FillCustomerDataGrid();
            //dg_Customers.Refresh();
        }

        private void btn_UpdateCustomer_Click(object sender, EventArgs e)
        {
            // Get customer and pass in to form
            AddEditCustomer addEditCustomer = new AddEditCustomer();
            addEditCustomer.ShowDialog();
        }

        private void btn_DeleteCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            AddEditAppointment addEditAppointment = new AddEditAppointment();
            addEditAppointment.ShowDialog();
        }

        private void btn_UpdateAppointment_Click(object sender, EventArgs e)
        {
            // Get appointment and pass in to form
            AddEditAppointment addEditAppointment = new AddEditAppointment();
            addEditAppointment.ShowDialog();
        }

        private void btn_DeleteAppointment_Click(object sender, EventArgs e)
        {

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
