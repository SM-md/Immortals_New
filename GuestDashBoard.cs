using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immortals_New
{
    public partial class GuestDashBoard : Form
    {
        //Database Connection
        private OleDbConnection _connection;

        private string _guestUsername;
        private int _guestID;
        private int currentBalance;
        private const int LowBalanceThreshold = 120; // 2 minutes
        private bool hasWarnedUser = false;

        private System.Windows.Forms.Timer balanceTimer = new System.Windows.Forms.Timer();

        public GuestDashBoard(OleDbConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            _guestID = CreateGuestAccount();
            _guestUsername = $"Guest{_guestID}";
            IDGuest_Lbl.Text = $"{_guestID}";
            MainDashBoard_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            TopUp_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
            UserReport_Pnl.BackColor = Color.FromArgb(128, Color.Violet);
            TopUp_Pnl.Visible = false;
            UserReport_Pnl.Visible = false;
            balanceTimer.Interval = 1000; // 1 second interval
            balanceTimer.Tick += BalanceTimer_Tick;
            RefreshUserBalance();
        }

        private void HideErrorLabels()
        {
            ErrorAmount_Lbl.Visible = false;
            TopUpSuccess_Lbl.Visible = false;
        }

        private int CreateGuestAccount()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                string insertQuery = "INSERT INTO Guest_Accounts (GuestBalance) VALUES (0)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, _connection))
                {
                    cmd.ExecuteNonQuery();
                }

                string getIdQuery = "SELECT MAX(GuestID) FROM Guest_Accounts";
                using (OleDbCommand cmd = new OleDbCommand(getIdQuery, _connection))
                {
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating guest account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private void BalanceTimer_Tick(object sender, EventArgs e)
        {
            if (currentBalance > 0)
            {
                currentBalance--;
                UpdateTimeLabel(currentBalance);

                // Show warning if balance drops to threshold
                if (currentBalance == LowBalanceThreshold && !hasWarnedUser)
                {
                    hasWarnedUser = true;
                    ShowLowBalanceWarning();
                }

                if (currentBalance % 30 == 0) // Sync to DB every 30s
                    UpdateBalanceInDatabase();
            }
            else
            {
                balanceTimer.Stop();
                UpdateBalanceInDatabase(); // Final sync when balance hits 0
            }
        }

        private int GetUserBalance()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = "SELECT GuestBalance FROM Guest_Accounts WHERE GuestID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@GuestID", GetGuestID());
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching balance: {ex.Message}", "Balance Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                _connection.Close();
            }
        }

        private int GetGuestID()
        {
            return _guestID;
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

                string query = "UPDATE Guest_Accounts SET GuestBalance = ? WHERE GuestID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("?", currentBalance);
                    cmd.Parameters.AddWithValue("?", GetGuestID());
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

        private void PlayNow_Btn_Click(object sender, EventArgs e)
        {
            int balance = GetUserBalance();
            if (balance > 0)
            {
                new AppsMenu(_connection, "Guest", _guestUsername, _guestID.ToString(), this).Show();
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

        private void SignOut_Btn_Click(object sender, EventArgs e)
        {
            balanceTimer.Stop();
            new LogIn_Page().Show();
            this.Close();
        }

        private void Report_Btn_Click(object sender, EventArgs e)
        {
            UserReport_Pnl.Visible = !UserReport_Pnl.Visible;
        }

        private async void EnterTopUp_Btn_Click(object sender, EventArgs e)
        {
            HideErrorLabels();

            if (!int.TryParse(Amount_Tbx.Text.Trim(), out int topupAmount) || topupAmount <= 0)
            {
                ErrorAmount_Lbl.Visible = true;
                return;
            }

            int topupInSeconds = topupAmount * 240; // 1 peso = 4 minutes

            try
            {
                TopUp_Btn.Enabled = false;

                _connection.Open();

                // Update Guest balance
                string updateBalanceQuery = "UPDATE Guest_Accounts SET GuestBalance = GuestBalance + ? WHERE GuestID = ?";
                using (OleDbCommand cmd = new OleDbCommand(updateBalanceQuery, _connection))
                {
                    cmd.Parameters.Add("TopupSeconds", OleDbType.Integer).Value = topupInSeconds;
                    cmd.Parameters.Add("GuestID", OleDbType.Integer).Value = GetGuestID();
                    cmd.ExecuteNonQuery();
                }

                // Insert into TopupHistory
                string insertTopupQuery = "INSERT INTO Topup_History (UserName, TopUpDateTime, TopUpAmount) VALUES (?, ?, ?)";
                using (OleDbCommand cmd = new OleDbCommand(insertTopupQuery, _connection))
                {
                    cmd.Parameters.Add("Username", OleDbType.VarChar).Value = _guestUsername;
                    cmd.Parameters.Add("TopupDateTime", OleDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("TopupAmount", OleDbType.Integer).Value = topupAmount;
                    cmd.ExecuteNonQuery();
                }

                TopUpSuccess_Lbl.Visible = true;

                RefreshUserBalance();
                EnterTopUp_Btn.Enabled = false;
                hasWarnedUser = false;
                Time_Lbl.ForeColor = Color.White;
                await Task.Delay(3000);
                TopUp_Pnl.Visible = false;
                Amount_Tbx.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during top-up: {ex.Message}", "Top-up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _connection.Close();
                TopUp_Btn.Enabled = true;
                EnterTopUp_Btn.Enabled = true;
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
                    cmd.Parameters.AddWithValue("?", _guestUsername);
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

        private void GuestDashBoard_Shown(object sender, EventArgs e)
        {
            int balance = GetUserBalance();
            if (balance == 0)
            {
                MessageBox.Show("Balance has run out. Please top-up to continue.", "Balance Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowLowBalanceWarning()
        {
            MessageBox.Show("⚠️ Your remaining time is below 5 minutes! Please top up soon.",
                            "Low Balance Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

            //Change Time label Color
            Time_Lbl.ForeColor = Color.Red;
        }

        private void GuestDashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            balanceTimer?.Stop();
            balanceTimer?.Dispose();
            if (_connection?.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
