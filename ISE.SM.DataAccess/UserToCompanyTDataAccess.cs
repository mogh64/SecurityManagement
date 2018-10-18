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
    public class UserToCompanyTDataAccess : TDataAccess<UserToCompany, UserToCompanyDto, UserToCompanyRepository>
    {
        public UserToCompanyTDataAccess()
            : base(new UserToCompanyRepository())
        {
        }
    }
}
