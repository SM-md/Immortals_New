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
    public partial class UserDashBoard : Form
    {
        //Database Connection
        private OleDbConnection _connection;
        private string _userRole;
        private string _username;
        private string _userID;

        private int currentBalance;
        private const int LowBalanceThreshold = 120; // 2 minutes
        private bool hasWarnedUser = false;
        private int? loginHistoryId = null; // nullable to track if insert was successful

        private System.Windows.Forms.Timer balanceTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer topUpHistoryTimer = new System.Windows.Forms.Timer();

        public UserDashBoard(string connectionString, string userRole, string username, string userID)
        {
            InitializeComponent();
            topUpHistoryTimer.Interval = 5000; // Refresh every 5 seconds
            topUpHistoryTimer.Tick += (s, e) =>
            {
                if (TopUpHistory_Pnl.Visible) // Only update if the panel is visible
                {
                    LoadUserTopUpHistory();
                }
            };
            topUpHistoryTimer.Start();
            _connection = new OleDbConnection(connectionString);
            _userRole = userRole;
            _username = username;
            _userID = userID;
            InsertLoginRecord();
            UserName_Lbl.Text = username;
            MainUserDashBoard_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            TopUp_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            AccountDetails_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            TopUpHistory_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            UserReport_Pnl.BackColor = Color.FromArgb(128, Color.Violet);
            TopUp_Pnl.Visible = false;
            AccountDetails_Pnl.Visible = false;
            TopUpHistory_Pnl.Visible = false;
            UserReport_Pnl.Visible = false;
            TopUpHistory_Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TopUpHistory_Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TopUpHistory_Dgv.ReadOnly = true;
            balanceTimer.Interval = 1000; // 1 second
            balanceTimer.Tick += BalanceTimer_Tick;
            RefreshUserBalance();
        }

        private void HideErrorLabels()
        {
            InvalidAmount_Lbl.Visible = false;
            SuccessfulTopUp_Lbl.Visible = false;
            InvalidOldPass_Lbl.Visible = false;
            InvalidLengthPass_Lbl.Visible = false;
            MismatchPass_Lbl.Visible = false;
            SuccessfullyUpdated_Lbl.Visible = false;
        }

        private void InsertLoginRecord()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string insertQuery = "INSERT INTO LogIn_History (UserName, LogInDateTime) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, _connection))
                {
                    cmd.Parameters.Add("UserName", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("LogInDateTime", OleDbType.Date).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                }

                // Immediately get the last inserted identity value
                string identityQuery = "SELECT @@IDENTITY";
                using (OleDbCommand cmd = new OleDbCommand(identityQuery, _connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        loginHistoryId = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login logging failed: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void UpdateLogoutRecord()
        {
            if (loginHistoryId == 0)
                return;

            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string updateQuery = "UPDATE LogIn_History SET LogOutDateTime = ? WHERE LogInID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, _connection))
                {
                    cmd.Parameters.Add("LogOutDateTime", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("LogInID", OleDbType.Integer).Value = loginHistoryId;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logout logging failed: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void LoadUserTopUpHistory()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = "SELECT TopUpDateTime, TopUpAmount FROM Topup_History WHERE UserName = ? ORDER BY TopUpDateTime DESC";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("?", _username);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        TopUpHistory_Dgv.DataSource = dt;

                        // Auto-scroll to the newest entry
                        if (TopUpHistory_Dgv.Rows.Count > 0)
                        {
                            TopUpHistory_Dgv.FirstDisplayedScrollingRowIndex = 0; // Scroll to top (most recent at top)
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top-up history: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void BalanceTimer_Tick(object sender, EventArgs e)
        {
            if (currentBalance > 0)
            {
                currentBalance--;
                UpdateTimeLabel(currentBalance);

                if (currentBalance == LowBalanceThreshold && !hasWarnedUser)
                {
                    hasWarnedUser = true;
                    ShowLowBalanceWarning();
                }

                if (currentBalance % 30 == 0)
                    UpdateBalanceInDatabase();
            }
            else
            {
                balanceTimer.Stop();
                UpdateBalanceInDatabase();
                MessageBox.Show("Your balance is depleted. Please top-up to continue.", "Balance Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private int GetUserBalance()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = "SELECT UserBalance FROM User_Accounts WHERE AccountID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@ID", _userID);
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching balance: {ex.Message}");
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }

        private void RefreshUserBalance()
        {
            currentBalance = GetUserBalance();
            UpdateTimeLabel(currentBalance);

            if (currentBalance > 0)
                balanceTimer.Start();
            else
                balanceTimer.Stop();
        }

        private void UpdateTimeLabel(int seconds)
        {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            int secs = seconds % 60;

            Time_Lbl.Text = $"{hours:00}:{minutes:00}:{secs:00}";
        }

        private void UpdateBalanceInDatabase()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = "UPDATE User_Accounts SET UserBalance = ? WHERE AccountID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("?", currentBalance);
                    cmd.Parameters.AddWithValue("?", _userID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to sync balance: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void ShowLowBalanceWarning()
        {
            MessageBox.Show("⚠️ Your remaining time is below 5 minutes! Please top up soon.",
                            "Low Balance Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            Time_Lbl.ForeColor = Color.Red;
        }

        private void PlayNow_Btn_Click(object sender, EventArgs e)
        {
            int balance = GetUserBalance();
            if (balance > 0)
            {
                new AppsMenu(_connection, "User", _username, _userID, null, this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Insufficient balance. Please top-up first.", "Balance Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TopUp_Btn_Click(object sender, EventArgs e)
        {
            TopUp_Pnl.Visible = !TopUp_Pnl.Visible;
        }

        private void AccountDetails_Btn_Click(object sender, EventArgs e)
        {
            AccountDetails_Pnl.Visible = !AccountDetails_Pnl.Visible;
        }

        private void ShowTopUpHistory_Btn_Click(object sender, EventArgs e)
        {
            if (UserReport_Pnl.Visible == true)
            {
                TopUpHistory_Pnl.Visible = false;
            }
            else
            {
                TopUpHistory_Pnl.Visible = !TopUpHistory_Pnl.Visible;
            }
            if (TopUpHistory_Pnl.Visible)
                LoadUserTopUpHistory();
        }

        private void Report_Btn_Click(object sender, EventArgs e)
        {
            if (TopUpHistory_Pnl.Visible == true)
            {
                UserReport_Pnl.Visible = false;
            }
            else
            {
                UserReport_Pnl.Visible = !UserReport_Pnl.Visible;
            }
        }

        private async void EnterTopUp_Btn_Click(object sender, EventArgs e)
        {
            HideErrorLabels();

            if (!int.TryParse(Amount_Tbx.Text.Trim(), out int topupAmount) || topupAmount <= 0)
            {
                InvalidAmount_Lbl.Visible = true;
                return;
            }

            int topupInSeconds = topupAmount * 360; //6 minutes

            try
            {
                TopUp_Btn.Enabled = false;

                _connection.Open();

                string updateBalanceQuery = "UPDATE User_Accounts SET UserBalance = UserBalance + ? WHERE AccountID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateBalanceQuery, _connection))
                {
                    cmd.Parameters.Add("TopupSeconds", OleDbType.Integer).Value = topupInSeconds;
                    cmd.Parameters.Add("UserID", OleDbType.Integer).Value = _userID;
                    cmd.ExecuteNonQuery();
                }

                string insertTopupQuery = "INSERT INTO Topup_History (UserName, TopUpDateTime, TopUpAmount) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertTopupQuery, _connection))
                {
                    cmd.Parameters.Add("Username", OleDbType.VarChar).Value = _username;
                    cmd.Parameters.Add("TopupDateTime", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("TopupAmount", OleDbType.Integer).Value = topupAmount;
                    cmd.ExecuteNonQuery();
                }

                SuccessfulTopUp_Lbl.Visible = true;
                RefreshUserBalance();
                ShowTopUpHistory_Btn.Enabled = false;
                EnterTopUp_Btn.Enabled = false;
                hasWarnedUser = false;
                Time_Lbl.ForeColor = Color.White;
                await Task.Delay(2000);
                TopUp_Pnl.Visible = false;
                Amount_Tbx.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Top-up failed: {ex.Message}");
            }
            finally
            {
                _connection.Close();
                TopUp_Btn.Enabled = true;
                ShowTopUpHistory_Btn.Enabled = true;
                EnterTopUp_Btn.Enabled = true;
            }
        }

        private void UserDashBoard_Shown(object sender, EventArgs e)
        {
            if (GetUserBalance() == 0)
            {
                MessageBox.Show("Your balance is 0. Please top-up to continue.", "No Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogOut_Btn_Click(object sender, EventArgs e)
        {
            balanceTimer.Stop();
            topUpHistoryTimer.Stop();
            UpdateBalanceInDatabase();
            UpdateLogoutRecord();
            new LogIn_Page().Show();
            this.Close();
        }

        private void UserDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateLogoutRecord();
            balanceTimer?.Stop();
            balanceTimer?.Dispose();
            topUpHistoryTimer.Stop();
            topUpHistoryTimer.Dispose();
            UpdateBalanceInDatabase();
            if (_connection?.State == ConnectionState.Open)
                _connection.Close();
        }

        private void UpdateAccountDetails_Btn_Click(object sender, EventArgs e)
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
                string getSaltQuery = "SELECT [Password], UserSalt FROM User_Accounts WHERE AccountID = ?";
                string storedHashedPassword = null;
                string storedSalt = null;

                using (OleDbCommand cmd = new OleDbCommand(getSaltQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", _userID);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            storedHashedPassword = reader["Password"].ToString();
                            storedSalt = reader["UserSalt"].ToString();
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

                // Update password and salt
                string updateQuery = "UPDATE User_Accounts SET [Password] = ?, UserSalt = ? WHERE AccountID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", hashedNewPassword);
                    cmd.Parameters.AddWithValue("?", newSalt);
                    cmd.Parameters.AddWithValue("?", _userID);
                    cmd.ExecuteNonQuery();
                }

                SuccessfullyUpdated_Lbl.Visible = true;
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

        private void DeleteAccount_Btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                                          "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();

                    string deleteQuery = "DELETE FROM User_Accounts WHERE AccountID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(deleteQuery, _connection))
                    {
                        cmd.Parameters.AddWithValue("?", _userID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Your account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Log out and go back to login screen
                    balanceTimer.Stop();
                    new LogIn_Page().Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }
            }
        }

        private void EnterReport_Btn_Click(object sender, EventArgs e)
        {
            string reportText = Report_Tbx.Text.Trim();

            if (string.IsNullOrEmpty(reportText))
            {
                MessageBox.Show("Please enter your report before submitting.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _connection.Open();

                string insertQuery = "INSERT INTO User_Reports (UserName, Report) VALUES (?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("?", _username);
                    cmd.Parameters.AddWithValue("?", reportText);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Report_Tbx.Clear();
                UserReport_Pnl.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting report: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void Show_btn_Click(object sender, EventArgs e)
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

        private void Show2_Btn_Click(object sender, EventArgs e)
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
    }
}
