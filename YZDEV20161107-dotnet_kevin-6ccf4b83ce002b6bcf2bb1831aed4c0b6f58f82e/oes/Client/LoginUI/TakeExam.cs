using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;

namespace LoginUI
{
    public partial class TakeExam : BaseWindowForm
    {
        private Exam exam;

        public TakeExam(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            this.lblContentId.Text = exam.ExamId;
            this.lblContentName.Text = exam.Title;
            this.lblContentQuantity.Text = exam.QuestionQuantity.ToString();
            this.lblContentEffTime.Text = exam.StartTime;
            this.lblContentEndTime.Text = "";
            this.lblContentTotalScore.Text = exam.TotalScore.ToString();
            this.lblContentEndTime.Text = (Convert.ToDateTime(exam.StartTime).AddMinutes(exam.DuringTime)).ToString();
            this.lblContentDurationTime.Text = exam.DuringTime.ToString();

        }

        private void DoLblRestTimeOnTick(object sender, EventArgs e)
        {
            DateTime startTime =  Convert.ToDateTime(exam.StartTime);
            if (DateTime.Now > startTime)
            {
                this.TmrClock.Stop();
                this.TmrClock.Enabled = false;
            }
  
            TimeSpan timeSpan = startTime.Subtract(DateTime.Now);
            this.lblRestTime.Text = timeSpan.ToString(@"dd\:hh\:mm\:ss");
            Console.WriteLine(timeSpan.TotalSeconds);
            if (timeSpan.TotalSeconds <  -60*exam.DuringTime)
            {
                 //showMsg();
                Console.WriteLine("已经过了考试时间");
            }

            //考试范围内
            if (timeSpan.TotalSeconds > -60 * exam.DuringTime * exam.DuringTime && timeSpan.TotalSeconds <= 0)
            {
                 //进入考试

            }
        }

        private void DoBtnReturnOnClick(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["ExamListForm"].Show();
        }

        private void DoBtnStartTestingOnClick(object sender, EventArgs e)
        {
            this.Hide();
            new TestExam(exam).Show();
        }

     
    }
}
