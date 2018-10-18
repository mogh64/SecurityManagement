using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTO
{
    public partial class LoginTypeDto:BaseDto
    {
        public LoginTypeDto()
        {
            this.PrimaryKeyName = "LoginTypeId";
        }
    }
}
