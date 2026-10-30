using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using QuizMaster.Models;

namespace QuizMaster.Services
{
    public static class DataStore
    {
        public static List<User> Users { get; } = new List<User>();
        public static List<Quiz> Quizzes { get; } = new List<Quiz>();
        public static List<Attempt> Attempts { get; } = new List<Attempt>();

        public static string Hash(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }

        public static void Seed()
        {
            if (Users.Count > 0) return;

            Users.Add(new User
            {
                Id = 1,
                SchoolId = "L-0021",
                FullName = "Binyam T.",
                Email = "binyam@example.com",
                PasswordHash = Hash("lecturer123"),
                Role = Role.Lecturer
            });
            Users.Add(new User
            {
                Id = 2,
                SchoolId = "1601547",
                FullName = "Naomi Dereje",
                Email = "naomi@example.com",
                PasswordHash = Hash("student123"),
                Role = Role.Student
            });
            Users.Add(new User
            {
                Id = 3,
                SchoolId = "ADMIN",
                FullName = "Administrator",
                Email = "admin@example.com",
                PasswordHash = Hash("admin123"),
                Role = Role.Admin
            });

            var q = new Quiz
            {
                Id = 1,
                Title = "Database Fundamentals",
                DurationMinutes = 45,
                AvailableFrom = DateTime.Today.AddDays(-1),
                AvailableUntil = DateTime.Today.AddDays(14),
                Status = QuizStatus.Published
            };
            q.Questions.Add(new Question
            {
                Id = 1,
                Text = "Which keyword creates a database in SQL?",
                Marks = 2,
                Options =
                {
                    new Option { Id = 1, Text = "CREATE", IsCorrect = true },
                    new Option { Id = 2, Text = "NEW" },
                    new Option { Id = 3, Text = "MAKE" },
                    new Option { Id = 4, Text = "BUILD" }
                }
            });
            Quizzes.Add(q);
        }
    }
}