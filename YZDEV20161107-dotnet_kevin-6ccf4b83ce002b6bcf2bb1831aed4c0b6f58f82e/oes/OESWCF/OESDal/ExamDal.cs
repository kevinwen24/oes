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

namespace OESDal
{
    public class ExamDal
    {
        public List<Exam> FindAllExam(Pagination pagination, int userId)
        {
            List<Exam> exams = new List<Exam>();
            Exam exam = null;

            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("procFindAllExam", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@sortDirection", pagination.SortDirection));
                command.Parameters.Add(new SqlParameter("@sortName", pagination.SortName));
                command.Parameters.Add(new SqlParameter("@otherType", pagination.OtherType));
                command.Parameters.Add(new SqlParameter("@userId", userId));
                command.Parameters.Add(new SqlParameter("@offset", pagination.Offset));
                command.Parameters.Add(new SqlParameter("@pageSize", pagination.PageSize));
               

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exam = new Exam();
                        exam.Id = reader[0] == null ? 0 : reader.GetInt32(0);
                        exam.ExamId = reader[1] == null ? string.Empty : reader.GetString(1);
                        exam.Title = reader[2] == null ? string.Empty : reader.GetString(2);
                        exam.CreateTime = reader.GetDateTime(3).ToString(Constants.DataFormatDateAndTime);
                        exam.StartTime = reader.GetDateTime(4).ToString(Constants.DataFormatDateAndTime);
                        exam.DuringTime = reader[5] == null ? 0 : reader.GetInt32(5);
                        exam.TotalScore = reader[6] == null ? 0 : reader.GetInt32(6);
                        exam.PassScore = reader[7] == null ? 0 : reader.GetInt32(7);
                        exam.SingleScore = reader[8] == null ? 0 : reader.GetInt32(8);
                        exam.QuestionQuantity = reader[9] == null ? 0 : reader.GetInt32(9);
                        exam.Score = reader[10] ==null ? 0 : reader.GetInt32(10);
                        exam.Operation = reader[11] == null ? string.Empty : reader.GetString(11);
                        exam.RowNum = reader[12] == null ? 0 : reader.GetInt64(12);
                        exams.Add(exam);
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
            return exams;
        }

        public void SaveExamAnswer(int userId, int examId, int questionId, int answer)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("procSaveExamAnswer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userId", userId));
                command.Parameters.Add(new SqlParameter("@examId", examId));
                command.Parameters.Add(new SqlParameter("@questionId", questionId));
                command.Parameters.Add(new SqlParameter("@answer", answer));
                command.ExecuteNonQuery();
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
        }
    }
}
