using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    public static class Country
    {
        public static int Create(Global g, string country)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)",
                DBConnection.Conn))
            {
                cmd.Parameters.Add("@country", MySqlDbType.VarChar, 50).Value = country;
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 50).Value = g.User.Username;
                cmd.ExecuteNonQuery();
            }

            MySqlCommand query = new MySqlCommand(
                $"SELECT countryId FROM country ORDER BY countryId DESC",
                DBConnection.Conn);
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            int result = reader.GetInt32(0);
            reader.Close();
            return result;
        }
    }
}
