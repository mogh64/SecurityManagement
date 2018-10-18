using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTOContainer
{
    public class UserDtoContainer:DtoContainer
    {
        public UserDtoContainer()
        {
            UserDtoList = new List<UserDto>();
            RoleDtoList = new List<RoleDto>();
            GroupDtoList=new List<SecurityGroupDto>();
        }
        public List<UserDto> UserDtoList { get; set; }
        public List<RoleDto> RoleDtoList { get; set; }
        public List<SecurityGroupDto> GroupDtoList { get; set; }
    }
}
