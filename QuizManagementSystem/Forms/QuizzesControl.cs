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
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class QuizzesControl : UserControl
    {
        private Quiz current;
        private bool refreshing;
        public QuizzesControl()
        {
            InitializeComponent();
        }

        private void QuizzesControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            cmbStatus.SelectedIndex = 0;
            ClearForm();
            RefreshList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lvQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (refreshing || lvQuizzes.SelectedItems.Count == 0) return;
            current = (Quiz)lvQuizzes.SelectedItems[0].Tag;
            txtTitle.Text = current.Title;
            numDuration.Value = current.DurationMinutes;
            dtFrom.Value = current.AvailableFrom;
            dtUntil.Value = current.AvailableUntil;
            ShowMessage("", true);
        }
        private string GetStatus(Quiz q)
        {
            if (q.Status == QuizStatus.Draft) return "Draft";
            return q.AvailableUntil.Date < DateTime.Today ? "Closed" : "Published";
        }

        private void ShowMessage(string text, bool ok)
        {
            lblMessage.ForeColor = ok ? Theme.Leaf : Theme.Brick;
            lblMessage.Text = text;
        }

        private void RefreshList()
        {
            refreshing = true;
            lvQuizzes.Items.Clear();
            string search = txtSearch.Text.Trim().ToLower();
            string filter = cmbStatus.Text;

            foreach (Quiz q in DataStore.Quizzes)
            {
                string status = GetStatus(q);
                if (search != "" && !q.Title.ToLower().Contains(search)) continue;
                if (filter != "" && filter != "All" && status != filter) continue;

                var item = new ListViewItem(q.Title);
                item.SubItems.Add(q.DurationMinutes + " min");
                item.SubItems.Add(q.Questions.Count.ToString());
                item.SubItems.Add(q.AvailableFrom.ToString("dd MMM") + " – " + q.AvailableUntil.ToString("dd MMM yyyy"));
                item.SubItems.Add(status);
                item.UseItemStyleForSubItems = false;
                item.SubItems[4].ForeColor = status == "Published" ? Theme.Leaf
                    : status == "Closed" ? Theme.Brick : Color.FromArgb(122, 79, 0);
                item.Tag = q;
                lvQuizzes.Items.Add(item);
                if (q == current) item.Selected = true;
            }
            refreshing = false;
        }

        private void ClearForm()
        {
            current = null;
            lvQuizzes.SelectedItems.Clear();
            txtTitle.Clear();
            numDuration.Value = 30;
            dtFrom.Value = DateTime.Today;
            dtUntil.Value = DateTime.Today.AddDays(14);
        }

        private void SaveQuiz(QuizStatus status)
        {
            string title = txtTitle.Text.Trim();
            if (title == "")
            {
                ShowMessage("Enter a quiz title.", false);
                txtTitle.Focus();
                return;
            }
            if (dtUntil.Value.Date < dtFrom.Value.Date)
            {
                ShowMessage("The end date must not be before the start date.", false);
                return;
            }
            if (status == QuizStatus.Published && (current == null || current.Questions.Count == 0))
            {
                ShowMessage("Add at least one question before publishing.", false);
                return;
            }

            bool isNew = (current == null);
            if (isNew)
            {
                int nextId = DataStore.Quizzes.Count == 0 ? 1 : DataStore.Quizzes.Max(x => x.Id) + 1;
                current = new Quiz { Id = nextId };
                DataStore.Quizzes.Add(current);
            }

            current.Title = title;
            current.DurationMinutes = (int)numDuration.Value;
            current.AvailableFrom = dtFrom.Value.Date;
            current.AvailableUntil = dtUntil.Value.Date;
            current.Status = status;

            RefreshList();
            ShowMessage(isNew ? "Quiz created." : "Quiz saved.", true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            ShowMessage("", true);
            txtTitle.Focus();
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SaveQuiz(QuizStatus.Draft);
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            SaveQuiz(QuizStatus.Published);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (current == null)
            {
                ShowMessage("Select or save a quiz first.", false);
                return;
            }
            MessageBox.Show("The questions screen comes next.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (current == null)
            {
                ShowMessage("Select a quiz to delete.", false);
                return;
            }
            if (DataStore.Attempts.Any(a => a.QuizId == current.Id))
            {
                ShowMessage("This quiz has attempts and cannot be deleted.", false);
                return;
            }
            var answer = MessageBox.Show("Delete \"" + current.Title + "\"?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes) return;

            DataStore.Quizzes.Remove(current);
            ClearForm();
            RefreshList();
            ShowMessage("Quiz deleted.", true);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
