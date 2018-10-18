using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class OperationDtoContainer:DtoContainer
    {
        public OperationDtoContainer()
        {
            OperationDtoList = new List<OperationDto>();
        }
        public List<OperationDto> OperationDtoList { get; set; }
    }
}
