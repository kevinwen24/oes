using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using OESModel;
using OESException;

namespace OESLogic
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(DBException))]
        [FaultContract(typeof(ServiceException))]
        User VerifyUserLogin(string userName, string password);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        User GetUserByName(string userName);

        [OperationContract]
        [FaultContract(typeof(DBException))]
        void ModifyPassword(int userId, string password);
    }
}
