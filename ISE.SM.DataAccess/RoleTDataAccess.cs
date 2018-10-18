using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class RoleTDataAccess : TDataAccess<Role, RoleDto, RoleRepository>
    {
        public RoleTDataAccess()
            : base(new RoleRepository())
        {
        }
        public override IList<RoleDto> GetAll()
        {
            var result = base.GetAll();
            foreach (var item in result)
            {
                var appDomain = this.Repository.Context.ApplicationDomains.Where(it => it.ApplicationDomainId == item.AppDomainId).FirstOrDefault();
                if (appDomain != null)
                    item.ApplicationDomainDto = ApplicationDomainRepository.GetDto(appDomain);
            }
            return result;
        }
        public Common.DTOContainer.UserDtoContainer AssignedUsers(Common.DTO.RoleDto role)
        {
            UserDtoContainer container = new UserDtoContainer();
            var users = this.Repository.Context.UserToRoles.Where(it => it.RoleId == role.RoleId).Select(it => it.User).ToList();
            foreach (var user in users)
	        {
                var userDto = UserRepository.GetDto(user);
                container.UserDtoList.Add(userDto);
	        }
            return container;
        }
    }
}
