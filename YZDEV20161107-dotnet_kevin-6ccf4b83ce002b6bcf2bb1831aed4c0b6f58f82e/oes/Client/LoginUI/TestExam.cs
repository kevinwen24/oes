using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESLogic;
using OESUtil;

namespace LoginUI
{
    public partial class TestExam : BaseWindowForm
    {
        private List<Question> questions;
        private int index ;
        private Exam exam;
        private DateTime endTime;
        private Question currentQuestion;

        public TestExam(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            endTime = Convert.ToDateTime(exam.StartTime).AddMinutes(exam.DuringTime);
            questions = new QuestionService.QuestionServiceClient().GetQuestionsByExamId(exam.Id);
            index = 1;
            currentQuestion = questions[index - 1];   
            this.lblQuestionIndex.Text = index.ToString();
            this.lblQuestionScore.Text = exam.SingleScore.ToString();
            this.lblCurrentPageNav.Text = index + "/" + exam.QuestionQuantity;
            InitialQuestionRelateText(currentQuestion);
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
            this.lblRestTestingTime.Text = timeSpan.ToString(@"hh\:mm\:ss");  
        }

        private void DoLblSelectRadioOnClick(object sender, EventArgs e)
        {
            Label currentRadio = (sender as Label);

            ClearSelectRadio();
            currentRadio.ImageIndex = 0;
            this.btnNextQuestion.BackColor = Color.FromArgb(254, 153, 0);
        }

        private void ClearSelectRadio()
        {
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

        private void DoBtnNextQuestionOnClick(object sender, EventArgs e)
        {
            int currentSelect = CurrentSelectRadio();
            bool isCanClickNextQuestion = true;

            if (currentSelect == -1)
            {
                isCanClickNextQuestion = false;
            }

            if (index + 1 == exam.QuestionQuantity)
            {
                this.btnNextQuestion.Text = "Submit Exam";
            }

            if (isCanClickNextQuestion)
            {
                new ExamService.ExamServiceClient().SaveExamAnswer(SessionUtil.User.Id, exam.Id, currentQuestion.Id, currentSelect);
                
                //load next question
                index++;
                
                if (index - 1 < exam.QuestionQuantity)
                {
                    currentQuestion = questions[index - 1];
                    this.lblQuestionIndex.Text = index.ToString();
                    this.lblCurrentPageNav.Text = index + "/" + exam.QuestionQuantity;
                    InitialQuestionRelateText(currentQuestion);
                }
                if (index == exam.QuestionQuantity + 1 ) {
                   //new ExamService.ExamServiceClient();
                }
                ClearSelectRadio(); 
            }
             
        }

        private void DoBtnNextQuestionOnMouseHover(object sender, EventArgs e)
        {

            if (CurrentSelectRadio() == -1)
            {
                this.btnNextQuestion.BackColor = Color.FromArgb(157, 157, 157);
            }     
        } 
    }
}
