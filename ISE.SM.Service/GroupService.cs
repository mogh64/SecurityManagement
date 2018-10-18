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
    public class GroupService : ContextBoundObject, IGroupService
    {
        GroupBussiness groupBussiness = new GroupBussiness();
        public Framework.Common.Service.Message.ResponseDto AssignUsers(List<Common.DTO.UserDto> users, int groupId)
        {
            return groupBussiness.AssignUsers(users, groupId);
        }
        
        public Framework.Common.Service.Message.ResponseDto AssignRoles(List<Common.DTO.RoleDto> roles, int groupId)
        {
            return groupBussiness.AssignRoles(roles, groupId);
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignUsers(List<Common.DTO.UserDto> users, int groupId)
        {
            return groupBussiness.DeAssignUsers(users, groupId);
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignRoles(List<Common.DTO.RoleDto> roles, int groupId)
        {
            return groupBussiness.DeAssignRoles(roles, groupId);
        }

        public Common.DTOContainer.UserDtoContainer AssignedUsers(int groupId)
        {
            return groupBussiness.AssignedUsers( groupId);
        }

        public Common.DTOContainer.RoleDtoContainer AssignedRoles(int groupId)
        {
            return groupBussiness.AssignedRoles(groupId);
        }

        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            groupBussiness.Delete((SecurityGroupDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityGroupDto> lst = dtoList.PersistanceList.Cast<SecurityGroupDto>().ToList();
            groupBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = groupBussiness.GetAll();
            SecurityGroupDtoContainer container = new SecurityGroupDtoContainer()
            {
                SecurityGroupDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<SecurityGroup>(predicate);
            SecurityGroupDtoContainer container = new SecurityGroupDtoContainer();
            var dtoResult = groupBussiness.GetAll(pars);
            container.SecurityGroupDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = groupBussiness.GetSingle(it => it.SecurityGroupId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            groupBussiness.Insert((SecurityGroupDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityGroupDto> lst = dtoList.PersistanceList.Cast<SecurityGroupDto>().ToList();
            groupBussiness.Insert(lst);
            SecurityGroupDtoContainer container = new SecurityGroupDtoContainer()
            {
                SecurityGroupDtoList = lst
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
            groupBussiness.Update((SecurityGroupDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityGroupDto> lst = dtoList.PersistanceList.Cast<SecurityGroupDto>().ToList();
            groupBussiness.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }
    }
}
