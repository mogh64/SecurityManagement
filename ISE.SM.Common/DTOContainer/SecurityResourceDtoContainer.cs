using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class SecurityResourceDtoContainer:DtoContainer
    {
        public SecurityResourceDtoContainer()
        {
            SecurityResourceDtoList = new List<SecurityResourceDto>();
        }
        public List<SecurityResourceDto> SecurityResourceDtoList { get; set; }
    }
}
