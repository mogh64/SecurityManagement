using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class SecuritySessionDtoContainer : DtoContainer
    {
        public SecuritySessionDtoContainer()
        {
            SecuritySessionDtoList = new List<SecuritySessionDto>();
        }
        public List<SecuritySessionDto> SecuritySessionDtoList { get; set; }
    }
}
