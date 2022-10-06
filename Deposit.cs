using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string cardNum = Login.title;

        // Helper function used to update the transaction database
        private void addTransaction()
        {
            string transactionType = "Deposit";
            try
            {
                Con.Open();
                string query = "insert into Transactions values('" + cardNum + "','" + transactionType + "'," + depAmt.Text + ",'" + DateTime.Now.ToString() + "')";
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
            if(depAmt.Text == "" || Convert.ToInt32(depAmt.Text) <= 0)
            {
                MessageBox.Show("Enter the desired amount you'd like to deposit!");
            }
            else
            {
                newBalance = oldBalance + Convert.ToInt32(depAmt.Text);
                try
                {
                    Con.Open();
                    string query = "update userInfodb set Balance=" + newBalance + "where CardNumber='" + cardNum + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success! An amount of $" + depAmt.Text + " has been successfuly deposited into your account! \n\nYour new balance is: $" + newBalance);
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

        // Exit Button
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Main Menu Button
        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        int oldBalance, newBalance;

        // Helper function to get the corresponding balance from the 
        // card number given to update the balance after a deposit
        private void getBalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from userInfodb where CardNumber='" + cardNum + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
