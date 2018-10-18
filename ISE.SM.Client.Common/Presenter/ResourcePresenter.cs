using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Utility.Utils;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.Common.Presenter
{
    public class ResourcePresenter
    {
        private ServiceAdapter<IResourceService> SecurityResourceServiceAdapter;
        public ResourcePresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            SecurityResourceServiceAdapter = new ServiceAdapter<IResourceService>(exceptionManager);
        }
        public List<SecurityResourceDto> GetResources(int resourceTypeId, int appDomainId)
        {
            string filter = ExpressionHelper.PredicateToDynamicString<SecurityResourceDto>(it => it.AppDomainId==appDomainId && it.ResourceTypeId==resourceTypeId);
            var result = (SecurityResourceDtoContainer)SecurityResourceServiceAdapter.Execute(s => s.GetAllByCondition(filter));            
            return result.SecurityResourceDtoList;
        }
        public SecurityResourceDtoContainer GetAll()
        {
            var result = (SecurityResourceDtoContainer)SecurityResourceServiceAdapter.Execute(s => s.GetAll());
            return result;
        }
        public SecurityResourceDto Insert(SecurityResourceDto SecurityResource)
        {

            SecurityResourceDto result = (SecurityResourceDto)SecurityResourceServiceAdapter.Execute(s => s.Insert(SecurityResource));
            if (result.Response.HasException)
            {
                return null;
            }
            SecurityResource.SecurityResourceId = result.SecurityResourceId;
            return SecurityResource;
        }
        public bool Update(SecurityResourceDto SecurityResource)
        {

            ResponseDto response = SecurityResourceServiceAdapter.Execute(s => s.Update(SecurityResource));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool Remove(SecurityResourceDto SecurityResource)
        {

            ResponseDto response = SecurityResourceServiceAdapter.Execute(s => s.Delete(SecurityResource));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public PermissionDtoContainer AddOperatins(SecurityResourceDto resource, List<OperationDto> operations)
        {
            var result = SecurityResourceServiceAdapter.Execute(s => s.AddOperations(resource, operations));
            if (result.Response.HasException)
            {
                return null;
            }
            return result;
        }
        public ResponseDto RemoveOperatin(SecurityResourceDto resource, OperationDto operation)
        {
            var result = SecurityResourceServiceAdapter.Execute(s => s.RemoveOperation(resource, operation));
            if (result.Response.HasException)
            {
                return null;
            }
            return result;
        }
    }
}
