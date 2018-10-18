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
    public class UserToGroupTDataAccess : TDataAccess<UserToGroup, UserToGroupDto, UserToGroupRepository>
    {
        public UserToGroupTDataAccess()
            : base(new UserToGroupRepository())
        {
        }
    }
}
