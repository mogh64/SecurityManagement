using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class PermissionDtoContainer:DtoContainer
    {
        public PermissionDtoContainer()
        {
            OperationDtoList = new List<OperationDto>();
            SecurityResourceDtoList = new List<SecurityResourceDto>();
            PermissionDtoList = new List<PermissionDto>();
        }
        public List<PermissionDto> PermissionDtoList { get; set; }
        public List<OperationDto> OperationDtoList { get; set; }
        public List<SecurityResourceDto> SecurityResourceDtoList { get; set; }
    }
}
