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
    public partial class ExamStudentResultDataLineControl : UserControl
    {
        private Exam exam;

        public ExamStudentResultDataLineControl(Exam exam)
        {
            this.exam = exam;
            InitializeComponent();
            InitializeShowText();
        }

        private void InitializeShowText()
        {
            this.lblContentIndex.Text = exam.RowNum.ToString();
            this.lblContentUserName.Text = exam.UserName;
            this.lblContentPassScore.Text = exam.PassScore.ToString();
            this.lblContentRate.Text = exam.Score + "/" + exam.TotalScore;
            this.lblContentResult.Text = exam.Operation;
        }

    }
}
