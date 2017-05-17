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
using OESCommon;
using OESUI.customer;

namespace OESUI
{
    public partial class ExamDetail : BaseWindowForm
    {
        private Exam exam;
        private List<Question> questions;

        public ExamDetail(Exam exam, int score, int correctQuantity, List<Question> questions)
        {
            InitializeComponent();
            this.exam = exam;
            this.questions = questions;
            InitialShowMsg(score, correctQuantity);
            ShowQuestionDeatil();
        }

        private void InitialShowMsg(int score, int correctQuantity)
        {
            this.lblContentId.Text = exam.ExamId;
            this.lblContentName.Text = exam.Title;
            this.lblContentQuantity.Text = exam.QuestionQuantity.ToString();
            this.lblContentEffTime.Text = exam.StartTime;
            this.lblContentTotalScore.Text = exam.TotalScore.ToString();
            this.lblContentDurationTime.Text = exam.DuringTime.ToString();
            this.lblExamCorrectQuantity.Text = correctQuantity.ToString();
            this.lblContentExamScore.Text = score.ToString();
            this.lblContentExamScoreB.Text = score.ToString();
        }

        private void ShowQuestionDeatil()
        {
            ExamService.ExamServiceClient client = new ExamService.ExamServiceClient();
            List<int> studentAnswers = new ExamService.ExamServiceClient().SelectStudentSelfAnswer(SessionUtil.User.Id, exam.Id);
            for (int i = 0; i < studentAnswers.Count; i++)
            {
                ShowQuestionControl showQuestionControl = new ShowQuestionControl(questions[i], studentAnswers[i], i);
                showQuestionControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                showQuestionControl.Location = new Point(0, i * 180);
                this.pnlQuestionsContainer.Controls.Add(showQuestionControl);
            }
        }

        public override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }
    }
}
