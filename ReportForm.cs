using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using jordan_rowland_c969.Database;


namespace jordan_rowland_c969
{
    public partial class ReportForm : Form
    {
        public ReportForm(Global g, (int Id, string Name) reportType)
        {
            InitializeComponent();

            MySqlDataAdapter adp = new MySqlDataAdapter();
            if (reportType.Id == 1)
            {
                lbl_Title.Text = GetReportName(reportType.Name);
                adp = CreateReportAdapter(
                    "SELECT DATE_FORMAT(start, \"%M-%Y\") AS Month, " +
                    "`type` AS \"Appointment Type\", COUNT(type) as 'Appointments Per Month'" +
                    "FROM appointment GROUP BY 1, 2");
            }
            else if (reportType.Id == 2)
            {
                lbl_Title.Text = GetReportName(reportType.Name);
                lbl_SelectUser.Visible = true;
                cbo_User.Visible = true;

                cbo_User.DataSource = FormHelpers.GetUserDataSource();

                // Set initially with Current User
                int userId = Convert.ToInt32(cbo_User.SelectedValue);
                MySqlCommand query = GetUserAppointmentsQuery(userId);
                adp = new MySqlDataAdapter(query);
            }
            else if (reportType.Id == 3)
            {
                lbl_Title.Text = GetReportName(reportType.Name);
                adp = CreateReportAdapter(
                    "SELECT customerName AS Customer, COUNT(*) as 'Customer Appointments' " +
                    "FROM appointment a " +
                    "INNER JOIN customer c on c.customerId = a.customerId " +
                    "GROUP BY 1");
            }

            FormHelpers.FillDataGrid(dg_Report, adp);
        }


        private readonly Func<int, MySqlCommand> GetUserAppointmentsQuery = userId =>
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT * FROM appointment WHERE userID = @userId",
                DBInit.Conn
            );
            query.Parameters.AddWithValue("@userId", userId);
            return query;
        };


        private readonly Func<string, string> GetReportName =
            report => $"Report: {report}";
        private readonly Func<string, MySqlDataAdapter> CreateReportAdapter =
            query => new MySqlDataAdapter(query, DBInit.Conn);


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
