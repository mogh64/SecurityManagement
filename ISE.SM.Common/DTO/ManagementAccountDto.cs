using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTO
{
    public partial class ManagementAccountDto:BaseDto
    {
        public ManagementAccountDto()
        {
            this.PrimaryKeyName = "ManagementAccountId";
        }
        public AccountDto MapToAccountDto()
        {
            AccountDto dto = new AccountDto()
            {
                UserId = this.SecurityUserId,
                Username = this.UserName,
                Password = this.Password,
                ExpiredDate = this.ExpireDate
            };
            return dto;
        }
    }
}
