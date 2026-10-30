using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizMaster.Models;
using QuizMaster.Services;

namespace QuizMaster.Forms
{
    public partial class RegisterForm : Form
    {
        public string RegisteredId { get; private set; }
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lblSub_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string name = txtFullName.Text.Trim();
            string id = txtStudentId.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (name == "" || id == "" || email == "" || txtPassword.Text == "")
            {
                ShowError("Please fill in every field.");
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowError("Enter a valid email address.");
                txtEmail.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Password must be at least 6 characters.");
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError("Passwords do not match.");
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            bool idTaken = DataStore.Users.Any(u =>
                string.Equals(u.SchoolId, id, StringComparison.OrdinalIgnoreCase));
            bool emailTaken = DataStore.Users.Any(u =>
                string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

            if (idTaken)
            {
                ShowError("Student ID already registered.");
                txtStudentId.Focus();
                return;
            }
            if (emailTaken)
            {
                ShowError("Email already registered.");
                txtEmail.Focus();
                return;
            }

            int nextId = DataStore.Users.Max(u => u.Id) + 1;
            DataStore.Users.Add(new User
            {
                Id = nextId,
                SchoolId = id,
                FullName = name,
                Email = email,
                PasswordHash = DataStore.Hash(txtPassword.Text),
                Role = Role.Student
            });

            MessageBox.Show("Account created. You can now log in.", "Registered");
            RegisteredId = id;
            DialogResult = DialogResult.OK;
        }
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
