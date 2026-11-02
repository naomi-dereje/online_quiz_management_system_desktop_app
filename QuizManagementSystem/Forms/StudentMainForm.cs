using System;
using System.Drawing;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class StudentMainForm : Form
    {
        private Button[] nav;

        public StudentMainForm()
        {
            InitializeComponent();
            nav = new[] { btnDashboard, btnQuizzes, btnResults };
            btnDashboard.Click += (s, e) => Open(0);
            btnQuizzes.Click += (s, e) => Open(1);
            btnResults.Click += (s, e) => Open(2);
            btnLogout.Click += (s, e) => Close();
            Load += (s, e) =>
            {
                if (Session.CurrentUser == null) return;
                lblUser.Text = Session.CurrentUser.FullName + " (Student)";
                Open(0);
            };
        }

        private void Open(int i)
        {
            for (int k = 0; k < nav.Length; k++)
            {
                bool on = (k == i);
                nav[k].BackColor = on ? Theme.Mustard : Theme.Slate;
                nav[k].ForeColor = on ? Theme.Slate : Theme.Chalk;
                nav[k].Font = new Font("Segoe UI", 10, on ? FontStyle.Bold : FontStyle.Regular);
            }
            UserControl page;
            if (i == 0) page = new StudentDashboardControl();
            else if (i == 1) page = new AvailableQuizzesControl();
            else page = new MyResultsControl();

            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }
    }
}