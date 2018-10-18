using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTO
{
    public partial class SecuritySessionDto:BaseDto
    {
        public SecuritySessionDto()
        {
            this.PrimaryKeyName = "RowId";
            
        }
        public ApplicationDomainDto ApplicationDomainDto { get; set; }
        public AccountDto AccountDto { get; set; }
    }
}
