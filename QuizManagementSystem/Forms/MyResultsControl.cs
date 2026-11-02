using System;
using System.Linq;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class MyResultsControl : UserControl
    {
        public MyResultsControl()
        {
            InitializeComponent();
            Load += (s, e) => { if (!DesignMode) RefreshList(); };
            txtSearch.TextChanged += (s, e) => RefreshList();
        }

        private void RefreshList()
        {
            lv.Items.Clear();
            string search = txtSearch.Text.Trim().ToLower();
            int me = Session.CurrentUser.Id;
            var mine = DataStore.Attempts.Where(a => a.StudentId == me && a.SubmittedAt != null)
                .OrderByDescending(a => a.SubmittedAt);

            foreach (Attempt a in mine)
            {
                Quiz q = DataStore.Quizzes.FirstOrDefault(z => z.Id == a.QuizId);
                string title = q == null ? "(deleted quiz)" : q.Title;
                if (search != "" && !title.ToLower().Contains(search)) continue;
                int total = q == null ? 0 : QuizRules.TotalMarks(q);
                bool passed = QuizRules.Passed(a.Percentage);

                var item = new ListViewItem(title);
                item.SubItems.Add(a.Score + " / " + total + "  (" + a.Percentage + "%)");
                item.SubItems.Add(a.SubmittedAt.Value.ToString("dd MMM yyyy HH:mm"));
                item.SubItems.Add(passed ? "Passed" : "Failed");
                item.UseItemStyleForSubItems = false;
                item.SubItems[3].ForeColor = passed ? Theme.Leaf : Theme.Brick;
                lv.Items.Add(item);
            }
        }
    }
}