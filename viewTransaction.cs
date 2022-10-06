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
    public partial class viewTransaction : Form
    {
        public viewTransaction()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string cardNum = Login.title;
        private void populate()
        {
            Con.Open();
            string query = "select * from Transactions where CardNumber='" + cardNum + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            statement.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void viewTransaction_Load(object sender, EventArgs e)
        {
            populate();
        }

        // Main Menu Button
        private void label6_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        // Exit Button
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
