using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Common.DTOContainer
{
    public class ResourceTypeDtoContainer : DtoContainer
    {
        public ResourceTypeDtoContainer()
        {
            ResourceTypeDtoList = new List<ResourceTypeDto>();
        }
        public List<ResourceTypeDto> ResourceTypeDtoList { get; set; }
    }
}
