using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using jordan_rowland_c969.Database;
using System.Diagnostics;


namespace jordan_rowland_c969
{
    public partial class MainForm : Form
    {

        Global Global { get; set; } = new Global() { User = (2, "test2") };
        //Global Global { get; set; }  // Keep this

        public MainForm(Global global)
        {
            // DO NOT DELETE, NEED ALL THIS
            //Global = global;
            //using (LoginForm loginForm = new LoginForm(DBInit.Conn, Global))
            //{
            //    loginForm.ShowDialog();
            //    if (!loginForm.LoginSuccessful) Environment.Exit(0);
            //    Global = loginForm.Global;
            //}

            InitializeComponent();
            txt_User.Text = $"Logged in as: {Global.User.Username}";

            // Write better queries - ALSO check all queries for correct parameters
            FormHelpers.FillDataGrid(dg_Customers, new MySqlDataAdapter("SELECT * FROM customer;", DBInit.Conn));
            FormHelpers.FillDataGrid(dg_Appointments, new MySqlDataAdapter("SELECT * FROM appointment;", DBInit.Conn));

            cbo_ReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_ReportType.DataSource = new ComboItem[]
            {
                new ComboItem{ Id = 1, Text = "Appointment Types Per Month" },
                new ComboItem{ Id = 2, Text = "Consultant Schedules" },
                new ComboItem{ Id = 3, Text = "Number of Customer Appointments" },
            };
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Services.Appointment.CheckUpcomingAppointments(Global.User.Id))
                MessageBox.Show("You have an upcoming appointment within the next 15 minutes.");
        }


        private void btn_Exit_Click(object sender, EventArgs e) => Close();


        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                AddEditCustomerForm addEditCustomer = new AddEditCustomerForm(Global);
                addEditCustomer.ShowDialog();
                FormHelpers.FillDataGrid(dg_Customers, new MySqlDataAdapter("SELECT * FROM customer;", DBInit.Conn));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_UpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dg_Customers.SelectedRows.Count >= 1)
            {
                // Will need to update customerId when queries are updated
                int id = (int)dg_Customers.SelectedRows[0].Cells["customerId"].Value;
                Services.Customer customer = Services.Customer.GetCustomer(id);
                AddEditCustomerForm addEditCustomer = new AddEditCustomerForm(Global, customer);

                try
                {
                    addEditCustomer.ShowDialog();
                    FormHelpers.FillDataGrid(
                        dg_Customers,
                        new MySqlDataAdapter("SELECT * FROM customer;", DBInit.Conn)
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("No Customer Selected");
        }


        private void btn_DeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dg_Customers.SelectedRows.Count >= 1)
            {
                try
                {
                    int id = (int)dg_Customers.SelectedRows[0].Cells["CustomerId"].Value;
                    string message = "Delete customer?";
                    string caption = "Click Yes or No to confirm";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes) Services.Customer.Delete(id);
                    FormHelpers.FillDataGrid(dg_Customers, new MySqlDataAdapter("SELECT * FROM customer;", DBInit.Conn));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("No Customer Selected");
        }


        private void btn_AddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                AddEditAppointmentForm addEditAppointment = new AddEditAppointmentForm(Global);
                addEditAppointment.ShowDialog();
                FormHelpers.FillDataGrid(dg_Appointments, new MySqlDataAdapter("SELECT * FROM appointment;", DBInit.Conn));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_UpdateAppointment_Click(object sender, EventArgs e)
        {
            if (dg_Customers.SelectedRows.Count >= 1)
            {
                try
                {
                    int id = (int)dg_Appointments.SelectedRows[0].Cells["appointmentId"].Value;
                    Services.Appointment appointment = Services.Appointment.GetAppointment(id);
                    AddEditAppointmentForm addEditAppointment = new AddEditAppointmentForm(Global, appointment);
                    addEditAppointment.ShowDialog();
                    FormHelpers.FillDataGrid(dg_Appointments, new MySqlDataAdapter("SELECT * FROM appointment;", DBInit.Conn));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("No Appointment Selected");
        }


        private void btn_DeleteAppointment_Click(object sender, EventArgs e)
        {
            if (dg_Customers.SelectedRows.Count >= 1)
            {
                try
                {
                    int id = (int)dg_Appointments.SelectedRows[0].Cells["AppointmentId"].Value;
                    string message = "Delete Apointment?";
                    string caption = "Click Yes or No to confirm";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes) Services.Appointment.Delete(id);
                    FormHelpers.FillDataGrid(dg_Appointments, new MySqlDataAdapter("SELECT * FROM appointment;", DBInit.Conn));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("No Appointment Selected");
        }


        private void btn_All_Click(object sender, EventArgs e)
        {
            FormHelpers.FillDataGrid(dg_Appointments, new MySqlDataAdapter("SELECT * FROM appointment;", DBInit.Conn));
        }


        private void btn_Monthly_Click(object sender, EventArgs e)
        {
            // Need to convert this to UTC before query
            DateTime now = DateTime.UtcNow;
            string month = now.Month < 10 ? $"0{now.Month}" : now.Month.ToString();
            string query = $"SELECT * FROM appointment WHERE start LIKE '{now.Year}-{month}%' ;";
            FormHelpers.FillDataGrid(
                dg_Appointments,
                new MySqlDataAdapter($"SELECT * FROM appointment WHERE start LIKE '{now.Year}-{month}%' ;", DBInit.Conn)
            );
        }


        private void btn_Day_Click(object sender, EventArgs e)
        {
            DateTime selectedDay = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(dt_Date.Text), TimeZoneInfo.Local);
            FormHelpers.FillDataGrid(
                dg_Appointments,
                new MySqlDataAdapter(
                    $"SELECT * FROM appointment WHERE start between " +
                    $"DATE('{selectedDay.ToString("yyyy-MM-dd")}') " +
                    $"AND DATE('{selectedDay.AddHours(24).ToString("yyyy-MM-dd")}') "
                    , DBInit.Conn)
                );
        }


        private void btn_Generate_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(cbo_ReportType.ValueMember);
            Debug.WriteLine(cbo_ReportType.DisplayMember);
            ReportForm reportForm = new ReportForm(Global, (Convert.ToInt32(cbo_ReportType.SelectedValue), cbo_ReportType.Text)) ;
            reportForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
