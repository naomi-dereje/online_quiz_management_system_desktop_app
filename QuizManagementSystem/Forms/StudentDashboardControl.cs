using System;
using System.Linq;
using System.Windows.Forms;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class StudentDashboardControl : UserControl
    {
        public StudentDashboardControl()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (DesignMode || Session.CurrentUser == null) return;
                var me = Session.CurrentUser;
                lblHello.Text = "Hello, " + me.FullName + "!";
                lblAvailable.Text = DataStore.Quizzes.Count(q => QuizRules.IsOpen(q)
                    && QuizRules.AttemptCount(me.Id, q.Id) == 0).ToString();
                var mine = DataStore.Attempts.Where(a => a.StudentId == me.Id && a.SubmittedAt != null).ToList();
                lblCompleted.Text = mine.Count.ToString();
                lblAverage.Text = mine.Count == 0 ? "-" : Math.Round(mine.Average(a => a.Percentage), 1) + "%";
            };
        }
    }
}