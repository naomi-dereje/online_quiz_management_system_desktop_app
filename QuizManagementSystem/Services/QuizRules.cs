using System;
using System.Linq;
using QuizMaster.Models;

namespace QuizMaster.Services
{
    public static class QuizRules
    {
        public const int PassPercent = 50;
        public const int MaxAttempts = 1;

        public static bool IsOpen(Quiz q)
        {
            return q.Status == QuizStatus.Published && q.Questions.Count > 0
                && q.AvailableFrom.Date <= DateTime.Today && q.AvailableUntil.Date >= DateTime.Today;
        }

        public static int AttemptCount(int studentId, int quizId)
        {
            return DataStore.Attempts.Count(a => a.StudentId == studentId
                && a.QuizId == quizId && a.SubmittedAt != null);
        }

        public static int TotalMarks(Quiz q) { return q.Questions.Sum(x => x.Marks); }
        public static bool Passed(double percentage) { return percentage >= PassPercent; }

        public static void Grade(Attempt a, Quiz q)
        {
            int score = 0;
            foreach (Question qu in q.Questions)
            {
                int chosenId;
                if (a.Answers.TryGetValue(qu.Id, out chosenId))
                {
                    Option o = qu.Options.FirstOrDefault(x => x.Id == chosenId);
                    if (o != null && o.IsCorrect) score += qu.Marks;
                }
            }
            int total = TotalMarks(q);
            a.Score = score;
            a.Percentage = total == 0 ? 0 : Math.Round(score * 100.0 / total, 1);
            a.SubmittedAt = DateTime.Now;
        }
    }
}