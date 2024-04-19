using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jordan_rowland_c969.Services
{
    public class Appointment
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


        public void Create(Global g)
        {
            ValidateDates(DBAction.CREATE);

            try
            {
                Database.Appointment.CreateUpdate(g, this, DBAction.CREATE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static Appointment GetAppointment(int appointmentID)
        {
            AppointmentStruct appointmentStruct = Database.Appointment.GetAppointment(appointmentID);
            return new Appointment()
            {
                AppointmentId = appointmentStruct.AppointmentId,
                CustomerId = appointmentStruct.CustomerId,
                UserId = appointmentStruct.UserId,
                UserName = appointmentStruct.UserName,
                CustomerName = appointmentStruct.CustomerName,
                Title = appointmentStruct.Title,
                Description = appointmentStruct.Description,
                Location = appointmentStruct.Location,
                Contact = appointmentStruct.Contact,
                Type = appointmentStruct.Type,
                Url = appointmentStruct.Url,
                Start = appointmentStruct.Start,
            };
        }


        public void Update(Global g)
        {
            ValidateDates(DBAction.UPDATE, this.AppointmentId);

            try
            {
                Database.Appointment.CreateUpdate(g, this, DBAction.UPDATE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void Delete(int appointmentId)
        {

            try
            {
                Database.Appointment.Delete(appointmentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void ValidateDates(DBAction action, int? appointmentID = null)
        {
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime utcStartTime = TimeZoneInfo.ConvertTimeToUtc(this.Start, TimeZoneInfo.Local);
            DateTime estStartTime = TimeZoneInfo.ConvertTimeFromUtc(utcStartTime, estZone);


            if (
                estStartTime.Hour < 9
                || estStartTime.Hour > 17
                || estStartTime.DayOfWeek == DayOfWeek.Saturday
                || estStartTime.DayOfWeek == DayOfWeek.Sunday
                )
            {
                // Received an error when editing Appt 1, make sure this is valid
                throw new Exception("Cannot schedule outside of Monday - Friday, 9am - 5pm Eastern Time.");
            }
            if (action == DBAction.CREATE)
                if (Database.Appointment.GetOverlappingAppointments(utcStartTime))
                    throw new Exception(
                        "There is already an appointment scheduled during this time.\n" +
                        "Please select another time."
                    );
            else if (action == DBAction.UPDATE)
                if (Database.Appointment.GetOverlappingAppointments(utcStartTime))
                    throw new Exception(
                        "There is already an appointment scheduled during this time.\n" +
                        "Please select another time."
                    );
        }

        public static bool CheckUpcomingAppointments(int userId) => Database.Appointment.CheckUpcomingAppointments(userId);
    }
}
