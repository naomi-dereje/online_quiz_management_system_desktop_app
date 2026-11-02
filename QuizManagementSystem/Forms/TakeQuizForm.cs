using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuizMaster.Helpers;
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class TakeQuizForm : Form
    {
        private Quiz quiz;
        private Attempt attempt;
        private int index;
        private int secondsLeft;
        private bool done;
        private bool loading;
        private HashSet<int> flagged = new HashSet<int>();
        private RadioButton[] rbs;
        private Button[] navButtons;

        public Attempt Result { get; private set; }

        public TakeQuizForm()
        {
            InitializeComponent();
            rbs = new[] { rb1, rb2, rb3, rb4 };
            for (int i = 0; i < 4; i++)
            {
                int k = i;
                rbs[i].CheckedChanged += (s, e) => OptionChecked(k);
            }
            chkFlag.CheckedChanged += ChkFlag_Changed;
            btnPrev.Click += (s, e) => ShowQuestion(index - 1);
            btnNext.Click += (s, e) => ShowQuestion(index + 1);
            btnSubmit.Click += (s, e) => SubmitClicked();
            tmrQuiz.Tick += Timer_Tick;
            KeyDown += TakeQuizForm_KeyDown;
        }

        public TakeQuizForm(Quiz q) : this()
        {
            quiz = q;
            Text = q.Title;
            attempt = new Attempt { StudentId = Session.CurrentUser.Id, QuizId = q.Id, StartedAt = DateTime.Now };
            secondsLeft = q.DurationMinutes * 60;
            prg.Maximum = q.Questions.Count;

            navButtons = new Button[q.Questions.Count];
            for (int i = 0; i < q.Questions.Count; i++)
            {
                int k = i;
                var b = new Button
                {
                    Size = new Size(44, 30),
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(3),
                    Cursor = Cursors.Hand
                };
                b.FlatAppearance.BorderColor = Theme.Slate;
                b.Click += (s, e) => ShowQuestion(k);
                flowNav.Controls.Add(b);
                navButtons[i] = b;
            }

            ShowQuestion(0);
            UpdateTimerLabel();
            tmrQuiz.Start();
        }

        private void ShowQuestion(int i)
        {
            if (i < 0 || i >= quiz.Questions.Count) return;
            index = i;
            Question q = quiz.Questions[i];
            loading = true;
            lblNo.Text = "Question " + (i + 1) + " of " + quiz.Questions.Count
                + "   (" + q.Marks + (q.Marks == 1 ? " mark)" : " marks)");
            lblQuestion.Text = q.Text;

            int chosen;
            attempt.Answers.TryGetValue(q.Id, out chosen);
            for (int k = 0; k < 4; k++)
            {
                if (k < q.Options.Count)
                {
                    rbs[k].Visible = true;
                    rbs[k].Text = (k + 1) + ".  " + q.Options[k].Text;
                    rbs[k].Checked = (q.Options[k].Id == chosen);
                }
                else
                {
                    rbs[k].Visible = false;
                    rbs[k].Checked = false;
                }
            }
            chkFlag.Checked = flagged.Contains(q.Id);
            loading = false;

            btnPrev.Enabled = i > 0;
            btnNext.Enabled = i < quiz.Questions.Count - 1;
            UpdateNav();
        }

        private void OptionChecked(int k)
        {
            if (loading || !rbs[k].Checked) return;
            Question q = quiz.Questions[index];
            attempt.Answers[q.Id] = q.Options[k].Id;
            UpdateNav();
        }

        private void ChkFlag_Changed(object sender, EventArgs e)
        {
            if (loading || quiz == null) return;
            int id = quiz.Questions[index].Id;
            if (chkFlag.Checked) flagged.Add(id); else flagged.Remove(id);
            UpdateNav();
        }

        private void UpdateNav()
        {
            prg.Value = Math.Min(prg.Maximum, attempt.Answers.Count);
            for (int i = 0; i < navButtons.Length; i++)
            {
                Question q = quiz.Questions[i];
                bool answered = attempt.Answers.ContainsKey(q.Id);
                Button b = navButtons[i];
                b.Text = (i + 1) + (flagged.Contains(q.Id) ? "*" : "");
                if (i == index) { b.BackColor = Theme.Mustard; b.ForeColor = Theme.Slate; }
                else if (answered) { b.BackColor = Theme.Slate; b.ForeColor = Theme.Chalk; }
                else { b.BackColor = Color.White; b.ForeColor = Theme.Slate; }
            }
        }

        private void UpdateTimerLabel()
        {
            lblTimer.Text = (secondsLeft / 60).ToString("00") + ":" + (secondsLeft % 60).ToString("00");
            lblTimer.ForeColor = secondsLeft <= 60 ? Theme.Brick
                : secondsLeft <= 300 ? Color.FromArgb(122, 79, 0) : Theme.Slate;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            UpdateTimerLabel();
            if (secondsLeft <= 0)
            {
                tmrQuiz.Stop();
                Finish();
                MessageBox.Show("Time is up! Your quiz has been submitted.", "Time up");
                Close();
            }
        }

        private void TakeQuizForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (quiz == null) return;
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D4)
            {
                int k = e.KeyCode - Keys.D1;
                if (k < quiz.Questions[index].Options.Count) rbs[k].Checked = true;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.PageDown) { ShowQuestion(index + 1); e.Handled = true; }
            else if (e.KeyCode == Keys.PageUp) { ShowQuestion(index - 1); e.Handled = true; }
        }

        private void SubmitClicked()
        {
            int unanswered = quiz.Questions.Count - attempt.Answers.Count;
            string msg = unanswered > 0
                ? "You have " + unanswered + " unanswered question(s). Submit anyway?"
                : "Submit your quiz now?";
            if (MessageBox.Show(msg, "Submit quiz", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            Finish();
            Close();
        }

        private void Finish()
        {
            if (done) return;
            done = true;
            tmrQuiz.Stop();
            QuizRules.Grade(attempt, quiz);
            attempt.Id = DataStore.Attempts.Count == 0 ? 1 : DataStore.Attempts.Max(a => a.Id) + 1;
            DataStore.Attempts.Add(attempt);
            Result = attempt;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (quiz != null && !done)
            {
                var r = MessageBox.Show("Leaving now will submit your quiz. Continue?", "Leave quiz",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r != DialogResult.Yes) { e.Cancel = true; return; }
                Finish();
            }
            base.OnFormClosing(e);
        }
        private void TakeQuizForm_Load(object sender, EventArgs e)
        {
        }

    }
}