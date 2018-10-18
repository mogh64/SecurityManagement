using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
    public  class AuthorizationRequest
    {
        public IdentityToken IdentityToken { get; set; }
        public SecurityResourceDto Resource { get; set; }
        public int ResourceTypeId { get; set; }
        public int AppDomainId { get; set; }
    }
}
