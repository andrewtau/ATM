using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class updatePhone : Form
    {
        public updatePhone()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string cardNum = Login.title;

        // Confirm Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (phone1.Text == "" || phone2.Text == "") // Checks that the user doesn't leave the field blank
            {
                MessageBox.Show("Enter a new Phone Number!");
            }
            else if (phone2.Text != phone1.Text) // Checks that the user enters the same phone number
            {
                MessageBox.Show("ERROR: Phone Numbers do not match!");
            }
            else if (phone1.Text.Length < 10 || phone1.Text.Length > 10 || phone2.Text.Length < 10 || phone2.Text.Length > 10) // Checks that the user enters a valid phone number
            {
                MessageBox.Show("Please enter a valid Phone Number! \nNote: Valid Phone Numbers typically have 10 digits.\n\nTip:Try removing special characters when entering your phone number.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update userInfodb set PhoneNumber=" + phone1.Text + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Phone Number Successfully Updated!");
                    Con.Close();

                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Main Menu Button
        private void label5_Click(object sender, EventArgs e)
        {

            Home home = new Home();
            home.Show();
            this.Hide();
        }

        // Exut Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
