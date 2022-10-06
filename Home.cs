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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATM
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        // Log Out Button
        private void label5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // Exit Button
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Withdraw Button
        private void button1_Click(object sender, EventArgs e)
        {
            Bridge bridge = new Bridge();
            bridge.Show();
            this.Hide();
        }

        // Deposit Button
        private void button2_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.Show();
            this.Hide();
        }

        // View Transaction Button
        private void button3_Click(object sender, EventArgs e)
        {
            viewTransaction vt = new viewTransaction();
            vt.Show();
            this.Hide();
        }

        // View Statement Button
        private void button6_Click(object sender, EventArgs e)
        {
            Statement statement = new Statement();
            statement.Show();
            this.Hide();
        }

        // View Balance Button
        private void button4_Click(object sender, EventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Hide();
        }

        // Account Information Button
        private void button5_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
            this.Hide();
        }

        public static String title;
        string cardNum = Login.title;
        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        // Helper function to get the corresponding Name from the 
        // card number given to print the Name
        private void getName()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Name from userInfodb where CardNumber='" + cardNum + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            name.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            getName();
            name.Text = "Welcome, " + name.Text;
            title = Login.title;
        }
    }
}
