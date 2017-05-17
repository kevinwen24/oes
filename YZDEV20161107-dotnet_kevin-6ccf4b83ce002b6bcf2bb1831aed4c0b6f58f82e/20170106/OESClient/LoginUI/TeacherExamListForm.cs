using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESUtil;
using OESUI.customer;
using OESException;
using System.ServiceModel;
using OESCommon;

namespace OESUI
{
    public partial class TeacherExamListForm : BaseWindowForm
    {
        private Pagination pagination;
        private TeacherDataLineControl dataLine;
        private PaginationControl paginationControl;
        private List<Exam> exams;
        private ExamService.ExamServiceClient client;

        public TeacherExamListForm()
        {
            InitializeComponent();

            pagination = new Pagination();
            pagination.SortName = "examId";
            pagination.SortDirection = "asc";
            FindAllExam(pagination, SessionUtil.User.Id); 
            this.lblNavName.Text = SessionUtil.User.UserName;
        }

        public void FindAllExam(Pagination pagination, int userId)
        {
           
            this.pnlPaginationContainer.Controls.Clear();
            this.pnlDataContainer.Controls.Clear();
            client = new ExamService.ExamServiceClient();
            try
            {
                exams = client.TeacherFindAllExam(pagination);
                this.pagination = client.GetTeacherPagination(pagination);

                for (int i = 0; i <  exams.Count; i++)
                {
                    dataLine = new TeacherDataLineControl(exams[i]);
                    dataLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                    dataLine.Width = this.pnlDataContainer.Width;
                    dataLine.Location = new Point(0, i * 31);
                    this.pnlDataContainer.Controls.Add(dataLine);
                }
                paginationControl = new PaginationControl(this.pagination, FindAllExam);
                this.pnlPaginationContainer.Controls.Add(paginationControl);
                if (!string.IsNullOrEmpty(pagination.ExamName))
                {
                    this.txtSearchContent.Text = pagination.ExamName;
                }
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

        private void DoLblTitleNameOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleName, "examTitle");
        }

        private void DoLblTitleIdOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleId, "examId");
        }

        private void DoLblTitleEffTimeOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleEffTime, "examStartTime");
        }

        private void DoLblTitleAvgOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleAvg, "examAvg");
        }

        private void DoLblTitlePassRateOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitlePassRate, "examPassRate");
        }

        public void SortExam(Label label, string sortName)
        {
            int index = GetCurrentIndexAndClearImage(label);
            label.ImageIndex = index;
            string sortDirection = index == 1 ? "asc" : "desc";
            pagination.SortName = sortName;
            pagination.SortDirection = sortDirection;
            FindAllExam(pagination,SessionUtil.User.Id);
        }

        public void ClearLabelSortImage()
        {
            this.lblTitleName.ImageIndex = 2;
            this.lblTitleId.ImageIndex = 2;
            this.lblTitleEffTime.ImageIndex = 2;
            this.lblTitleRate.ImageIndex = 2;
            this.lblTitleAvg.ImageIndex = 2;
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

        private void DoPicSearchOnClick(object sender, EventArgs e)
        {
            string content = this.txtSearchContent.Text;
            pagination.ExamName = StringUtil.FilterSearchString(content);
            FindAllExam(pagination,SessionUtil.User.Id);
        }

        private void DoLblplaceholderOnClick(object sender, EventArgs e)
        {
            this.txtSearchContent.Focus();
        }

        private void DoTxtSearchContentOnLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchContent.Text))
            {
                this.lblplaceholder.Visible = true;
            }                
        }

        private void DoTxtSearchContentOnEnter(object sender, EventArgs e)
        {
            this.lblplaceholder.Visible = false;
        }

        private void DoLblNaviTitleFreshOnClick(object sender, EventArgs e)
        {
            pagination = new Pagination();
            pagination.SortName = "examId";
            pagination.SortDirection = "asc";
            FindAllExam(pagination, SessionUtil.User.Id); 
        }

        private void DoLblDateSearchOnClick(object sender, EventArgs e)
        {
            string startTime = dtpStartTime.Value.ToString();
            string endTime = dtpEndTime.Value.ToString();
            
            pagination.StartTime = startTime;
            pagination.EndTime = endTime.Substring(0, 11) + Constants.DateAppendTime;
          
            FindAllExam(pagination, SessionUtil.User.Id);
        }

        private void DoTxtSearchContentOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoPicSearchOnClick(sender, new EventArgs());
            }
        }
    }
}
