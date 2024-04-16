using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;


namespace jordan_rowland_c969
{
    public partial class Login : Form
    {
        public Login(MySqlConnection conn)
        {
            InitializeComponent();
            MySqlCommand query = new MySqlCommand("SELECT * FROM address", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(query);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
