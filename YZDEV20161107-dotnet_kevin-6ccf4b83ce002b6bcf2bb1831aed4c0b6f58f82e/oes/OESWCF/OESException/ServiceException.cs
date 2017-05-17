using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESLogic
{
    [DataContract]
    public class ServiceException
    {
        [DataMember]
        private string msg;

        public ServiceException(string msg)
        {
            this.msg = msg;
        }

        public string getMsg()
        {
            return msg;
        }
    }
}
