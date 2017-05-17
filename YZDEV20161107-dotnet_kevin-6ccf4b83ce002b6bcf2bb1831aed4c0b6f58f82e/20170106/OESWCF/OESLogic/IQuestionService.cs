using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;
using System.ServiceModel;

namespace OESLogic
{
    [ServiceContract]
    public interface IQuestionService
    {
        [OperationContract]
        List<Question> GetQuestionsByExamId(int examId);

        [OperationContract]
        int GetQuestionAnswerByQuestionId(int questionId);
    }
}
