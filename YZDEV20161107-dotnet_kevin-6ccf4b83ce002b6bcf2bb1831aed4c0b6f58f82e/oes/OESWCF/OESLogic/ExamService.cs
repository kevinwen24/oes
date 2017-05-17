using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;

namespace OESLogic
{
    public class ExamService : IExamService
    {
        private ExamDal examDal = new ExamDal();

        public List<Exam> FindAllExam(Pagination pagination, int userId)
        {
            return examDal.FindAllExam(pagination,userId);
        }

        public void SaveExamAnswer(int userId, int examId, int questionId, int answer)
        {
            examDal.SaveExamAnswer(userId, examId, questionId,  answer);
        }
    }
}
