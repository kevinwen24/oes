using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESUI
{
    public partial class BaseWindowForm : BaseMovingForm
    {
        private DateTime currentTime;

        public BaseWindowForm()
        {
            InitializeComponent(); 
            BindMovForForm(pnlFormTitle);
            BindMovForForm(lblonlineExamTitle);
            BindMovForForm(picLogo); 
        }

        private void DoPicMinOnClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoPicMaxOnClick(object sender, EventArgs e)
        {
            if ( WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else {
                WindowState = FormWindowState.Normal;
            }
        }

        public virtual void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoLblLogoutOnClick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        protected virtual void DoLblNameAndPhotobgOnClick(object sender, EventArgs e)
        {
            this.Hide();
            new UserInfoForm().ShowDialog();
        }

        public void showFlashMsg(string msg)
        {
            this.tmrShowFlashMsg.Enabled = true;
            this.lblFlashMsg.Visible = true;
            this.lblFlashMsg.Text = msg;
            currentTime = DateTime.Now;
            this.tmrShowFlashMsg.Interval = 1000;
        }

        private void DoTmrShowFlashMsgOnTick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now - currentTime;
            if (timeSpan.TotalSeconds >= 3)
            {
                this.tmrShowFlashMsg.Enabled = false;
                this.lblFlashMsg.Visible = false;
            }
        }

        protected void ShowAlertWindow(string alertMsg)
        {
            this.pnlAlertWindow.Visible = true;
            this.lblAlertMessage.Text = alertMsg;
        }

        private void DoPicCloseAlertWinOnClick(object sender, EventArgs e)
        {
            this.pnlAlertWindow.Visible = false;
        }

        private void DoLblCloseAlertWinIKnowOnClick(object sender, EventArgs e)
        {
            this.pnlAlertWindow.Visible = false;
        }
    }
     
}
