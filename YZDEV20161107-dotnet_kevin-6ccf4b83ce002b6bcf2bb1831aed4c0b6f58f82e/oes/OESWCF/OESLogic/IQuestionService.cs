using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;
using System.ServiceModel;

namespace OESLogic
{
    [ServiceContract(Namespace = "localhost:8888/OESLogic")]
    public interface IQuestionService
    {
        [OperationContract]
        List<Question> GetQuestionsByExamId(int examId);  
    }
}
