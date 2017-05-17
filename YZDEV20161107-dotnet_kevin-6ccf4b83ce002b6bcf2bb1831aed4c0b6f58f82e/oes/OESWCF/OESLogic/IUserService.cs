using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace OESLogic
{
    [ServiceContract(Namespace = "localhost:8888/OESLogic")]
    public interface IUserService
    {
        [OperationContract]
        bool verifyUserLogin(string userName, string password);    
    }
}
