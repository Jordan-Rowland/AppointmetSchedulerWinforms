using System;
using System.Collections.Generic;
using System.Diagnostics;

using MySql.Data.MySqlClient;


namespace jordan_rowland_c969.Database
{
    public static class Appointment
    {
        public static void CreateUpdate(Global g, Services.Appointment appointment, DBAction action)
        {
            MySqlCommand cmd = new MySqlCommand();

            Debug.WriteLine(TimeZoneInfo.ConvertTimeToUtc(appointment.Start, TimeZoneInfo.Local));

            if (action == DBAction.CREATE)
            {
                cmd = new MySqlCommand(
                "INSERT INTO appointment (" +
                "customerId, userId, title, description, location, contact, " +
                "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy" +
                ") VALUES (" +
                "@customerId, @userId, @title, @description, @location, @contact, " +
                "@type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy" +
                ")",
                DBInit.Conn);
            }
            else if (action == DBAction.UPDATE)
            {
                cmd = new MySqlCommand(
                    "UPDATE appointment SET " +
                    "customerId = @customerId, " +
                    "userId = @userId, " +
                    "title = @title, " +
                    "description = @description, " +
                    "location = @location, " +
                    "contact = @contact, " +
                    "type = @type, " +
                    "url = @url, " +
                    "start = @start, " +
                    "end = @end, " +
                    "lastUpdate = @lastUpdate, " +
                    "lastUpdateBy = @lastUpdateBy " +
                    "WHERE appointmentId = @appointmentId",
                    DBInit.Conn);
            }
            using (cmd)
            {
                cmd.Parameters.Add("@customerId", MySqlDbType.Int32).Value = appointment.CustomerId;
                cmd.Parameters.Add("@userId", MySqlDbType.Int32).Value = appointment.UserId;
                cmd.Parameters.Add("@title", MySqlDbType.VarChar, 255).Value = DBHelper.NormalizeStringLength(appointment.Title, 255, defaultValue: "not needed");
                cmd.Parameters.Add("@description", MySqlDbType.VarChar, 50).Value = DBHelper.NormalizeStringLength(appointment.Description, defaultValue: "not needed");
                cmd.Parameters.Add("@location", MySqlDbType.VarChar, 50).Value = DBHelper.NormalizeStringLength(appointment.Location, defaultValue: "not needed");
                cmd.Parameters.Add("@contact", MySqlDbType.VarChar, 50).Value = DBHelper.NormalizeStringLength(appointment.Contact, defaultValue: "not needed");
                cmd.Parameters.Add("@type", MySqlDbType.VarChar, 50).Value = appointment.Type;
                cmd.Parameters.Add("@url", MySqlDbType.VarChar, 255).Value = DBHelper.NormalizeStringLength(appointment.Url, 255, defaultValue: "not needed");
                cmd.Parameters.Add("@start", MySqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(appointment.Start, TimeZoneInfo.Local);
                cmd.Parameters.Add("@end", MySqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(appointment.Start.AddMinutes(45), TimeZoneInfo.Local);
                cmd.Parameters.Add("@lastUpdate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                cmd.Parameters.Add("@lastUpdateBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);

                if (action == DBAction.CREATE)
                {
                    // Had a crash when updating the Beat Farm row related to @createdDate
                    cmd.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = DateTime.UtcNow;
                    cmd.Parameters.Add("@createdBy", MySqlDbType.VarChar, 40).Value = DBHelper.NormalizeStringLength(g.User.Username, 40);
                }
                else if (action == DBAction.UPDATE)
                    cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointment.AppointmentId;

                cmd.ExecuteNonQuery();
            }
        }


        public static AppointmentStruct GetAppointment(int appointmentId)
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT " +
                "a.appointmentID " +
                ", a.customerId" +
                ", a.userId" +
                ", title" +
                ", description" +
                ", location" +
                ", contact" +
                ", type" +
                ", url" +
                ", start" +
                ", u.userName" +
                ", c.customerName " +
                "FROM appointment a " +
                "INNER JOIN user u on u.userId = a.userId " +
                "INNER JOIN customer c on c.customerId = a.customerId " +
                "WHERE a.appointmentId = @appointmentId",
                DBInit.Conn);
            query.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            MySqlDataReader reader = query.ExecuteReader();

            reader.Read();
            AppointmentStruct appointment = new AppointmentStruct()
            {
                AppointmentId = reader.GetInt32(0),
                CustomerId = reader.GetInt32(1),
                UserId = reader.GetInt32(2),
                Title = reader.GetString(3),
                Description = reader.GetString(4),
                Location = reader.GetString(5),
                Contact = reader.GetString(6),
                Type = reader.GetString(7),
                Url = reader.GetString(8),
                Start = reader.GetDateTime(9),
                UserName = reader.GetString(10),
                CustomerName = reader.GetString(11),
            };
            reader.Close();
            return appointment;
        }

