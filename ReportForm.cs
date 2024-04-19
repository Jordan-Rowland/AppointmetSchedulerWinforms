using jordan_rowland_c969.Database;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using jordan_rowland_c969.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace jordan_rowland_c969
{
    public partial class ReportForm : Form
    {

        //private readonly int FormType;

        public ReportForm(Global g, (int Id, string Name) reportType)
        {
            InitializeComponent();

            MySqlDataAdapter adp = new MySqlDataAdapter();
            if (reportType.Id == 1)
            {
                lbl_Title.Text = $"Report: {reportType.Name}";
                adp = new MySqlDataAdapter(
                    "SELECT DATE_FORMAT(start, \"%M-%Y\") AS Month, " +
                    "`type` AS \"Appointment Type\", COUNT(type) as 'Appointments Per Month'" +
                    "FROM appointment GROUP BY 1, 2",
                    DBInit.Conn);
            }
            else if (reportType.Id == 2)
            {
                lbl_Title.Text = $"Report: {reportType.Name}";
                lbl_SelectUser.Visible = true;
                cbo_User.Visible = true;

                cbo_User.DataSource = FormHelpers.GetUserDataSource();

                // Set initially with Current User
                int userId = Convert.ToInt32(cbo_User.SelectedValue);
                MySqlCommand query = GetUserAppointmentsQuery(userId);
                adp = new MySqlDataAdapter(query);
            }

            FormHelpers.FillDataGrid(dg_Report, adp);
        }


        private MySqlCommand GetUserAppointmentsQuery(int userId)
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT * FROM appointment WHERE userID = @userId",
                DBInit.Conn);
            query.Parameters.AddWithValue("@userId", userId);
            return query;
        }


        private void ReportForm_Load(object sender, EventArgs e) {}


        private void cbo_User_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(cbo_User.SelectedValue);
            MySqlCommand query = GetUserAppointmentsQuery(userId);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            FormHelpers.FillDataGrid(dg_Report, adp);
        }


        private void btn_Exit_Click(object sender, EventArgs e) => Close();
    }
}
