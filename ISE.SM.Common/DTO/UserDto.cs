using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
    public partial class UserDto:BaseDto
    {
        public UserDto()
        {
            this.PrimaryKeyName = "UserId";
            Roles = new List<RoleDto>();
            Groups = new List<SecurityGroupDto>();
            RoleIdList = new List<int>();
            GroupIdList = new List<int>();          
        }
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        [DataMember]
        public List<int> GroupIdList { get; set; }
        [DataMember]
        public List<int> RoleIdList { get; set; }
        [DataMember]
        public List<RoleDto> Roles { get; set; }
        [DataMember]
        public List<SecurityGroupDto> Groups { get; set; }
        public bool IsLocked
        {
            get
            {
                if (this.LockDate.HasValue && this.LockDate.Value>DateTime.Now)
                    return true;
                return false;
            }
            set
            {
                if (value)
                {
                    LockDate = DateTime.Now;
                }
                else
                {
                    LockDate  = null;
                }
            }
        }
        public bool IsReal
        {
            get
            {
                if (this.IsRealPerson > 0)
                    return true;
                return false;
            }
            set
            {
                if (value)
                {
                    IsRealPerson = 1;
                }
                else
                {
                    IsRealPerson = 0;
                }
            }
        }
    }
}
