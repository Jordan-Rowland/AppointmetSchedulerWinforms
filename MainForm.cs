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
using jordan_rowland_c969.Services;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;


namespace jordan_rowland_c969
{
    public partial class MainForm : Form
    {

        User CurrentUser { get; set; }

        public MainForm(MySqlConnection conn)
        {
            using (LoginForm loginForm = new LoginForm(conn))
            {
                loginForm.ShowDialog();
                if (!loginForm.LoginSuccessful) Environment.Exit(0);
                CurrentUser = loginForm.CurrentUser;
            }
            InitializeComponent();
            txt_User.Text = $"Logged in as: {CurrentUser.Username}";
            //MySqlCommand query = new MySqlCommand("SELECT * FROM address", conn);
            //MySqlDataAdapter adp = new MySqlDataAdapter(query);
            //DataTable dt = new DataTable();
            //adp.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e) => Close();

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
