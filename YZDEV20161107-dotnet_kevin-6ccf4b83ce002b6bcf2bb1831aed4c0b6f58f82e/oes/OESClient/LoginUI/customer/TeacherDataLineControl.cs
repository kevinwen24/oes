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
    public partial class TeacherDataLineControl : UserControl
    {
        private Exam exam;
        private ExamService.ExamServiceClient client = new ExamService.ExamServiceClient();
        public TeacherDataLineControl(Exam exam)
        {
            this.exam = exam;
            InitializeComponent();
            InitializeShowText();
        }

        private void InitializeShowText()
        {
            this.lblExamIndex.Text = exam.RowNum.ToString();
            this.lblExamName.Text = exam.Title;
            this.lblExamId.Text = exam.ExamId;
            this.lblExamStartTime.Text = exam.StartTime;
            this.lblExamTotalQuantity.Text = exam.QuestionQuantity.ToString();
            this.lblExamAvg.Text = exam.ExamAvgScore.ToString();
            this.lblExamExamineeCount.Text = client.GetExamineeCountByExamId(exam.Id).ToString();
            this.lblExamQualifiedCount.Text = client.GetQualifiedCountByExamId(exam.Id).ToString();
            this.lblExamPassRate.Text = exam.ExamPassRate + "%";
        }

        private void DoLblExamNameOnClick(object sender, EventArgs e)
        {
            ExamStudentResult examStudentResult = new ExamStudentResult(exam.Id);
            examStudentResult.ShowDialog();
        }

      
    }
}
