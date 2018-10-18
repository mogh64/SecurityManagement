using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
    public class SignOutResult:BaseDto
    {
        public IdentityToken IdentityToken { get; set; }
        public SignOutResult()
        {

        }
    }
}
