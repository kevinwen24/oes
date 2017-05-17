using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string QuestionId { set; get; }
        [DataMember]
        public string Title { set; get; }
        [DataMember]
        public string OptionA { set; get; }
        [DataMember]
        public string OptionB { set; get; }
        [DataMember]
        public string OptionC { set; get; }
        [DataMember]
        public string OptionD { set; get; }
        [DataMember]
        public int Answer { set; get; }
        [DataMember]
        public string CreateTime { set; get; }
        [DataMember]
        public string UpdateTime { set; get; }
        [DataMember]
        public int IsActive { set; get; }

    }
}
