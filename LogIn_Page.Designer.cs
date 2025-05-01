namespace Immortals_New
{
    partial class LogIn_Page
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn_Page));
            LogIn_Panel = new Panel();
            Credential_Pnl = new Panel();
            Username_Lbl = new Label();
            Password_Lbl = new Label();
            Guest_Btn = new Button();
            BeMember_Btn = new Button();
            LogIn_Btn = new Button();
            ShowPassword_Btn = new Button();
            InvalidPassword_Lbl = new Label();
            InvalidUsername_Lbl = new Label();
            Line1_Pnl = new Panel();
            Line_Pnl = new Panel();
            Invalid_Lbl = new Label();
            Password_Tbx = new TextBox();
            UserName_Tbx = new TextBox();
            User_Img = new PictureBox();
            Password_Img = new PictureBox();
            LogIn_Panel.SuspendLayout();
            Credential_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)User_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Password_Img).BeginInit();
            SuspendLayout();
            // 
            // LogIn_Panel
            // 
            resources.ApplyResources(LogIn_Panel, "LogIn_Panel");
            LogIn_Panel.BackColor = Color.Transparent;
            LogIn_Panel.Controls.Add(Credential_Pnl);
            LogIn_Panel.Name = "LogIn_Panel";
            // 
            // Credential_Pnl
            // 
            resources.ApplyResources(Credential_Pnl, "Credential_Pnl");
            Credential_Pnl.BackColor = Color.DarkOrchid;
            Credential_Pnl.Controls.Add(Username_Lbl);
            Credential_Pnl.Controls.Add(Password_Lbl);
            Credential_Pnl.Controls.Add(Guest_Btn);
            Credential_Pnl.Controls.Add(BeMember_Btn);
            Credential_Pnl.Controls.Add(LogIn_Btn);
            Credential_Pnl.Controls.Add(ShowPassword_Btn);
            Credential_Pnl.Controls.Add(InvalidPassword_Lbl);
            Credential_Pnl.Controls.Add(InvalidUsername_Lbl);
            Credential_Pnl.Controls.Add(Line1_Pnl);
            Credential_Pnl.Controls.Add(Line_Pnl);
            Credential_Pnl.Controls.Add(Invalid_Lbl);
            Credential_Pnl.Controls.Add(Password_Tbx);
            Credential_Pnl.Controls.Add(UserName_Tbx);
            Credential_Pnl.Controls.Add(User_Img);
            Credential_Pnl.Controls.Add(Password_Img);
            Credential_Pnl.Name = "Credential_Pnl";
            // 
            // Username_Lbl
            // 
            resources.ApplyResources(Username_Lbl, "Username_Lbl");
            Username_Lbl.BackColor = Color.Transparent;
            Username_Lbl.Name = "Username_Lbl";
            // 
            // Password_Lbl
            // 
            resources.ApplyResources(Password_Lbl, "Password_Lbl");
            Password_Lbl.BackColor = Color.Transparent;
            Password_Lbl.Name = "Password_Lbl";
            // 
            // Guest_Btn
            // 
            resources.ApplyResources(Guest_Btn, "Guest_Btn");
            Guest_Btn.BackColor = Color.Transparent;
            Guest_Btn.FlatAppearance.BorderSize = 3;
            Guest_Btn.Name = "Guest_Btn";
            Guest_Btn.UseVisualStyleBackColor = false;
            Guest_Btn.Click += Guest_Btn_Click;
            // 
            // BeMember_Btn
            // 
            resources.ApplyResources(BeMember_Btn, "BeMember_Btn");
            BeMember_Btn.BackColor = Color.Transparent;
            BeMember_Btn.FlatAppearance.BorderSize = 3;
            BeMember_Btn.Name = "BeMember_Btn";
            BeMember_Btn.UseVisualStyleBackColor = false;
            BeMember_Btn.Click += BeMember_Btn_Click;
            // 
            // LogIn_Btn
            // 
            resources.ApplyResources(LogIn_Btn, "LogIn_Btn");
            LogIn_Btn.BackColor = Color.Transparent;
            LogIn_Btn.FlatAppearance.BorderSize = 3;
            LogIn_Btn.Name = "LogIn_Btn";
            LogIn_Btn.UseVisualStyleBackColor = false;
            LogIn_Btn.Click += LogIn_Btn_Click;
            // 
            // ShowPassword_Btn
            // 
            resources.ApplyResources(ShowPassword_Btn, "ShowPassword_Btn");
            ShowPassword_Btn.BackColor = Color.Transparent;
            ShowPassword_Btn.BackgroundImage = Properties.Resources.showPass;
            ShowPassword_Btn.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 255);
            ShowPassword_Btn.FlatAppearance.BorderSize = 0;
            ShowPassword_Btn.ForeColor = Color.Transparent;
            ShowPassword_Btn.Name = "ShowPassword_Btn";
            ShowPassword_Btn.UseVisualStyleBackColor = false;
            ShowPassword_Btn.Click += ShowPassword_Btn_Click;
            // 
            // InvalidPassword_Lbl
            // 
            resources.ApplyResources(InvalidPassword_Lbl, "InvalidPassword_Lbl");
            InvalidPassword_Lbl.BackColor = Color.Transparent;
            InvalidPassword_Lbl.ForeColor = Color.Red;
            InvalidPassword_Lbl.Name = "InvalidPassword_Lbl";
            // 
            // InvalidUsername_Lbl
            // 
            resources.ApplyResources(InvalidUsername_Lbl, "InvalidUsername_Lbl");
            InvalidUsername_Lbl.BackColor = Color.Transparent;
            InvalidUsername_Lbl.ForeColor = Color.Red;
            InvalidUsername_Lbl.Name = "InvalidUsername_Lbl";
            // 
            // Line1_Pnl
            // 
            Line1_Pnl.BackColor = Color.GhostWhite;
            resources.ApplyResources(Line1_Pnl, "Line1_Pnl");
            Line1_Pnl.Name = "Line1_Pnl";
            // 
            // Line_Pnl
            // 
            Line_Pnl.BackColor = Color.GhostWhite;
            resources.ApplyResources(Line_Pnl, "Line_Pnl");
            Line_Pnl.Name = "Line_Pnl";
            // 
            // Invalid_Lbl
            // 
            resources.ApplyResources(Invalid_Lbl, "Invalid_Lbl");
            Invalid_Lbl.BackColor = Color.Transparent;
            Invalid_Lbl.ForeColor = Color.Red;
            Invalid_Lbl.Name = "Invalid_Lbl";
            // 
            // Password_Tbx
            // 
            resources.ApplyResources(Password_Tbx, "Password_Tbx");
            Password_Tbx.BackColor = Color.DarkOrchid;
            Password_Tbx.ForeColor = Color.White;
            Password_Tbx.Name = "Password_Tbx";
            // 
            // UserName_Tbx
            // 
            resources.ApplyResources(UserName_Tbx, "UserName_Tbx");
            UserName_Tbx.BackColor = Color.DarkOrchid;
            UserName_Tbx.ForeColor = Color.White;
            UserName_Tbx.Name = "UserName_Tbx";
            // 
            // User_Img
            // 
            resources.ApplyResources(User_Img, "User_Img");
            User_Img.BackColor = Color.Transparent;
            User_Img.Image = Properties.Resources.User;
            User_Img.Name = "User_Img";
            User_Img.TabStop = false;
            // 
            // Password_Img
            // 
            resources.ApplyResources(Password_Img, "Password_Img");
            Password_Img.BackColor = Color.Transparent;
            Password_Img.Image = Properties.Resources.Lock;
            Password_Img.Name = "Password_Img";
            Password_Img.TabStop = false;
            // 
            // LogIn_Page
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.LoginBackground;
            Controls.Add(LogIn_Panel);
            ForeColor = Color.Transparent;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LogIn_Page";
            LogIn_Panel.ResumeLayout(false);
            Credential_Pnl.ResumeLayout(false);
            Credential_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)User_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)Password_Img).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel LogIn_Panel;
        private Panel Credential_Pnl;
        private Label Invalid_Lbl;
        private TextBox Password_Tbx;
        private TextBox UserName_Tbx;
        private PictureBox User_Img;
        private PictureBox Password_Img;
        private Panel Line_Pnl;
        private Panel Line1_Pnl;
        private Label InvalidPassword_Lbl;
        private Label InvalidUsername_Lbl;
        private Button ShowPassword_Btn;
        private Button Guest_Btn;
        private Button BeMember_Btn;
        private Button LogIn_Btn;
        private Label Username_Lbl;
        private Label Password_Lbl;
    }
}
