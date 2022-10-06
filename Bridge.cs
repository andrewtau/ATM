using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Bridge : Form
    {
        public Bridge()
        {
            InitializeComponent();
        }

        // Withdraw Button
        private void button1_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
            this.Hide();
        }

        // Fast Cash Button
        private void button2_Click(object sender, EventArgs e)
        {
            fastCash fc = new fastCash();
            fc.Show();
            this.Hide();
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
