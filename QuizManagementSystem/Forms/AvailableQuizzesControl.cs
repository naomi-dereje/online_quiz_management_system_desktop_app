using System;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class AvailableQuizzesControl : UserControl
    {
        public AvailableQuizzesControl()
        {
            InitializeComponent();
            Load += (s, e) => { if (!DesignMode) RefreshList(); };
            txtSearch.TextChanged += (s, e) => RefreshList();
            btnStart.Click += (s, e) => StartSelected();
            lv.DoubleClick += (s, e) => StartSelected();
        }

        private void Msg(string text, bool ok)
        {
            lblMessage.ForeColor = ok ? Theme.Leaf : Theme.Brick;
            lblMessage.Text = text;
        }

        private void RefreshList()
        {
            lv.Items.Clear();
            string search = txtSearch.Text.Trim().ToLower();
            int me = Session.CurrentUser.Id;
            foreach (Quiz q in DataStore.Quizzes)
            {
                if (!QuizRules.IsOpen(q)) continue;
                if (search != "" && !q.Title.ToLower().Contains(search)) continue;
                bool done = QuizRules.AttemptCount(me, q.Id) >= QuizRules.MaxAttempts;

                var item = new ListViewItem(q.Title);
                item.SubItems.Add(q.Questions.Count.ToString());
                item.SubItems.Add(q.DurationMinutes + " min");
                item.SubItems.Add(q.AvailableUntil.ToString("dd MMM yyyy"));
                item.SubItems.Add(done ? "Completed" : "Ready");
                item.UseItemStyleForSubItems = false;
                item.SubItems[4].ForeColor = done ? Theme.Slate : Theme.Leaf;
                item.Tag = q;
                lv.Items.Add(item);
            }
        }

        private void StartSelected()
        {
            if (lv.SelectedItems.Count == 0) { Msg("Select a quiz first.", false); return; }
            Quiz q = (Quiz)lv.SelectedItems[0].Tag;
            if (!QuizRules.IsOpen(q)) { Msg("This quiz is not open.", false); RefreshList(); return; }
            if (QuizRules.AttemptCount(Session.CurrentUser.Id, q.Id) >= QuizRules.MaxAttempts)
            {
                Msg("You have already taken this quiz.", false);
                return;
            }
            var ok = MessageBox.Show(q.Title + "\n" + q.Questions.Count + " questions, " + q.DurationMinutes
                + " minutes.\nThe quiz is submitted automatically when time is up.\n\nStart now?",
                "Start quiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            using (var f = new TakeQuizForm(q))
            {
                f.ShowDialog();
                if (f.Result != null)
                {
                    using (var r = new ResultsForm(f.Result, q)) r.ShowDialog();
                }
            }
            RefreshList();
            Msg("", true);
        }
    }
}