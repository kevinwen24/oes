using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESModel
{
    public class Exam
    {
        public int Id { set; get; }

        public string ExamId { set; get; }

        public string Title { set; get; }

        public string CreateTime { set; get; }

        public string StartTime { set; get; }

        public int DuringTime { set; get; }

        public int TotalScore { set; get; }

        public int PassScore { set; get; }

        public int SingleScore { set; get; }

        public int QuestionQuantity { set; get; }

        public int CreateUser { set; get; }

        public int Score { set; get; }

        public long RowNum { set; get; }

        public string Operation { set; get; }
    }
}
