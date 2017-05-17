using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESCommon
{
    public class Constants
    {
        public const string UserNoExit = "Username does not exist!";
        public const string UserNameIsRequired = "Username is required";
        public const string PasswordIsRequired = "Password is required!";
        public const string PasswordIncorrect = "Login password is incorrect!";
        public const string UserNameAndPasswordIsRequired = "Username and password is required";

        public const string DataFormatDateAndTime = "yyyy-MM-dd HH:mm:ss";
        public const string TimeSpanFormatWithDdHhMmSs = @"dd\:hh\:mm\:ss";
        public const string TimeSpanFormatWithHhMmSs = @"hh\:mm\:ss";
        public const string DateAppendTime = "23:59:59";

        public const string TipInputPassword = "please input password!";
        public const string TipInputSamePassword = "please input same password!";
        public const string TipInputKeyWords = "please input keywords!";

        public const string StudentExamListForm = "StudentExamListForm";
        public const string TeacherExamListForm = "TeacherExamListForm";

        public const string SortByUserName = "userName";
        public const string SortByResult = "result";
        public const string SortByUserScore = "score";
        public const string SortByExamId = "examId";
        public const string SortByExamTitle = "examTitle";
        public const string SortByExamStartTime = "examStartTime";
        public const string SortByExamPassScore = "examPassScore";
        public const string SortByExamOperation = "examOperation";
        public const string SortByExamScore = "examScore";
        public const string StringStudent = "student";
        public const string StringTeacher = "teacher";

        public const string ServerError = "Internal server error occured.";
        public const string CannotConnServer = "Can't connect to the server.";
        public const string NetworkTimeout = "Network timeout,try again later.";

        public const string DataBaseAddress = "Data Source=YT00701\\SQLEXPRESS;Initial Catalog=oes;Integrated Security=SSPI;";

        public const string NotConnectServer = "Can't connect to the server";
    }
}
