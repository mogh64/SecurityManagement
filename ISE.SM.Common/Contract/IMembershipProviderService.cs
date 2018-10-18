using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Common.Contract
{
     [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IMembershipProviderService : IServiceContract
    {
         [OperationContract]
         [Process]
         ResponseDto RegisterUser(UserDto userMember);
         [OperationContract]
         [Process]
         ResponseDto UnRegisterUser(UserDto userMember);
         [OperationContract]
         [Process]
         ResponseDto AssignAccountAppDomain(AccountDto account, int appDomain);
         [OperationContract]
         [Process]
         ResponseDto DeAssignAccountAppDomain(AccountDto account, int appDomain);
         [OperationContract]
         [Process]
         AccountDtoContainer GetUserAccounts(UserDto userMember);
         [OperationContract]
         [Process]
         AccountDto CreateAccount(AccountDto account, UserDto user);
         [OperationContract]
         [Process]
         ResponseDto DeleteAccount(AccountDto account);
         [OperationContract]
         [Process]
         ResponseDto UpdateAccount(AccountDto account);
         [OperationContract]
         [Process]
         AccountDto ChangePassword(string userName, string newPassword, string currentPassword);
         [OperationContract]
         [Process]
         AccountDto ResetPassword(string userName, long userId);
    }
}
