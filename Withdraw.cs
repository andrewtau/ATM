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
    public partial class Withdraw : Form
    {
        public Withdraw()
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

        // Exit Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string cardNum = Login.title;
        int bal, oldBalance, newBalance;
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
        private void addTransaction()
        {
            string transactionType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into Transactions values('" + cardNum + "', '" + transactionType + "', '" + wAmount.Text + "', '" + DateTime.Now.ToString() + "')";
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

        // Confirm Button
        private void button1_Click(object sender, EventArgs e)
        {
           if(wAmount.Text == "")
            {
                MessageBox.Show("Enter the amount you'd like to withdraw!");
            }
           else if(Convert.ToInt32(wAmount.Text) <= 0)
            {
                MessageBox.Show("ERROR: Please enter a valid amount!");
            }
            else if(Convert.ToInt32(wAmount.Text) > bal)
            {
                MessageBox.Show("ERROR: You do not have sufficient funds!");
            }
            else
            {
                try
                {
                    newBalance = bal - Convert.ToInt32(wAmount.Text);
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + wAmount.Text + " has been successfuly withdrawn from your account! \n\nYour new balance is: $" + newBalance);
                    Con.Close();


                    // Update Transactions Database
                    addTransaction();

                    // Return Home
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
