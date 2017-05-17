using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using System.Collections.Generic;
using OESDal;
using OESModel;

namespace OESLogic
{
    public class QuestionManager
    {
        public List<Question> GetQuestionsByExamId(int examId) 
        {
            return new QuestionDal().GetQuestionsByExamId(examId);
        }
    }
}
