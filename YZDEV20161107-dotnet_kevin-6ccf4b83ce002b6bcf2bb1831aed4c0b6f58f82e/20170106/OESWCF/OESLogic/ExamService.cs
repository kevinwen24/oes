using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;
using System.Data.SqlClient;
using OESException;
using System.ServiceModel;
using OESCommon;
using log4net;

namespace OESLogic
{
    public class ExamService : IExamService
    {
        private ExamDal examDal = new ExamDal();
        private QuestionDal questionDal = new QuestionDal();
        private ILog log;

        public ExamService()
        {
            log = LogManager.GetLogger(this.GetType());
        }

        public List<Exam> StudentFindAllExam(Pagination pagination, int userId)
        {
            List<Exam> exams = null;
            try
            {
                exams = examDal.FindNeedUpdateScoreUserIdAndExamId();
                for (int i = 0; i < exams.Count; i++)
                {
                    examDal.UpdateResultWithNoExamineeUser(exams[i].Id, exams[i].UserId);
                }
                exams = examDal.StudentFindAllExam(pagination, userId);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
            return exams;
        }

        public List<Exam> TeacherFindAllExam(Pagination pagination)
        {
            List<Exam> exams = null;
            try
            {
                exams = examDal.FindNeedUpdateExam();
                double qualifiedCount = 0;
                double examineeCounnt = 0;

                for (int i = 0; i < exams.Count; i++ )
                {
                    qualifiedCount = examDal.GetQualifiedCountByExamId(exams[i].Id);
                    examineeCounnt = examDal.GetExamineeCountByExamId(exams[i].Id);
                    double passRate = Math.Round(qualifiedCount / examineeCounnt, 2) * 100;
                    examDal.UpdateAvgPassRate(exams[i].Id, exams[i].ExamAvgScore, passRate);
                }
                pagination.TotalCount = examDal.GetTeacherExamTotalCount(pagination);
                exams = examDal.TeacherFindAllExam(pagination);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
            return exams;
        }

        public Pagination GetStudentPagination(Pagination pagination, int userId)
        {
            try
            {
                pagination.TotalCount = examDal.GetStudentExamTotalCount(pagination.OtherType, userId);
                return pagination;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
        }

        public Pagination GetTeacherPagination(Pagination pagination)
        {
            try
            {
                pagination.TotalCount = examDal.GetTeacherExamTotalCount(pagination);
                return pagination;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }    
        }

        public void SaveExamAnswer(StoreAnswer storeAnswer)
        {
            try
            {
                int correctAnswer = questionDal.GetQuestionAnswerByQuestionId(storeAnswer.QuestionId);
                if (storeAnswer.Answer == correctAnswer)
                {
                    storeAnswer.AnswerScore = 1;
                }
                else
                {
                    storeAnswer.AnswerScore = 0;
                }
                examDal.SaveExamAnswer(storeAnswer);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
            
        }

        public List<int> SaveStudentTotalScore(StoreScore storeScore) 
        {
            try
            {
                List<int> results = new List<int>();
                Exam exam = examDal.GetExamByExamId(storeScore.ExamId);
                List<int> isCorrectAnswers = examDal.SelectStudentAnswerScore(storeScore.UserId, storeScore.ExamId);

                int correctNum = 0;
                for (int i = 0; i < isCorrectAnswers.Count; i++)
                {
                    if (isCorrectAnswers[i] == 1)
                    {
                        correctNum++;
                    }
                }

                storeScore.Score = correctNum * exam.SingleScore;

                if (storeScore.Score >= exam.PassScore)
                {
                    storeScore.Operation = "Pass";
                }

                else if (storeScore.Score < exam.PassScore)
                {
                    storeScore.Operation = "No pass";
                }
                examDal.SaveStudentTotalScore(storeScore);
                results.Add(storeScore.Score);
                results.Add(correctNum);
                return results;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
            
        }

        public List<int> SelectStudentSelfAnswer(int userId, int examId)
        {
            try
            {
                return examDal.SelectStudentSelfAnswer(userId, examId);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
        }

        public int GetStudentTotalScore(int userId, Exam exam)
        {
            try {
                List<int> isCorrectAnswers = examDal.SelectStudentAnswerScore(userId, exam.Id);

                int correctNum = 0;
                for (int i = 0; i < isCorrectAnswers.Count; i++)
                {
                    if (isCorrectAnswers[i] == 1)
                    {
                        correctNum++;
                    }
                }

                return correctNum * exam.SingleScore;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
        }

        public int GetQualifiedCountByExamId(int examId)
        {
            try
            {
                return examDal.GetQualifiedCountByExamId(examId);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
        }

        public int GetExamineeCountByExamId(int examId) 
        {
            try
            {
                return examDal.GetExamineeCountByExamId(examId);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
           
        }

        public List<Exam> FindAllStudentExamResultByExamId(Pagination pagination, int examId)
        {
            try
            {
                return examDal.FindAllStudentExamResultByExamId(pagination, examId);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }   
        }

        public Pagination GetStudentResultByExamIdPagination(Pagination pagination, int examId)
        {
            try
            {
                pagination.TotalCount = examDal.StudentResultByExamIdTotalCount(pagination, examId);
                return pagination;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
        }
    }
}
