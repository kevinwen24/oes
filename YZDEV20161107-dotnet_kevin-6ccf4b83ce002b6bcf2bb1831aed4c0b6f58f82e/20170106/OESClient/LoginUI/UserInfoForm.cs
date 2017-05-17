using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESUtil;
using OESModel;
using OESCommon;
using System.ServiceModel;
using OESException;
using OESModel;

namespace OESUI
{
    public partial class UserInfoForm : BaseWindowForm
    {
        private UserService.UserServiceClient client = new UserService.UserServiceClient();
        private static Bitmap bitmap;

        public UserInfoForm()
        {
            InitializeComponent();
            try
            {
                InitializeShowText();
            }
            catch (FaultException<DBException> faultDbException)
            {
                ShowAlertWindow(faultDbException.Message);
            }
            catch (CommunicationException communicationException)
            {
                ShowAlertWindow(Constants.CannotConnServer);
            }
            catch (TimeoutException timeoutException)
            {
                ShowAlertWindow(Constants.NetworkTimeout);
            }
        }

        private void InitializeShowText()
        {
            if (SessionUtil.User.RoleId == 3)
            {
                this.pnlTeacherExamList.Visible = true;
            }
            else 
            {
                this.pnlTeacherExamList.Visible = false;
            }

            User user = client.GetUserByName(SessionUtil.User.UserName);
            this.lblNavUserName.Text = user.UserName;
            this.lblUserName.Text = user.UserName;
            this.lblUserId.Text = user.UserId;
            this.lblContentUserName.Text = user.UserName;
            if (user.RoleId == 4)
            {
                this.lblContentRoleType.Text = Constants.StringStudent;
            }
            else if (user.RoleId == 3)
            {
                this.lblContentRoleType.Text = Constants.StringTeacher;
            }
            
            this.lblContentPhone.Text = user.PhoneNumber;
            this.lblContentMail.Text = user.Email;
            this.lblContentID.Text = user.UserId;
            this.lblContentGender.Text = user.Gender;
            this.lblContentChineseName.Text = user.ChineseName;
            this.lblChangePasswordTipUserName.Text = user.UserName;
            if (bitmap != null)
            {
                this.picUserPhoto.Image = bitmap;
            } 
        }

        private void DoLblNavExamListOnClick(object sender, EventArgs e)
        {
            this.Hide();
            if (SessionUtil.User.RoleId == 3)
            {
                Application.OpenForms[Constants.TeacherExamListForm].Show();
            }
            else if (SessionUtil.User.RoleId == 4)
            {
                Application.OpenForms[Constants.StudentExamListForm].Show();
            }
        }

        private void DoLblChangePasswordOnClick(object sender, EventArgs e)
        {
            this.lblChangePassword.BackColor = Color.FromArgb(46, 67, 88);
            this.lblChangePassword.ForeColor = Color.FromArgb(255, 255, 255);
            this.lblBasicInfo.BackColor = Color.FromArgb(255, 255, 255);
            this.lblBasicInfo.ForeColor = Color.FromArgb(46, 67, 88);
            this.pnlChangePassword.Visible = true;
            this.pnlBasicInformation.Visible = false;
        }

        private void DoLblBasicInfoOnClick(object sender, EventArgs e)
        {
            ShowBasicInfoOnClick();
        }

        private void ShowBasicInfoOnClick()
        {
            this.lblChangePassword.BackColor = Color.FromArgb(255, 255, 255);
            this.lblChangePassword.ForeColor = Color.FromArgb(46, 67, 88);
            this.lblBasicInfo.BackColor = Color.FromArgb(46, 67, 88);
            this.lblBasicInfo.ForeColor = Color.FromArgb(255, 255, 255);
            this.pnlChangePassword.Visible = false;
            this.pnlBasicInformation.Visible = true;
        }

        private void DoLblCancelOnClick(object sender, EventArgs e)
        {
            this.txtPassword.Text = "";
            this.txtPasswordConfirm.Text = "";
            ShowBasicInfoOnClick();
        }

        private void DoLblSubmitOnClick(object sender, EventArgs e)
        {
            string password = this.txtPassword.Text.Trim();
            string confirmPassword = this.txtPasswordConfirm.Text.Trim();
            if (password.Length == 0 || confirmPassword.Length == 0)
            {
                showFlashMsg(Constants.TipInputPassword);
                return;
            }
            if (!password.Equals(confirmPassword))
            {
                showFlashMsg(Constants.TipInputSamePassword);
                return;
            }
            
            new UserService.UserServiceClient().ModifyPassword(SessionUtil.User.Id, Md5Util.EncryptStringWithMD5(password));
            
            this.pnlTipWindow.Visible = true;
        }

        private void DoLblYesOnClick(object sender, EventArgs e)
        {
            this.pnlTipWindow.Visible = false;
            this.Hide();
            if (SessionUtil.User.RoleId == 3)
            {
                Application.OpenForms[Constants.TeacherExamListForm].Show();
            }
            else if (SessionUtil.User.RoleId == 4)
            {
                Application.OpenForms[Constants.StudentExamListForm].Show();
            }
            
        }

        private void DoPicCloseTipWindowOnClick(object sender, EventArgs e)
        {
            this.Hide();
            if (SessionUtil.User.RoleId == 3)
            {
                Application.OpenForms[Constants.TeacherExamListForm].Show();
            }
            else if (SessionUtil.User.RoleId == 4)
            {
                Application.OpenForms[Constants.StudentExamListForm].Show();
            }
        }

        private void DolblAddPhotoOnClick(object sender, EventArgs e)
        {
            string picPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG(*.JPG;*.JPEG);gif文件(*.GIF)|*.jpg;*.jpeg;*.gif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picPath = openFileDialog.FileName.ToString();
                bitmap = new Bitmap(picPath);

                this.picShowPhoto.Image = bitmap;
                this.lblAddPhoto.Location = new Point(140, 330);
                this.lblsetMyAvatar.Visible = true;
            }
        }

        private void DopicClosePnlAddPhotoOnClick(object sender, EventArgs e)
        {
            this.pnlAddPhonoWindow.Visible = false;
        }

        private void DoPicShowPhoteOnClick(object sender, EventArgs e)
        {
            this.pnlAddPhonoWindow.Visible = true;
        }

        private void DoLblsetMyAvatarOnClick(object sender, EventArgs e)
        {
            this.picUserPhoto.Image = bitmap;
            this.pnlAddPhonoWindow.Visible = false;
        }

        private void DoLblNavHomeOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }

        private void DoLblNavMyExamOnClick(object sender, EventArgs e)
        {

            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }
    }
}
