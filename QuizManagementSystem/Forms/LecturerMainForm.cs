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

            Load -= LecturerMainForm_Load;
            Load += LecturerMainForm_Load;

            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;
            btnQuizzes.Click -= btnQuizzes_Click;
            btnQuizzes.Click += btnQuizzes_Click;
            btnQuestions.Click -= btnQuestions_Click;
            btnQuestions.Click += btnQuestions_Click;
            btnResults.Click -= btnResults_Click;
            btnResults.Click += btnResults_Click;
            btnStudents.Click -= btnStudents_Click;
            btnStudents.Click += btnStudents_Click;
            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }
        private void LecturerMainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session.CurrentUser.FullName + " (Lecturer)";
            SetActive(btnDashboard);
        }

        private void btnDashboard_Click(object sender, EventArgs e) { SetActive(btnDashboard); }
        private void btnQuizzes_Click(object sender, EventArgs e) { SetActive(btnQuizzes, new QuizzesControl()); }
        private void btnQuestions_Click(object sender, EventArgs e) { SetActive(btnQuestions); }
        private void btnResults_Click(object sender, EventArgs e) { SetActive(btnResults); }
        private void btnStudents_Click(object sender, EventArgs e) { SetActive(btnStudents); }
        private void btnLogout_Click(object sender, EventArgs e) { Close(); }

        

        

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void SetActive(Button active, UserControl page = null)
        {
            Button[] all = { btnDashboard, btnQuizzes, btnQuestions, btnResults, btnStudents };
            foreach (Button b in all)
            {
                bool on = (b == active);
                b.BackColor = on ? Theme.Mustard : Theme.Slate;
                b.ForeColor = on ? Theme.Slate : Theme.Chalk;
                b.Font = new Font("Segoe UI", 10, on ? FontStyle.Bold : FontStyle.Regular);
            }

            pnlContent.Controls.Clear();
            if (page != null)
            {
                page.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(page);
            }
            else
            {
                lblPage.Text = active.Text;
                pnlContent.Controls.Add(lblPage);
            }
            lblStatus.Text = "Ready";
        }  

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QuizMaster – Lecturer", "About");
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logoutAndExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
