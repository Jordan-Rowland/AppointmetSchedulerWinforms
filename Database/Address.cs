using jordan_rowland_c969.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    public static class Address
    {
        public static int Create(Global g, string address, int cityId, string phone)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO address (" +
                "address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@address, '', @cityId, '', @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                DBInit.Conn))
            {
                cmd.Parameters.Add("@address", MySqlDbType.VarChar, 50).Value = DBHelper.NormalizeStringLength(address, 50);
                cmd.Parameters.Add("@cityId", MySqlDbType.Int32).Value = cityId;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar, 20).Value = DBHelper.NormalizeStringLength(phone, 20);
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);
                cmd.ExecuteNonQuery();
            }
            MySqlCommand query = new MySqlCommand(
                $"SELECT addressId FROM address ORDER BY addressId DESC",
                DBInit.Conn);
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            int result = reader.GetInt32(0);
            reader.Close();
            return result;
        }
    }
}