using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                // CHANGE USERNAME AND PASSWORD WHEN PUSHING TO VM
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=client_schedule");
                conn.Open();

                MySqlCommand query = new MySqlCommand("SELECT * FROM address", conn);
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string address = reader.GetString(1);
                    Console.WriteLine(id + " " + address);
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
