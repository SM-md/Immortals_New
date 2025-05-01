using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immortals_New
{
    public partial class Registration_Page : Form
    {
        //Database Conncetion
        private OleDbConnection _connection;
        private DataSet _dataSet;

        public Registration_Page(OleDbConnection connection, DataSet dataSet)
        {
            InitializeComponent();
            _connection = connection;
            _dataSet = dataSet;
            RegCredential_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
        }

        private void HideErrorLabels()
        {
            Req_Lbl.Visible = false;
            Req1_Lbl.Visible = false;
            Req2_Lbl.Visible = false;
            Invalid_Lbl.Visible = false;
            SuccessfulRegistration_Lbl.Visible = false;
        }

        // Password Encryption (Hashing + Salting)
        public static class PasswordUtils
        {
            // Generates a random salt
            public static string GenerateSalt(int length = 32)
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    byte[] saltBytes = new byte[length];
                    rng.GetBytes(saltBytes);
                    return Convert.ToBase64String(saltBytes);
                }
            }

            // Hash the password using SHA-256 + salt
            public static string HashPassword(string password, string salt)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
                    byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                    return Convert.ToBase64String(hashBytes); // return as Base64
                }
            }
        }

        private void Register_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserName_Tbx.Text.Trim();
                string password = Password_Tbx.Text.Trim();
                string confirmpassword = ConfirmPass_Tbx.Text.Trim();

                HideErrorLabels();

                if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(confirmpassword))
                {
                    Req_Lbl.Visible = true;
                    Req1_Lbl.Visible = true;
                    Req2_Lbl.Visible = true;
                    return;
                }
                else if (string.IsNullOrEmpty(username))
                {
                    Req_Lbl.Visible = true;
                    return;
                }
                else if (string.IsNullOrEmpty(password))
                {
                    Req1_Lbl.Visible = true;
                    return;
                }
                else if (string.IsNullOrEmpty(confirmpassword))
                {
                    Req2_Lbl.Visible = true;
                    return;
                }

                if (username.Length < 4)
                {
                    MessageBox.Show("Username must be at least 4 characters long.", "Username Too Short", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 4)
                {
                    MessageBox.Show("Password must be at least 4 characters long.", "Password Too Short", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmpassword)
                {
                    MessageBox.Show("Passwords do not match. Please confirm your password again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM User_Accounts WHERE Username = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, _connection))
                {
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        Invalid_Lbl.Visible = true;
                        return; // Stop and let user correct input
                    }
                }

                // Generate salt for password
                string salt = PasswordUtils.GenerateSalt();
                // Hash the password with the generated salt
                string hashedPassword = PasswordUtils.HashPassword(password, salt);

                // Proceed with insertion if username is unique
                string query = "INSERT INTO User_Accounts ([Username], [Password], [UserSalt]) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@UserSalt", salt);
                    cmd.ExecuteNonQuery();
                }

                // After successful registration
                SuccessfulRegistration_Lbl.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error during registration: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackToLogin_Btn_Click(object sender, EventArgs e)
        {
            new LogIn_Page().Show();
            this.Close();
        }

        private void ShowPassword_Btn_Click(object sender, EventArgs e)
        {
            if (Password_Tbx.PasswordChar == '•')
            {
                Password_Tbx.PasswordChar = '\0';
            }
            else
            {
                Password_Tbx.PasswordChar = '•';
            }
        }

        private void ConfirmPass_Btn_Click(object sender, EventArgs e)
        {
            if (ConfirmPass_Tbx.PasswordChar == '•')
            {
                ConfirmPass_Tbx.PasswordChar = '\0';
            }
            else
            {
                ConfirmPass_Tbx.PasswordChar = '•';
            }
        }

        private void AddAdmin_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserName_Tbx.Text.Trim();
                string password = Password_Tbx.Text.Trim();
                string confirmPassword = ConfirmPass_Tbx.Text.Trim();

                
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("All fields are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (password != confirmPassword)
                {
                    MessageBox.Show("Password and Confirm Password do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if admin username already exists
                string checkQuery = "SELECT COUNT(*) FROM Admin_Account WHERE AdminUserName = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, _connection))
                {
                    checkCmd.Parameters.AddWithValue("@AdminUserName", username);
                    int adminCount = (int)checkCmd.ExecuteScalar();

                    if (adminCount > 0)
                    {
                        MessageBox.Show("Admin username already exists. Choose another.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Generate salt and hash password
                string salt = PasswordUtils.GenerateSalt();
                string hashedPassword = LogIn_Page.PasswordUtils.HashPassword(password, salt);

                // Insert into Admin_Account table
                string insertQuery = "INSERT INTO Admin_Account (AdminUserName, AdminPassWord, AdminSalt) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@AdminUserName", username);
                    cmd.Parameters.AddWithValue("@AdminPassWord", hashedPassword);
                    cmd.Parameters.AddWithValue("@AdminSalt", salt);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Admin account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear textboxes
                UserName_Tbx.Clear();
                Password_Tbx.Clear();
                ConfirmPass_Tbx.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
