using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESException
{
    [DataContract]
    public class DBException
    {
        [DataMember]
        private string msg;

        public DBException() { }

        public DBException(string msg)
        {
            this.msg = msg;
        }

        public string getMsg()
        {
            return msg;
        }
    }
}
