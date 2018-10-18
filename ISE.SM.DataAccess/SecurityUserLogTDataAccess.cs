using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class SecurityUserLogTDataAccess : TDataAccess<SecurityUserLog, SecurityUserLogDto, SecurityUserLogRepository>
    {
        public SecurityUserLogTDataAccess()
            : base(new SecurityUserLogRepository())
        {
        }
    }
}
