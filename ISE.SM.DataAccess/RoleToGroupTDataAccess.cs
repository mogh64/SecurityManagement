using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class RoleToGroupTDataAccess : TDataAccess<RoleToGroup, ISE.SM.Common.DTO.RoleToGroupDto, RoleToGroupRepository>
    {
        public RoleToGroupTDataAccess()
            : base(new RoleToGroupRepository())
        {
        }
        public List<SecurityGroupDto> GetRoleGroups(RoleDto role)
        {
            AppDomainTDataAccess appDomainDa=new AppDomainTDataAccess();
           var groups=  this.Repository.Context.RoleToGroups.Where(it => it.RoleId == role.RoleId).Select(it => it.Securitygroup);
           var dtoList = SecurityGroupRepository.GetDtos(groups);
           foreach (var dto in dtoList)
           {
               var appDomain  = appDomainDa.GetSingle(it => it.ApplicationDomainId == dto.AppDomainId);
               if (appDomain != null)
               {
                   dto.ApplicationDomainDto = appDomain;
               }
           }
           return dtoList.ToList();
        }
    }
}
