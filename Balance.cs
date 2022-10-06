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

namespace ATM
{
    public partial class Balance : Form
    {
        public Balance()
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
        // Helper function to get the corresponding balance from the 
        // card number given to print the current balance
        private void getBalance()
        {
            Con.Open(); 
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from userInfodb where CardNumber='" + cardNum.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            currBalance.Text = "$ " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void Balance_Load(object sender, EventArgs e)
        {
            cardNum.Text = Home.title;
            getBalance(); 
        }

        // Exit Button
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
