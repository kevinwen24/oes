namespace OESUI
{
    partial class LoginForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.picErrorPassword = new System.Windows.Forms.PictureBox();
            this.picErrorUserName = new System.Windows.Forms.PictureBox();
            this.pnlTipMsg = new System.Windows.Forms.Panel();
            this.lblTipMsg = new System.Windows.Forms.Label();
            this.lblForgetPassword = new System.Windows.Forms.Label();
            this.RememberMe = new System.Windows.Forms.CheckBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.OesTitle = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorUserName)).BeginInit();
            this.pnlTipMsg.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OesTitle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogin.Location = new System.Drawing.Point(203, 310);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(293, 31);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.DoBtnLoginOnClick);
            this.btnLogin.Enter += new System.EventHandler(this.DoBtnLoginOnEnter);
            // 
            // picErrorPassword
            // 
            this.picErrorPassword.BackgroundImage = global::OESUI.Properties.Resources.ICN_Client_Login_Wrong_20X20;
            this.picErrorPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picErrorPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picErrorPassword.Location = new System.Drawing.Point(515, 260);
            this.picErrorPassword.Name = "picErrorPassword";
            this.picErrorPassword.Size = new System.Drawing.Size(21, 22);
            this.picErrorPassword.TabIndex = 9;
            this.picErrorPassword.TabStop = false;
            this.picErrorPassword.Visible = false;
            // 
            // picErrorUserName
            // 
            this.picErrorUserName.BackgroundImage = global::OESUI.Properties.Resources.ICN_Client_Login_Wrong_20X20;
            this.picErrorUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picErrorUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picErrorUserName.Location = new System.Drawing.Point(515, 210);
            this.picErrorUserName.Name = "picErrorUserName";
            this.picErrorUserName.Size = new System.Drawing.Size(21, 19);
            this.picErrorUserName.TabIndex = 8;
            this.picErrorUserName.TabStop = false;
            this.picErrorUserName.Visible = false;
            // 
            // pnlTipMsg
            // 
            this.pnlTipMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(203)))), ((int)(((byte)(155)))));
            this.pnlTipMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipMsg.Controls.Add(this.lblTipMsg);
            this.pnlTipMsg.Location = new System.Drawing.Point(200, 170);
            this.pnlTipMsg.Name = "pnlTipMsg";
            this.pnlTipMsg.Size = new System.Drawing.Size(300, 20);
            this.pnlTipMsg.TabIndex = 7;
            this.pnlTipMsg.Visible = false;
            // 
            // lblTipMsg
            // 
            this.lblTipMsg.AutoSize = true;
            this.lblTipMsg.ForeColor = System.Drawing.Color.Red;
            this.lblTipMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipMsg.Location = new System.Drawing.Point(3, 1);
            this.lblTipMsg.Name = "lblTipMsg";
            this.lblTipMsg.Size = new System.Drawing.Size(0, 15);
            this.lblTipMsg.TabIndex = 0;
            this.lblTipMsg.Visible = false;
            // 
            // lblForgetPassword
            // 
            this.lblForgetPassword.AutoSize = true;
            this.lblForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgetPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblForgetPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblForgetPassword.Location = new System.Drawing.Point(399, 365);
            this.lblForgetPassword.Name = "lblForgetPassword";
            this.lblForgetPassword.Size = new System.Drawing.Size(107, 15);
            this.lblForgetPassword.TabIndex = 6;
            this.lblForgetPassword.Text = "Forget password?";
            // 
            // RememberMe
            // 
            this.RememberMe.AutoSize = true;
            this.RememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RememberMe.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RememberMe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RememberMe.Location = new System.Drawing.Point(200, 365);
            this.RememberMe.Name = "RememberMe";
            this.RememberMe.Size = new System.Drawing.Size(110, 19);
            this.RememberMe.TabIndex = 5;
            this.RememberMe.Text = "Remember me";
            this.RememberMe.UseVisualStyleBackColor = true;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.picLogo);
            this.pnlTitle.Controls.Add(this.picClose);
            this.pnlTitle.Location = new System.Drawing.Point(0, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(700, 30);
            this.pnlTitle.TabIndex = 4;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::OESUI.Properties.Resources.myPic_title;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(128, 27);
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // picClose
            // 
            this.picClose.BackgroundImage = global::OESUI.Properties.Resources.myPic_close_win;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picClose.Location = new System.Drawing.Point(655, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(44, 27);
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.DoPicCloseOnClick);
            // 
            // OesTitle
            // 
            this.OesTitle.BackgroundImage = global::OESUI.Properties.Resources.LOGO_Client_Login_40X300;
            this.OesTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OesTitle.Location = new System.Drawing.Point(200, 110);
            this.OesTitle.Name = "OesTitle";
            this.OesTitle.Size = new System.Drawing.Size(300, 39);
            this.OesTitle.TabIndex = 3;
            this.OesTitle.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblPassword);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.picPassword);
            this.panel2.Location = new System.Drawing.Point(200, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 35);
            this.panel2.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.lblPassword.Location = new System.Drawing.Point(39, 10);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 17);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.DoLblPasswordOnClick);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.CausesValidation = false;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtPassword.Location = new System.Drawing.Point(39, 10);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(261, 17);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Enter += new System.EventHandler(this.DoTxtPasswordOnEnter);
            this.txtPassword.Leave += new System.EventHandler(this.DoTxtPasswordOnLeave);
            // 
            // picPassword
            // 
            this.picPassword.BackgroundImage = global::OESUI.Properties.Resources.ICN_Password_20x15_png;
            this.picPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picPassword.Location = new System.Drawing.Point(9, 4);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(24, 28);
            this.picPassword.TabIndex = 0;
            this.picPassword.TabStop = false;
            this.picPassword.Click += new System.EventHandler(this.DoPicPasswordOnClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.picUser);
            this.panel1.Location = new System.Drawing.Point(200, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 35);
            this.panel1.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.lblUserName.Location = new System.Drawing.Point(39, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 18);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username";
            this.lblUserName.Click += new System.EventHandler(this.DoLblUserNameOnClick);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.CausesValidation = false;
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.txtUserName.Location = new System.Drawing.Point(39, 10);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(258, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Enter += new System.EventHandler(this.DoTxtUserNameOnEnter);
            this.txtUserName.Leave += new System.EventHandler(this.DoTxtUserNameOnLeave);
            // 
            // picUser
            // 
            this.picUser.BackgroundImage = global::OESUI.Properties.Resources.ICN_Usename_20x20_png;
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picUser.Location = new System.Drawing.Point(9, 4);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(24, 28);
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            this.picUser.Click += new System.EventHandler(this.DoPicUserOnClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(700, 500);
            this.shapeContainer1.TabIndex = 10;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.rectangleShape1.BorderWidth = 5;
            this.rectangleShape1.CornerRadius = 3;
            this.rectangleShape1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.rectangleShape1.Location = new System.Drawing.Point(202, 310);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(295, 30);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.picErrorPassword);
            this.Controls.Add(this.picErrorUserName);
            this.Controls.Add(this.pnlTipMsg);
            this.Controls.Add(this.lblForgetPassword);
            this.Controls.Add(this.RememberMe);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.OesTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.shapeContainer1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.picErrorPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorUserName)).EndInit();
            this.pnlTipMsg.ResumeLayout(false);
            this.pnlTipMsg.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OesTitle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox OesTitle;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.CheckBox RememberMe;
        private System.Windows.Forms.Label lblForgetPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlTipMsg;
        private System.Windows.Forms.Label lblTipMsg;
        private System.Windows.Forms.PictureBox picErrorUserName;
        private System.Windows.Forms.PictureBox picErrorPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
    }
}