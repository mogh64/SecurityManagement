using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
    public partial class OperationDto:BaseDto
    {
        public OperationDto()
        {
            this.PrimaryKeyName = "OperationId";
        }
        public bool IsDefaultBool
        {
            get
            {
                if (this.IsDefault > 0)
                    return true;
                return false;
            }
            set
            {
                if (value)
                {
                    IsDefault = 1;
                }
                else
                {
                    IsDefault = 0;
                }
            }
        }
        [DataMember]
        public bool Checked { get; set; }
    }
}
