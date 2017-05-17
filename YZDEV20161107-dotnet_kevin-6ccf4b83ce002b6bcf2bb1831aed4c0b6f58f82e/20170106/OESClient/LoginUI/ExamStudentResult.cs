using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESUI.customer;
using OESUtil;
using OESCommon;
using System.ServiceModel;
using OESException;

namespace OESUI
{
    public partial class ExamStudentResult : BaseWindowForm
    {
        private ExamStudentResultDataLineControl examStudentResultDataLineControl;
        private ExamService.ExamServiceClient client;
        private PaginationControl paginationControl;
        private List<Exam> exams;
        private int examId;
        private Pagination pagination;
       
        public ExamStudentResult(int examId)
        {
            InitializeComponent();
            this.examId = examId;

            pagination = new Pagination();
            pagination.SortName = Constants.SortByExamId;
            pagination.SortDirection = "asc";
            FindAllExam(pagination, SessionUtil.User.Id);     
        }

        public void FindAllExam(Pagination pagination, int userId)
        {
            if (!string.IsNullOrWhiteSpace(pagination.UserName))
            {
                this.txtSearchContent.Text = pagination.UserName;
            }
            this.pnlPaginationContainer.Controls.Clear();
            this.pnlDataContainer.Controls.Clear();
            client = new ExamService.ExamServiceClient();

            try
            {
                exams = client.FindAllStudentExamResultByExamId(pagination, examId);
                this.pagination = client.GetStudentResultByExamIdPagination(pagination, examId);

                for (int i = 0; i < exams.Count; i++)
                {
                    examStudentResultDataLineControl = new ExamStudentResultDataLineControl(exams[i]);
                    examStudentResultDataLineControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                    examStudentResultDataLineControl.Width = this.pnlDataContainer.Width;
                    examStudentResultDataLineControl.Location = new Point(0, i * 31);
                    this.pnlDataContainer.Controls.Add(examStudentResultDataLineControl);
                }
                paginationControl = new PaginationControl(this.pagination, FindAllExam);
                this.pnlPaginationContainer.Controls.Add(paginationControl);
            }
            catch (FaultException<DBException> faultDbException)
            {
                ShowAlertWindow(faultDbException.Message);
            }   
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
            this.lblTitleUserName.ImageIndex = 2;
            this.lblTitleResult.ImageIndex = 2;
            this.lblTitleRate.ImageIndex = 2;
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
            string content = this.txtSearchContent.Text.Trim();
            if (content.Length <= 0)
            {
                showFlashMsg(Constants.TipInputKeyWords);
                return;
            }
            pagination.UserName = StringUtil.FilterSearchString(content);
            FindAllExam(pagination,SessionUtil.User.Id);
        }

        private void DoLblplaceholderOnClick(object sender, EventArgs e)
        {
            this.txtSearchContent.Focus();
            this.lblplaceholder.Visible = false;
        }

        private void DoTxtSearchContentOnLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtSearchContent.Text))
            {
                 this.lblplaceholder.Visible = true;
            }
        }

        private void DoTxtSearchContentOnEnter(object sender, EventArgs e)
        {
            this.lblplaceholder.Visible = false;
        }

 
        private void DoLblTitleUserNameOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleUserName, Constants.SortByUserName);
        }

        private void DoLblTitleResultOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleResult, Constants.SortByResult);
        }

        private void DoLblTitleRateOnClick(object sender, EventArgs e)
        {
            SortExam(this.lblTitleRate, Constants.SortByUserScore);
        }

        public override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.TeacherExamListForm].Show();
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
