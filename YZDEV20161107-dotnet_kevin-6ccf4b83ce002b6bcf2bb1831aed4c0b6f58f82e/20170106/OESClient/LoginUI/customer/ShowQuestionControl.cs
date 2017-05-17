using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;

namespace OESUI.customer
{
    public partial class ShowQuestionControl : UserControl
    {
        private Question question;
        private int studentAnswer;
        private int index;
        private List<Label> labelRadios;
        private List<Label> labelOptions;
        private Pagination pagination;

        public ShowQuestionControl(Question question, int studentAnswer, int index)
        {
            InitializeComponent();
            this.question = question;
            this.studentAnswer = studentAnswer;
            this.index = index + 1;
            labelRadios = InitializeRadioList();
            labelOptions = InitializeQuestionOptionList();
            InitializeText(question, studentAnswer);
         
        }

        private void InitializeText(Question question, int studentAnswer)
        {
            if (studentAnswer == question.Answer)
            {
                this.lblIsCorrectPic.ImageIndex = 1; 
            }
            else
            {
                this.lblIsCorrectPic.ImageIndex = 0;
                this.rtsIndex.BorderColor = Color.FromArgb(255, 0, 0);
            }

            SelectStudentAnswer(studentAnswer, question.Answer);
            this.lblQuestionIndex.Text = index.ToString();
            this.lblQuestionTitle.Text = question.Title;
            this.lblContentQuestionA.Text = "A  " + question.OptionA;
            this.lblContentQuestionB.Text = "B  " + question.OptionB;
            this.lblContentQuestionC.Text = "C  " + question.OptionC;
            this.lblContentQuestionD.Text = "D  " + question.OptionD;
                             
        }

        private List<Label> InitializeRadioList() 
        {
            List<Label> labels = new List<Label>();
            labels.Add(this.lblTitleQuestionA);
            labels.Add(this.lblTitleQuestionB);
            labels.Add(this.lblTitleQuestionC);
            labels.Add(this.lblTitleQuestionD);
            return labels;
        }

        private List<Label> InitializeQuestionOptionList()
        {
            List<Label> labels = new List<Label>();
            labels.Add(this.lblContentQuestionA);
            labels.Add(this.lblContentQuestionB);
            labels.Add(this.lblContentQuestionC);
            labels.Add(this.lblContentQuestionD);
            return labels;
        }

        private void SelectStudentAnswer(int studentAnswer, int answer)
        {
            labelRadios[studentAnswer].ImageIndex = 1;
            labelOptions[answer].BackColor = Color.FromArgb(210, 218, 227);
        }

        private void ShowQuestionControl_Load(object sender, EventArgs e)
        {

        }

        private void lblContentQuestionA_Click(object sender, EventArgs e)
        {

        }
      
    }
}
