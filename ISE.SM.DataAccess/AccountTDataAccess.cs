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
    public class AccountTDataAccess : TDataAccess<Account, AccountDto, AccountRepository>
    {
        public AccountTDataAccess()
            : base(new AccountRepository())
        {
        }
        public override IList<AccountDto> GetAll()
        {
           
            
            var result=base.GetAll();
            foreach (var item in result)
            {
                if (item.ExpiredDate == null)
                {
                    var appDomains = this.Repository.Context.AccountToAppDomains.Where(it => it.AccountId == item.AccountId).Select(it => it.Applicationdomain).ToList();
                    foreach (var app in appDomains)
                    {
                        var appDto = ApplicationDomainRepository.GetDto(app);
                        item.ApplicationDomainDtoList.Add(appDto);
                    }
                    
                }
            }
            return result;
        }
        public override IList<AccountDto> GetAll(System.Linq.Expressions.Expression<Func<Account, bool>> whereCondition)
        {
            var result=base.GetAll(whereCondition);
           
            foreach (var item in result)
            {
                if (item.ExpiredDate == null)
                {
                    var appDomains = this.Repository.Context.AccountToAppDomains.Where(it => it.AccountId == item.AccountId).Select(it => it.Applicationdomain).ToList();
                    foreach (var app in appDomains)
                    {
                        var appDto = ApplicationDomainRepository.GetDto(app);
                        item.ApplicationDomainDtoList.Add(appDto);
                    }                  
                }
            }
            return result;
        }
        public override AccountDto GetSingle(System.Linq.Expressions.Expression<Func<Account, bool>> whereCondition)
        {
            var result=base.GetSingle(whereCondition);
            if (result != null)
            {
                if (result.ExpiredDate == null)
                {
                    var appDomains = this.Repository.Context.AccountToAppDomains.Where(it => it.AccountId == result.AccountId).Select(it => it.Applicationdomain).ToList();
                    foreach (var app in appDomains)
                    {
                        var appDto = ApplicationDomainRepository.GetDto(app);
                        result.ApplicationDomainDtoList.Add(appDto);
                    }
                    return result;
                }
                    
            }
            return null;
        }
        public override void Insert(AccountDto entityDto)
        {
            entityDto.Password = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(entityDto.Password,entityDto.Username);
            base.Insert(entityDto);
        }
        public AccountDto CheckAccount(string userName,int clientId)
        {
            
            AccountDto dtoResult = new AccountDto();
            try
            {
                var result1 = (from a in this.Repository.Context.Accounts
                               join p in this.Repository.Context.AccountToAppDomains on a.AccountId equals p.AccountId
                               where (a.Username.Equals(userName) && p.AppDomainId == clientId)
                               select a).FirstOrDefault();
                if (result1 != null)
                {
                    dtoResult = AccountRepository.GetDto(result1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            


            return dtoResult;


        }
        public override void Insert(List<AccountDto> entityDtoList)
        {
            foreach (var entityDto in entityDtoList)
            {
                entityDto.Password = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(entityDto.Password,entityDto.Username);
            }
            base.Insert(entityDtoList);
        }
        public AccountDto ChangePassword(string userName, string oldPassword, string newPassword)
        {
            
            var decOldPas = ISE.Framework.Utility.Utils.Encryption.DecryptData(oldPassword);
            var decnewPas = ISE.Framework.Utility.Utils.Encryption.DecryptData(newPassword);
            string hashed = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(decOldPas,userName);
            var result = this.Repository.Context.Accounts.Where(it => it.Username == userName && it.Password == hashed && it.ExpiredDate == null).FirstOrDefault();
            if (result != null)
            {
                PasswordHistoryTDataAccess passwordHistoryDa = new PasswordHistoryTDataAccess();
                string newHashed = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(decnewPas, userName);
                result.Password = newHashed;
                result.UpdateDate = DateTime.Now;
                PasswordHistoryDto pHistory = new PasswordHistoryDto()
                {
                    AccountId = result.AccountId,
                    ChangeDate=DateTime.Now,
                     UserId =result.UserId,
                     Password = oldPassword
                };
                this.Repository.Context.SaveChanges();
                passwordHistoryDa.Insert(pHistory);
                var dtoResult = AccountRepository.GetDto(result);

                return dtoResult;
            }
            return null;
        }
        public AccountDto ResetPassword(string userName,long userId)
        {

            var user = this.Repository.Context.Users.FirstOrDefault(it => userId == userId);
            var decnewPas = ISE.Framework.Utility.Utils.Encryption.DecryptData(user.NationalNo);
           
            var result = this.Repository.Context.Accounts.Where(it => it.Username == userName  && it.ExpiredDate == null).FirstOrDefault();
            if (result != null)
            {
                PasswordHistoryTDataAccess passwordHistoryDa = new PasswordHistoryTDataAccess();
                string newHashed = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(decnewPas,userName);
                string oldPass = result.Password;
                result.Password = newHashed;
                result.UpdateDate = DateTime.Now;
                PasswordHistoryDto pHistory = new PasswordHistoryDto()
                {
                    AccountId = result.AccountId,
                    ChangeDate = DateTime.Now,
                    UserId = result.UserId,
                    Password = oldPass
                };
                this.Repository.Context.SaveChanges();
                passwordHistoryDa.Insert(pHistory);
                var dtoResult = AccountRepository.GetDto(result);

                return dtoResult;
            }
            return null;
        }
        public override void Update(AccountDto entityDto)
        {
            var result = this.Repository.Context.Accounts.Where(it => it.AccountId == entityDto.AccountId ).FirstOrDefault();
            if (result != null)
            {
                entityDto.Password = result.Password;
                entityDto.PassChangeDate = result.PassChangeDate;
                base.Update(entityDto);
            }
            else
            {
                entityDto.Response.AddBusinessException("این حساب کاربری موجود نیست!", Framework.Common.Service.Message.BusinessExceptionEnum.Operational);
            }
        }
        public bool ExistAccount(string userName)
        {
            var result = this.Repository.Context.Accounts.Where(it => it.Username == userName).FirstOrDefault();
            if (result != null)
                return true;
            return false;
        }
    }
}
