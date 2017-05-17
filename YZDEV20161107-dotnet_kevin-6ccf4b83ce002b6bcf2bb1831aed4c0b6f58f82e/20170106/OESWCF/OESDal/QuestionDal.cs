using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using OESModel;
using OESUtil;
using OESCommon;
using OESException;
using OESCommon;

namespace OESDal
{
    public class QuestionDal
    {
        public List<Question> GetQuestionsByExamId(int examId) 
        {
            List<Question> questions = new List<Question>();
            Question question = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetQuestionsByExamId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterExamId, examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        question = new Question();
                        question.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        question.QuestionId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        question.Title = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        question.OptionA = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        question.OptionB = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        question.OptionC = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        question.OptionD = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        question.Answer = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        question.CreateTime = reader.GetDateTime(8).ToString(Constants.DataFormatDateAndTime);
                        question.UpdateTime = reader.GetDateTime(9).ToString(Constants.DataFormatDateAndTime);
                        question.IsActive = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                        questions.Add(question);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return questions;
        }

        public int GetQuestionAnswerByQuestionId(int questionId)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();
            int answer = 0;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetQuestionAnswerByQuestionId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterQuestionId, questionId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       answer = reader[0] == null ? 0 : reader.GetInt32(0);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return answer;
        }
    }
}
