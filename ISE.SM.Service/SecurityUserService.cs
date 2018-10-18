using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class SecurityUserService :ContextBoundObject, ISecurityUserService
    {
        SecurityUserBussiness securityUserBs = new SecurityUserBussiness();
        public Framework.Common.Service.Message.ResponseDto AssignUser(Common.DTO.UserDto user, int roleId)
        {
            return securityUserBs.AssignUser(user, roleId);
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignUser(Common.DTO.UserDto user, int roleId)
        {
            return securityUserBs.DeAssignUser(user, roleId);
        }

        public Framework.Common.Service.Message.ResponseDto ActivateUser(Common.DTO.UserDto user)
        {
            return securityUserBs.ActivateUser(user);
        }

        public Framework.Common.Service.Message.ResponseDto DeActivateUser(Common.DTO.UserDto user)
        {
            return securityUserBs.DeActivateUser(user);
        }

        public Common.DTOContainer.RoleDtoContainer AssignedRoles(Common.DTO.UserDto user)
        {
            return securityUserBs.AssignedRoles(user);
        }

        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            securityUserBs.Delete((UserDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<UserDto> lst = dtoList.PersistanceList.Cast<UserDto>().ToList();
            securityUserBs.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = securityUserBs.GetAll();
            RoleBussiness roleBs = new RoleBussiness();
            GroupBussiness groupBs = new GroupBussiness();
            var roles = roleBs.GetAll().ToList();
            var grps = groupBs.GetAll().ToList();
            UserDtoContainer container = new UserDtoContainer()
            {
                UserDtoList = result.ToList(),
                RoleDtoList = roles,
                GroupDtoList = grps
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<User>(predicate);
            UserDtoContainer container = new UserDtoContainer();
            var dtoResult = securityUserBs.GetAll(pars);
            container.UserDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = securityUserBs.GetSingle(it => it.UserId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            securityUserBs.Insert((UserDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<UserDto> lst = dtoList.PersistanceList.Cast<UserDto>().ToList();
            securityUserBs.Insert(lst);
            UserDtoContainer container = new UserDtoContainer()
            {
                UserDtoList = lst
            };
            return container;
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAllByCondition(string predicate, int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.Service.Message.ResponseDto Update(Framework.Common.CommonBase.BaseDto dto)
        {
            securityUserBs.Update((UserDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<UserDto> lst = dtoList.PersistanceList.Cast<UserDto>().ToList();
            securityUserBs.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }


        public UserDto GetUserRoleIds(long userId)
        {
            UserDto userRolesIds = new UserDto();
            userRolesIds.RoleIdList.AddRange(securityUserBs.GetUserRoleIds(userId));
            return userRolesIds;
        }

        public UserDto GetUserGroupIds(long userId)
        {
            UserDto userRolesIds = new UserDto();
            userRolesIds.GroupIdList.AddRange(securityUserBs.GetUserGroupIds(userId));
            return userRolesIds;
        }
    }
}