        public static List<AppointmentStruct> GetAppointments()
        {
            MySqlCommand query = new MySqlCommand(
                "SELECT " +
                "a.appointmentID " +
                ", a.customerId" +
                ", a.userId" +
                ", title" +
                ", description" +
                ", location" +
                ", contact" +
                ", type" +
                ", url" +
                ", start" +
                ", u.userName" +
                ", c.customerName " +
                "FROM appointment a " +
                "INNER JOIN user u on u.userId = a.userId " +
                "INNER JOIN customer c on c.customerId = a.customerId " +
                DBInit.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            List<AppointmentStruct> appointments = new List<AppointmentStruct>();
            while (reader.Read())
            {
                appointments.Add(new AppointmentStruct()
                {
                    AppointmentId = reader.GetInt32(0),
                    CustomerId = reader.GetInt32(1),
                    UserId = reader.GetInt32(2),
                    Title = reader.GetString(3),
                    Description = reader.GetString(4),
                    Location = reader.GetString(5),
                    Contact = reader.GetString(6),
                    Type = reader.GetString(7),
                    Url = reader.GetString(8),
                    Start = reader.GetDateTime(9),
                    UserName = reader.GetString(10),
                    CustomerName = reader.GetString(11),
                });

            }
            reader.Close();
            return appointments;
        }


        public static void Delete(int appointmentId)
        {
            using (MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM appointment WHERE appointmentId = @appointmentId", DBInit.Conn))
            {
                cmd.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
                cmd.ExecuteNonQuery();
            }
        }


        public static bool GetOverlappingAppointments(DateTime utcStartTime)
        {
            string strStartTime = utcStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = utcStartTime.AddMinutes(45).ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand query = new MySqlCommand(
                $"SELECT * FROM appointment WHERE (" +
                $"start < '{strStartTime}' AND '{strStartTime}' < end" +
                $") OR (" +
                $"start < '{strEndTime}' AND '{strEndTime}' < end" +
                $")",
                DBInit.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }


        public static bool GetOverlappingAppointments(DateTime utcStartTime, int appointmentID)
        {
            string strStartTime = utcStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            string strEndTime = utcStartTime.AddMinutes(45).ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand query = new MySqlCommand(
                $"SELECT start, end FROM appointment WHERE ((" +
                $"start < '{strStartTime}' AND '{strStartTime}' < end" +
                $") OR (" +
                $"start < '{strEndTime}' AND '{strEndTime}' < end" +
                $")) AND appointmentId != {appointmentID}",
                DBInit.Conn
            );

            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                Debug.WriteLine($"\n\nGOT ONE {reader.GetInt32(0)}\n\n");
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }

        public static bool CheckUpcomingAppointments(int userId)
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime utcNowPlus15 = utcNow.AddMinutes(15);

            MySqlCommand query = new MySqlCommand(
                "SELECT * FROM appointment WHERE userId = @userId " +
                "AND start > @utcNow AND start < @utcNowPlus15",
            DBInit.Conn
            );

            query.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
            query.Parameters.Add("@utcNow", MySqlDbType.VarChar, 40).Value = utcNow.ToString("yyyy-MM-dd HH:mm:ss");
            query.Parameters.Add("@utcNowPlus15", MySqlDbType.VarChar, 40).Value = utcNowPlus15.ToString("yyyy-MM-dd HH:mm:ss");

            Debug.WriteLine("SELECT * FROM appointment " +
                $"WHERE userId = {userId} " +
                $"AND start BETWEEN DATE('{utcNow.ToString("yyyy-MM-dd HH:mm:ss")}') " +
                $"AND DATE('{utcNowPlus15.ToString("yyyy-MM-dd HH:mm:ss")}')");

            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }


        public static bool CheckForCustomerAppointments(int customerId)
        {
            MySqlCommand query = new MySqlCommand(
                "select * FROM appointment WHERE customerId = @customerId", DBInit.Conn);
            query.Parameters.Add("@customerId", MySqlDbType.Int32).Value = customerId;

            MySqlDataReader reader = query.ExecuteReader();

            if (reader.Read()) return true;
            return false;

        }
    }


    public struct AppointmentStruct
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
    }
}
