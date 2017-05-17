using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;

namespace LoginUI.customer
{
    public partial class DataLineControl : UserControl
    {
        private Exam exam;

        public DataLineControl(Exam exam)
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
            if (this.lblExamOperation.Text.Trim() == "Do it")
            {
                Application.OpenForms["ExamListForm"].Hide();
                new TakeExam(exam).ShowDialog();
            }
        }

        private void DoLblOperationOnMouseHover(object sender, EventArgs e)
        {
            if (this.lblExamOperation.Text.Trim() == "Do it")
            {
                this.lblExamOperation.Cursor = Cursors.Hand; 
            }
        }

    }
}
