using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class ApplicationDomainDtoContainer : DtoContainer
    {
        public ApplicationDomainDtoContainer()
        {
            ApplicationDomainDtoList = new List<ApplicationDomainDto>();
            LoginTypeDtoList = new List<LoginTypeDto>();
        }
        public List<ApplicationDomainDto> ApplicationDomainDtoList { get; set; }
        public List<LoginTypeDto> LoginTypeDtoList { get; set; }
    }
}
