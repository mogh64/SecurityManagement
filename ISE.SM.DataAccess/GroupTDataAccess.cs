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
    public class GroupTDataAccess : TDataAccess<SecurityGroup, SecurityGroupDto, SecurityGroupRepository>
    {
        public GroupTDataAccess()
            : base(new SecurityGroupRepository())
        {
        }
        public override IList<SecurityGroupDto> GetAll()
        {
            var result = base.GetAll();
            foreach (var item in result)
            {
                var appDomain = this.Repository.Context.ApplicationDomains.Where(it => it.ApplicationDomainId == item.AppDomainId).FirstOrDefault();
                if (appDomain!=null)
                    item.ApplicationDomainDto = ApplicationDomainRepository.GetDto(appDomain);
            }
            return result;
        }
        public List<RoleDto> GetGroupRoles(int groupId)
        {
            AppDomainTDataAccess appDomainDa = new AppDomainTDataAccess();
            List<RoleDto> roleList = new List<RoleDto>();
            var roles=  this.Repository.Context.RoleToGroups.Where(it => it.GroupId == groupId).Select(it=>it.Role).ToList();
            foreach (var role in roles)
            {
                var appDomain = appDomainDa.GetSingle(it => it.ApplicationDomainId == role.AppDomainId);
                var roleDto = RoleRepository.GetDto(role);
                roleDto.ApplicationDomainDto = appDomain;
                roleList.Add(roleDto);
                

            }
            return roleList;
        }
        public List<UserDto> GetGroupUsers(int groupId)
        {
            List<UserDto> userList = new List<UserDto>();
            var users = this.Repository.Context.UserToGroups.Where(it => it.GroupId == groupId).Select(it => it.User).ToList();
            foreach (var user in users)
            {
                var roleDto = UserRepository.GetDto(user);
                userList.Add(roleDto);
            }
            return userList;
        }
    }
}
