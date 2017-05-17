using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESLogic
{
    public class LogicException : Exception
    {
        private string msg;

        public LogicException(string msg)
        {
            this.msg = msg;
        }

        public string getMsg()
        {
            return msg;
        }
    }
}
