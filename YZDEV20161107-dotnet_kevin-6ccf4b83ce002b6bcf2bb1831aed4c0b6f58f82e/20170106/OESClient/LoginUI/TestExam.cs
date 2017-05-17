using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESLogic;
using OESUtil;
using OESModel;
using OESCommon;
using System.ServiceModel;
using OESException;

namespace OESUI
{
    public partial class TestExam : BaseWindowForm
    {
        private ExamService.ExamServiceClient examClient = new ExamService.ExamServiceClient();
        private QuestionService.QuestionServiceClient questionClient = new QuestionService.QuestionServiceClient();
        private List<Question> questions;
        private int index ;
        private Exam exam;
        private DateTime endTime;
        private Question currentQuestion;
        private int studentScore;
        private int correctQuantity;

        public TestExam(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            endTime = Convert.ToDateTime(exam.StartTime).AddMinutes(exam.DuringTime);
            try
            {
                InitialQuestions();
                InitialQuestionRelateText(currentQuestion); 
            }
            catch (FaultException<DBException> faultDbException)
            {
                ShowAlertWindow(faultDbException.Message);
                HideQuestionRelativeControls();
            }
        }

        private void HideQuestionRelativeControls()
        {
            this.pnlRestTimeHeader.Visible = false;
            this.pnlContentQuestion.Visible = false;
            this.pnlContainerBtnNextQuestion.Visible = false;
        }

        private void InitialQuestions()
        {
            questions = questionClient.GetQuestionsByExamId(exam.Id);
            List<int> studentAnswer = examClient.SelectStudentSelfAnswer(SessionUtil.User.Id, exam.Id);
            index = 1;
            for (int i = 0; i < studentAnswer.Count; i++)
            {
                if (studentAnswer[i] == -1)
                {
                    index = i + 1;
                    break;
                }
            }
            if (index == exam.QuestionQuantity)
            {
                this.lblNextQuestion.Text = "Submit Exam";
            }
            currentQuestion = questions[index - 1];
            this.lblQuestionIndex.Text = index.ToString();
            this.lblNavSingleScore.Text = exam.SingleScore.ToString();
            this.lblCurrentAndTotal.Text = index + "/" + exam.QuestionQuantity;    
        }

        private void InitialQuestionRelateText(Question question)
        {
            this.lblQuestionTitle.Text = question.Title;
            this.lblOptionA.Text = question.OptionA;
            this.lblOptionB.Text = question.OptionB;
            this.lblOptionC.Text = question.OptionC;
            this.lblOptionD.Text = question.OptionD;
        }

        private void DoRestTestingTimeOnTick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = endTime.Subtract(DateTime.Now);
            this.lblRestTime.Text = timeSpan.ToString(Constants.TimeSpanFormatWithHhMmSs);
            if (timeSpan.TotalSeconds <= 0) 
            {
                this.lblAutomaticSubmit.Visible = true;
                SubmitExam();  
            }
        }

        private void DoLblSelectRadioOnClick(object sender, EventArgs e)
        {
            Label currentRadio = (sender as Label);

            ClearSelectRadio();
            currentRadio.ImageIndex = 0;
            this.lblNextQuestion.BackColor = Color.FromArgb(254, 153, 0);
            this.rtsNextQuestion.BorderColor = Color.FromArgb(254, 153, 0);
        }

        private void ClearSelectRadio()
        {
            this.lblNextQuestion.BackColor = Color.FromArgb(151, 151, 151);
            this.rtsNextQuestion.BorderColor = Color.FromArgb(151, 151, 151);

            foreach (Control control in this.pnlContentQuestion.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    if (label.Tag != null)
                    {
                        if (label.Tag.ToString().Equals("radio"))
                        {
                            label.ImageIndex = 1;
                        }
                    }
                }
            }
        }

        private int CurrentSelectRadio() 
        {
            List<Label> labels = new List<Label>();
            labels.Add(this.lblOptionARadioA);
            labels.Add(this.lblOptionARadioB);
            labels.Add(this.lblOptionARadioC);
            labels.Add(this.lblOptionARadioD);
            for (int i = 0; i < labels.Count; i++)
            {
                if (labels[i].ImageIndex == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private void lblNextQuestion_Click(object sender, EventArgs e)
        {
            
            int currentSelect = CurrentSelectRadio();

            if (currentSelect == -1)
            {
                return;
            }

            if (index + 1 == exam.QuestionQuantity)
            {
                this.lblNextQuestion.Text = "Submit Exam";
            }

            StoreAnswer storeAnswer = new StoreAnswer();
            storeAnswer.UserId = SessionUtil.User.Id;
            storeAnswer.ExamId = exam.Id;
            storeAnswer.QuestionId = currentQuestion.Id;
            storeAnswer.Answer = currentSelect;
            
            try
            {
                examClient.SaveExamAnswer(storeAnswer);
            }
            catch (FaultException<DBException> faultDbException)
            {
                ShowAlertWindow(faultDbException.Message);
                HideQuestionRelativeControls();
            }
            catch (CommunicationException communicationException)
            {
                ShowAlertWindow(Constants.CannotConnServer);
                HideQuestionRelativeControls();
            }
            catch (TimeoutException timeoutException)
            {
                ShowAlertWindow(Constants.NetworkTimeout);
                HideQuestionRelativeControls();
            }

            if (index == exam.QuestionQuantity)
            {
                SubmitExam();
            }

            //load next question
            index++;

            if (index <= exam.QuestionQuantity)
            {
                currentQuestion = questions[index - 1];
                this.lblQuestionIndex.Text = index.ToString();
                this.lblCurrentAndTotal.Text = index + "/" + exam.QuestionQuantity;
                InitialQuestionRelateText(currentQuestion);
            }
            ClearSelectRadio();
        }     

        private void SubmitExam()
        {
            StoreScore storeStore = new StoreScore();
            storeStore.UserId = SessionUtil.User.Id;
            storeStore.ExamId = exam.Id;
            this.pnlExamResult.Visible = true;
            List<int> results = null;
            try
            {
                results = examClient.SaveStudentTotalScore(storeStore);
            }
            catch (FaultException<DBException> faultDbException)
            {
                ShowAlertWindow(faultDbException.Message);
                HideQuestionRelativeControls();
            }
            catch (CommunicationException communicationException)
            {
                ShowAlertWindow(Constants.CannotConnServer);
                HideQuestionRelativeControls();
            }
            catch (TimeoutException timeoutException)
            {
                ShowAlertWindow(Constants.NetworkTimeout);
                HideQuestionRelativeControls();
            }

            this.lblExamResultScore.Text = results[0].ToString();
            this.lblExamResultCorrectQuantity.Text = results[1].ToString();
            this.studentScore = results[0];
            this.correctQuantity = results[1];
        }

        public override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }

        private void DoRtsViewResultDetailOnClick(object sender, EventArgs e)
        {
            this.Hide();
            ExamDetail examResult = new ExamDetail(exam, studentScore, correctQuantity, questions);
            examResult.Show();
        }

    }
}
