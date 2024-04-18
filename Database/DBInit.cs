using System.Configuration;
using System.Windows.Forms;

using MySql.Data.MySqlClient;


namespace jordan_rowland_c969.Database
{
    public class DBInit
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

    public static class DBHelper
    {
        public static string NormalizeStringLength(string value, int? maxLength = null, string defaultValue = "")
        {
            if (value == "") return defaultValue;
            if (value.Length < maxLength || maxLength == null) return value;
            return value.Substring(0, maxLength.Value);
        }
    }

    public enum DBAction { CREATE, UPDATE };
}
