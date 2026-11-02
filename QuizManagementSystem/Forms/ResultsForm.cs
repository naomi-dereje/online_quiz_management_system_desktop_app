using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class ResultsForm : Form
    {
        private Attempt attempt;
        private Quiz quiz;

        public ResultsForm()
        {
            InitializeComponent();
            btnClose.Click += (s, e) => Close();
            btnView.Click += (s, e) => ShowAnswers();
        }

        public ResultsForm(Attempt a, Quiz q) : this()
        {
            attempt = a;
            quiz = q;
            bool passed = QuizRules.Passed(a.Percentage);
            TimeSpan took = a.SubmittedAt.Value - a.StartedAt;
            lblQuiz.Text = q.Title;
            lblPercent.Text = a.Percentage + "%";
            lblPercent.ForeColor = passed ? Theme.Leaf : Theme.Brick;
            lblScore.Text = "Score: " + a.Score + " / " + QuizRules.TotalMarks(q) + " marks\nTime taken: "
                + (int)took.TotalMinutes + " min " + took.Seconds + " s";
            lblStatus.Text = passed ? "PASSED" : "FAILED";
            lblStatus.BackColor = passed ? Theme.Leaf : Theme.Brick;
        }

        private void ShowAnswers()
        {
            var f = new Form
            {
                Text = "Your answers – " + quiz.Title,
                ClientSize = new Size(760, 380),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Theme.Chalk,
                Font = new Font("Segoe UI", 10)
            };
            var lv = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                BackColor = Color.White,
                Dock = DockStyle.Fill
            };
            lv.Columns.Add("#", 36);
            lv.Columns.Add("Question", 300);
            lv.Columns.Add("Your answer", 160);
            lv.Columns.Add("Correct answer", 160);
            lv.Columns.Add("Result", 70);
            f.Controls.Add(lv);

            int n = 1;
            foreach (Question q in quiz.Questions)
            {
                int chosenId;
                bool has = attempt.Answers.TryGetValue(q.Id, out chosenId);
                Option chosen = has ? q.Options.FirstOrDefault(o => o.Id == chosenId) : null;
                Option correct = q.Options.FirstOrDefault(o => o.IsCorrect);
                bool ok = chosen != null && chosen.IsCorrect;

                var item = new ListViewItem(n.ToString());
                item.SubItems.Add(q.Text);
                item.SubItems.Add(chosen == null ? "(no answer)" : chosen.Text);
                item.SubItems.Add(correct == null ? "-" : correct.Text);
                item.SubItems.Add(ok ? "Correct" : "Wrong");
                item.UseItemStyleForSubItems = false;
                item.SubItems[4].ForeColor = ok ? Theme.Leaf : Theme.Brick;
                lv.Items.Add(item);
                n++;
            }
            f.ShowDialog(this);
            f.Dispose();
        }
    }
}