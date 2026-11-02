using QuizMaster.Services;
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

namespace QuizMaster.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShow.Checked;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var f = new RegisterForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtId.Text = f.RegisteredId;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string id = txtId.Text.Trim();
            

            if (id == "" || txtPassword.Text == "")
            {
                ShowError("Enter your ID and password.");
                return;
            }

            string hash = DataStore.Hash(txtPassword.Text);
            var user = DataStore.Users.FirstOrDefault(u =>
                (string.Equals(u.SchoolId, id, StringComparison.OrdinalIgnoreCase) || u.Email == id) &&
                u.PasswordHash == hash &&
                u.IsActive &&
                u.Role.ToString() == cmbRole.Text);

            if (user == null)
            {
                ShowError("Wrong ID or password. Please try again.");
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
            Session.CurrentUser = user;

            if (user.Role == Role.Lecturer)
            {
                Hide();
                using (var main = new LecturerMainForm()) { main.ShowDialog(); }
                Session.CurrentUser = null;
                txtPassword.Clear();
                Show();
            }
            else if (user.Role == Role.Student)
            {
                Hide();
                using (var main = new StudentMainForm()) { main.ShowDialog(); }
                Session.CurrentUser = null;
                txtPassword.Clear();
                Show();
            }
            else
            {
                MessageBox.Show("Welcome, " + user.FullName + " (" + user.Role + ") – this role's window comes later.");
            }
        }
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
