using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class StoreScore
    {
        [DataMember]
        public int UserId { set; get; }
        [DataMember]
        public int ExamId { set; get; }
        [DataMember]
        public int Score { set; get; }
        [DataMember]
        public string Operation { set; get; }
    }
}
