using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Immortals_New
{
    public partial class AdminDashBoard_Page : Form
    {
        //Database Connection
        private OleDbConnection _connection;

        private string _userRole;
        private string _username;
        private string _userID;

        public AdminDashBoard_Page(string connectionString, string userRole, string username, string userID)
        {
            InitializeComponent();
            _connection = new OleDbConnection(connectionString);
            _userRole = userRole;
            _username = username;
            _userID = userID;
            UserReport_Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UserReport_Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AdMainDashBoard_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            TopUp_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            UserReport_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            AdminDetail_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
        }

        private void AdminDashBoard_Page_Load(object sender, EventArgs e)
        {
            LoadUserReports();
        }

        private void HideErrorLabels()
        {
            InvalidAmount_Lbl.Visible = false;
            TopUpSuccess_Lbl.Visible = false;
            InvalidOldPass_Lbl.Visible = false;
            InvalidLengthPass_Lbl.Visible = false;
            MismatchPass_Lbl.Visible = false;
            SuccessfulUpdate_Lbl.Visible = false;
            ErrorUsername_Lbl.Visible = false;
        }

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

        private void LoadUserReports()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            string query = "SELECT ReportID, UserName, Report, ReportStatus FROM User_Reports"; // adjust table name/fields
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, _connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Add checkbox column if not already added
            if (!UserReport_Dgv.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkboxCol = new DataGridViewCheckBoxColumn
                {
                    Name = "Select",
                    HeaderText = "Select"
                };
                UserReport_Dgv.Columns.Insert(0, checkboxCol);
            }

            UserReport_Dgv.DataSource = dt;

            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        private void AdminDetails_Btn_Click(object sender, EventArgs e)
        {
            AdminDetail_Pnl.Visible = !AdminDetail_Pnl.Visible;
        }

        private void UserReports_Btn_Click(object sender, EventArgs e)
        {
            UserReport_Pnl.Visible = !UserReport_Pnl.Visible;
        }

        private void Analytics_Btn_Click(object sender, EventArgs e)
        {

        }

        private void AddApps_Btn_Click(object sender, EventArgs e)
        {
            new AppsMenu(_connection, "Admin", _username, _userID, null, null, this).Show();
            this.Hide();
        }

        private void TopUp_Btn_Click(object sender, EventArgs e)
        {
            TopUp_Pnl.Visible = !TopUp_Pnl.Visible;
        }

        private void LogOut_Btn_Click(object sender, EventArgs e)
        {
            new LogIn_Page().Show();
            this.Close();
        }

        private async void EnterTopUp_Btn_Click(object sender, EventArgs e)
        {
            HideErrorLabels();

            string username = UserName_Tbx.Text.Trim();
            string amountText = Amount_Tbx.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(amountText))
            {
                ErrorUsername_Lbl.Visible = true;
                return;
            }

            if (!decimal.TryParse(amountText, out decimal topUpPeso) || topUpPeso <= 0)
            {
                InvalidAmount_Lbl.Visible = true;
                return;
            }

            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                // Check if user exists
                string getUserQuery = "SELECT UserBalance FROM User_Accounts WHERE Username = ?";
                decimal currentBalance;

                using (OleDbCommand getUserCmd = new OleDbCommand(getUserQuery, _connection))
                {
                    getUserCmd.Parameters.AddWithValue("?", username);
                    object result = getUserCmd.ExecuteScalar();

                    if (result == null)
                    {
                        InvalidAmount_Lbl.Text = "User not found.";
                        InvalidAmount_Lbl.Visible = true;
                        return;
                    }

                    currentBalance = Convert.ToDecimal(result);
                }

                // Convert peso to minutes (1 peso = 6 minutes)
                decimal topUpMinutes = topUpPeso * 360;
                decimal newBalance = currentBalance + topUpMinutes;

                // Update balance
                string updateBalanceQuery = "UPDATE User_Accounts SET UserBalance = ? WHERE Username = ?";
                using (OleDbCommand updateCmd = new OleDbCommand(updateBalanceQuery, _connection))
                {
                    updateCmd.Parameters.AddWithValue("?", newBalance);
                    updateCmd.Parameters.AddWithValue("?", username);
                    updateCmd.ExecuteNonQuery();
                }

                // Insert into Topup_History
                string insertTopupQuery = "INSERT INTO Topup_History (UserName, TopUpDateTime, TopUpAmount) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertTopupQuery, _connection))
                {
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = username; // this is the target user
                    cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = topUpPeso; // store original peso value
                    cmd.ExecuteNonQuery();
                }

                TopUpSuccess_Lbl.Visible = true;

                UserName_Tbx.Clear();
                Amount_Tbx.Clear();
                EnterTopUp_Btn.Enabled = false;
                TopUp_Btn.Enabled = false;
                await Task.Delay(2000);
                TopUp_Pnl.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during top-up: {ex.Message}", "Top-Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                EnterTopUp_Btn.Enabled = true;
                TopUp_Btn.Enabled = true;
            }
        }

        private void UpdateInformation_Btn_Click(object sender, EventArgs e)
        {
            HideErrorLabels();

            string oldPassword = OldPassword_Tbx.Text.Trim();
            string newPassword = NewPassword_Tbx.Text.Trim();
            string confirmPassword = ConfirmPassword_Tbx.Text.Trim();

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill out all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MismatchPass_Lbl.Visible = true;
                return;
            }

            if (newPassword.Length < 4)
            {
                InvalidLengthPass_Lbl.Visible = true;
                return;
            }

            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                // Retrieve salt and hashed password from DB
                string getSaltQuery = "SELECT [AdminPassWord], AdminSalt FROM Admin_Account WHERE AdminID = ?";
                string storedHashedPassword = null;
                string storedSalt = null;

                using (OleDbCommand cmd = new OleDbCommand(getSaltQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", _userID);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            storedHashedPassword = reader["AdminPassWord"].ToString();
                            storedSalt = reader["AdminSalt"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Verify old password
                string hashedOldPassword = PasswordUtils.HashPassword(oldPassword, storedSalt);
                if (hashedOldPassword != storedHashedPassword)
                {
                    InvalidOldPass_Lbl.Visible = true;
                    return;
                }

                // Generate new salt and hash new password
                string newSalt = PasswordUtils.GenerateSalt();
                string hashedNewPassword = PasswordUtils.HashPassword(newPassword, newSalt);

                // Update admin password and salt
                string updateQuery = "UPDATE Admin_Account SET AdminPassWord = ?, AdminSalt = ? WHERE AdminID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", hashedNewPassword);
                    cmd.Parameters.AddWithValue("?", newSalt);
                    cmd.Parameters.AddWithValue("?", _userID);
                    cmd.ExecuteNonQuery();
                }

                SuccessfulUpdate_Lbl.Visible = true;
                OldPassword_Tbx.Clear();
                NewPassword_Tbx.Clear();
                ConfirmPassword_Tbx.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void Show_Btn_Click(object sender, EventArgs e)
        {
            if (OldPassword_Tbx.PasswordChar == '•')
            {
                OldPassword_Tbx.PasswordChar = '\0';
            }
            else
            {
                OldPassword_Tbx.PasswordChar = '•';
            }
        }

        private void Show1_Btn_Click(object sender, EventArgs e)
        {
            if (NewPassword_Tbx.PasswordChar == '•')
            {
                NewPassword_Tbx.PasswordChar = '\0';
            }
            else
            {
                NewPassword_Tbx.PasswordChar = '•';
            }
        }

        private void Show3_Btn_Click(object sender, EventArgs e)
        {
            if (ConfirmPassword_Tbx.PasswordChar == '•')
            {
                ConfirmPassword_Tbx.PasswordChar = '\0';
            }
            else
            {
                ConfirmPassword_Tbx.PasswordChar = '•';
            }
        }

        private void AdminDashBoard_Page_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connection?.State == ConnectionState.Open)
                _connection.Close();
        }

        private void UserReport_Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != 0) // Exclude checkbox column
            {
                DataGridViewRow row = UserReport_Dgv.Rows[e.RowIndex];
                string reportId = row.Cells["ReportID"].Value.ToString();

                // Load full report into textbox
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string getReportQuery = "SELECT Report FROM User_Reports WHERE ReportID = ?";
                using (OleDbCommand cmd = new OleDbCommand(getReportQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", reportId);
                    object reportDetails = cmd.ExecuteScalar();
                    Report_Tbx.Text = reportDetails?.ToString() ?? "[No Details]";
                }

                // Mark report as viewed
                string markViewedQuery = "UPDATE User_Reports SET ReportStatus = 'Viewed' WHERE ReportID = ?";
                using (OleDbCommand cmd = new OleDbCommand(markViewedQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", reportId);
                    cmd.ExecuteNonQuery();
                }

                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                // Refresh to update status
                LoadUserReports();
            }
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            List<int> selectedReportIds = new List<int>();

            foreach (DataGridViewRow row in UserReport_Dgv.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isChecked)
                {
                    int reportId = Convert.ToInt32(row.Cells["ReportID"].Value);
                    selectedReportIds.Add(reportId);
                }
            }

            if (selectedReportIds.Count == 0)
            {
                MessageBox.Show("No reports selected.", "Delete Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Delete {selectedReportIds.Count} selected report(s)?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                foreach (int id in selectedReportIds)
                {
                    string deleteQuery = "DELETE FROM User_Reports WHERE ReportID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(deleteQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("?", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (_connection.State == ConnectionState.Open)
                    _connection.Close();

                LoadUserReports(); // Refresh
                Report_Tbx.Clear();
            }
        }
    }
}
