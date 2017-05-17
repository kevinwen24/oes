using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class Exam
    {
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string ExamId { set; get; }
        [DataMember]
        public string Title { set; get; }
        [DataMember]
        public string CreateTime { set; get; }
        [DataMember]
        public string StartTime { set; get; }
        [DataMember]
        public int DuringTime { set; get; }
        [DataMember]
        public int TotalScore { set; get; }
        [DataMember]
        public int PassScore { set; get; }
        [DataMember]
        public int SingleScore { set; get; }
        [DataMember]
        public int QuestionQuantity { set; get; }
        [DataMember]
        public int CreateUser { set; get; }
        [DataMember]
        public int Score { set; get; }
        [DataMember]
        public long RowNum { set; get; }
        [DataMember]
        public string Operation { set; get; }
        [DataMember]
        public double ExamAvgScore { set; get; }
        [DataMember]
        public double ExamPassRate { set; get; }
        [DataMember]
        public string UserName { set; get; }
        [DataMember]
        public int UserId { set; get; }
    }
}
