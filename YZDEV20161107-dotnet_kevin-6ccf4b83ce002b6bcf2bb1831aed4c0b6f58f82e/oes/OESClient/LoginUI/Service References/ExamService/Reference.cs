﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OESUI.ExamService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExamService.IExamService")]
    public interface IExamService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/StudentFindAllExam", ReplyAction="http://tempuri.org/IExamService/StudentFindAllExamResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/StudentFindAllExamDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        System.Collections.Generic.List<OESModel.Exam> StudentFindAllExam(OESModel.Pagination pagination, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/SaveExamAnswer", ReplyAction="http://tempuri.org/IExamService/SaveExamAnswerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/SaveExamAnswerDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        void SaveExamAnswer(OESModel.StoreAnswer storeAnswer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/SaveStudentTotalScore", ReplyAction="http://tempuri.org/IExamService/SaveStudentTotalScoreResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/SaveStudentTotalScoreDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        System.Collections.Generic.List<int> SaveStudentTotalScore(OESModel.StoreScore storeScore);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/SelectStudentSelfAnswer", ReplyAction="http://tempuri.org/IExamService/SelectStudentSelfAnswerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/SelectStudentSelfAnswerDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        System.Collections.Generic.List<int> SelectStudentSelfAnswer(int userId, int examId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetStudentTotalScore", ReplyAction="http://tempuri.org/IExamService/GetStudentTotalScoreResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/GetStudentTotalScoreDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        int GetStudentTotalScore(int userId, OESModel.Exam exam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/TeacherFindAllExam", ReplyAction="http://tempuri.org/IExamService/TeacherFindAllExamResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/TeacherFindAllExamDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        System.Collections.Generic.List<OESModel.Exam> TeacherFindAllExam(OESModel.Pagination pagination);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetStudentPagination", ReplyAction="http://tempuri.org/IExamService/GetStudentPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/GetStudentPaginationDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        OESModel.Pagination GetStudentPagination(OESModel.Pagination pagination, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetTeacherPagination", ReplyAction="http://tempuri.org/IExamService/GetTeacherPaginationResponse")]
        OESModel.Pagination GetTeacherPagination(OESModel.Pagination pagination);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetQualifiedCountByExamId", ReplyAction="http://tempuri.org/IExamService/GetQualifiedCountByExamIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/GetQualifiedCountByExamIdDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        int GetQualifiedCountByExamId(int examId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetExamineeCountByExamId", ReplyAction="http://tempuri.org/IExamService/GetExamineeCountByExamIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/GetExamineeCountByExamIdDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        int GetExamineeCountByExamId(int examId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/FindAllStudentExamResultByExamId", ReplyAction="http://tempuri.org/IExamService/FindAllStudentExamResultByExamIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/FindAllStudentExamResultByExamIdDBExceptionFault", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        System.Collections.Generic.List<OESModel.Exam> FindAllStudentExamResultByExamId(OESModel.Pagination pagination, int examId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetStudentResultByExamIdPagination", ReplyAction="http://tempuri.org/IExamService/GetStudentResultByExamIdPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(OESException.DBException), Action="http://tempuri.org/IExamService/GetStudentResultByExamIdPaginationDBExceptionFaul" +
            "t", Name="DBException", Namespace="http://schemas.datacontract.org/2004/07/OESException")]
        OESModel.Pagination GetStudentResultByExamIdPagination(OESModel.Pagination pagination, int examId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExamServiceChannel : OESUI.ExamService.IExamService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExamServiceClient : System.ServiceModel.ClientBase<OESUI.ExamService.IExamService>, OESUI.ExamService.IExamService {
        
        public ExamServiceClient() {
        }
        
        public ExamServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExamServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExamServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExamServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<OESModel.Exam> StudentFindAllExam(OESModel.Pagination pagination, int userId) {
            return base.Channel.StudentFindAllExam(pagination, userId);
        }
        
        public void SaveExamAnswer(OESModel.StoreAnswer storeAnswer) {
            base.Channel.SaveExamAnswer(storeAnswer);
        }
        
        public System.Collections.Generic.List<int> SaveStudentTotalScore(OESModel.StoreScore storeScore) {
            return base.Channel.SaveStudentTotalScore(storeScore);
        }
        
        public System.Collections.Generic.List<int> SelectStudentSelfAnswer(int userId, int examId) {
            return base.Channel.SelectStudentSelfAnswer(userId, examId);
        }
        
        public int GetStudentTotalScore(int userId, OESModel.Exam exam) {
            return base.Channel.GetStudentTotalScore(userId, exam);
        }
        
        public System.Collections.Generic.List<OESModel.Exam> TeacherFindAllExam(OESModel.Pagination pagination) {
            return base.Channel.TeacherFindAllExam(pagination);
        }
        
        public OESModel.Pagination GetStudentPagination(OESModel.Pagination pagination, int userId) {
            return base.Channel.GetStudentPagination(pagination, userId);
        }
        
        public OESModel.Pagination GetTeacherPagination(OESModel.Pagination pagination) {
            return base.Channel.GetTeacherPagination(pagination);
        }
        
        public int GetQualifiedCountByExamId(int examId) {
            return base.Channel.GetQualifiedCountByExamId(examId);
        }
        
        public int GetExamineeCountByExamId(int examId) {
            return base.Channel.GetExamineeCountByExamId(examId);
        }
        
        public System.Collections.Generic.List<OESModel.Exam> FindAllStudentExamResultByExamId(OESModel.Pagination pagination, int examId) {
            return base.Channel.FindAllStudentExamResultByExamId(pagination, examId);
        }
        
        public OESModel.Pagination GetStudentResultByExamIdPagination(OESModel.Pagination pagination, int examId) {
            return base.Channel.GetStudentResultByExamIdPagination(pagination, examId);
        }
    }
}
