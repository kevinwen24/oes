using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using OESLogic;
using OESUtil;
using OESCommon;
using System.ServiceModel;
using OESModel;
using OESException;


namespace OESUI
{
    public partial class LoginForm : BaseMovingForm
    {
        public LoginForm()
        {
            InitializeComponent();
            BindMovForForm(pnlTitle);
            BindMovForForm(picLogo);
            InitLocation();
        }

        private void InitLocation()
        {
            this.Location = new System.Drawing.Point(300, 100);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        private void DoBtnLoginOnClick(object sender, EventArgs e)
        {
            bool isLegalData = ValidationLoginTxtBox();
            if (isLegalData)
            {
                try
                {
                    UserService.UserServiceClient userService = new UserService.UserServiceClient();
                    User user = userService.VerifyUserLogin(txtUserName.Text.Trim(), Md5Util.EncryptStringWithMD5(txtPassword.Text.Trim()));

                    if (user != null)
                    {
                        SessionUtil.User = user;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.ShowTipMsg(Constants.PasswordIncorrect);
                    }
                }
                catch (FaultException<DBException> faultDbException)
                {
                    this.ShowTipMsg(faultDbException.Message);
                }
                catch (FaultException<ServiceException> faultServiceException)
                {
                    this.ShowTipMsg(faultServiceException.Detail.getMsg());
                }
                catch (CommunicationException communicationException)
                {
                    this.ShowTipMsg(Constants.CannotConnServer);
                }
                catch (TimeoutException timeoutException)
                {
                    this.ShowTipMsg(Constants.NetworkTimeout);
                }
            }
        }

        private void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoTxtUserNameOnEnter(object sender, EventArgs e)
        {
            HideTipMsg();
            picErrorUserName.Visible = false;
            lblUserName.Visible = false;
        }

        private void DoTxtUserNameOnLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                lblUserName.Visible = true;
            }
        }

        private void DoTxtPasswordOnEnter(object sender, EventArgs e)
        {
            HideTipMsg();
            picErrorPassword.Visible = false;
            lblPassword.Visible = false;
        }

        private void DoTxtPasswordOnLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblPassword.Visible = true;
            }         
        }

        private void DoLblPasswordOnClick(object sender, EventArgs e)
        {
            lblPassword.Visible = false;
            txtPassword.Focus();
        }

        private void DoLblUserNameOnClick(object sender, EventArgs e)
        {
            lblUserName.Visible = false;
            txtUserName.Focus();
        }

        private void DoBtnLoginOnEnter(object sender, EventArgs e)
        {
            picLogo.Focus();
        }

        private void DoPicUserOnClick(object sender, EventArgs e)
        {
            this.txtUserName.Focus();
            HideTipMsg();
            picErrorUserName.Visible = false;
        }

        private void DoPicPasswordOnClick(object sender, EventArgs e)
        {
            this.txtPassword.Focus();
            HideTipMsg();
            picErrorPassword.Visible = false;
        }

        private void ShowTipMsg(string tipMsg)
        {
            pnlTipMsg.Visible = true;
            lblTipMsg.Visible = true;
            lblTipMsg.Text = tipMsg;
        }

        private void HideTipMsg()
        {
            pnlTipMsg.Visible = false;
            lblTipMsg.Visible = false;
        }
       
        private bool ValidationLoginTxtBox()
        { 
            if (string.IsNullOrWhiteSpace(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                this.ShowTipMsg(Constants.UserNameAndPasswordIsRequired);
                picErrorUserName.Visible = true;
                picErrorPassword.Visible = true;
                return false;
            }

            bool isLegal = true;
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                this.ShowTipMsg(Constants.UserNameIsRequired);
                picErrorUserName.Visible = true;
                isLegal = false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                this.ShowTipMsg(Constants.PasswordIsRequired);
                picErrorPassword.Visible = true;
                isLegal = false;
            }
            return isLegal;
        }
    }
}
