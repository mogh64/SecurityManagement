using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
    public partial class RoleDto:BaseDto
    {
        public RoleDto()
        {
            this.PrimaryKeyName = "RoleId";
        }
        [DataMember]
        public ApplicationDomainDto ApplicationDomainDto { get; set; }
        public string AppDomainName
        {
            get
            {
                if (ApplicationDomainDto != null)
                    return ApplicationDomainDto.Title;
                return string.Empty;
            }
        }
        public bool IsEnabled
        {
            get
            {
                if (this.Enabled > 0)
                    return true;
                return false;
            }
            set
            {
                if (value)
                {
                    Enabled = 1;
                }
                else
                {
                    Enabled = 0;
                }
            }
        }
    }
}
