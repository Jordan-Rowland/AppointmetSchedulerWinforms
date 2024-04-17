using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jordan_rowland_c969.Services;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace jordan_rowland_c969
{
    public partial class LoginForm : Form
    {
        MySqlConnection Conn { get; }
        public Global Global { get; set; }
        public bool LoginSuccessful { get; set; }

        internal LoginForm(MySqlConnection conn, Global g)
        {
            InitializeComponent();
            Conn = conn;
            Global = g;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            (bool result, Global global) = Services.Login.ValidateLogin(Conn, txt_Username.Text, txt_Password.Text);
            
            if (!result) MessageBox.Show("Username or Password is incorrect");
            else
            {
                Global = global;
                LoginSuccessful = true;
                Close();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
