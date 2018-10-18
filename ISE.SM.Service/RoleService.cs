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
    
    public class RoleService : ContextBoundObject, IRoleService
    {
        RoleBussiness roleBussiness = new RoleBussiness();
        public Framework.Common.Service.Message.ResponseDto ActivateRole(Common.DTO.RoleDto role)
        {
            return roleBussiness.ActivateRole(role);
        }

        public Framework.Common.Service.Message.ResponseDto DeActivateRole(Common.DTO.RoleDto role)
        {
            return roleBussiness.DeActivateRole(role);
        }
    
        public Common.DTOContainer.UserDtoContainer AssignedUsers(Common.DTO.RoleDto role)
        {
            return roleBussiness.AssignedUsers(role);
        }

        public Framework.Common.Service.Message.ResponseDto AddInheritance(int parentRoleId, int childRoleId)
        {
            return roleBussiness.AddInheritance(parentRoleId, childRoleId);
        }

        public Framework.Common.Service.Message.ResponseDto DeleteInheritance(int parentRoleId, int childRoleId)
        {
            return roleBussiness.DeleteInheritance(parentRoleId, childRoleId);
        }

        public Framework.Common.Service.Message.ResponseDto AddAscendant(Common.DTO.RoleDto parent, int childRoleId)
        {
            return roleBussiness.AddAscendant(parent, childRoleId);
        }


        public Common.DTO.RoleToRoleConstraintDto AddRoleToRoleConstraint(Common.DTO.RoleToRoleConstraintDto constraint)
        {
            return roleBussiness.AddRoleToRoleConstraint(constraint);
        }

        public Common.DTO.UserToRoleConstraintDto AddUserToRoleConstraint(Common.DTO.UserToRoleConstraintDto constraint)
        {
            return roleBussiness.AddUserToRoleConstraint(constraint);
        }

      

        public Framework.Common.Service.Message.ResponseDto AddDescendant(RoleDto child, int parentRoleId)
        {
            return roleBussiness.AddAscendant(child, parentRoleId);
        }

       
        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            roleBussiness.Delete((RoleDto)dto);
            return ResponseBuilder.GetResponse(dto); 
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<RoleDto> lst = dtoList.PersistanceList.Cast<RoleDto>().ToList();
            roleBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = roleBussiness.GetAll();
            RoleDtoContainer container = new RoleDtoContainer()
            {
                RoleDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<Role>(predicate);
            RoleDtoContainer container = new RoleDtoContainer();
            var dtoResult = roleBussiness.GetAll(pars);
            container.RoleDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = roleBussiness.GetSingle(it => it.RoleId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            roleBussiness.Insert((RoleDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<RoleDto> lst = dtoList.PersistanceList.Cast<RoleDto>().ToList();
            roleBussiness.Insert(lst);
            RoleDtoContainer container = new RoleDtoContainer()
            {
                RoleDtoList = lst
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
            roleBussiness.Update((RoleDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<RoleDto> lst = dtoList.PersistanceList.Cast<RoleDto>().ToList();
            roleBussiness.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }

        public SecurityGroupDtoContainer RoleGroups(RoleDto role)
        {
            return roleBussiness.RoleGroups(role);
        }


        public RoleToRoleConstraintDto UpdateRoleToRoleConstraint(RoleToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public UserToRoleConstraintDto UpdateUserToRoleConstraint(UserToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public ResponseDto RemoveRoleToRoleConstraint(RoleToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public ResponseDto RemoveUserToRoleConstraint(UserToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }
    }
}
