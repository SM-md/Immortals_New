namespace Immortals_New
{
    partial class Registration_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Reg_Pnl = new Panel();
            RegCredential_Pnl = new Panel();
            AddAdmin_Btn = new Button();
            SuccessfulRegistration_Lbl = new Label();
            BackToLogin_Btn = new Button();
            Register_Btn = new Button();
            ConfirmPass_Lbl = new Label();
            ConfirmPass_Img = new PictureBox();
            ConfirmPass_Btn = new Button();
            Req2_Lbl = new Label();
            ConfirmPass_Tbx = new TextBox();
            Line2_Pnl = new Panel();
            Username_Lbl = new Label();
            User_Img = new PictureBox();
            Password_Lbl = new Label();
            Password_Img = new PictureBox();
            ShowPassword_Btn = new Button();
            UserName_Tbx = new TextBox();
            Req1_Lbl = new Label();
            Password_Tbx = new TextBox();
            Req_Lbl = new Label();
            Invalid_Lbl = new Label();
            Line1_Pnl = new Panel();
            Line_Pnl = new Panel();
            Reg_Pnl.SuspendLayout();
            RegCredential_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ConfirmPass_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)User_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Password_Img).BeginInit();
            SuspendLayout();
            // 
            // Reg_Pnl
            // 
            Reg_Pnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Reg_Pnl.BackColor = Color.Transparent;
            Reg_Pnl.Controls.Add(RegCredential_Pnl);
            Reg_Pnl.Location = new Point(621, 377);
            Reg_Pnl.Name = "Reg_Pnl";
            Reg_Pnl.Size = new Size(674, 665);
            Reg_Pnl.TabIndex = 0;
            // 
            // RegCredential_Pnl
            // 
            RegCredential_Pnl.BackColor = Color.DarkOrchid;
            RegCredential_Pnl.Controls.Add(AddAdmin_Btn);
            RegCredential_Pnl.Controls.Add(SuccessfulRegistration_Lbl);
            RegCredential_Pnl.Controls.Add(BackToLogin_Btn);
            RegCredential_Pnl.Controls.Add(Register_Btn);
            RegCredential_Pnl.Controls.Add(ConfirmPass_Lbl);
            RegCredential_Pnl.Controls.Add(ConfirmPass_Img);
            RegCredential_Pnl.Controls.Add(ConfirmPass_Btn);
            RegCredential_Pnl.Controls.Add(Req2_Lbl);
            RegCredential_Pnl.Controls.Add(ConfirmPass_Tbx);
            RegCredential_Pnl.Controls.Add(Line2_Pnl);
            RegCredential_Pnl.Controls.Add(Username_Lbl);
            RegCredential_Pnl.Controls.Add(User_Img);
            RegCredential_Pnl.Controls.Add(Password_Lbl);
            RegCredential_Pnl.Controls.Add(Password_Img);
            RegCredential_Pnl.Controls.Add(ShowPassword_Btn);
            RegCredential_Pnl.Controls.Add(UserName_Tbx);
            RegCredential_Pnl.Controls.Add(Req1_Lbl);
            RegCredential_Pnl.Controls.Add(Password_Tbx);
            RegCredential_Pnl.Controls.Add(Req_Lbl);
            RegCredential_Pnl.Controls.Add(Invalid_Lbl);
            RegCredential_Pnl.Controls.Add(Line1_Pnl);
            RegCredential_Pnl.Controls.Add(Line_Pnl);
            RegCredential_Pnl.Location = new Point(64, 28);
            RegCredential_Pnl.Name = "RegCredential_Pnl";
            RegCredential_Pnl.Size = new Size(526, 582);
            RegCredential_Pnl.TabIndex = 0;
            // 
            // AddAdmin_Btn
            // 
            AddAdmin_Btn.FlatStyle = FlatStyle.Flat;
            AddAdmin_Btn.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AddAdmin_Btn.ForeColor = Color.White;
            AddAdmin_Btn.Location = new Point(129, 534);
            AddAdmin_Btn.Name = "AddAdmin_Btn";
            AddAdmin_Btn.Size = new Size(272, 35);
            AddAdmin_Btn.TabIndex = 36;
            AddAdmin_Btn.Text = "Admin Register";
            AddAdmin_Btn.UseVisualStyleBackColor = true;
            AddAdmin_Btn.Visible = false;
            AddAdmin_Btn.Click += AddAdmin_Btn_Click;
            // 
            // SuccessfulRegistration_Lbl
            // 
            SuccessfulRegistration_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SuccessfulRegistration_Lbl.AutoSize = true;
            SuccessfulRegistration_Lbl.BackColor = Color.Transparent;
            SuccessfulRegistration_Lbl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SuccessfulRegistration_Lbl.ForeColor = Color.Lime;
            SuccessfulRegistration_Lbl.ImeMode = ImeMode.NoControl;
            SuccessfulRegistration_Lbl.Location = new Point(162, 13);
            SuccessfulRegistration_Lbl.Name = "SuccessfulRegistration_Lbl";
            SuccessfulRegistration_Lbl.Size = new Size(216, 19);
            SuccessfulRegistration_Lbl.TabIndex = 35;
            SuccessfulRegistration_Lbl.Text = "Registration successful";
            SuccessfulRegistration_Lbl.Visible = false;
            // 
            // BackToLogin_Btn
            // 
            BackToLogin_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BackToLogin_Btn.BackColor = Color.Transparent;
            BackToLogin_Btn.FlatAppearance.BorderSize = 3;
            BackToLogin_Btn.FlatStyle = FlatStyle.Flat;
            BackToLogin_Btn.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            BackToLogin_Btn.ForeColor = Color.White;
            BackToLogin_Btn.ImeMode = ImeMode.NoControl;
            BackToLogin_Btn.Location = new Point(129, 476);
            BackToLogin_Btn.Name = "BackToLogin_Btn";
            BackToLogin_Btn.Size = new Size(272, 52);
            BackToLogin_Btn.TabIndex = 34;
            BackToLogin_Btn.Text = "Back to Login";
            BackToLogin_Btn.UseVisualStyleBackColor = false;
            BackToLogin_Btn.Click += BackToLogin_Btn_Click;
            // 
            // Register_Btn
            // 
            Register_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Register_Btn.BackColor = Color.Transparent;
            Register_Btn.FlatAppearance.BorderSize = 3;
            Register_Btn.FlatStyle = FlatStyle.Flat;
            Register_Btn.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Register_Btn.ForeColor = Color.White;
            Register_Btn.ImeMode = ImeMode.NoControl;
            Register_Btn.Location = new Point(129, 407);
            Register_Btn.Name = "Register_Btn";
            Register_Btn.Size = new Size(272, 52);
            Register_Btn.TabIndex = 33;
            Register_Btn.Text = "Register";
            Register_Btn.UseVisualStyleBackColor = false;
            Register_Btn.Click += Register_Btn_Click;
            // 
            // ConfirmPass_Lbl
            // 
            ConfirmPass_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmPass_Lbl.AutoSize = true;
            ConfirmPass_Lbl.BackColor = Color.Transparent;
            ConfirmPass_Lbl.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmPass_Lbl.ForeColor = Color.White;
            ConfirmPass_Lbl.ImeMode = ImeMode.NoControl;
            ConfirmPass_Lbl.Location = new Point(115, 275);
            ConfirmPass_Lbl.Name = "ConfirmPass_Lbl";
            ConfirmPass_Lbl.Size = new Size(202, 24);
            ConfirmPass_Lbl.TabIndex = 32;
            ConfirmPass_Lbl.Text = "Confirm Password";
            // 
            // ConfirmPass_Img
            // 
            ConfirmPass_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmPass_Img.BackColor = Color.Transparent;
            ConfirmPass_Img.Image = Properties.Resources.Lock;
            ConfirmPass_Img.ImeMode = ImeMode.NoControl;
            ConfirmPass_Img.Location = new Point(55, 293);
            ConfirmPass_Img.Name = "ConfirmPass_Img";
            ConfirmPass_Img.Size = new Size(50, 50);
            ConfirmPass_Img.SizeMode = PictureBoxSizeMode.Zoom;
            ConfirmPass_Img.TabIndex = 27;
            ConfirmPass_Img.TabStop = false;
            // 
            // ConfirmPass_Btn
            // 
            ConfirmPass_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmPass_Btn.BackColor = Color.Transparent;
            ConfirmPass_Btn.BackgroundImage = Properties.Resources.showPass;
            ConfirmPass_Btn.BackgroundImageLayout = ImageLayout.Zoom;
            ConfirmPass_Btn.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 255);
            ConfirmPass_Btn.FlatAppearance.BorderSize = 0;
            ConfirmPass_Btn.FlatStyle = FlatStyle.Flat;
            ConfirmPass_Btn.ForeColor = Color.Transparent;
            ConfirmPass_Btn.ImeMode = ImeMode.NoControl;
            ConfirmPass_Btn.Location = new Point(407, 305);
            ConfirmPass_Btn.Name = "ConfirmPass_Btn";
            ConfirmPass_Btn.Size = new Size(48, 32);
            ConfirmPass_Btn.TabIndex = 31;
            ConfirmPass_Btn.UseVisualStyleBackColor = false;
            ConfirmPass_Btn.Click += ConfirmPass_Btn_Click;
            // 
            // Req2_Lbl
            // 
            Req2_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Req2_Lbl.AutoSize = true;
            Req2_Lbl.BackColor = Color.Transparent;
            Req2_Lbl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Req2_Lbl.ForeColor = Color.Red;
            Req2_Lbl.ImeMode = ImeMode.NoControl;
            Req2_Lbl.Location = new Point(102, 355);
            Req2_Lbl.Name = "Req2_Lbl";
            Req2_Lbl.Size = new Size(207, 19);
            Req2_Lbl.TabIndex = 30;
            Req2_Lbl.Text = "This field is required";
            Req2_Lbl.Visible = false;
            // 
            // ConfirmPass_Tbx
            // 
            ConfirmPass_Tbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmPass_Tbx.BackColor = Color.DarkOrchid;
            ConfirmPass_Tbx.Font = new Font("Consolas", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmPass_Tbx.ForeColor = Color.White;
            ConfirmPass_Tbx.Location = new Point(115, 302);
            ConfirmPass_Tbx.MaxLength = 15;
            ConfirmPass_Tbx.Name = "ConfirmPass_Tbx";
            ConfirmPass_Tbx.PasswordChar = '•';
            ConfirmPass_Tbx.PlaceholderText = "Confirm Password";
            ConfirmPass_Tbx.Size = new Size(286, 39);
            ConfirmPass_Tbx.TabIndex = 28;
            // 
            // Line2_Pnl
            // 
            Line2_Pnl.BackColor = Color.GhostWhite;
            Line2_Pnl.Location = new Point(55, 349);
            Line2_Pnl.Name = "Line2_Pnl";
            Line2_Pnl.Size = new Size(400, 3);
            Line2_Pnl.TabIndex = 29;
            // 
            // Username_Lbl
            // 
            Username_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Username_Lbl.AutoSize = true;
            Username_Lbl.BackColor = Color.Transparent;
            Username_Lbl.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Username_Lbl.ForeColor = Color.White;
            Username_Lbl.ImeMode = ImeMode.NoControl;
            Username_Lbl.Location = new Point(115, 48);
            Username_Lbl.Name = "Username_Lbl";
            Username_Lbl.Size = new Size(106, 24);
            Username_Lbl.TabIndex = 26;
            Username_Lbl.Text = "Username";
            // 
            // User_Img
            // 
            User_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            User_Img.BackColor = Color.Transparent;
            User_Img.Image = Properties.Resources.User;
            User_Img.ImeMode = ImeMode.NoControl;
            User_Img.Location = new Point(59, 68);
            User_Img.Name = "User_Img";
            User_Img.Size = new Size(50, 50);
            User_Img.SizeMode = PictureBoxSizeMode.Zoom;
            User_Img.TabIndex = 15;
            User_Img.TabStop = false;
            // 
            // Password_Lbl
            // 
            Password_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Password_Lbl.AutoSize = true;
            Password_Lbl.BackColor = Color.Transparent;
            Password_Lbl.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Password_Lbl.ForeColor = Color.White;
            Password_Lbl.ImeMode = ImeMode.NoControl;
            Password_Lbl.Location = new Point(115, 160);
            Password_Lbl.Name = "Password_Lbl";
            Password_Lbl.Size = new Size(106, 24);
            Password_Lbl.TabIndex = 25;
            Password_Lbl.Text = "Password";
            // 
            // Password_Img
            // 
            Password_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Password_Img.BackColor = Color.Transparent;
            Password_Img.Image = Properties.Resources.Lock;
            Password_Img.ImeMode = ImeMode.NoControl;
            Password_Img.Location = new Point(55, 178);
            Password_Img.Name = "Password_Img";
            Password_Img.Size = new Size(50, 50);
            Password_Img.SizeMode = PictureBoxSizeMode.Zoom;
            Password_Img.TabIndex = 16;
            Password_Img.TabStop = false;
            // 
            // ShowPassword_Btn
            // 
            ShowPassword_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ShowPassword_Btn.BackColor = Color.Transparent;
            ShowPassword_Btn.BackgroundImage = Properties.Resources.showPass;
            ShowPassword_Btn.BackgroundImageLayout = ImageLayout.Zoom;
            ShowPassword_Btn.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 255);
            ShowPassword_Btn.FlatAppearance.BorderSize = 0;
            ShowPassword_Btn.FlatStyle = FlatStyle.Flat;
            ShowPassword_Btn.ForeColor = Color.Transparent;
            ShowPassword_Btn.ImeMode = ImeMode.NoControl;
            ShowPassword_Btn.Location = new Point(407, 190);
            ShowPassword_Btn.Name = "ShowPassword_Btn";
            ShowPassword_Btn.Size = new Size(48, 32);
            ShowPassword_Btn.TabIndex = 24;
            ShowPassword_Btn.UseVisualStyleBackColor = false;
            ShowPassword_Btn.Click += ShowPassword_Btn_Click;
            // 
            // UserName_Tbx
            // 
            UserName_Tbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserName_Tbx.BackColor = Color.DarkOrchid;
            UserName_Tbx.Font = new Font("Consolas", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            UserName_Tbx.ForeColor = Color.White;
            UserName_Tbx.Location = new Point(115, 75);
            UserName_Tbx.MaxLength = 20;
            UserName_Tbx.Name = "UserName_Tbx";
            UserName_Tbx.PlaceholderText = "Enter Username";
            UserName_Tbx.Size = new Size(344, 39);
            UserName_Tbx.TabIndex = 17;
            // 
            // Req1_Lbl
            // 
            Req1_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Req1_Lbl.AutoSize = true;
            Req1_Lbl.BackColor = Color.Transparent;
            Req1_Lbl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Req1_Lbl.ForeColor = Color.Red;
            Req1_Lbl.ImeMode = ImeMode.NoControl;
            Req1_Lbl.Location = new Point(102, 240);
            Req1_Lbl.Name = "Req1_Lbl";
            Req1_Lbl.Size = new Size(207, 19);
            Req1_Lbl.TabIndex = 23;
            Req1_Lbl.Text = "This field is required";
            Req1_Lbl.Visible = false;
            // 
            // Password_Tbx
            // 
            Password_Tbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Password_Tbx.BackColor = Color.DarkOrchid;
            Password_Tbx.Font = new Font("Consolas", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Password_Tbx.ForeColor = Color.White;
            Password_Tbx.Location = new Point(115, 187);
            Password_Tbx.MaxLength = 15;
            Password_Tbx.Name = "Password_Tbx";
            Password_Tbx.PasswordChar = '•';
            Password_Tbx.PlaceholderText = "Enter Password";
            Password_Tbx.Size = new Size(286, 39);
            Password_Tbx.TabIndex = 18;
            // 
            // Req_Lbl
            // 
            Req_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Req_Lbl.AutoSize = true;
            Req_Lbl.BackColor = Color.Transparent;
            Req_Lbl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Req_Lbl.ForeColor = Color.Red;
            Req_Lbl.ImeMode = ImeMode.NoControl;
            Req_Lbl.Location = new Point(106, 130);
            Req_Lbl.Name = "Req_Lbl";
            Req_Lbl.Size = new Size(207, 19);
            Req_Lbl.TabIndex = 22;
            Req_Lbl.Text = "This field is required";
            Req_Lbl.Visible = false;
            // 
            // Invalid_Lbl
            // 
            Invalid_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Invalid_Lbl.AutoSize = true;
            Invalid_Lbl.BackColor = Color.Transparent;
            Invalid_Lbl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Invalid_Lbl.ForeColor = Color.Red;
            Invalid_Lbl.ImeMode = ImeMode.NoControl;
            Invalid_Lbl.Location = new Point(57, 13);
            Invalid_Lbl.Name = "Invalid_Lbl";
            Invalid_Lbl.Size = new Size(405, 19);
            Invalid_Lbl.TabIndex = 19;
            Invalid_Lbl.Text = "Username already exists please try a new one";
            Invalid_Lbl.Visible = false;
            // 
            // Line1_Pnl
            // 
            Line1_Pnl.BackColor = Color.GhostWhite;
            Line1_Pnl.Location = new Point(55, 234);
            Line1_Pnl.Name = "Line1_Pnl";
            Line1_Pnl.Size = new Size(400, 3);
            Line1_Pnl.TabIndex = 21;
            // 
            // Line_Pnl
            // 
            Line_Pnl.BackColor = Color.GhostWhite;
            Line_Pnl.Location = new Point(59, 124);
            Line_Pnl.Name = "Line_Pnl";
            Line_Pnl.Size = new Size(400, 3);
            Line_Pnl.TabIndex = 20;
            // 
            // Registration_Page
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            BackgroundImage = Properties.Resources.RegisterPage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1920, 1080);
            Controls.Add(Reg_Pnl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Registration_Page";
            StartPosition = FormStartPosition.CenterScreen;
            Reg_Pnl.ResumeLayout(false);
            RegCredential_Pnl.ResumeLayout(false);
            RegCredential_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ConfirmPass_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)User_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)Password_Img).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Reg_Pnl;
        private Panel RegCredential_Pnl;
        private Label ConfirmPass_Lbl;
        private PictureBox ConfirmPass_Img;
        private Button ConfirmPass_Btn;
        private Label Req2_Lbl;
        private TextBox ConfirmPass_Tbx;
        private Panel Line2_Pnl;
        private Label Username_Lbl;
        private PictureBox User_Img;
        private Label Password_Lbl;
        private PictureBox Password_Img;
        private Button ShowPassword_Btn;
        private TextBox UserName_Tbx;
        private Label Req1_Lbl;
        private TextBox Password_Tbx;
        private Label Req_Lbl;
        private Label Invalid_Lbl;
        private Panel Line1_Pnl;
        private Panel Line_Pnl;
        private Button BackToLogin_Btn;
        private Button Register_Btn;
        private Label SuccessfulRegistration_Lbl;
        private Button AddAdmin_Btn;
    }
}