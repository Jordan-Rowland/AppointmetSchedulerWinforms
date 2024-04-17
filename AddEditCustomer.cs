using jordan_rowland_c969.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jordan_rowland_c969
{
    public partial class AddEditCustomer : Form
    {
        bool EditMode = false;

        public AddEditCustomer()
        {
            InitializeComponent();
        }

        //public AddEditCustomer(Customer customer)
        //{
        //    InitializeComponent();
        //    EditMode = true;
        //}

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> customerData = new Dictionary<string, string>
            {
                {"name", txt_Name.Text},
                {"address", txt_Address.Text },
                {"city", txt_City.Text},
                {"country", txt_Country.Text},
                {"phoneNumber", txt_PhoneNumber.Text},
            };

            Customer customer = new Customer()
            {
                Name = txt_Name.Text,
                Address = txt_Address.Text,
                City = txt_City.Text,
                Country = txt_Country.Text,
                PhoneNumber = txt_PhoneNumber.Text,
            };

            customer.Create();
            Close();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
