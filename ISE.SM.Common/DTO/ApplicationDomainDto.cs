using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Common.DTO
{
    public partial class ApplicationDomainDto:BaseDto
    {
        public ApplicationDomainDto()
        {
            this.PrimaryKeyName = "ApplicationDomainId";
        }
        public bool IsLocked
        {
            get
            {
                if (this.Locked > 0)
                    return true;
                return false;
            }
            set
            {
                if (value)
                {
                    Locked = 1;
                }
                else
                {
                    Locked = 0;
                }
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
