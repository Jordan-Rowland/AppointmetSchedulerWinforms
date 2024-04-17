using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace jordan_rowland_c969.Services
{
    public static class Login
    {
        internal static (bool result, Global global) ValidateLogin(
            MySqlConnection conn, string username, string password)
        {
            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM user WHERE userName = @username and password = @password",
                conn
            );
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = query.ExecuteReader();

            (bool result, Global global) results = (false, new Global());
            if (reader.Read())
            {
                results = (true, new Global() {
                    User = (reader.GetInt32(0), reader.GetString(1)),
                });
            }
            // TODO: Throw an exception here instead 
            reader.Close();
            return results;
        }
    }
}
