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
        public List<Question> GetQuestionsByExamId(int examId) 
        {
            return new QuestionDal().GetQuestionsByExamId(examId);
        }
    }
}
