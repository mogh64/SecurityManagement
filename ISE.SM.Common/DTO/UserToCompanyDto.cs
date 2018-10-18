using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Common.DTO
{
    public partial class UserToCompanyDto:BaseDto
    {
        public UserToCompanyDto()
        {
            this.PrimaryKeyName = "UserToCompanyId";
        }
    }
}
