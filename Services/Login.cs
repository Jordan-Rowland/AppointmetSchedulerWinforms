using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.IO;


namespace jordan_rowland_c969.Services
{
    public static class Login
    {
        internal static (bool result, Global g) ValidateLogin(
            MySqlConnection conn, string username, string password)
        {
            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM user " +
                $"WHERE userName = @username " +
                $"AND password = @password",
                conn
            );
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@password", password);
            MySqlDataReader reader = query.ExecuteReader();

            (bool result, Global g) results = (false, new Global());
            if (reader.Read())
            {
                results = (true, new Global() { User = (reader.GetInt32(0), reader.GetString(1)) });
                LogLoginActivity($"[SUCCESSFUL][{DateTime.UtcNow}]: {results.g.User.Username}");
            }
            else LogLoginActivity($"[FAILED][{DateTime.UtcNow}]: {username}");

            reader.Close();
            return results;
        }

        internal static void LogLoginActivity(string log)
        {
            using (StreamWriter writer = File.AppendText("..\\..\\Login_History.txt")) { writer.WriteLine(log); }
        }
    }
}
