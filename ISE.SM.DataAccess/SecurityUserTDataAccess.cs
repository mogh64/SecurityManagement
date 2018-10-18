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
    public class SecurityUserTDataAccess : TDataAccess<User, UserDto, UserRepository>
    {
        public SecurityUserTDataAccess()
            : base(new UserRepository())
        {
        }
        public bool ExistUser(UserDto user)
        {
            if (!string.IsNullOrWhiteSpace(user.NationalNo))
            {
                var dbUser = this.Repository.Context.Users.Where(it => it.NationalNo == user.NationalNo).FirstOrDefault();
                if (dbUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception("کد ملی الزامیست!");
            }
        }
        public List<RoleDto> GetUserRoles(string userId)
        {
            List<RoleDto> roles = new List<RoleDto>();

            return roles;
        }
        public List<int> GetUserRoleIds(long userId)
        {
            List<int> roles = new List<int>();
            var result= this.Repository.Context.UserToRoles.Where(it => it.UserId == userId && it.RoleId!=null).Select(it=>it.RoleId.Value).ToList();
            roles.AddRange(result);
            
            return roles;
        }
        public override void Insert(ISE.SM.Common.DTO.UserDto entityDto)
        {
            SecurityCompanyTDataAccess companayDa = new SecurityCompanyTDataAccess();
            
            var company = companayDa.GetSingle(it => it.NationalNo == entityDto.NationalNo);
            if (company != null)
            {
                UserToCompanyTDataAccess userToCompDa = new UserToCompanyTDataAccess();
                UserToCompanyDto userToCompany = new UserToCompanyDto()
                {
                    CompanyId=company.CompanyId,
                    SecurityUserId=entityDto.UserId,
                    FromDate = DateTime.Now
                };
                userToCompDa.Insert(userToCompany);
            }
            
            base.Insert(entityDto);
        }
        public override void Insert(List<UserDto> entityDtoList)
        {
            SecurityCompanyTDataAccess companayDa = new SecurityCompanyTDataAccess();
            foreach (var entityDto in entityDtoList)
            {


                var company = companayDa.GetSingle(it => it.NationalNo == entityDto.NationalNo);
                if (company != null)
                {
                   UserToCompanyTDataAccess userToCompDa = new UserToCompanyTDataAccess();
                   UserToCompanyDto userToCompany = new UserToCompanyDto()
                   {
                       CompanyId=company.CompanyId,
                       SecurityUserId=entityDto.UserId,
                       FromDate = DateTime.Now
                   };
                   userToCompDa.Insert(userToCompany);
                }
            }
            base.Insert(entityDtoList);
        }
        public override void Update(UserDto entityDto)
        {
            var dbUser = this.GetSingle(it => it.UserId == entityDto.UserId);
            if (dbUser != null)
            {
                if (dbUser.NationalNo != entityDto.NationalNo)
                {
                    SecurityCompanyTDataAccess companayDa = new SecurityCompanyTDataAccess();
                    var company = companayDa.GetSingle(it => it.NationalNo == entityDto.NationalNo);
                    if (company != null)
                    {
                        UserToCompanyTDataAccess userToCompDa = new UserToCompanyTDataAccess();
                        var userToCompanyDb = userToCompDa.GetSingle(it => it.ToDate == null && it.SecurityUserId == entityDto.UserId);
                        UserToCompanyDto userToCompany = new UserToCompanyDto()
                        {
                            CompanyId = company.CompanyId,
                            SecurityUserId = entityDto.UserId,
                            FromDate = DateTime.Now
                        };
                        userToCompanyDb.ToDate = DateTime.Now;
                        userToCompDa.Insert(userToCompany);
                        userToCompDa.Update(userToCompany);
                    }
                }
                base.Update(entityDto);
            }
            
        }
        public List<int> GetUserGroupIds(long userId)
        {
            List<int> groups = new List<int>();
            var result = this.Repository.Context.UserToGroups.Where(it => it.UserId == userId && it.GroupId != null).Select(it => it.GroupId.Value).ToList();
            groups.AddRange(result);

            return groups;
        }
    }
}
