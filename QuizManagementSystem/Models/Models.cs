using System;
using System.Collections.Generic;

namespace QuizMaster.Models
{
    public enum Role { Student, Lecturer, Admin }
    public enum QuizStatus { Draft, Published }

    public class User
    {
        public int Id { get; set; }
        public string SchoolId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public bool IsCorrect { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public int Marks { get; set; } = 1;
        public List<Option> Options { get; set; } = new List<Option>();
    }

    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int DurationMinutes { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableUntil { get; set; }
        public QuizStatus Status { get; set; } = QuizStatus.Draft;
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    public class Attempt
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public Dictionary<int, int> Answers { get; set; } = new Dictionary<int, int>();
        public int Score { get; set; }
        public double Percentage { get; set; }
    }
}