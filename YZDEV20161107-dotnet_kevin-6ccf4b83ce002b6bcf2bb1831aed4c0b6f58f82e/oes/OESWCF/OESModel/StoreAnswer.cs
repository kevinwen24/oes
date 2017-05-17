using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class StoreAnswer
    {
        [DataMember]
        public int UserId { set; get; }
        [DataMember]
        public int ExamId { set; get; }
        [DataMember]
        public  int QuestionId   { set; get; }
        [DataMember]
        public int Answer   { set; get; }
        [DataMember]
        public int AnswerScore { set; get; }
    }
}
