using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.SM.Common.DTO
{
   public partial  class AccountDto:BaseDto
    {
       public AccountDto()
       {
           this.PrimaryKeyName = "AccountId";
           ApplicationDomainDtoList = new List<ApplicationDomainDto>();
           Enabled = 1;
       }
       [DataMember]
       public UserDto UserDto { get; set; }
       [DataMember]
       public List<ApplicationDomainDto> ApplicationDomainDtoList { get; set; }
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
    
       public string AppDomainString
       {
           get
           {
               string appDomains = string.Empty;
               foreach (var item in ApplicationDomainDtoList)
               {
                   appDomains += item.Title+",";
               }
               return appDomains;
           }
       }
    }
}
