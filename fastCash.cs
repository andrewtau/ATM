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
    public partial class fastCash : Form
    {
        public fastCash()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        int bal, oldBalance, newBalance;
        string cardNum = Login.title;
        // Helper function to get the corresponding balance from the 
        // card number given to update the balance after a withdrawal
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from userInfodb where CardNumber='" + cardNum + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            currBal.Text = "$ " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        // Helper function used to update the transaction database
        private void addTransaction(int amount)
        {
            string transactionType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into Transactions values('" + cardNum + "','" + transactionType + "','" + amount + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
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

        // $10 Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (10 > bal)
            {
                MessageBox.Show("ERROR: You do not have sufficient funds!");
            }
            else
            {
                try
                {
                    newBalance = bal - 10;
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + 10 + " has been successfuly withdrawn from your account! \n\nYour new balance is: $" + newBalance);
                    Con.Close();

                    // Update Transaction Datebase
                    addTransaction(10);

                    // Return Home
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

        private void fastCash_Load(object sender, EventArgs e)
        {
            getBalance();
        }

        // $20 Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (20 > bal)
            {
                MessageBox.Show("ERROR: You do not have sufficient funds!");
            }
            else
            {
                try
                {
                    newBalance = bal - 20;
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + 20 + " has been successfuly withdrawn from your account! \n\nYour new balance is: $" + newBalance);
                    Con.Close();

                    // Update Transaction Datebase
                    addTransaction(20);
                    
                    // Return Home
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

        // $50 Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (50 > bal)
            {
                MessageBox.Show("ERROR: You do not have sufficient funds!");
            }
            else
            {
                try
                {
                    newBalance = bal - 50;
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + 50 + " has been successfuly withdrawn from your account! \n\nYour new balance is: $" + newBalance);
                    Con.Close();

                    // Update Transaction Datebase
                    addTransaction(50);

                    // Return Home
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

        // $100 Button
        private void button4_Click(object sender, EventArgs e)
        {
            if (100 > bal)
            {
                MessageBox.Show("ERROR: You do not have sufficient funds!");
            }
            else
            {
                try
                {
                    newBalance = bal - 100;
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + 100 + " has been successfuly withdrawn from your account! \n\nYour new balance is: $" + newBalance);
                    Con.Close();

                    // Update Transaction Datebase
                    addTransaction(100);

                    // Return Home
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

        private void button5_Click(object sender, EventArgs e)
        {

        }



        // Main Menu Button
        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        // Exit Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
