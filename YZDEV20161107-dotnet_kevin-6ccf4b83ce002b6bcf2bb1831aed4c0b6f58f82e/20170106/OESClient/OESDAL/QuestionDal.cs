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
                SqlCommand command = new SqlCommand("procGetQuestionsByExamId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@examId", examId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        question = new Question();
                        question.Id = reader[0] == null ? 0 : reader.GetInt32(0);
                        question.QuestionId = reader[1] == null ? string.Empty : reader.GetString(1);
                        question.Title = reader[2] == null ? string.Empty : reader.GetString(2);
                        question.OptionA = reader[3] == null ? string.Empty : reader.GetString(3);
                        question.OptionB = reader[4] == null ? string.Empty : reader.GetString(4);
                        question.OptionC = reader[5] == null ? string.Empty : reader.GetString(5);
                        question.OptionD = reader[6] == null ? string.Empty : reader.GetString(6);
                        question.Answer = reader[7] == null ? 0 : reader.GetInt32(7);
                        question.CreateTime = reader.GetDateTime(8).ToString(Constants.DataFormatDateAndTime);
                        question.UpdateTime = reader.GetDateTime(9).ToString(Constants.DataFormatDateAndTime);
                        question.IsActive = reader[10] == null ? 0 : reader.GetInt32(10);
                        questions.Add(question);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("data access error {0}", e.StackTrace);
                throw new DBException();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return questions;
        }
    }
}
