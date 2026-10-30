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
            MessageBox.Show("Welcome, " + user.FullName + " (" + user.Role + ")");
        }
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
