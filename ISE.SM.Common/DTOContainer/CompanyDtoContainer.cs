using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Common.DTOContainer
{
    public class CompanyDtoContainer : DtoContainer
    {
        public CompanyDtoContainer()
        {
            CompanyDtoList = new List<CompanyDto>();
        }
        public List<CompanyDto> CompanyDtoList { get; set; }
    }
}
