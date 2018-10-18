using ISE.Framework.Common.Service.Message;
using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Bussiness.Helper;
using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class AccountBussiness : BussinessBase<Account, AccountDto>
    {
        public AccountBussiness()
        {
            this.dataAccess = new AccountTDataAccess();
        }
        public Common.Message.AuthenticationResult Authenticate(Common.Message.SignInMessage message)
        {
            Common.Message.AuthenticationResult result = new Common.Message.AuthenticationResult();
            SecurityUserBussiness userBs = new SecurityUserBussiness();
            
            var userAccount = ((AccountTDataAccess)this.dataAccess).CheckAccount(message.UserName, int.Parse(message.ClientId));
            
            if (userAccount != null)
            {
                var user = userBs.GetSingle(it => it.UserId == userAccount.UserId);
                if (user == null || user.IsLocked)
                {
                    result.ErrorMessage = " کاربر بطور موقت قفل است!";
                    UserLogGenerator.GenerateUserLog("-1", "-1", "", message.ClientId, "Authenticate", message.UserName, "faild login.user not exist");
                    return result;
                }
                if (userAccount.IsEnabled)
                {
                    if (userAccount.IsActiveDirectory > 0)
                    {
                        //TODO: Active directory check
                    }
                    else
                    {
                        if (userAccount.ExpiredDate==null || userAccount.ExpiredDate > DateTime.Now)
                        {
                            string hashed = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(message.PlainPassword, message.UserName);
                            if (userAccount.Password.Equals(hashed))
                            {
                                IdentityTokenGenerator generator = new IdentityTokenGenerator();
                                var token = generator.GenerateToken(userAccount, message);
                                result.IdentityToken = token;
                                UserLogGenerator.GenerateUserLog(token.SessionId, token.SubjectId, userAccount.AccountId.ToString(), message.ClientId, "Authenticate", message.UserName, "success login");
                            }
                            else
                            {
                                result.ErrorMessage = "رمز عبور اشتباه است";
                                UserLogGenerator.GenerateUserLog("-1", userAccount.UserId.ToString(), userAccount.AccountId.ToString(), message.ClientId, "Authenticate", message.UserName, "failed login.incorrect password.");
                            }
                        }
                        else
                        {
                            result.ErrorMessage = "کاربر منقضی شده است!";
                            UserLogGenerator.GenerateUserLog("-1", userAccount.UserId.ToString(), userAccount.AccountId.ToString(), message.ClientId, "Authenticate", message.UserName, "failed login.expired account.");
                        }
                    }
                }
                else
                {
                    result.ErrorMessage = " حساب کاربری غیرفعال است!";
                    UserLogGenerator.GenerateUserLog("-1", "-1", "", message.ClientId, "Authenticate", message.UserName, "faild login.user not exist");
                }
              
            }
            else
            {
                result.ErrorMessage = "اطلاعات حساب کاربری اشتباه است!";
                UserLogGenerator.GenerateUserLog("-1", "-1", "", message.ClientId, "Authenticate", message.UserName, "faild login.user not exist");
            }
            
            return result;
        }
        public Common.Message.SignOutResult Logout(Common.Message.SignOutMessage message)
        {
            SignOutResult result = new SignOutResult();
            IdentityTokenGenerator generator = new IdentityTokenGenerator();
            result.IdentityToken = generator.ExpireToken(message.IdentityToken);           
            return result;
        }
        public override void Insert(AccountDto entityDto)
        {
            base.Insert(entityDto);
        }
        public override void Delete(AccountDto entityDto)
        {
            base.Delete(entityDto);
        }
        public Common.DTO.AccountDto CreateAccount(Common.DTO.AccountDto account, Common.DTO.UserDto user)
        {
            SecurityUserTDataAccess userDa = new SecurityUserTDataAccess();
            var dbUser = userDa.GetSingle(it => it.UserId == user.UserId);
            if (dbUser != null)
            {
                account.UserId = user.UserId;
                this.Insert(account);
                if (account.ApplicationDomainDtoList != null && account.ApplicationDomainDtoList.Count > 0)
                {
                    List<AccountToAppDomainDto> accToAppList = new List<AccountToAppDomainDto>();
                    AccountToAppDomainTDataAccess accToAppDa = new AccountToAppDomainTDataAccess();
                    foreach (var item in account.ApplicationDomainDtoList)
                    {
                        AccountToAppDomainDto accToApp = new AccountToAppDomainDto()
                        {
                            AccountId = account.AccountId,
                            AppDomainId = item.ApplicationDomainId
                        };
                        accToAppList.Add(accToApp);
                    }
                    if (accToAppList.Count > 0)
                    {
                        accToAppDa.Insert(accToAppList);
                    }
                }
            }
            else
            {
                account.Response.AddBusinessException("کاربر موجود نیست!", BusinessExceptionEnum.Validation);
            }

            return account;
        }

        public Framework.Common.Service.Message.ResponseDto DeleteAccount(Common.DTO.AccountDto account)
        {
            ResponseDto response = new ResponseDto();
            var dbAccount = this.GetSingle(it => it.AccountId == account.AccountId);
            if (dbAccount != null)
            {
                dbAccount.Enabled=0;
                dbAccount.ExpiredDate = DateTime.Now;
                this.Update(dbAccount);
            }
            else
            {
                response.Response.AddBusinessException("حساب کاربری موجود نیست!", BusinessExceptionEnum.Validation);
            }
            return response;
        }
        public Framework.Common.Service.Message.ResponseDto UpdateAccount(Common.DTO.AccountDto account)
        {
            ResponseDto response = new ResponseDto();
            AccountToAppDomainTDataAccess accAppDa = new AccountToAppDomainTDataAccess();
            var dbAccount = this.GetSingle(it => it.AccountId == account.AccountId);
            if (dbAccount != null)
            {
                List<AccountToAppDomainDto> deletedAppDomain = new List<AccountToAppDomainDto>();
                List<AccountToAppDomainDto> insertedAppDomain = new List<AccountToAppDomainDto>();
                foreach (var item in account.ApplicationDomainDtoList)
                {
                    if (item.State == Framework.Common.CommonBase.DtoObjectState.Deleted)
                    {
                        var accApp = accAppDa.GetSingle(it => it.AppDomainId == item.ApplicationDomainId && it.AccountId == account.AccountId);
                        if (accApp!=null)
                           deletedAppDomain.Add(accApp);
                    }
                    if (item.State == Framework.Common.CommonBase.DtoObjectState.Inserted)
                    {
                        AccountToAppDomainDto newDto = new AccountToAppDomainDto()
                        {
                            AccountId= account.AccountId,
                            AppDomainId = item.ApplicationDomainId                            
                        };
                        insertedAppDomain.Add(newDto);
                    }
                }
                if (deletedAppDomain.Count > 0)
                {
                    accAppDa.Delete(deletedAppDomain);
                }
                if (insertedAppDomain.Count > 0)
                {
                    accAppDa.Insert(insertedAppDomain);
                }
                dbAccount.Enabled = account.Enabled;
               
                dbAccount.Username = account.Username;
                this.Update(dbAccount);
            }
            else
            {
                response.Response.AddBusinessException("حساب کاربری موجود نیست!", BusinessExceptionEnum.Validation);
            }
            return response;
        }
        public AccountDto ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return  ((AccountTDataAccess)this.dataAccess).ChangePassword(userName, oldPassword, newPassword);
        }
        public AccountDto ResetPassword(string userName, long userId)
        {
            return ((AccountTDataAccess)this.dataAccess).ResetPassword(userName, userId);
        }
    }
}
