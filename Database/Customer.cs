using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using jordan_rowland_c969.Services;

namespace jordan_rowland_c969.Database
{
    public static class Customer
    {
        public static bool Create(Services.Customer customer)
        {

            MySqlConnection conn = DBConnection.Conn;
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO customer (" +
                "customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@customerName, @addressId, 1, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                conn))
            {
                // Probably need try/catch here
                cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 50).Value = customer.Name;
                cmd.Parameters.Add("@addressId", MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = "test";
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = "test";
                cmd.ExecuteNonQuery();
                return true;
            }

            return false;
        }
    }
}
