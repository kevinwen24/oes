using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESModel;
using OESCommon;

namespace OESUI.customer
{
    public partial class NoticeDataLineControl : UserControl
    {
        private Exam exam;
        private int index;
        private string date = "exam on ";

        public NoticeDataLineControl(Exam exam, int index)
        {
            this.exam = exam;
            this.index = index;
            InitializeComponent();
            InitializeShowTextContent();
        }

        private void InitializeShowTextContent()
        {
            this.lblLineIndex.Text = index + ". ";
            this.lblLineExamName.Text ="\"" + exam.Title + "\"";
            date += exam.StartTime.Substring(0,10) + " at ";
            date += exam.StartTime.Substring(11, 5);
            this.lblRestDateInfo.Text = date + ".";
            index++;
        }

        private void DoLblLineExamNameOnClick(object sender, EventArgs e)
        {
            Application.OpenForms[Constants.StudentExamListForm].Hide();
            TakeExam takeExam = new TakeExam(exam);
            takeExam.ShowDialog();
        }
    }
}
