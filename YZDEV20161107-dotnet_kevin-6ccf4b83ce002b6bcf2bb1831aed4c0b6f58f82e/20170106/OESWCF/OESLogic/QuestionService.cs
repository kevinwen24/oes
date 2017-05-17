using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;

namespace OESLogic
{
    public class QuestionService  : IQuestionService
    {
        private QuestionDal questionDal = new QuestionDal();

        public List<Question> GetQuestionsByExamId(int examId) 
        {
            return questionDal.GetQuestionsByExamId(examId);
        }

        public int GetQuestionAnswerByQuestionId(int questionId)
        {
            return questionDal.GetQuestionAnswerByQuestionId(questionId);
        }

    }
}
