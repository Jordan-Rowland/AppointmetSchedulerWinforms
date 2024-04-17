using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    internal class Country
    {
        public void Create()
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)",
                DBConnection.Conn))
            {
                //cmd.Parameters.Add("@customerName", MySqlDbType.VarChar, 50).Value = customer.Name;
                cmd.Parameters.Add("@country", MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = "test"; // Make sure correct
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = "test"; // Make sure correct
                cmd.ExecuteNonQuery();
                //return true;
            }
        }
    }
}
