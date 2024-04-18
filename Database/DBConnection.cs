using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace jordan_rowland_c969.Database
{
    public class DBConnection
    {
        public static MySqlConnection Conn { get; set; }

        public static void StartConnection()
        {
            try
            {
                // CHANGE USERNAME AND PASSWORD WHEN PUSHING TO PRODUCTION / VM
                Conn = new MySqlConnection(
                    ConfigurationManager
                        .ConnectionStrings["localdb"]
                        .ConnectionString
                );
                Conn.Open();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
        }

        public static void CloseConnection()
        {
            try
            {
                Conn?.Close();
                Conn = null;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }

        }
    }

    public enum DBAction { CREATE, UPDATE };
}
