using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginUI.customer;
using OESModel;
using OESLogic;
using OESUtil;

namespace LoginUI
{
    public partial class ExamListForm : BaseWindowForm
    {
        private Pagination pagination = new Pagination();
        public ExamListForm()
        {
            //模拟4用户,绕过登陆
            User user = new User();
            user.Id = 4;
            SessionUtil.User = user;

            InitializeComponent();
            pagination.SortName = "examId";
            pagination.SortDirection = "asc";
            FindAllExam(pagination, SessionUtil.User.Id);
            
        }

        public void FindAllExam(Pagination pagination, int userId)
        {
            ExamService.ExamServiceClient client = new ExamService.ExamServiceClient();
            List<Exam>   exams =  client.FindAllExam(pagination, userId);

            for (int i = 0; i <  exams.Count; i++)
            {
                DataLineControl dataLine = new DataLineControl(exams[i]);
                dataLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                dataLine.Width = this.pnlDataContainer.Width;
                dataLine.Location = new Point(0, i * 30);
                this.pnlDataContainer.Controls.Add(dataLine);
            }
        }

        private void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoPicMaxWinOnClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
           
        }

        private void DoPicMiniWinOnClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DoLblTitleNameOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleName, "examTitle", SessionUtil.User.Id);
        }

        private void DoLblTitleIdOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleId, "examId", SessionUtil.User.Id);
        }

        private void DoLblTitleEffTimeOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleEffTime, "examStartTime", SessionUtil.User.Id);
        }

        private void DoLblTitlePassCreditOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitlePassCredit, "examPassScore", SessionUtil.User.Id);
        }

        private void DoLblOperationOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleOperation, "examOperation", SessionUtil.User.Id);
        }

        private void DoLblTitleRateOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleRate, "examScore", SessionUtil.User.Id);
        }

        private void DoLblFinishedOnClick(object sender, EventArgs e)
        {
            ClearBackColor(this.lblFinished);
            pagination.OtherType = "finished";
            FindAllExam(pagination, SessionUtil.User.Id);
        }

        private void DoLblUnFinishedOnClick(object sender, EventArgs e)
        {
            ClearBackColor(this.lblUnFinished);
            pagination.OtherType = "unFinished";
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

       
     
    }
}
