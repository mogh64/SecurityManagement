using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.DTO
{
   public partial  class PermissionToRoleDto:BaseDto
    {
       public PermissionToRoleDto()
       {
           this.PrimaryKeyName = "PermissionToRoleId";
       }
    }
}
