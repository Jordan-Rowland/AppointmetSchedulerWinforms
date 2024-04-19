using jordan_rowland_c969.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace jordan_rowland_c969
{
    public partial class AddEditAppointmentForm : Form
    {
        bool EditMode = false;
        int AppointmentId { get; set; }
        Global g { get; set; }

        public AddEditAppointmentForm(Global global)
        {
            InitializeComponent();
            g = global;
            dt_Date.Format = DateTimePickerFormat.Custom;
            dt_Date.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            ConfigureForm();
        }

        public AddEditAppointmentForm(Global global, Services.Appointment appointment)
        {
            InitializeComponent();
            g = global;
            EditMode = true;
            AppointmentId = appointment.AppointmentId;
            ConfigureForm();
            lbl_Title.Text = "Update Appointment";
            cbo_Customer.Text = appointment.CustomerName;
            cbo_User.Text = appointment.UserName;
            cbo_Type.Text = appointment.Type;
            txt_Contact.Text = appointment.Contact;
            txt_Description.Text = appointment.Description;
            txt_Location.Text = appointment.Location;
            txt_Title.Text = appointment.Title;
            txt_Url.Text = appointment.Url;
            dt_Date.Text = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local).ToString();
        }

        private void ConfigureForm()
        {
            // Comboc boxes need to be read-only
            dt_Date.Format = DateTimePickerFormat.Custom;
            dt_Date.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            List<CustomerStruct> customers = Database.Customer.GetCustomers();
            List<ComboItem> customerDataSource = new List<ComboItem>();
            foreach (var c in customers) customerDataSource.Add(new ComboItem { Id = c.Id, Text = c.Name });
            cbo_Customer.DataSource = customerDataSource;

            cbo_User.DataSource = FormHelpers.GetUserDataSource();

            cbo_Type.DataSource = new ComboItem[]
            {
                new ComboItem{ Id = 1, Text = "Presentation" },
                new ComboItem{ Id = 2, Text = "Scrum" },
                new ComboItem{ Id = 3, Text = "Interview" },
                new ComboItem{ Id = 4, Text = "Touchbase" },
                new ComboItem{ Id = 5, Text = "Recap" },
            };
        }

        private void AddEditAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            // In one instance, appt didn't seem to save. Ensure this works. 
            Services.Appointment appointment = new Services.Appointment()
            {
                CustomerId = Convert.ToInt32(cbo_Customer.SelectedValue),
                UserId = Convert.ToInt32(cbo_User.SelectedValue),
                Title = txt_Title.Text,
                Description = txt_Description.Text,
                Location = txt_Location.Text,
                Contact = txt_Contact.Text,
                Type = cbo_Type.Text,
                Url = txt_Url.Text,
                Start = dt_Date.Value,
            };

            if (EditMode)
            {
                appointment.AppointmentId = AppointmentId;
                appointment.Update(g);
            }
            else appointment.Create(g);
            Close();
        }

    }
}
