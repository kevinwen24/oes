namespace OESUI
{
    partial class BaseWindowForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlBodyContainer = new System.Windows.Forms.Panel();
            this.pnlAlertWindow = new System.Windows.Forms.Panel();
            this.lblCloseAlertWinIKnow = new System.Windows.Forms.Label();
            this.picCloseAlertWin = new System.Windows.Forms.PictureBox();
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.pnlNaviation = new System.Windows.Forms.Panel();
            this.lblFlashMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblNavName = new System.Windows.Forms.Label();
            this.lblNavUserPic = new System.Windows.Forms.PictureBox();
            this.lblNavMyExam = new System.Windows.Forms.Label();
            this.lblNavHome = new System.Windows.Forms.Label();
            this.lblNameAndPhonebg = new System.Windows.Forms.Label();
            this.pnlFormTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picCloseWin = new System.Windows.Forms.PictureBox();
            this.picMaxWin = new System.Windows.Forms.PictureBox();
            this.picMiniWin = new System.Windows.Forms.PictureBox();
            this.lblonlineExamTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.tmrShowFlashMsg = new System.Windows.Forms.Timer(this.components);
            this.pnlBodyContainer.SuspendLayout();
            this.pnlAlertWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseAlertWin)).BeginInit();
            this.pnlNaviation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavUserPic)).BeginInit();
            this.pnlFormTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBodyContainer
            // 
            this.pnlBodyContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBodyContainer.AutoSize = true;
            this.pnlBodyContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.pnlBodyContainer.Controls.Add(this.pnlAlertWindow);
            this.pnlBodyContainer.Controls.Add(this.pnlNaviation);
            this.pnlBodyContainer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlBodyContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.pnlBodyContainer.Location = new System.Drawing.Point(0, 28);
            this.pnlBodyContainer.Name = "pnlBodyContainer";
            this.pnlBodyContainer.Size = new System.Drawing.Size(1024, 740);
            this.pnlBodyContainer.TabIndex = 3;
            // 
            // pnlAlertWindow
            // 
            this.pnlAlertWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAlertWindow.BackColor = System.Drawing.Color.White;
            this.pnlAlertWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertWindow.Controls.Add(this.lblCloseAlertWinIKnow);
            this.pnlAlertWindow.Controls.Add(this.picCloseAlertWin);
            this.pnlAlertWindow.Controls.Add(this.lblAlertMessage);
            this.pnlAlertWindow.Location = new System.Drawing.Point(316, 270);
            this.pnlAlertWindow.Name = "pnlAlertWindow";
            this.pnlAlertWindow.Size = new System.Drawing.Size(434, 174);
            this.pnlAlertWindow.TabIndex = 1;
            this.pnlAlertWindow.Visible = false;
            // 
            // lblCloseAlertWinIKnow
            // 
            this.lblCloseAlertWinIKnow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblCloseAlertWinIKnow.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCloseAlertWinIKnow.ForeColor = System.Drawing.Color.White;
            this.lblCloseAlertWinIKnow.Location = new System.Drawing.Point(112, 117);
            this.lblCloseAlertWinIKnow.Name = "lblCloseAlertWinIKnow";
            this.lblCloseAlertWinIKnow.Size = new System.Drawing.Size(198, 35);
            this.lblCloseAlertWinIKnow.TabIndex = 15;
            this.lblCloseAlertWinIKnow.Text = "I Know!";
            this.lblCloseAlertWinIKnow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCloseAlertWinIKnow.Click += new System.EventHandler(this.DoLblCloseAlertWinIKnowOnClick);
            // 
            // picCloseAlertWin
            // 
            this.picCloseAlertWin.BackgroundImage = global::OESUI.Properties.Resources.BTN_Close_16x16_png;
            this.picCloseAlertWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCloseAlertWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCloseAlertWin.Location = new System.Drawing.Point(400, 7);
            this.picCloseAlertWin.Name = "picCloseAlertWin";
            this.picCloseAlertWin.Size = new System.Drawing.Size(23, 23);
            this.picCloseAlertWin.TabIndex = 14;
            this.picCloseAlertWin.TabStop = false;
            this.picCloseAlertWin.Click += new System.EventHandler(this.DoPicCloseAlertWinOnClick);
            // 
            // lblAlertMessage
            // 
            this.lblAlertMessage.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAlertMessage.Location = new System.Drawing.Point(51, 33);
            this.lblAlertMessage.Name = "lblAlertMessage";
            this.lblAlertMessage.Size = new System.Drawing.Size(328, 68);
            this.lblAlertMessage.TabIndex = 12;
            this.lblAlertMessage.Text = "label1";
            this.lblAlertMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNaviation
            // 
            this.pnlNaviation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNaviation.BackColor = System.Drawing.Color.White;
            this.pnlNaviation.Controls.Add(this.lblFlashMsg);
            this.pnlNaviation.Controls.Add(this.panel1);
            this.pnlNaviation.Controls.Add(this.lblLanguage);
            this.pnlNaviation.Controls.Add(this.lblLogout);
            this.pnlNaviation.Controls.Add(this.lblNavName);
            this.pnlNaviation.Controls.Add(this.lblNavUserPic);
            this.pnlNaviation.Controls.Add(this.lblNavMyExam);
            this.pnlNaviation.Controls.Add(this.lblNavHome);
            this.pnlNaviation.Controls.Add(this.lblNameAndPhonebg);
            this.pnlNaviation.Location = new System.Drawing.Point(0, 1);
            this.pnlNaviation.Name = "pnlNaviation";
            this.pnlNaviation.Size = new System.Drawing.Size(1024, 38);
            this.pnlNaviation.TabIndex = 0;
            // 
            // lblFlashMsg
            // 
            this.lblFlashMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblFlashMsg.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFlashMsg.ForeColor = System.Drawing.Color.White;
            this.lblFlashMsg.Location = new System.Drawing.Point(383, 2);
            this.lblFlashMsg.Name = "lblFlashMsg";
            this.lblFlashMsg.Size = new System.Drawing.Size(285, 35);
            this.lblFlashMsg.TabIndex = 10;
            this.lblFlashMsg.Text = "label2";
            this.lblFlashMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFlashMsg.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(594, -65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 63);
            this.panel1.TabIndex = 6;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLanguage.Location = new System.Drawing.Point(899, 14);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(36, 16);
            this.lblLanguage.TabIndex = 5;
            this.lblLanguage.Text = "中文";
            // 
            // lblLogout
            // 
            this.lblLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogout.AutoSize = true;
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLogout.Location = new System.Drawing.Point(952, 14);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(47, 16);
            this.lblLogout.TabIndex = 4;
            this.lblLogout.Text = "logout";
            this.lblLogout.Click += new System.EventHandler(this.DoLblLogoutOnClick);
            // 
            // lblNavName
            // 
            this.lblNavName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNavName.AutoSize = true;
            this.lblNavName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNavName.Location = new System.Drawing.Point(839, 14);
            this.lblNavName.Name = "lblNavName";
            this.lblNavName.Size = new System.Drawing.Size(43, 16);
            this.lblNavName.TabIndex = 3;
            this.lblNavName.Text = "name";
            // 
            // lblNavUserPic
            // 
            this.lblNavUserPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNavUserPic.Image = global::OESUI.Properties.Resources.ICN_Client_PersonalInformation_20x202;
            this.lblNavUserPic.Location = new System.Drawing.Point(793, 11);
            this.lblNavUserPic.Name = "lblNavUserPic";
            this.lblNavUserPic.Size = new System.Drawing.Size(26, 26);
            this.lblNavUserPic.TabIndex = 2;
            this.lblNavUserPic.TabStop = false;
            // 
            // lblNavMyExam
            // 
            this.lblNavMyExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.lblNavMyExam.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNavMyExam.Location = new System.Drawing.Point(146, -1);
            this.lblNavMyExam.Name = "lblNavMyExam";
            this.lblNavMyExam.Size = new System.Drawing.Size(100, 40);
            this.lblNavMyExam.TabIndex = 1;
            this.lblNavMyExam.Text = "My Exam";
            this.lblNavMyExam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNavHome
            // 
            this.lblNavHome.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNavHome.Location = new System.Drawing.Point(43, -1);
            this.lblNavHome.Name = "lblNavHome";
            this.lblNavHome.Size = new System.Drawing.Size(100, 40);
            this.lblNavHome.TabIndex = 0;
            this.lblNavHome.Text = "Home";
            this.lblNavHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameAndPhonebg
            // 
            this.lblNameAndPhonebg.BackColor = System.Drawing.Color.White;
            this.lblNameAndPhonebg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNameAndPhonebg.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNameAndPhonebg.Location = new System.Drawing.Point(778, -1);
            this.lblNameAndPhonebg.Name = "lblNameAndPhonebg";
            this.lblNameAndPhonebg.Size = new System.Drawing.Size(112, 39);
            this.lblNameAndPhonebg.TabIndex = 9;
            this.lblNameAndPhonebg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameAndPhonebg.Click += new System.EventHandler(this.DoLblNameAndPhotobgOnClick);
            // 
            // pnlFormTitle
            // 
            this.pnlFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.pnlFormTitle.Controls.Add(this.panel2);
            this.pnlFormTitle.Controls.Add(this.picCloseWin);
            this.pnlFormTitle.Controls.Add(this.picMaxWin);
            this.pnlFormTitle.Controls.Add(this.picMiniWin);
            this.pnlFormTitle.Controls.Add(this.lblonlineExamTitle);
            this.pnlFormTitle.Controls.Add(this.picLogo);
            this.pnlFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlFormTitle.Name = "pnlFormTitle";
            this.pnlFormTitle.Size = new System.Drawing.Size(1024, 28);
            this.pnlFormTitle.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(88, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 44);
            this.panel2.TabIndex = 1;
            // 
            // picCloseWin
            // 
            this.picCloseWin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picCloseWin.BackgroundImage = global::OESUI.Properties.Resources.LOGO_Client_TS_Close;
            this.picCloseWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCloseWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCloseWin.Location = new System.Drawing.Point(976, 5);
            this.picCloseWin.Name = "picCloseWin";
            this.picCloseWin.Size = new System.Drawing.Size(24, 19);
            this.picCloseWin.TabIndex = 4;
            this.picCloseWin.TabStop = false;
            this.picCloseWin.Click += new System.EventHandler(this.DoPicCloseOnClick);
            // 
            // picMaxWin
            // 
            this.picMaxWin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picMaxWin.BackgroundImage = global::OESUI.Properties.Resources.LOGO_Client_Maxmize2;
            this.picMaxWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picMaxWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMaxWin.Location = new System.Drawing.Point(940, 8);
            this.picMaxWin.Name = "picMaxWin";
            this.picMaxWin.Size = new System.Drawing.Size(18, 14);
            this.picMaxWin.TabIndex = 3;
            this.picMaxWin.TabStop = false;
            this.picMaxWin.Click += new System.EventHandler(this.DoPicMaxOnClick);
            // 
            // picMiniWin
            // 
            this.picMiniWin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picMiniWin.BackgroundImage = global::OESUI.Properties.Resources.LOGO_Client_Minimize;
            this.picMiniWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picMiniWin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMiniWin.Location = new System.Drawing.Point(898, 14);
            this.picMiniWin.Name = "picMiniWin";
            this.picMiniWin.Size = new System.Drawing.Size(22, 13);
            this.picMiniWin.TabIndex = 2;
            this.picMiniWin.TabStop = false;
            this.picMiniWin.Click += new System.EventHandler(this.DoPicMinOnClick);
            // 
            // lblonlineExamTitle
            // 
            this.lblonlineExamTitle.AutoSize = true;
            this.lblonlineExamTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblonlineExamTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblonlineExamTitle.Location = new System.Drawing.Point(204, 6);
            this.lblonlineExamTitle.Name = "lblonlineExamTitle";
            this.lblonlineExamTitle.Size = new System.Drawing.Size(214, 19);
            this.lblonlineExamTitle.TabIndex = 1;
            this.lblonlineExamTitle.Text = "Online Exam System Client";
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::OESUI.Properties.Resources.LOGO_Client_Titel_120x202;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogo.Location = new System.Drawing.Point(12, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(176, 22);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // tmrShowFlashMsg
            // 
            this.tmrShowFlashMsg.Interval = 1000;
            this.tmrShowFlashMsg.Tick += new System.EventHandler(this.DoTmrShowFlashMsgOnTick);
            // 
            // BaseWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pnlBodyContainer);
            this.Controls.Add(this.pnlFormTitle);
            this.Name = "BaseWindowForm";
            this.Text = "BaseForm";
            this.pnlBodyContainer.ResumeLayout(false);
            this.pnlAlertWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCloseAlertWin)).EndInit();
            this.pnlNaviation.ResumeLayout(false);
            this.pnlNaviation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavUserPic)).EndInit();
            this.pnlFormTitle.ResumeLayout(false);
            this.pnlFormTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picCloseWin;
        private System.Windows.Forms.PictureBox picMaxWin;
        private System.Windows.Forms.PictureBox picMiniWin;
        private System.Windows.Forms.Label lblonlineExamTitle;
        private System.Windows.Forms.PictureBox picLogo;
        protected System.Windows.Forms.Panel pnlBodyContainer;
        protected System.Windows.Forms.Panel pnlNaviation;
        protected System.Windows.Forms.Label lblNavMyExam;
        protected System.Windows.Forms.Label lblNavHome;
        protected System.Windows.Forms.Panel pnlAlertWindow;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.PictureBox picCloseAlertWin;
        protected System.Windows.Forms.PictureBox lblNavUserPic;
        protected System.Windows.Forms.Label lblNavName;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label lblNameAndPhonebg;
        private System.Windows.Forms.Label lblFlashMsg;
        private System.Windows.Forms.Timer tmrShowFlashMsg;
        private System.Windows.Forms.Label lblCloseAlertWinIKnow;
    }
}