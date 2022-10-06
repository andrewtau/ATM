using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ATM
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // Register Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNameTb.Text == "" || CardNumTb.Text == "" || PinTb.Text == "" || AccBalanceTb.Text == "" || AccPhoneNumTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(!AccNameTb.Text.Contains(" ") && AccNameTb.Text.Any(x => !char.IsLetter(x))) // Checks that the user enters a valid name with characters only
            {
                MessageBox.Show("Please enter a valid name with characters only!");
            }
            else if(CardNumTb.Text.Length != 16) // Checks that the user enters a valid credit card number
            {
                MessageBox.Show("Please enter a valid credit card number! \nNote: Valid Card numbers typically have 16 digits.");
            }
            else if(PinTb.Text.Length > 4 || PinTb.Text.Length < 4) // Checks that the user enters a long enough PIN
            {
                MessageBox.Show("Please enter a 4-Digit PIN!");
            }
            else if(Convert.ToInt32(AccBalanceTb.Text) < 0) // Checks that the user enters a positive amount
            {
                MessageBox.Show("Please enter a valid balance! \nNote: You can't have a negative balance.");
            }
            else if(AccPhoneNumTb.Text.Length < 10 || AccPhoneNumTb.Text.Length > 10) // Checks that the user enters a valid phone number
            {
                MessageBox.Show("Please enter a valid Phone Number! \nNote: Valid Phone Numbers typically have 10 digits.\n\nTip:Try removing special characters when entering your phone number.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into userInfodb values('" + CardNumTb.Text + "','" + PinTb.Text + "','" + AccNameTb.Text + "','" + AccPhoneNumTb.Text + "','" + AccBalanceTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully!");
                    Con.Close();

                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Exit Button
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Main Menu Button
        private void label8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
