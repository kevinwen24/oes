using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OESModel;
using OESException;
using OESCommon;
using OESUtil;
using OESCommon;

namespace OESDal
{
    public class ExamDal
    {

        public List<Exam> StudentFindAllExam(Pagination pagination, int userId)
        {
            List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcStudentFindAllExam, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortDirection, pagination.SortDirection));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortName, pagination.SortName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterOtherType, pagination.OtherType));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterCurrentPage, pagination.CurrentPage));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterPageSize, pagination.PageSize));
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        exam.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        exam.ExamId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        exam.Title = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        exam.CreateTime = reader.GetDateTime(3).ToString(Constants.DataFormatDateAndTime);
                        exam.StartTime = reader.GetDateTime(4).ToString(Constants.DataFormatDateAndTime);
                        exam.DuringTime = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                        exam.TotalScore = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        exam.PassScore = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        exam.SingleScore = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        exam.QuestionQuantity = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        exam.Score = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                        exam.Operation = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        exam.RowNum = reader.IsDBNull(12) ? 0 : reader.GetInt64(12);
                        exams.Add(exam);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
  
            return exams;
        }

        public void SaveExamAnswer(StoreAnswer storeAnswer)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcSaveExamAnswer, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, storeAnswer.UserId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, storeAnswer.ExamId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterQuestionId, storeAnswer.QuestionId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterAnswer, storeAnswer.Answer));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterAnswerScore, storeAnswer.AnswerScore));
                command.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }
        /// <summary>
        /// select exam by examId
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        public Exam GetExamByExamId(int examId)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();
            Exam exam = null;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetExamByExamId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        exam = new Exam();
                        exam.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        exam.ExamId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        exam.Title = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        exam.CreateTime = reader.GetDateTime(3).ToString(Constants.DataFormatDateAndTime);
                        exam.StartTime = reader.GetDateTime(4).ToString(Constants.DataFormatDateAndTime);
                        exam.DuringTime = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                        exam.TotalScore = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        exam.PassScore = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        exam.SingleScore = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        exam.QuestionQuantity = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);                     
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return exam;
        }

        public void SaveStudentTotalScore(StoreScore storeScore)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcSaveStudentScore, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, storeScore.UserId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, storeScore.ExamId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterScore, storeScore.Score));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterOperation, storeScore.Operation));
                command.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }
        /// <summary>
        /// select student answer is correct or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        public List<int> SelectStudentAnswerScore(int userId, int examId)
        {
            List<int> answers = new List<int>();
            int answer = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcSelectStudentAllAnswerScore, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        answer = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                        answers.Add(answer);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return answers;
        }
        /// <summary>
        /// select student answer list
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="examId"></param>
        /// <returns>List<int></returns>
        public List<int> SelectStudentSelfAnswer(int userId, int examId)
        {
            List<int> answers = new List<int>();
            int answer = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcSelectStudentSelfAnswer, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        answer = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                        answers.Add(answer);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return answers;
        }
        /// <summary>
        /// Get student exam list total count
        /// </summary>
        /// <param name="otherType"></param>
        /// <param name="userId"></param>
        /// <returns>total count</returns>
        public int GetStudentExamTotalCount(string otherType, int userId)
        {
            int totalCount = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetStudentExamTotalCount, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterOtherType, otherType));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return totalCount;
        }

        public List<Exam> TeacherFindAllExam(Pagination pagination)
        {
            List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcTeacherFindAllExam, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortDirection, pagination.SortDirection));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortName, pagination.SortName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamName, pagination.ExamName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterCurrentPage, pagination.CurrentPage));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterPageSize, pagination.PageSize));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterStartTime, pagination.StartTime));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterEndTime, pagination.EndTime));
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        exam.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        exam.ExamId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        exam.Title = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        exam.StartTime = reader.GetDateTime(3).ToString(Constants.DataFormatDateAndTime); 
                        exam.QuestionQuantity = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        exam.ExamAvgScore = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);
                        exam.ExamPassRate = reader.IsDBNull(6) ? 0 : reader.GetDouble(6);
                        exam.RowNum = reader.IsDBNull(7) ? 0 : reader.GetInt64(7);
                        exams.Add(exam);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }

            return exams;
        }

        public int GetQualifiedCountByExamId(int examId)
        {
            int qualifiedCount = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetQualifiedCountByExamId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        qualifiedCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return qualifiedCount;
        }

        public int GetExamineeCountByExamId(int examId)
        {
            int examineeCount = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetExamineeCountByExamId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        examineeCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return examineeCount;
        }

        public int GetTeacherExamTotalCount(Pagination pagination)
        {
            int totalCount = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetTeacherExamTotalCount, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamName, pagination.ExamName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterStartTime, pagination.StartTime));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterEndTime, pagination.EndTime));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return totalCount;
        }

        public List<Exam> FindAllStudentExamResultByExamId(Pagination pagination,int examId)
        {
            List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcFindAllStudentExamResultByExamId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortDirection, pagination.SortDirection));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortName, pagination.SortName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserName, pagination.UserName));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterCurrentPage, pagination.CurrentPage));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterPageSize, pagination.PageSize));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        exam.UserName = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        exam.PassScore = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        exam.Score = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        exam.TotalScore = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        exam.Operation = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        exam.RowNum = reader.IsDBNull(5) ? 0 : reader.GetInt64(5);
                        exams.Add(exam);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }

            return exams;
        }

        public int StudentResultByExamIdTotalCount(Pagination pagination, int examId)
        {
            int totalCount = 0;
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcStudentResultByExamIdTotalCount, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserName, pagination.UserName));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return totalCount;
        }

        public List<Exam> FindNeedUpdateExam()
        {
            List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcFindNeedUpdateAvgRateExam, connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        double avg = Math.Round( reader.IsDBNull(0) ? 0 : reader.GetDouble(0));
                        exam.ExamAvgScore = avg;
                        exam.Id = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        exams.Add(exam);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }

            return exams;
        }

        public void UpdateAvgPassRate(int examId, double avg, double passRate)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcUpdateAvgPassRate, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterAvg, avg));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterPassRate, passRate));
                command.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }

        public List<Exam> FindNeedUpdateScoreUserIdAndExamId()
        { 
             List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcFindNeedUpdateScoreUserIdAndExamId, connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        exam.UserId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        exam.Id = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        exams.Add(exam);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }

            return exams;
        }

        public void UpdateResultWithNoExamineeUser(int examId, int userId)
        { 
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcUpdateResultWithNoExamineeUser, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));
                command.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }
    }
}
