﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Database
{
    public static class City
    {
        public static int Create(Global g, string city, int countryId)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)",
                DBInit.Conn))
            {
                cmd.Parameters.Add("@city", MySqlDbType.VarChar, 50).Value = DBHelper.NormalizeStringLength(city, 50);
                cmd.Parameters.Add("@countryId", MySqlDbType.Int32).Value = countryId;
                cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);
                cmd.ExecuteNonQuery();
            }

            MySqlCommand query = new MySqlCommand(
                $"SELECT cityId FROM city ORDER BY cityId DESC",
                DBInit.Conn);
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            int result = reader.GetInt32(0);
            reader.Close();
            return result;
        }
    }
}
