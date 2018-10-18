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
   public  class OperationPresenter
    {
       private ServiceAdapter<IOperationService> OperationServiceAdapter;
       public OperationPresenter()
       {
           IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
           OperationServiceAdapter = new ServiceAdapter<IOperationService>(exceptionManager);
       }
       public OperationDtoContainer GetAll()
       {
           var result = (OperationDtoContainer)OperationServiceAdapter.Execute(s => s.GetAll());
           return result;
       }
       public OperationDto Insert(OperationDto Operation)
       {

           OperationDto result = (OperationDto)OperationServiceAdapter.Execute(s => s.Insert(Operation));
           if (result.Response.HasException)
           {
               return null;
           }
           Operation.OperationId = result.OperationId;
           return Operation;
       }
       public bool Update(OperationDto Operation)
       {

           ResponseDto response = OperationServiceAdapter.Execute(s => s.Update(Operation));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
       public bool Remove(OperationDto Operation)
       {

           ResponseDto response = OperationServiceAdapter.Execute(s => s.Delete(Operation));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
    }
}
