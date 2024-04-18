﻿using jordan_rowland_c969.Database;
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
            // Check against Eastern timezone, 9am-5pm
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime utcStartTime= TimeZoneInfo.ConvertTimeToUtc(this.Start, TimeZoneInfo.Local);
            DateTime estStartTime = TimeZoneInfo.ConvertTimeFromUtc(utcStartTime, estZone);

            if (
                estStartTime.Hour < 9
                || estStartTime.Hour > 17
                || estStartTime.DayOfWeek == DayOfWeek.Saturday
                || estStartTime.DayOfWeek == DayOfWeek.Sunday
                )
            {
                throw new Exception("Cannot schedule outside of business hours.");
            }

            Database.Appointment.Create(g, this);
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

        public void Update(Global g) => // Capture the exception if it bubbles up
            Database.Appointment.Update(g, this);

        public static void Delete(int appointmentId) => // Capture the exception if it bubbles up
            Database.Appointment.Delete(appointmentId);
    }
}
