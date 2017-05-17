namespace LoginUI
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
            this.pnlBodyContainer = new System.Windows.Forms.Panel();
            this.pnlAlertWindow = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlNaviation = new System.Windows.Forms.Panel();
            this.lblNavMyExam = new System.Windows.Forms.Label();
            this.lblNavHome = new System.Windows.Forms.Label();
            this.pnlFormTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picCloseWin = new System.Windows.Forms.PictureBox();
            this.picMaxWin = new System.Windows.Forms.PictureBox();
            this.picMiniWin = new System.Windows.Forms.PictureBox();
            this.lblonlineExamTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlBodyContainer.SuspendLayout();
            this.pnlAlertWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlNaviation.SuspendLayout();
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
            this.pnlBodyContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.pnlBodyContainer.Controls.Add(this.pnlAlertWindow);
            this.pnlBodyContainer.Controls.Add(this.pnlNaviation);
            this.pnlBodyContainer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlBodyContainer.Location = new System.Drawing.Point(0, 28);
            this.pnlBodyContainer.Name = "pnlBodyContainer";
            this.pnlBodyContainer.Size = new System.Drawing.Size(1024, 740);
            this.pnlBodyContainer.TabIndex = 3;
            // 
            // pnlAlertWindow
            // 
            this.pnlAlertWindow.BackColor = System.Drawing.Color.White;
            this.pnlAlertWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertWindow.Controls.Add(this.pictureBox1);
            this.pnlAlertWindow.Controls.Add(this.button1);
            this.pnlAlertWindow.Controls.Add(this.lblAlertMessage);
            this.pnlAlertWindow.Controls.Add(this.btnReturn);
            this.pnlAlertWindow.Location = new System.Drawing.Point(316, 270);
            this.pnlAlertWindow.Name = "pnlAlertWindow";
            this.pnlAlertWindow.Size = new System.Drawing.Size(434, 174);
            this.pnlAlertWindow.TabIndex = 1;
            this.pnlAlertWindow.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LoginUI.Properties.Resources.BTN_Close_16x16_png;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(400, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(230, 120);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblAlertMessage
            // 
            this.lblAlertMessage.Location = new System.Drawing.Point(63, 33);
            this.lblAlertMessage.Name = "lblAlertMessage";
            this.lblAlertMessage.Size = new System.Drawing.Size(342, 68);
            this.lblAlertMessage.TabIndex = 12;
            this.lblAlertMessage.Text = "label1";
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReturn.Location = new System.Drawing.Point(124, 120);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 29);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "I Know!";
            this.btnReturn.UseVisualStyleBackColor = false;
            // 
            // pnlNaviation
            // 
            this.pnlNaviation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNaviation.BackColor = System.Drawing.Color.White;
            this.pnlNaviation.Controls.Add(this.lblNavMyExam);
            this.pnlNaviation.Controls.Add(this.lblNavHome);
            this.pnlNaviation.Location = new System.Drawing.Point(0, 1);
            this.pnlNaviation.Name = "pnlNaviation";
            this.pnlNaviation.Size = new System.Drawing.Size(1024, 38);
            this.pnlNaviation.TabIndex = 0;
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
            this.picCloseWin.BackgroundImage = global::LoginUI.Properties.Resources.LOGO_Client_TS_Close;
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
            this.picMaxWin.BackgroundImage = global::LoginUI.Properties.Resources.LOGO_Client_Maxmize2;
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
            this.picMiniWin.BackgroundImage = global::LoginUI.Properties.Resources.LOGO_Client_Minimize;
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
            this.picLogo.BackgroundImage = global::LoginUI.Properties.Resources.LOGO_Client_Titel_120x202;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picLogo.Location = new System.Drawing.Point(12, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(176, 22);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlNaviation.ResumeLayout(false);
            this.pnlFormTitle.ResumeLayout(false);
            this.pnlFormTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaxWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlNaviation;
        private System.Windows.Forms.Label lblNavMyExam;
        private System.Windows.Forms.Label lblNavHome;
        private System.Windows.Forms.Panel pnlAlertWindow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}