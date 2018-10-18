using ISE.Framework.Common.CommonBase;
using ISE.SM.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
    
    public partial class PermissionDto:BaseDto
    {
        public PermissionDto()
        {
            this.PrimaryKeyName = "PermissionId";
            AccessType = Enums.AccessType.None;
            RoleDtos = new List<RoleDto>();
            IsToUser = false;
            GroupDtos = new List<SecurityGroupDto>();
        }
        [DataMember]
        public OperationDto OperationDto { get; set; }
        [DataMember]
        public SecurityResourceDto SecurityResourceDto { get; set; }
        [DataMember]
        public AccessType AccessType { get; set; }
        public bool Access { get { if (AccessType == Enums.AccessType.Access) return true; else return false; } }
        [DataMember]
        public List<RoleDto> RoleDtos { get; set; }
        [DataMember]
        public List<SecurityGroupDto> GroupDtos { get; set; }
        [DataMember]
        public bool IsToUser { get; set; }
    }
}
