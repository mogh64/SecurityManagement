using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
   public partial  class SecurityResourceDto:BaseDto
    {
       public SecurityResourceDto()
       {
           this.PrimaryKeyName = "SecurityResourceId";
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
       public bool HasParam
       {
           get
           {
               if (this.HasParameter > 0)
                   return true;
               return false;
           }
           set
           {
               if (value)
               {
                   HasParameter = 1;
               }
               else
               {
                   HasParameter = 0;
               }
           }
       }
       [DataMember]
       public bool Checked { get; set; }
    }
}
