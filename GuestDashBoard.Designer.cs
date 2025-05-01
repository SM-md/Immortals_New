namespace Immortals_New
{
    partial class GuestDashBoard
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
            MainDashBoard_Pnl = new Panel();
            SignOut_Img = new PictureBox();
            TopUp_Img = new PictureBox();
            PlayNow_Img = new PictureBox();
            SignOut_Btn = new Button();
            TopUp_Btn = new Button();
            Time_Img = new PictureBox();
            Time_Lbl = new Label();
            PlayNow_Btn = new Button();
            Line_Pnl = new Panel();
            IDGuest_Lbl = new Label();
            GuestUser_Lbl = new Label();
            GuestLogo_Img = new PictureBox();
            Logo_Img = new PictureBox();
            TopUp_Pnl = new Panel();
            TopUpSuccess_Lbl = new Label();
            ErrorAmount_Lbl = new Label();
            Amount_Tbx = new TextBox();
            EnterTopUp_Btn = new Button();
            Amount_Lbl = new Label();
            TopUp_Lbl = new Label();
            UserReport_Pnl = new Panel();
            Report_Tbx = new TextBox();
            EnterReport_Btn = new Button();
            UserReport_Lbl = new Label();
            Report_Btn = new Button();
            MainDashBoard_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SignOut_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TopUp_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayNow_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Time_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GuestLogo_Img).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Logo_Img).BeginInit();
            TopUp_Pnl.SuspendLayout();
            UserReport_Pnl.SuspendLayout();
            SuspendLayout();
            // 
            // MainDashBoard_Pnl
            // 
            MainDashBoard_Pnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MainDashBoard_Pnl.BackColor = Color.DarkOrchid;
            MainDashBoard_Pnl.Controls.Add(SignOut_Img);
            MainDashBoard_Pnl.Controls.Add(TopUp_Img);
            MainDashBoard_Pnl.Controls.Add(PlayNow_Img);
            MainDashBoard_Pnl.Controls.Add(SignOut_Btn);
            MainDashBoard_Pnl.Controls.Add(TopUp_Btn);
            MainDashBoard_Pnl.Controls.Add(Time_Img);
            MainDashBoard_Pnl.Controls.Add(Time_Lbl);
            MainDashBoard_Pnl.Controls.Add(PlayNow_Btn);
            MainDashBoard_Pnl.Controls.Add(Line_Pnl);
            MainDashBoard_Pnl.Controls.Add(IDGuest_Lbl);
            MainDashBoard_Pnl.Controls.Add(GuestUser_Lbl);
            MainDashBoard_Pnl.Controls.Add(GuestLogo_Img);
            MainDashBoard_Pnl.Controls.Add(Logo_Img);
            MainDashBoard_Pnl.Location = new Point(0, 2);
            MainDashBoard_Pnl.Name = "MainDashBoard_Pnl";
            MainDashBoard_Pnl.Size = new Size(482, 1078);
            MainDashBoard_Pnl.TabIndex = 0;
            // 
            // SignOut_Img
            // 
            SignOut_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SignOut_Img.BackColor = Color.Transparent;
            SignOut_Img.Image = Properties.Resources.logout;
            SignOut_Img.Location = new Point(28, 797);
            SignOut_Img.Name = "SignOut_Img";
            SignOut_Img.Size = new Size(100, 89);
            SignOut_Img.SizeMode = PictureBoxSizeMode.Zoom;
            SignOut_Img.TabIndex = 15;
            SignOut_Img.TabStop = false;
            // 
            // TopUp_Img
            // 
            TopUp_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TopUp_Img.BackColor = Color.Transparent;
            TopUp_Img.Image = Properties.Resources.Topup;
            TopUp_Img.Location = new Point(28, 681);
            TopUp_Img.Name = "TopUp_Img";
            TopUp_Img.Size = new Size(100, 89);
            TopUp_Img.SizeMode = PictureBoxSizeMode.Zoom;
            TopUp_Img.TabIndex = 14;
            TopUp_Img.TabStop = false;
            // 
            // PlayNow_Img
            // 
            PlayNow_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlayNow_Img.BackColor = Color.Transparent;
            PlayNow_Img.Image = Properties.Resources.PlayNow1;
            PlayNow_Img.Location = new Point(28, 564);
            PlayNow_Img.Name = "PlayNow_Img";
            PlayNow_Img.Size = new Size(100, 89);
            PlayNow_Img.SizeMode = PictureBoxSizeMode.Zoom;
            PlayNow_Img.TabIndex = 13;
            PlayNow_Img.TabStop = false;
            // 
            // SignOut_Btn
            // 
            SignOut_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SignOut_Btn.BackColor = Color.Transparent;
            SignOut_Btn.FlatAppearance.BorderSize = 0;
            SignOut_Btn.FlatStyle = FlatStyle.Flat;
            SignOut_Btn.Font = new Font("Consolas", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            SignOut_Btn.ForeColor = Color.White;
            SignOut_Btn.Location = new Point(28, 797);
            SignOut_Btn.Name = "SignOut_Btn";
            SignOut_Btn.Size = new Size(420, 89);
            SignOut_Btn.TabIndex = 12;
            SignOut_Btn.Text = "Sign Out";
            SignOut_Btn.UseVisualStyleBackColor = false;
            SignOut_Btn.Click += SignOut_Btn_Click;
            // 
            // TopUp_Btn
            // 
            TopUp_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TopUp_Btn.BackColor = Color.Transparent;
            TopUp_Btn.FlatAppearance.BorderSize = 0;
            TopUp_Btn.FlatStyle = FlatStyle.Flat;
            TopUp_Btn.Font = new Font("Consolas", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            TopUp_Btn.ForeColor = Color.White;
            TopUp_Btn.Location = new Point(28, 681);
            TopUp_Btn.Name = "TopUp_Btn";
            TopUp_Btn.Size = new Size(420, 89);
            TopUp_Btn.TabIndex = 11;
            TopUp_Btn.Text = "Top-Up";
            TopUp_Btn.UseVisualStyleBackColor = false;
            TopUp_Btn.Click += TopUp_Btn_Click;
            // 
            // Time_Img
            // 
            Time_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Time_Img.BackColor = Color.Transparent;
            Time_Img.Image = Properties.Resources.Clock;
            Time_Img.Location = new Point(28, 358);
            Time_Img.Name = "Time_Img";
            Time_Img.Size = new Size(100, 100);
            Time_Img.SizeMode = PictureBoxSizeMode.Zoom;
            Time_Img.TabIndex = 10;
            Time_Img.TabStop = false;
            // 
            // Time_Lbl
            // 
            Time_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Time_Lbl.AutoSize = true;
            Time_Lbl.BackColor = Color.Transparent;
            Time_Lbl.Font = new Font("Consolas", 36F, FontStyle.Regular, GraphicsUnit.Point);
            Time_Lbl.ForeColor = Color.White;
            Time_Lbl.Location = new Point(157, 384);
            Time_Lbl.Name = "Time_Lbl";
            Time_Lbl.Size = new Size(232, 56);
            Time_Lbl.TabIndex = 8;
            Time_Lbl.Text = "00:00:00";
            // 
            // PlayNow_Btn
            // 
            PlayNow_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlayNow_Btn.BackColor = Color.Transparent;
            PlayNow_Btn.FlatAppearance.BorderSize = 0;
            PlayNow_Btn.FlatStyle = FlatStyle.Flat;
            PlayNow_Btn.Font = new Font("Consolas", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            PlayNow_Btn.ForeColor = Color.White;
            PlayNow_Btn.ImageAlign = ContentAlignment.MiddleLeft;
            PlayNow_Btn.Location = new Point(28, 564);
            PlayNow_Btn.Name = "PlayNow_Btn";
            PlayNow_Btn.Size = new Size(420, 89);
            PlayNow_Btn.TabIndex = 5;
            PlayNow_Btn.Text = "Play Now";
            PlayNow_Btn.UseVisualStyleBackColor = false;
            PlayNow_Btn.Click += PlayNow_Btn_Click;
            // 
            // Line_Pnl
            // 
            Line_Pnl.BackColor = Color.Cyan;
            Line_Pnl.Location = new Point(28, 338);
            Line_Pnl.Name = "Line_Pnl";
            Line_Pnl.Size = new Size(420, 4);
            Line_Pnl.TabIndex = 4;
            // 
            // IDGuest_Lbl
            // 
            IDGuest_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            IDGuest_Lbl.AutoSize = true;
            IDGuest_Lbl.BackColor = Color.Transparent;
            IDGuest_Lbl.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point);
            IDGuest_Lbl.ForeColor = Color.White;
            IDGuest_Lbl.Location = new Point(286, 298);
            IDGuest_Lbl.Name = "IDGuest_Lbl";
            IDGuest_Lbl.Size = new Size(53, 37);
            IDGuest_Lbl.TabIndex = 3;
            IDGuest_Lbl.Text = "ID";
            // 
            // GuestUser_Lbl
            // 
            GuestUser_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GuestUser_Lbl.AutoSize = true;
            GuestUser_Lbl.BackColor = Color.Transparent;
            GuestUser_Lbl.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point);
            GuestUser_Lbl.ForeColor = Color.White;
            GuestUser_Lbl.Location = new Point(83, 298);
            GuestUser_Lbl.Name = "GuestUser_Lbl";
            GuestUser_Lbl.Size = new Size(197, 37);
            GuestUser_Lbl.TabIndex = 2;
            GuestUser_Lbl.Text = "Guest User";
            // 
            // GuestLogo_Img
            // 
            GuestLogo_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GuestLogo_Img.BackColor = Color.Transparent;
            GuestLogo_Img.Image = Properties.Resources.User1;
            GuestLogo_Img.Location = new Point(157, 133);
            GuestLogo_Img.Name = "GuestLogo_Img";
            GuestLogo_Img.Size = new Size(150, 150);
            GuestLogo_Img.SizeMode = PictureBoxSizeMode.Zoom;
            GuestLogo_Img.TabIndex = 1;
            GuestLogo_Img.TabStop = false;
            // 
            // Logo_Img
            // 
            Logo_Img.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Logo_Img.BackColor = Color.Transparent;
            Logo_Img.Image = Properties.Resources.LogoImmortals;
            Logo_Img.Location = new Point(28, 30);
            Logo_Img.Name = "Logo_Img";
            Logo_Img.Size = new Size(420, 90);
            Logo_Img.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo_Img.TabIndex = 0;
            Logo_Img.TabStop = false;
            // 
            // TopUp_Pnl
            // 
            TopUp_Pnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TopUp_Pnl.BackColor = Color.DarkOrchid;
            TopUp_Pnl.Controls.Add(TopUpSuccess_Lbl);
            TopUp_Pnl.Controls.Add(ErrorAmount_Lbl);
            TopUp_Pnl.Controls.Add(Amount_Tbx);
            TopUp_Pnl.Controls.Add(EnterTopUp_Btn);
            TopUp_Pnl.Controls.Add(Amount_Lbl);
            TopUp_Pnl.Controls.Add(TopUp_Lbl);
            TopUp_Pnl.Location = new Point(520, 32);
            TopUp_Pnl.Name = "TopUp_Pnl";
            TopUp_Pnl.Size = new Size(382, 332);
            TopUp_Pnl.TabIndex = 1;
            TopUp_Pnl.Visible = false;
            // 
            // TopUpSuccess_Lbl
            // 
            TopUpSuccess_Lbl.AutoSize = true;
            TopUpSuccess_Lbl.BackColor = Color.Transparent;
            TopUpSuccess_Lbl.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TopUpSuccess_Lbl.ForeColor = Color.Lime;
            TopUpSuccess_Lbl.Location = new Point(185, 192);
            TopUpSuccess_Lbl.Name = "TopUpSuccess_Lbl";
            TopUpSuccess_Lbl.Size = new Size(119, 15);
            TopUpSuccess_Lbl.TabIndex = 5;
            TopUpSuccess_Lbl.Text = "TopUp Successful";
            TopUpSuccess_Lbl.Visible = false;
            // 
            // ErrorAmount_Lbl
            // 
            ErrorAmount_Lbl.AutoSize = true;
            ErrorAmount_Lbl.BackColor = Color.Transparent;
            ErrorAmount_Lbl.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ErrorAmount_Lbl.ForeColor = Color.Red;
            ErrorAmount_Lbl.Location = new Point(32, 192);
            ErrorAmount_Lbl.Name = "ErrorAmount_Lbl";
            ErrorAmount_Lbl.Size = new Size(105, 15);
            ErrorAmount_Lbl.TabIndex = 4;
            ErrorAmount_Lbl.Text = "Invalid Amount";
            ErrorAmount_Lbl.Visible = false;
            // 
            // Amount_Tbx
            // 
            Amount_Tbx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Amount_Tbx.Font = new Font("Consolas", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Amount_Tbx.ForeColor = Color.Black;
            Amount_Tbx.Location = new Point(32, 150);
            Amount_Tbx.MaxLength = 10;
            Amount_Tbx.Name = "Amount_Tbx";
            Amount_Tbx.Size = new Size(272, 39);
            Amount_Tbx.TabIndex = 3;
            // 
            // EnterTopUp_Btn
            // 
            EnterTopUp_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EnterTopUp_Btn.BackColor = Color.Transparent;
            EnterTopUp_Btn.FlatAppearance.BorderSize = 2;
            EnterTopUp_Btn.FlatStyle = FlatStyle.Flat;
            EnterTopUp_Btn.Font = new Font("Consolas", 24F, FontStyle.Regular, GraphicsUnit.Point);
            EnterTopUp_Btn.ForeColor = Color.White;
            EnterTopUp_Btn.Location = new Point(32, 226);
            EnterTopUp_Btn.Name = "EnterTopUp_Btn";
            EnterTopUp_Btn.Size = new Size(323, 61);
            EnterTopUp_Btn.TabIndex = 2;
            EnterTopUp_Btn.Text = "Top-Up";
            EnterTopUp_Btn.UseVisualStyleBackColor = false;
            EnterTopUp_Btn.Click += EnterTopUp_Btn_Click;
            // 
            // Amount_Lbl
            // 
            Amount_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Amount_Lbl.AutoSize = true;
            Amount_Lbl.BackColor = Color.Transparent;
            Amount_Lbl.Font = new Font("Consolas", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            Amount_Lbl.ForeColor = Color.White;
            Amount_Lbl.Location = new Point(24, 113);
            Amount_Lbl.Name = "Amount_Lbl";
            Amount_Lbl.Size = new Size(223, 34);
            Amount_Lbl.TabIndex = 1;
            Amount_Lbl.Text = "Enter Amount:";
            // 
            // TopUp_Lbl
            // 
            TopUp_Lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TopUp_Lbl.AutoSize = true;
            TopUp_Lbl.BackColor = Color.Transparent;
            TopUp_Lbl.Font = new Font("Consolas", 36F, FontStyle.Regular, GraphicsUnit.Point);
            TopUp_Lbl.ForeColor = Color.White;
            TopUp_Lbl.Location = new Point(24, 20);
            TopUp_Lbl.Name = "TopUp_Lbl";
            TopUp_Lbl.Size = new Size(180, 56);
            TopUp_Lbl.TabIndex = 0;
            TopUp_Lbl.Text = "Top-Up";
            // 
            // UserReport_Pnl
            // 
            UserReport_Pnl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserReport_Pnl.BackColor = Color.Violet;
            UserReport_Pnl.Controls.Add(Report_Tbx);
            UserReport_Pnl.Controls.Add(EnterReport_Btn);
            UserReport_Pnl.Controls.Add(UserReport_Lbl);
            UserReport_Pnl.Location = new Point(930, 34);
            UserReport_Pnl.Name = "UserReport_Pnl";
            UserReport_Pnl.Size = new Size(952, 698);
            UserReport_Pnl.TabIndex = 2;
            UserReport_Pnl.Visible = false;
            // 
            // Report_Tbx
            // 
            Report_Tbx.BackColor = Color.MediumPurple;
            Report_Tbx.BorderStyle = BorderStyle.None;
            Report_Tbx.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Report_Tbx.ForeColor = Color.White;
            Report_Tbx.Location = new Point(51, 101);
            Report_Tbx.Multiline = true;
            Report_Tbx.Name = "Report_Tbx";
            Report_Tbx.Size = new Size(850, 465);
            Report_Tbx.TabIndex = 2;
            // 
            // EnterReport_Btn
            // 
            EnterReport_Btn.BackColor = Color.Brown;
            EnterReport_Btn.FlatAppearance.BorderSize = 0;
            EnterReport_Btn.FlatStyle = FlatStyle.Flat;
            EnterReport_Btn.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            EnterReport_Btn.ForeColor = Color.White;
            EnterReport_Btn.Location = new Point(701, 600);
            EnterReport_Btn.Name = "EnterReport_Btn";
            EnterReport_Btn.Size = new Size(200, 50);
            EnterReport_Btn.TabIndex = 1;
            EnterReport_Btn.Text = "Report";
            EnterReport_Btn.UseVisualStyleBackColor = false;
            EnterReport_Btn.Click += EnterReport_Btn_Click;
            // 
            // UserReport_Lbl
            // 
            UserReport_Lbl.AutoSize = true;
            UserReport_Lbl.BackColor = Color.Transparent;
            UserReport_Lbl.Font = new Font("Consolas", 36F, FontStyle.Regular, GraphicsUnit.Point);
            UserReport_Lbl.ForeColor = Color.White;
            UserReport_Lbl.Location = new Point(38, 34);
            UserReport_Lbl.Name = "UserReport_Lbl";
            UserReport_Lbl.Size = new Size(440, 56);
            UserReport_Lbl.TabIndex = 0;
            UserReport_Lbl.Text = "Report A Problem";
            // 
            // Report_Btn
            // 
            Report_Btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Report_Btn.BackColor = Color.Transparent;
            Report_Btn.FlatAppearance.BorderSize = 0;
            Report_Btn.FlatStyle = FlatStyle.Flat;
            Report_Btn.Image = Properties.Resources.error;
            Report_Btn.Location = new Point(1828, 988);
            Report_Btn.Name = "Report_Btn";
            Report_Btn.Size = new Size(80, 80);
            Report_Btn.TabIndex = 3;
            Report_Btn.UseVisualStyleBackColor = false;
            Report_Btn.Click += Report_Btn_Click;
            // 
            // GuestDashBoard
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1920, 1080);
            Controls.Add(Report_Btn);
            Controls.Add(UserReport_Pnl);
            Controls.Add(TopUp_Pnl);
            Controls.Add(MainDashBoard_Pnl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "GuestDashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GuestDashBoard";
            FormClosing += GuestDashBoard_FormClosing;
            Shown += GuestDashBoard_Shown;
            MainDashBoard_Pnl.ResumeLayout(false);
            MainDashBoard_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SignOut_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)TopUp_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayNow_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)Time_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)GuestLogo_Img).EndInit();
            ((System.ComponentModel.ISupportInitialize)Logo_Img).EndInit();
            TopUp_Pnl.ResumeLayout(false);
            TopUp_Pnl.PerformLayout();
            UserReport_Pnl.ResumeLayout(false);
            UserReport_Pnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainDashBoard_Pnl;
        private PictureBox Logo_Img;
        private Label GuestUser_Lbl;
        private PictureBox GuestLogo_Img;
        private Label IDGuest_Lbl;
        private Panel Line_Pnl;
        private PictureBox Time_Img;
        private Label Time_Lbl;
        private Button PlayNow_Btn;
        private Button SignOut_Btn;
        private Button TopUp_Btn;
        private PictureBox PlayNow_Img;
        private PictureBox SignOut_Img;
        private PictureBox TopUp_Img;
        private Panel TopUp_Pnl;
        private Button EnterTopUp_Btn;
        private Label Amount_Lbl;
        private Label TopUp_Lbl;
        private TextBox Amount_Tbx;
        private Panel UserReport_Pnl;
        private Button Report_Btn;
        private Label UserReport_Lbl;
        private TextBox Report_Tbx;
        private Button EnterReport_Btn;
        private Label ErrorAmount_Lbl;
        private Label TopUpSuccess_Lbl;
    }
}