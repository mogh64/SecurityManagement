using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.View
{
    public class ResourceView
    {
        ResourcePresenter presenter = new ResourcePresenter();
        public ResourceView() { }
        List<ApplicationDomainDto> AppDomainList = new List<ApplicationDomainDto>();
        List<ResourceTypeDto> ResourceTypeList = new List<ResourceTypeDto>();
        List<SecurityResourceDto> ResourceList = new List<SecurityResourceDto>();
        List<LoginTypeDto> LoginTypeList=new List<LoginTypeDto>();
        List<PermissionDto> PermissionDtolist = new List<PermissionDto>();
        int callState = 1;
        public List<SecurityResourceDto> LoadCatchResources()
        {
            return ResourceList;
        }
        public List<SecurityResourceDto> LoadResources(long userId,int all=1,bool reload=false)
        {

            //if (ResourceList.Count > 0 && callState==all && !reload)
            //{
            //    return ResourceList;
            //}
            if (all > 0)
            {
                //var list = presenter.GetAll();
                //ResourceList = list.SecurityResourceDtoList;
                PermissionDtolist.Clear();
                PermissionPresenter ppresenter = new PermissionPresenter();
                var container = ppresenter.GetAllUserPermissios(userId);
                ResourceList = container.SecurityResourceDtoList;
                PermissionDtolist = container.PermissionDtoList;
            }
            else
            {
                PermissionPresenter ppresenter = new PermissionPresenter();
                var container = ppresenter.GetAllCurrentUserPermissios(userId);
                ResourceList =container.SecurityResourceDtoList;
                PermissionDtolist= container.PermissionDtoList;

            }

            return ResourceList;
        }
        public List<SecurityResourceDto> LoadResources(int roleId, int all = 1, bool reload = false)
        {

            //if (ResourceList.Count > 0 && callState==all && !reload)
            //{
            //    return ResourceList;
            //}
            if (all > 0)
            {
                //var list = presenter.GetAll();
                //ResourceList = list.SecurityResourceDtoList;
                PermissionDtolist.Clear();
                PermissionPresenter ppresenter = new PermissionPresenter();
                var container = ppresenter.GetAllRolePermissios(roleId);
                ResourceList = container.SecurityResourceDtoList;
                PermissionDtolist = container.PermissionDtoList;
            }
            else
            {
                PermissionPresenter ppresenter = new PermissionPresenter();
                var container = ppresenter.GetAllCurrentRolePermissios(roleId);
                ResourceList = container.SecurityResourceDtoList;
                PermissionDtolist = container.PermissionDtoList;

            }

            return ResourceList;
        }
        public List<PermissionDto> LoadPermissions()
        {

            if (PermissionDtolist.Count > 0)
            {
                return PermissionDtolist;
            }
            PermissionPresenter permissionPresenter=new PermissionPresenter();
            var list = permissionPresenter.GetAll().PermissionDtoList;
            if (list != null)
            {
                PermissionDtolist.AddRange(list);
            }
            return PermissionDtolist;
        }
        public bool Insert(SecurityResourceDto role)
        {
            if (presenter.Insert(role) != null)
            {
                ResourceList.Add(role);
                return true;
            }
            return false;
        }
        public bool InsertAppDomain(ApplicationDomainDto appDomain)
        {
            AppDomainPresenter appPresenter = new AppDomainPresenter();
            if (appPresenter.Insert(appDomain) != null)
            {
                AppDomainList.Add(appDomain);
                return true;
            }
            return false;
        }
        public bool Update(SecurityResourceDto resource)
        {
            if (presenter.Update(resource))
            {
                return true;
               
            }
            return false;
        }
        public bool UpdateAppDomain(ApplicationDomainDto appDomain)
        {
            AppDomainPresenter appPresenter = new AppDomainPresenter();
            if (appPresenter.Update(appDomain))
            {
                return true;
            }
            return false;
        }
        public bool Remove(SecurityResourceDto role)
        {
            if (presenter.Remove(role))
            {
                return true;
            }
            return false;
        }
        public bool RemoveAppDomain(ApplicationDomainDto appDomain)
        {
            AppDomainPresenter appPresenter = new AppDomainPresenter();
            if (appPresenter.Remove(appDomain))
            {
                return true;
            }
            return false;
        }
        public List<ApplicationDomainDto> LoadApplicationDomains()
        {
            if (AppDomainList.Count > 0)
            {
                return AppDomainList;
            }
            List<ApplicationDomainDto> lst = new List<ApplicationDomainDto>();
            AppDomainPresenter appDomainPresenter = new AppDomainPresenter();
            var result = appDomainPresenter.GetAppDomainContainer();
            if (LoginTypeList.Count==0)
               LoginTypeList.AddRange(result.LoginTypeDtoList);
            if (result.ApplicationDomainDtoList != null && result.ApplicationDomainDtoList.Count > 0)
            {
                lst.AddRange(result.ApplicationDomainDtoList);
            }
            AppDomainList.AddRange(lst);
            return AppDomainList;
        }
        public List<ApplicationDomainDto> LoadApplicationDomains(long userId)
        {
           
            List<ApplicationDomainDto> lst = new List<ApplicationDomainDto>();
            AppDomainPresenter appDomainPresenter = new AppDomainPresenter();
            var result = appDomainPresenter.GetAppDomainContainer(userId);
            if (LoginTypeList.Count == 0)
                LoginTypeList.AddRange(result.LoginTypeDtoList);
            if (result.ApplicationDomainDtoList != null && result.ApplicationDomainDtoList.Count > 0)
            {
                lst.AddRange(result.ApplicationDomainDtoList);
            }
         
            return lst;
        }
        public List<LoginTypeDto> GetLoginTypes()
        {
             if (LoginTypeList.Count==0)
             {
                 AppDomainPresenter appDomainPresenter = new AppDomainPresenter();
                 var result = appDomainPresenter.GetAppDomainContainer();
                 LoginTypeList.AddRange(result.LoginTypeDtoList);
             }
             return LoginTypeList;
        }
        public List<ResourceTypeDto> LoadResourceTypeList()
        {
            if (ResourceTypeList.Count > 0)
            {
                return ResourceTypeList;
            }
            List<ResourceTypeDto> lst = new List<ResourceTypeDto>();
            AppDomainPresenter appDomainPresenter = new AppDomainPresenter();
            var result = appDomainPresenter.GetResourceTypeList();
            if (result != null && result.Count > 0)
            {
                lst.AddRange(result);
            }
            ResourceTypeList.AddRange(lst);
            return ResourceTypeList;
        }
    }
}
