using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Account : Form
    {
        string cardNumber = Login.title;

        public Account()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        // Helper function to get the corresponding Balance from the 
        // card number given to print the current Balance
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from userInfodb where CardNumber='" + cardNum.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            currBal.Text = "$ " + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // Helper function to get the corresponding Phone Number from the 
        // card number given to print the Phone Number
        private void getPhoneNumber()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select PhoneNumber from userInfodb where CardNumber='" + cardNum.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            phoneNum.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        // Helper function to get the corresponding PIN from the 
        // card number given to print the PIN
        private void getPin()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select PIN from userInfodb where CardNumber='" + cardNum.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            userPin.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        // Helper function to get the corresponding Name from the 
        // card number given to print the Name
        private void getName()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Name from userInfodb where CardNumber='" + cardNum.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            userName.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        // Change Pin Button
        private void label9_Click(object sender, EventArgs e)
        {
            changePin cp = new changePin();
            cp.Show();
            this.Hide();
        }

        // Exit Button
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        // Log Out Button
        private void label11_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Main Menu
        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        // Update Phone Button
        private void label10_Click(object sender, EventArgs e)
        {
            updatePhone up = new updatePhone();
            up.Show();
            this.Hide();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            cardNum.Text = cardNumber;
            getName();
            getBalance();
            getPhoneNumber();
            getPin();

        }


    }
}
