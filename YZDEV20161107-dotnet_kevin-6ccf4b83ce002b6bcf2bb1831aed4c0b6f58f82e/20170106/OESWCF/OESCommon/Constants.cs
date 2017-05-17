using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESCommon
{
    public class Constants
    {
        public const string UserNoExit = "Username does not exist!";

        public const string DataFormatDateAndTime = "yyyy-MM-dd HH:mm:ss";
        public const string TimeSpanFormatWithDdHhMmSs = @"dd\:hh\:mm\:ss";
        public const string TimeSpanFormatWithHhMmSs = @"hh\:mm\:ss";

        public const string ServerError = "Internal server error occured.";

        public const string DataBaseAddress = "Data Source=YT00701\\SQLEXPRESS;Initial Catalog=oes;Integrated Security=SSPI;";

        public const string ProcGetUserByUserName = "procGetUserByUserName";
        public const string ProcUpdatePasswordByUserId = "procUpdatePasswordByUserId";
        public const string ProcGetQuestionsByExamId = "procGetQuestionsByExamId";
        public const string ProcGetQuestionAnswerByQuestionId = "procGetQuestionAnswerByQuestionId";
        public const string ProcStudentFindAllExam = "procStudentFindAllExam";
        public const string ProcSaveExamAnswer = "procSaveExamAnswer";
        public const string ProcGetExamByExamId = "procGetExamByExamId";
        public const string ProcSaveStudentScore = "procSaveStudentScore";
        public const string ProcSelectStudentAllAnswerScore = "procSelectStudentAllAnswerScore";
        public const string ProcSelectStudentSelfAnswer = "procSelectStudentSelfAnswer";
        public const string ProcGetStudentExamTotalCount = "procGetStudentExamTotalCount";
        public const string ProcTeacherFindAllExam = "procTeacherFindAllExam";
        public const string ProcGetQualifiedCountByExamId = "procGetQualifiedCountByExamId";
        public const string ProcGetExamineeCountByExamId = "procGetExamineeCountByExamId";
        public const string ProcGetTeacherExamTotalCount = "procGetTeacherExamTotalCount";
        public const string ProcFindAllStudentExamResultByExamId = "procFindAllStudentExamResultByExamId";
        public const string ProcStudentResultByExamIdTotalCount = "procStudentResultByExamIdTotalCount";
        public const string ProcFindNeedUpdateAvgRateExam = "procFindNeedUpdateAvgRateExam";
        public const string ProcUpdateAvgPassRate = "procUpdateAvgPassRate";
        public const string ProcUpdateResultWithNoExamineeUser = "procUpdateResultWithNoExamineeUser";
        public const string ProcFindNeedUpdateScoreUserIdAndExamId = "procFindNeedUpdateScoreUserIdAndExamId";

        public const string SqlParameterUserName = "@userName";
        public const string SqlParameterUserId = "@userId";
        public const string SqlParameterPassword = "@password";
        public const string SqlParameterExamId = "@examId";
        public const string SqlParameterQuestionId = "@questionId";
        public const string SqlParameterSortDirection = "@sortDirection";
        public const string SqlParameterSortName = "@sortName";
        public const string SqlParameterOtherType = "@otherType";
        public const string SqlParameterCurrentPage = "@currentPage";
        public const string SqlParameterPageSize = "@pageSize";
        public const string SqlParameterAnswer = "@answer";
        public const string SqlParameterAnswerScore = "@answerScore";
        public const string SqlParameterScore = "@score";
        public const string SqlParameterOperation = "@operation";
        public const string SqlParameterExamName = "@examName";
        public const string SqlParameterStartTime = "@startTime";
        public const string SqlParameterEndTime = "@endTime";
        public const string SqlParameterAvg = "@avg";
        public const string SqlParameterPassRate = "@pass_rate";

    }
}
