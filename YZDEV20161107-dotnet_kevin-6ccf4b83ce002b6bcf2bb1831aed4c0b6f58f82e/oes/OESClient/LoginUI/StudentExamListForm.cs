using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESUI.customer;
using OESModel;
using OESLogic;
using OESUtil;
using OESCommon;
using System.ServiceModel;
using OESException;

namespace OESUI
{
    public partial class StudentExamListForm : BaseWindowForm
    {
        private Pagination pagination;
        private ExamService.ExamServiceClient client;
        private StudentDataLineControl dataLine;
        private PaginationControl paginationControl;
        private List<Exam> exams;

        public StudentExamListForm()
        {
            InitializeComponent();
            pagination = new Pagination();
            pagination.SortName = Constants.SortByExamId;
            pagination.SortDirection = "asc";
           
            FindAllExam(pagination, SessionUtil.User.Id);
            this.lblNavName.Text = SessionUtil.User.UserName;
            if (exams !=null)
            {
                InitializeNoticeMsg();
            }
        }

        public void FindAllExam(Pagination pagination, int userId)
        {
            this.pnlPaginationContainer.Controls.Clear();
            this.pnlDataContainer.Controls.Clear();
            client = new ExamService.ExamServiceClient();

            try
            {
                exams = client.StudentFindAllExam(pagination, userId);
                this.pagination = client.GetStudentPagination(pagination, userId);

                for (int i = 0; i < exams.Count; i++)
                {
                    dataLine = new StudentDataLineControl(exams[i]);
                    dataLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                    dataLine.Width = this.pnlDataContainer.Width;
                    dataLine.Location = new Point(0, i * 30);
                    this.pnlDataContainer.Controls.Add(dataLine);
                }
                paginationControl = new PaginationControl(this.pagination, FindAllExam);
                this.pnlPaginationContainer.Controls.Add(paginationControl); 
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

        private void InitializeNoticeMsg()
        {
            this.pnlNotice.Controls.Clear();
            int noticeCount = 1;
            for (int i = 0; i < exams.Count; i++)
            {
                if (!"Do it".Equals(exams[i].Operation))
                {
                    continue;
                }

                NoticeDataLineControl noticeDataLineControl = new NoticeDataLineControl(exams[i], noticeCount);
                noticeDataLineControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                noticeDataLineControl.Width = this.pnlDataContainer.Width;
                noticeDataLineControl.Location = new Point(0, noticeCount * 40);
                this.pnlNotice.Controls.Add(noticeDataLineControl);
                noticeCount++;
            }
        }

        public override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoLblTitleNameOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleName, Constants.SortByExamTitle, SessionUtil.User.Id);
        }

