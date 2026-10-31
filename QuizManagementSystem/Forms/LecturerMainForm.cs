using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class LecturerMainForm : Form
    {
        public LecturerMainForm()
        {
            InitializeComponent();
        }

        private void LecturerMainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            lblUser.Text = Session.CurrentUser.FullName + " (Lecturer)";
            SetActive(btnDashboard);
        }
        private void SetActive(Button active)
        {
            Button[] all = { btnDashboard, btnQuizzes, btnQuestions, btnResults, btnStudents };
            foreach (Button b in all)
            {
                bool on = (b == active);
                b.BackColor = on ? Theme.Mustard : Theme.Slate;
                b.ForeColor = on ? Theme.Slate : Theme.Chalk;
                b.Font = new Font("Segoe UI", 10, on ? FontStyle.Bold : FontStyle.Regular);
            }
            lblPage.Text = active.Text;
            lblStatus.Text = "Ready";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActive(btnDashboard);
        }

        private void btnQuizzes_Click(object sender, EventArgs e)
        {
            SetActive(btnQuizzes);
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            SetActive(btnQuestions);
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            SetActive(btnResults);
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            SetActive(btnStudents);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QuizMaster – Lecturer", "About");
        }
    }
}
