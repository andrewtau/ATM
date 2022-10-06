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
using System.Net.NetworkInformation;


namespace ATM
{
    public partial class changePin : Form
    {
        public changePin()
        {
            InitializeComponent();
        }

        // Main Menu Button
        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string cardNum = Login.title;
        // Confirm Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1.Text == "" || Pin2.Text == "")
            {
                MessageBox.Show("Enter a new PIN");
            }
            else if(Pin2.Text != Pin1.Text)
            {
                MessageBox.Show("ERROR: PINs do not match!");
            }
            else if (Pin1.Text.Length > 4 || Pin1.Text.Length < 4 || Pin2.Text.Length > 4 || Pin2.Text.Length < 4) // Checks that the user enters a long enough PIN
            {
                MessageBox.Show("Please enter a 4-Digit PIN!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update userInfodb set PIN=" + Pin1.Text + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Successfully Updated! You will now be logged out!");
                    Con.Close();

                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // Exit Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