        private void DoLblTitleIdOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleId, Constants.SortByExamId, SessionUtil.User.Id);
        }

        private void DoLblTitleEffTimeOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleEffTime, Constants.SortByExamStartTime, SessionUtil.User.Id);
        }

        private void DoLblTitlePassCreditOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitlePassCredit, Constants.SortByExamPassScore, SessionUtil.User.Id);
        }

        private void DoLblOperationOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleOperation, Constants.SortByExamOperation, SessionUtil.User.Id);
        }

        private void DoLblTitleRateOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleRate, Constants.SortByExamScore, SessionUtil.User.Id);
        }

        private void DoLblFinishedOnClick(object sender, EventArgs e)
        {
            ClearBackColor(this.lblFinished);
            pagination.OtherType = "finished";
            pagination.CurrentPage = 1;
            FindAllExam(pagination, SessionUtil.User.Id);
        }

        private void DoLblUnFinishedOnClick(object sender, EventArgs e)
        {
            ClearBackColor(this.lblUnFinished);
            pagination.OtherType = "unFinished";
            pagination.CurrentPage = 1;
            FindAllExam(pagination, SessionUtil.User.Id);
        }

        private void DoLblAllOnClick(object sender, EventArgs e)
        {
            ClearBackColor(this.lblAll);
            pagination.OtherType = "";
            FindAllExam(pagination, SessionUtil.User.Id);
        }

        public void SortExam(Label label, string sortName,  int userId)
        {
            int index = GetCurrentIndexAndClearImage(label);
            label.ImageIndex = index;
            string sortDirection = index == 1 ? "asc" : "desc";
            pagination.SortName = sortName;
            pagination.SortDirection = sortDirection;
            FindAllExam(pagination, userId);
        }

        public int GetCurrentIndexAndClearImage(Label label) 
        {
            int index = 0;
            this.pnlDataContainer.Controls.Clear();
            if (label.ImageIndex == 1)
            {
                label.ImageIndex = 0;
            }
            else
            {
                label.ImageIndex = 1;
            }
            index = label.ImageIndex;
            ClearLabelSortImage();
            return index;
        }

        public void ClearLabelSortImage()
        {
            this.lblTitleName.ImageIndex = 2;
            this.lblTitleId.ImageIndex = 2;
            this.lblTitleEffTime.ImageIndex = 2;
            this.lblTitlePassCredit.ImageIndex = 2;
            this.lblTitleRate.ImageIndex = 2;
            this.lblTitleOperation.ImageIndex = 2;
        }

        public void ClearBackColor(Label label)
        {
            
            this.lblFinished.BackColor = Color.FromArgb(255, 255, 255);
            this.lblUnFinished.BackColor = Color.FromArgb(255, 255, 255);
            this.lblAll.BackColor = Color.FromArgb(255, 255, 255);
            this.lblFinished.ForeColor = Color.FromArgb(46, 67, 88);
            this.lblUnFinished.ForeColor = Color.FromArgb(46, 67, 88);
            this.lblAll.ForeColor = Color.FromArgb(46, 67, 88);
            //current label
            label.BackColor = Color.FromArgb(46, 67, 88);
            label.ForeColor = Color.FromArgb(255, 255, 255);

            this.pnlDataContainer.Controls.Clear();
        }

        private void LoadExamListOnVisibilityChange(object sender, EventArgs e)
        {
            FindAllExam(pagination, SessionUtil.User.Id); 
        }

        protected override void DoLblNameAndPhotobgOnClick(object sender, EventArgs e)
        {
            this.Hide();
            new UserInfoForm().ShowDialog();
        }

        private void DoLblNavNameOnClick(object sender, EventArgs e)
        {
            this.Hide();
            new UserInfoForm().ShowDialog();
        }

        private void DoLblNavUserPicOnClick(object sender, EventArgs e)
        {
            this.Hide();
            new UserInfoForm().ShowDialog();
        }

        private void DoLblNavHomeOnClick(object sender, EventArgs e)
        {
            this.pnlHome.Visible = true;
            this.pnlContainerMain.Visible = false;
            this.lblNavHome.BackColor = Color.FromArgb(210, 218, 227);
            this.lblNavMyExam.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void DoLblNavMyExamOnClick(object sender, EventArgs e)
        {
            this.pnlHome.Visible = false;
            this.pnlContainerMain.Visible = true;
            this.lblNavHome.BackColor = Color.FromArgb(255, 255, 255); 
            this.lblNavMyExam.BackColor = Color.FromArgb(210, 218, 227);
        }
     
        private void DoLblAboutOnClick(object sender, EventArgs e)
        {
            this.pnlAbout.Visible = true;
            this.pnlNotice.Visible = false;
            this.lblLeftNotice.BackColor = Color.FromArgb(255, 255, 255);
            this.lblLeftNotice.ForeColor = Color.FromArgb(46, 67, 88);
            this.lblAbout.BackColor = Color.FromArgb(46, 67, 88);
            this.lblAbout.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void DoLblLeftNoticeOnClick(object sender, EventArgs e)
        {
            this.pnlAbout.Visible = false;
            this.pnlNotice.Visible = true;
            this.lblLeftNotice.BackColor = Color.FromArgb(46, 67, 88);
            this.lblLeftNotice.ForeColor = Color.FromArgb(255, 255, 255);
            this.lblAbout.BackColor = Color.FromArgb(255, 255, 255);
            this.lblAbout.ForeColor = Color.FromArgb(46, 67, 88);
        }

        private void DoPnlHomeOnVisibilityChange(object sender, EventArgs e)
        {
            pagination = new Pagination();
            pagination.SortName = Constants.SortByExamId;
            pagination.SortDirection = "asc";
            FindAllExam(pagination, SessionUtil.User.Id);
            if (exams != null)
            {
                InitializeNoticeMsg();
            }
        }
    }
}
