using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(firstname.Text == "" || lastname.Text == "" || address.Text == "" || phoneno.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Database database = new Database();
                database.addnewcustomer(firstname.Text, lastname.Text, address.Text, phoneno.Text);
                MessageBox.Show("Customer Added");
                Dispose();
            }
        }
    }
}
