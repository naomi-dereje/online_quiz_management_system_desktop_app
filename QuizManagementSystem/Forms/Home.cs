using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMaster.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void StatusMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
            using (var f = new LoginForm())
            {
                f.ShowDialog();
            }
            Show();
        }

        private void btnGetStarted_Click(object sender, EventArgs e)
        {
            using (var f = new RegisterForm())
            {
                f.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QuizMaster – Online Quiz Management System", "About");
        }
    }
}
