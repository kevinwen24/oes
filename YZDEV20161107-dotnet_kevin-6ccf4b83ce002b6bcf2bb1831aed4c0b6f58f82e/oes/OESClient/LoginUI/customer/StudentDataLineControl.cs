using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESUtil;
using OESCommon;

namespace OESUI.customer
{
    public partial class StudentDataLineControl : UserControl
    {
        private Exam exam;
        private QuestionService.QuestionServiceClient questionClient = new QuestionService.QuestionServiceClient();
        private ExamService.ExamServiceClient examClient = new ExamService.ExamServiceClient();

        public StudentDataLineControl(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            this.lblExamIndex.Text = exam.RowNum.ToString();
            this.lblExamName.Text = exam.Title;
            this.lblExamId.Text = exam.ExamId;
            this.lblStartTime.Text = exam.StartTime.Substring(0,16);
            this.lblDuringTime.Text = exam.DuringTime.ToString();
            this.lblPassCredit.Text = exam.PassScore.ToString();
            this.lblExamRate.Text = exam.Score >= 0 ? exam.Score + ""+ "/" + exam.TotalScore : "-" + "/" + exam.TotalScore;
            if (exam.Operation == "Do it")
            {
                 lblExamOperation.Font = new Font("Arial", 12, FontStyle.Underline);
                 lblExamOperation.ForeColor = Color.FromArgb(41, 103, 147);
            }
            this.lblExamOperation.Text = exam.Operation;
        }

        protected void DoLblOperationOnClick(object sender, EventArgs e)
        {
            if (!this.lblExamOperation.Text.Trim().Equals("Do it"))
            {
                Application.OpenForms[Constants.StudentExamListForm].Hide();
                List<Question> questions = questionClient.GetQuestionsByExamId(exam.Id);
                int studentTotalScore = examClient.GetStudentTotalScore(SessionUtil.User.Id, exam);
                new ExamDetail(exam, studentTotalScore, (studentTotalScore/exam.SingleScore), questions).Show();
            }

            if (this.lblExamOperation.Text.Trim().Equals("Do it"))
            {
                Application.OpenForms[Constants.StudentExamListForm].Hide();
                new TakeExam(exam).ShowDialog();
            }
        }

        private void DoLblExamNameOnMouseHover(object sender, EventArgs e)
        {
            this.toolTipName.SetToolTip(this.lblExamName, this.exam.Title);
        }

        private void DoLblExamNameOnClick(object sender, EventArgs e)
        {
            //TimeSpan timeSpan = Convert.ToDateTime(exam.StartTime) - DateTime.Now;
            if (!this.lblExamOperation.Text.Trim().Equals("Do it"))
            {
                Application.OpenForms[Constants.StudentExamListForm].Hide();
                List<Question> questions = questionClient.GetQuestionsByExamId(exam.Id);
                int studentTotalScore = examClient.GetStudentTotalScore(SessionUtil.User.Id, exam);
                new ExamDetail(exam, studentTotalScore, (studentTotalScore / exam.SingleScore), questions).Show();
            }

            if (this.lblExamOperation.Text.Trim().Equals("Do it"))
            {
                Application.OpenForms[Constants.StudentExamListForm].Hide();
                new TakeExam(exam).ShowDialog();
            }
        }  
    }
}
