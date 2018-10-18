using ISE.Framework.Common.Service.Message;
using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class GroupBussiness : BussinessBase<SecurityGroup, SecurityGroupDto>
    {
        
        public GroupBussiness()
        {
            this.dataAccess = new GroupTDataAccess();
        }
        public override IList<SecurityGroupDto> GetAll()
        {
            AppDomainTDataAccess appDomainrep = new AppDomainTDataAccess();
            var result = base.GetAll();
            foreach (var item in result)
            {
                var app = appDomainrep.GetSingle(it => it.ApplicationDomainId == item.AppDomainId);
                if (app != null)
                {
                    item.ApplicationDomainDto = app;
                }
            }
            return result;
            
        }
        public Framework.Common.Service.Message.ResponseDto AssignUsers(List<Common.DTO.UserDto> users, int groupId)
        {
            ResponseDto response = new ResponseDto();
            var group = GetSingle(it => it.SecurityGroupId == groupId);
            if (group != null)
            {
                UserToGroupTDataAccess userToGroupDa = new UserToGroupTDataAccess();
                List<UserToGroupDto> assignList = new List<UserToGroupDto>();
                foreach (var user in users)
	            {
                    UserToGroupDto utg = new UserToGroupDto()
                    {
                        UserId = user.UserId,
                        GroupId = groupId
                    };
                    var relation = userToGroupDa.GetSingle(it => it.UserId == user.UserId && it.GroupId == groupId);
                    if (relation == null)
                    {
                        assignList.Add(utg);
                    }
	            }
                userToGroupDa.Insert(assignList);
            }
            else
            {
                response.Response.AddBusinessException("چنین گروهی موجود نیست!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto AssignRoles(List<Common.DTO.RoleDto> roles, int groupId)
        {
            ResponseDto response = new ResponseDto();
            var group = GetSingle(it => it.SecurityGroupId == groupId);
            if (group != null)
            {
                RoleToGroupTDataAccess roleToGroupDa = new RoleToGroupTDataAccess();
                List<RoleToGroupDto> assignList = new List<RoleToGroupDto>();
                foreach (var role in roles)
                {
                    RoleToGroupDto utg = new RoleToGroupDto()
                    {
                        RoleId = role.RoleId,
                        GroupId = groupId
                    };
                    var relation = roleToGroupDa.GetSingle(it => it.RoleId == role.RoleId && it.GroupId == groupId);
                    if (relation == null)
                    {
                        assignList.Add(utg);
                    }
                }
                roleToGroupDa.Insert(assignList);
            }
            else
            {
                response.Response.AddBusinessException("چنین گروهی موجود نیست!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignUsers(List<Common.DTO.UserDto> users, int groupId)
        {
            ResponseDto response = new ResponseDto();
            var group = GetSingle(it => it.SecurityGroupId == groupId);
            if (group != null)
            {
                UserToGroupTDataAccess userToGroupDa = new UserToGroupTDataAccess();
                
                List<UserToGroupDto> assignList = new List<UserToGroupDto>();
                foreach (var user in users)
                {
                    var relatios = userToGroupDa.GetAll(it => it.GroupId == groupId && it.UserId == user.UserId).ToList();
                    assignList.AddRange(relatios);
                }
                userToGroupDa.Delete(assignList);
            }
            else
            {
                response.Response.AddBusinessException("چنین گروهی موجود نیست!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignRoles(List<Common.DTO.RoleDto> roles, int groupId)
        {
            ResponseDto response = new ResponseDto();
            var group = GetSingle(it => it.SecurityGroupId == groupId);
            if (group != null)
            {
                RoleToGroupTDataAccess roleToGroupDa = new RoleToGroupTDataAccess();

                List<RoleToGroupDto> assignList = new List<RoleToGroupDto>();
                foreach (var role in roles)
                {
                    var relatios = roleToGroupDa.GetAll(it => it.GroupId == groupId && it.RoleId == role.RoleId).ToList();
                    assignList.AddRange(relatios);
                }
                roleToGroupDa.Delete(assignList);
            }
            else
            {
                response.Response.AddBusinessException("چنین گروهی موجود نیست!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Common.DTOContainer.UserDtoContainer AssignedUsers(int groupId)
        {
            UserDtoContainer container = new UserDtoContainer();
            var result = ((GroupTDataAccess)this.dataAccess).GetGroupUsers(groupId);
            container.UserDtoList.AddRange(result);
            return container;
        }

        public Common.DTOContainer.RoleDtoContainer AssignedRoles(int groupId)
        {
            RoleDtoContainer container = new RoleDtoContainer();
            var result = ((GroupTDataAccess)this.dataAccess).GetGroupRoles(groupId);
            container.RoleDtoList.AddRange(result);
            return container;
        }

    }
}
