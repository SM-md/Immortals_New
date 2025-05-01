using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Immortals_New
{
    public partial class AppsMenu : Form
    {
        // Database and session info
        private readonly OleDbConnection _connection;
        private readonly string _userRole;
        private readonly string _username;
        private readonly string _userID;

        // Dashboards
        private readonly GuestDashBoard _guestDashboard;
        private readonly UserDashBoard _userDashboard;
        private readonly AdminDashBoard_Page _adminDashboard;

        // App shortcuts
        private readonly Dictionary<Button, string> appPaths = new();
        private Button[] appButtons;

        public AppsMenu(
        OleDbConnection connection,
        string userRole, string username, string userID,
        GuestDashBoard guestDashboard = null,
        UserDashBoard userDashboard = null,
        AdminDashBoard_Page adminDashboard = null)
        {
            InitializeComponent();
            _connection = connection;
            _userRole = userRole;
            _username = username;
            _userID = userID;
            _guestDashboard = guestDashboard;
            _userDashboard = userDashboard;
            _adminDashboard = adminDashboard;

            ConfigureUIBasedOnRole();
            InitializeAppButtons();
            LoadShortcutsFromDatabase();
        }

        private void ConfigureUIBasedOnRole()
        {
            AddApps_Btn.Visible = (_userRole == "Admin");
            AddApps_Btn.Enabled = (_userRole == "Admin");
        }

        private void InitializeAppButtons()
        {
            appButtons = this.Controls
            .OfType<Button>()
            .Where(btn => btn.Name.StartsWith("App") && int.TryParse(btn.Name.Substring(3), out _))
            .OrderBy(btn => int.Parse(btn.Name.Substring(3)))
            .ToArray();

            foreach (Button btn in appButtons)
            {
                btn.Visible = false;
                btn.Click += AppButton_Click;
            }
        }

        private void AppButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && appPaths.TryGetValue(btn, out string path) && File.Exists(path))
            {
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open application: {ex.Message}");
                }
            }
        }

        private void AddApps_Btn_Click(object sender, EventArgs e)
        {
            if (_userRole != "Admin")
            {
                MessageBox.Show("Only administrators can add apps.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using OpenFileDialog ofd = new()
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select an application"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = ofd.FileName;

                foreach (Button btn in appButtons)
                {
                    if (!btn.Visible)
                    {
                        SetButtonIcon(btn, selectedPath);
                        btn.Text = "";
                        btn.Visible = true;
                        appPaths[btn] = selectedPath;

                        SaveShortcutToDatabase(selectedPath);
                        break;
                    }
                }
            }
        }

        private void SetButtonIcon(Button btn, string path)
        {
            try
            {
                Icon icon = Icon.ExtractAssociatedIcon(path);
                if (icon != null)
                {
                    btn.Image = icon.ToBitmap();
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }
            catch { /* No error message but does not stop program when icon is failed to load */ }
        }

        private void SaveShortcutToDatabase(string appPath)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                using OleDbCommand cmd = new("INSERT INTO AppShortcuts (AppPath) VALUES (?)", _connection);
                cmd.Parameters.AddWithValue("?", appPath);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving shortcut: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void LoadShortcutsFromDatabase()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string query = "SELECT AppPath FROM AppShortcuts";
                using OleDbCommand cmd = new(query, _connection);
                using OleDbDataReader reader = cmd.ExecuteReader();

                int i = 0;
                while (reader.Read() && i < appButtons.Length)
                {
                    string path = reader.GetString(0);
                    if (File.Exists(path))
                    {
                        Button btn = appButtons[i++];
                        SetButtonIcon(btn, path);
                        btn.Text = "";
                        btn.Visible = true;
                        appPaths[btn] = path;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shortcuts: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void Return_Btn_Click(object sender, EventArgs e)
        {
            if (_userRole == "Guest" && _guestDashboard != null)
                _guestDashboard.Show();
            else if (_userRole == "User" && _userDashboard != null)
                _userDashboard.Show();
            else if (_userRole == "Admin" && _adminDashboard != null)
                _adminDashboard.Show();

            this.Close();
        }
    }
}