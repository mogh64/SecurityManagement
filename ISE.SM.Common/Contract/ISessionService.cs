﻿using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Contract
{
     [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface ISessionService : IServiceContract
    {
        [OperationContract]
        [Process]
        SecuritySessionDtoContainer GetOnlineUsers(int appdomainId); // if set 0 users for all appdomains returns
    }
}
