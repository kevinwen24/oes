using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;
using System.ServiceModel;
using OESException;

namespace OESLogic
{
    [ServiceContract]
    public interface IExamService
    {
        [OperationContract]
        [FaultContract(typeof(DBException))]
        List<Exam> StudentFindAllExam(Pagination pagination, int userId);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        void SaveExamAnswer(StoreAnswer storeAnswer);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        List<int> SaveStudentTotalScore(StoreScore storeScore);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        List<int> SelectStudentSelfAnswer(int userId, int examId);
 
        [OperationContract]
        [FaultContract(typeof(DBException))]
        int GetStudentTotalScore(int userId, Exam exam);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        List<Exam> TeacherFindAllExam(Pagination pagination);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        Pagination GetStudentPagination(Pagination pagination, int userId);
        
        [OperationContract]
        Pagination GetTeacherPagination(Pagination pagination);
        
        [OperationContract]
        [FaultContract(typeof(DBException))]
        int GetQualifiedCountByExamId(int examId);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        int GetExamineeCountByExamId(int examId);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        List<Exam> FindAllStudentExamResultByExamId(Pagination pagination, int examId);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        Pagination GetStudentResultByExamIdPagination(Pagination pagination, int examId);
    }
}
