using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Immortals_New
{
    public partial class LogIn_Page : Form
    {
        //Database Connection
        private OleDbConnection _connection;
        private DataSet _dataSet;

        public LogIn_Page()
        {
            InitializeComponent();
            ConnectToDatabase();
            Credential_Pnl.BackColor = Color.FromArgb(128, Color.DarkOrchid);
        }

        private void HideErrorLabels()
        {
            InvalidUsername_Lbl.Visible = false;
            InvalidPassword_Lbl.Visible = false;
            Invalid_Lbl.Visible = false;
        }

        private void ConnectToDatabase()
        {
            string folderPath = @"W:\Documents\BSCpE\Soft Dev\Immortals_New"; //Path of folder where the database is located
            string accdbFile = FindAccdbFile(folderPath);

            if (accdbFile == null)
            {
                MessageBox.Show("No .accdb file found in the folder.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accdbFile};Persist Security Info=False;";
            _connection = new OleDbConnection(connectionString);

            try
            {
                _connection.Open();
                MessageBox.Show("Connected to database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadDataSet()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Cannot reload, database not connected.", "Reload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Query for User_Accounts table
                string userQuery = "SELECT * FROM User_Accounts";
                OleDbCommand userCommand = new OleDbCommand(userQuery, _connection);
                OleDbDataAdapter userAdapter = new OleDbDataAdapter(userCommand);

                // Query for Admin_Account table
                string adminQuery = "SELECT * FROM Admin_Account";
                OleDbCommand adminCommand = new OleDbCommand(adminQuery, _connection);
                OleDbDataAdapter adminAdapter = new OleDbDataAdapter(adminCommand);

                // Clear previous data in the DataSet
                _dataSet = new DataSet();

                // Fill the DataSet with data from both tables
                userAdapter.Fill(_dataSet, "User_Accounts");
                adminAdapter.Fill(_dataSet, "Admin_Account");

                MessageBox.Show("Data refreshed successfully!", "Data Reloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Reload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string FindAccdbFile(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                return null;

            string[] files = Directory.GetFiles(folderPath, "*.accdb");
            if (files.Length > 0)
                return files[0];

            return null;
        }

        //Password Encryption Class (Hashing + Salting)
        public static class PasswordUtils
        {
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

        private void LogIn_Btn_Click(object sender, EventArgs e)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database is not connected.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredUsername = UserName_Tbx.Text.Trim();
            string enteredPassword = Password_Tbx.Text.Trim();

            HideErrorLabels();

            if (string.IsNullOrEmpty(enteredUsername) && string.IsNullOrEmpty(enteredPassword))
            {
                Invalid_Lbl.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(enteredUsername))
            {
                InvalidUsername_Lbl.Visible = true;
                return;
            }
            else if (string.IsNullOrEmpty(enteredPassword))
            {
                InvalidPassword_Lbl.Visible = true;
                return;
            }

            try
            {
                //Check if account is admin
                string adminQuery = "SELECT AdminID, AdminPassWord, AdminSalt FROM Admin_Account WHERE AdminUsername = ?";
                using (OleDbCommand adminCmd = new OleDbCommand(adminQuery, _connection))
                {
                    adminCmd.Parameters.AddWithValue("@AdminUsername", enteredUsername);

                    OleDbDataReader reader = adminCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string storedHashedPassword = reader["AdminPassWord"].ToString();
                        string storedSalt = reader["AdminSalt"].ToString();
                        string adminID = reader["AdminID"].ToString();

                        // Hash the entered password + stored salt
                        string hashedInputPassword = PasswordUtils.HashPassword(enteredPassword, storedSalt);

                        if (storedHashedPassword == hashedInputPassword)
                        {
                            string connectionString = _connection.ConnectionString;
                            AdminDashBoard_Page adminDash = new AdminDashBoard_Page(connectionString, "Admin", enteredUsername, adminID);
                            adminDash.Show();
                            this.Hide();
                            return;
                        }
                    }
                }
                // If not admin, check UserAccounts
                string userQuery = "SELECT AccountID, [Password], UserSalt FROM User_Accounts WHERE Username = ?";
                using (OleDbCommand userCmd = new OleDbCommand(userQuery, _connection))
                {
                    userCmd.Parameters.AddWithValue("@Username", enteredUsername);

                    OleDbDataReader reader = userCmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string storedHashedPassword = reader["Password"].ToString();
                        string storedSalt = reader["UserSalt"].ToString();
                        string userID = reader["AccountID"].ToString();

                        // Hash the entered password + stored salt
                        string hashedInputPassword = PasswordUtils.HashPassword(enteredPassword, storedSalt);

                        if (storedHashedPassword == hashedInputPassword)
                        {
                            string connectionString = _connection.ConnectionString;
                            UserDashBoard userDashBoard = new UserDashBoard(connectionString, "User", enteredUsername, userID);
                            userDashBoard.Show();
                            this.Hide();
                            return;
                        }
                    }
                }

                // If no match found in both tables
                Invalid_Lbl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReloadDataSet();
        }

        private void BeMember_Btn_Click(object sender, EventArgs e)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database is not connected.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Registration_Page registrationPage = new Registration_Page(_connection, _dataSet);//Pass the database connection and dataset to RegistrationPage
            registrationPage.Show();
            this.Hide();
        }

        private void Guest_Btn_Click(object sender, EventArgs e)
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Database is not connected.", "Guest Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GuestDashBoard guestDashBoard = new GuestDashBoard(_connection);//Pass the database connection to GuestDashBoard
            guestDashBoard.Show();
            this.Hide();
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
    }
}
