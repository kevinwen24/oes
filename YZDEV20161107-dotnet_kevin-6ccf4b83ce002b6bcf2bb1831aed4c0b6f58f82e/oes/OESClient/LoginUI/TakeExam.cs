using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESCommon;

namespace OESUI
{
    public partial class TakeExam : BaseWindowForm
    {
        private Exam exam;
        private bool isCanTestExam = false;

        public TakeExam(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            this.lblContentId.Text = exam.ExamId;
            this.lblContentName.Text = exam.Title;
            this.lblContentQuantity.Text = exam.QuestionQuantity.ToString();
            this.lblContentEffTime.Text = exam.StartTime;
            this.lblContentTotalScore.Text = exam.TotalScore.ToString();
            this.lblContentEndTime.Text = (Convert.ToDateTime(exam.StartTime).AddMinutes(exam.DuringTime)).ToString();
            this.lblContentDurationTime.Text = exam.DuringTime.ToString();

        }

        private void DoLblRestTimeOnTick(object sender, EventArgs e)
        {
            DateTime startTime =  Convert.ToDateTime(exam.StartTime);
            if (DateTime.Now > startTime)
            {
                this.tmrClock.Stop();
                this.tmrClock.Enabled = false;
            }

          
            TimeSpan timeSpan = startTime.Subtract(DateTime.Now);
            this.lblRestTime.Text = timeSpan.ToString(Constants.TimeSpanFormatWithDdHhMmSs);

            if (timeSpan.TotalSeconds > 0)
            {
                this.lblStartTesting.BackColor = Color.FromArgb(151,151,151);
                this.rtsStartTesting.BorderColor = Color.FromArgb(151, 151, 151);
            }

            //in testing exam time range
            if (timeSpan.TotalSeconds > -60 * exam.DuringTime * exam.DuringTime && timeSpan.TotalSeconds <= 0)
            {
                 //attend exam
                this.lblStartTesting.BackColor = Color.FromArgb(254, 153, 0);
                this.rtsStartTesting.BorderColor = Color.FromArgb(254, 153, 0);
                isCanTestExam = true;
            }
        }

        public override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }

        private void DoLblReturnOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[Constants.StudentExamListForm].Show();
        }

        private void DoLblStartTestingOnClick(object sender, EventArgs e)
        {
            
            //if (isCanTestExam) 
            //{
                this.Hide();
                new TestExam(exam).Show();
           // }
        }
    }
}
