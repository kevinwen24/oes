using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;
using System.ServiceModel;

namespace OESLogic
{
    [ServiceContract(Namespace = "localhost:8888/OESLogic")]
    public interface IExamService
    {
        [OperationContract]
        List<Exam> FindAllExam(Pagination pagination, int userId);

        [OperationContract]
        void SaveExamAnswer(int userId, int examId, int questionId, int answer);
    }
}
