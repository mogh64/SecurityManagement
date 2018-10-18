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
    public class SecurityUserBussiness : BussinessBase<User, UserDto>
    {
        public SecurityUserBussiness()
        {
            this.dataAccess = new SecurityUserTDataAccess();
        }
        public override IList<UserDto> GetAll()
        {
           
            var result =base.GetAll();
            //foreach (var item in result)
            //{
            //    item.RoleIdList.AddRange(((SecurityUserTDataAccess)this.dataAccess).GetUserRoleIds(item.SecurityUserId));
            //    item.GroupIdList.AddRange(((SecurityUserTDataAccess)this.dataAccess).GetUserGroupIds(item.SecurityUserId));
            //}
            return result;
        }
        public ResponseDto RegisterUser(UserDto user)
        {
            AccountTDataAccess accountDa = new AccountTDataAccess();
            ResponseDto response = new ResponseDto();
            try
            {
                if (ValidateNewUser(user))
                {
                    bool existUser = ((SecurityUserTDataAccess)this.dataAccess).ExistUser(user);
                    if (!existUser)
                    {
                        if (user.Accounts.Count() > 0)
                        {
                            var account = user.Accounts.FirstOrDefault();
                            var existAccount = accountDa.ExistAccount(account.Username);
                            if (!existAccount)
                            {
                                this.Insert(user);
                                foreach (var newAccount in user.Accounts)
                                {
                                    newAccount.UserId = user.UserId;
                                }
                                try
                                {
                                    accountDa.Insert(user.Accounts.ToList());
                                }
                                catch
                                {
                                    accountDa.Delete(user.Accounts.ToList());
                                    this.Delete(user);
                                    response.Response.AddBusinessException("ثبت کاربر جدید با شکست مواجه شد!", BusinessExceptionEnum.Operational);
                                }
                            }
                            else
                            {
                                response.Response.AddBusinessException("کاربر با این حساب کاربری قبلا ثبت شده است!", BusinessExceptionEnum.Validation);
                            }
                        }
                        else
                        {
                            response.Response.AddBusinessException("کاربر باید دارای حساب کاربری پیش فرض باشد!", BusinessExceptionEnum.Validation);
                        }

                    }
                    else
                    {
                        response.Response.AddBusinessException("!کاربر با این کد ملی قبلا ثبت شده است", BusinessExceptionEnum.Validation);
                    }
                }
                else
                {
                    response.SetResponse(user.Response);
                }
            }
            catch (Exception ex)
            {
                response.Response.AddBusinessException(ex.Message, BusinessExceptionEnum.Operational);
            }
            
            return response;
        }
        public Framework.Common.Service.Message.ResponseDto UnRegisterUser(Common.DTO.UserDto userMember)
        {
            
            ResponseDto response = new ResponseDto();
            var user = ((SecurityUserTDataAccess)this.dataAccess).GetSingle(it => it.UserId == userMember.UserId);
            if (user != null)
            {
               
                AccountTDataAccess accountDa = new AccountTDataAccess();
                var accounts = accountDa.GetAll(it => it.UserId == user.UserId).ToList();
                foreach (var account in accounts)
                {
                    account.ExpiredDate = DateTime.Now;
                }
                this.Update(user);
                accountDa.Update(accounts);
            }
            else
            {
                response.Response.AddBusinessException("!چنین کاربری وجود ندارد", BusinessExceptionEnum.Validation);
            }
            return response;
        }
        public bool ValidateNewUser(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.NationalNo))
            {
                user.Response.AddBusinessException("کد ملی اجباریست", BusinessExceptionEnum.Validation);
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                user.Response.AddBusinessException("نام اجباریست", BusinessExceptionEnum.Validation);
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                user.Response.AddBusinessException("نام خانوادگی اجباریست", BusinessExceptionEnum.Validation);
                return false;
            }
            return true;
        }
        public List<int> GetUserRoleIds(long userId)
        {
            return ((SecurityUserTDataAccess)this.dataAccess).GetUserRoleIds(userId);
        }
        public List<int> GetUserGroupIds(long userId)
        {
            return ((SecurityUserTDataAccess)this.dataAccess).GetUserGroupIds(userId);
        }
        public Framework.Common.Service.Message.ResponseDto AssignAccountAppDomain(Common.DTO.AccountDto account, int appDomain)
        {
            AccountTDataAccess accountDa = new AccountTDataAccess();
            ResponseDto response = new ResponseDto();
            var dbAccount = accountDa.GetSingle(it => it.AccountId == account.AccountId);
            if (dbAccount != null)
            {
                AccountToAppDomainTDataAccess accToDomainDa = new AccountToAppDomainTDataAccess();
                var dbAccToDomain = accToDomainDa.GetSingle(it => it.AccountId == account.AccountId && it.AppDomainId == appDomain );
                if (dbAccToDomain == null || dbAccToDomain.ExpireDate!=null)
                {
                    if (dbAccToDomain != null)
                    {
                        dbAccToDomain.ExpireDate = null;
                        accToDomainDa.Update(dbAccToDomain);
                    }
                    else
                    {
                        AccountToAppDomainDto accToDomain = new AccountToAppDomainDto()
                        {
                            AccountId = account.AccountId,
                            AppDomainId = appDomain
                        };
                        accToDomainDa.Insert(accToDomain);
                    }
                    
                }
                else
                {
                    response.Response.AddBusinessException("انتصاب موجود است!", BusinessExceptionEnum.Operational);
                }
            }
            else
            {
                response.Response.AddBusinessException("حساب کاربری وجود ندارد!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignAccountAppDomain(Common.DTO.AccountDto account, int appDomain)
        {
            AccountTDataAccess accountDa = new AccountTDataAccess();
            ResponseDto response = new ResponseDto();
            var dbAccount = accountDa.GetSingle(it => it.AccountId == account.AccountId);
            if (dbAccount != null)
            {
                AccountToAppDomainTDataAccess accToDomainDa = new AccountToAppDomainTDataAccess();
                var dbAccToDomain = accToDomainDa.GetSingle(it => it.AccountId == account.AccountId && it.AppDomainId == appDomain && it.ExpireDate==null);
                dbAccToDomain.ExpireDate = null;
                accToDomainDa.Update(dbAccToDomain);
            }
            else
            {
                response.Response.AddBusinessException("حساب کاربری وجود ندارد!", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Common.DTOContainer.AccountDtoContainer GetUserAccounts(Common.DTO.UserDto userMember)
        {
            AccountTDataAccess accountDa = new AccountTDataAccess();
            var accounts = accountDa.GetAll(it => it.UserId == userMember.UserId && it.ExpiredDate == null).ToList();
            AccountDtoContainer container = new AccountDtoContainer();
            container.AccountDtoList.AddRange(accounts);
            return container;
        }
        public UserDto GetUserById(int userId)
        {
            var user = GetSingle(it => it.UserId == userId);
            var roleIds = GetUserRoleIds(userId);
            var groupIds = GetUserGroupIds(userId);
            RoleTDataAccess roleDa = new RoleTDataAccess();
            GroupTDataAccess groupDa = new GroupTDataAccess();
            foreach (var roleId in roleIds)
            {
                var role = roleDa.GetSingle(it => it.RoleId == roleId);
                user.Roles.Add(role);
            }
            foreach (var groupId in groupIds)
            {
                var grp = groupDa.GetSingle(it => it.SecurityGroupId == groupId);
                user.Groups.Add(grp);
            }
            return user;
        }
        public Framework.Common.Service.Message.ResponseDto AssignUser(Common.DTO.UserDto user, int roleId)
        {
            ResponseDto response = new ResponseDto();
            RoleBussiness roleBs = new RoleBussiness();
            var dbuser = GetSingle(it => it.UserId == user.UserId);
            if (dbuser != null)
            {
                var dbRole = roleBs.GetSingle(it => it.RoleId == roleId);
                if (dbRole != null)
                {
                    UserToRoleTDataAccess userToRoleDa = new UserToRoleTDataAccess();
                    var relation = userToRoleDa.GetSingle(it => it.RoleId == roleId && it.UserId == user.UserId);
                    if(relation==null){
                        UserToRoleDto dto = new UserToRoleDto()
                        {
                            RoleId = roleId,
                            UserId = user.UserId
                        };
                        userToRoleDa.Insert(dto);
                    }
                    else{
                        response.Response.AddBusinessException("رابطه قبلا ایجاد شده است!", BusinessExceptionEnum.Operational);
                    }                   
                }
                else
                {
                    response.Response.AddBusinessException("نقش موجود نیست", BusinessExceptionEnum.Operational);
                }
            }
            else
            {
                response.Response.AddBusinessException("کاربر موجود نیست", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignUser(Common.DTO.UserDto user, int roleId)
        {
            ResponseDto response = new ResponseDto();
            RoleBussiness roleBs = new RoleBussiness();
            var dbuser = GetSingle(it => it.UserId == user.UserId);
            if (dbuser != null)
            {
                var dbRole = roleBs.GetSingle(it => it.RoleId == roleId);
                if (dbRole != null)
                {
                    UserToRoleTDataAccess userToRoleDa = new UserToRoleTDataAccess();
                    var relation = userToRoleDa.GetSingle(it => it.RoleId == roleId && it.UserId == user.UserId);
                    if (relation != null)
                    {
                        userToRoleDa.Delete(relation);
                    }
                    else
                    {
                        response.Response.AddBusinessException("رابطه نشده است!", BusinessExceptionEnum.Operational);
                    }
                }
                else
                {
                    response.Response.AddBusinessException("نقش موجود نیست", BusinessExceptionEnum.Operational);
                }
            }
            else
            {
                response.Response.AddBusinessException("کاربر موجود نیست", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto ActivateUser(Common.DTO.UserDto user)
        {
            ResponseDto response = new ResponseDto();
            var dbuser = GetSingle(it => it.UserId == user.UserId);
            if (dbuser != null)
            {
                dbuser.IsLocked = false;
                Update(dbuser);
            }
            else
            {
                response.Response.AddBusinessException("کاربر موجود نیست", BusinessExceptionEnum.Operational);
            }
            
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeActivateUser(Common.DTO.UserDto user)
        {
            ResponseDto response = new ResponseDto();
            var dbuser = GetSingle(it => it.UserId == user.UserId);
            if (dbuser != null)
            {
                dbuser.IsLocked = true;
                Update(dbuser);
            }
            else
            {
                response.Response.AddBusinessException("کاربر موجود نیست", BusinessExceptionEnum.Operational);
            }
            
            return response;
        }

        public Common.DTOContainer.RoleDtoContainer AssignedRoles(Common.DTO.UserDto user)
        {
            RoleDtoContainer container = new RoleDtoContainer();
            RoleBussiness roleBs = new RoleBussiness();
            var dbuser = GetSingle(it => it.UserId == user.UserId);
            if (dbuser != null)
            {
                UserToRoleTDataAccess userToRoleDa = new UserToRoleTDataAccess();
                var roleIds =  userToRoleDa.GetAll(it => it.UserId == dbuser.UserId).Select(it => it.RoleId).ToList();
                foreach (var roleId in roleIds)
                {
                    var role = roleBs.GetSingle(it => it.RoleId == roleId);
                    container.RoleDtoList.Add(role);
                }
            }
            else
            {
                container.Response.AddBusinessException("کاربر موجود نیست", BusinessExceptionEnum.Operational);
            }
            return container;
        }
    }
}
