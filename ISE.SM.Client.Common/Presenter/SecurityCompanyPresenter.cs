using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.Common.Presenter
{
    public class SecurityCompanyPresenter
    {
        private ServiceAdapter<ISecurityCompanyService> SecurityCompanyServiceAdapter;
         public SecurityCompanyPresenter()
       {
           IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
           SecurityCompanyServiceAdapter = new ServiceAdapter<ISecurityCompanyService>(exceptionManager);
       }
       public CompanyDtoContainer GetAll()
       {
           var result = (CompanyDtoContainer)SecurityCompanyServiceAdapter.Execute(s => s.GetAll());
           return result;
       }
       public CompanyDto Insert(CompanyDto SecurityCompany)
       {

           CompanyDto result = (CompanyDto)SecurityCompanyServiceAdapter.Execute(s => s.Insert(SecurityCompany));
           if (result.Response.HasException)
           {
               return null;
           }
           SecurityCompany.CompanyId = result.CompanyId;
           return SecurityCompany;
       }
       public bool Update(CompanyDto SecurityCompany)
       {

           ResponseDto response = SecurityCompanyServiceAdapter.Execute(s => s.Update(SecurityCompany));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
       public bool Remove(CompanyDto SecurityCompany)
       {

           ResponseDto response = SecurityCompanyServiceAdapter.Execute(s => s.Delete(SecurityCompany));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
    }
}
