using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OESLogic;

namespace OESWCF
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHost userServiceHost = new ServiceHost(typeof(UserService));
            userServiceHost.Open();
            Console.WriteLine("UserService starting......");

            ServiceHost questionServiceHost = new ServiceHost(typeof(QuestionService));
            questionServiceHost.Open();
            Console.WriteLine("QuestionService starting......");

            ServiceHost examServiceHost = new ServiceHost(typeof(ExamService));
            examServiceHost.Open();
            Console.WriteLine("ExamService starting......");

            Console.Read();
        }
    }
}
