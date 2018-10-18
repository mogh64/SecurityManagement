using ISE.Framework.Common.Aspects;
using Router.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service.WindowsHost
{
    public class SMWindowsService:ServiceBase
    {
        ServiceHostDecorator AuthenticationServiceHost ;
        ServiceHostDecorator AuthorizationServiceHost ;
        ServiceHostDecorator GroupServiceHost ;
        ServiceHostDecorator ManagementServiceHost ;
        ServiceHostDecorator MembershipProviderServiceHost ;
        ServiceHostDecorator PermissionServiceHost ;
        ServiceHostDecorator ResourceServiceHost ;
        ServiceHostDecorator RoleServiceHost ;
        ServiceHostDecorator SecurityUserServiceHost ;
        ServiceHostDecorator DataServiceHost ;
        ServiceHostDecorator ApplicationDomainServiceHost ;
        ServiceHostDecorator OperationServiceHost ;
        ServiceHostDecorator SecurityCompanyHost ;
        public SMWindowsService()
        {
            this.InitializeComponent();
        }
      
        protected override void OnStart(string[] args)
        {
            if (AuthenticationServiceHost != null)
            {
                AuthenticationServiceHost.Close();
            }
            if (AuthorizationServiceHost != null)
            {
                AuthorizationServiceHost.Close();
            }
            if (GroupServiceHost != null)
            {
                GroupServiceHost.Close();
            }
            if (ManagementServiceHost != null)
            {
                ManagementServiceHost.Close();
            }
            if (MembershipProviderServiceHost != null)
            {
                MembershipProviderServiceHost.Close();
            }
            if (PermissionServiceHost != null)
            {
                PermissionServiceHost.Close();
            }
            if (ResourceServiceHost != null)
            {
                ResourceServiceHost.Close();
            }
            if (RoleServiceHost != null)
            {
                RoleServiceHost.Close();
            }
            if (SecurityUserServiceHost != null)
            {
                SecurityUserServiceHost.Close();
            }
            if (DataServiceHost != null)
            {
                DataServiceHost.Close();
            }
            if (ApplicationDomainServiceHost != null)
            {
                ApplicationDomainServiceHost.Close();
            }
            if (OperationServiceHost != null)
            {
                OperationServiceHost.Close();
            }
            if (SecurityCompanyHost != null)
            {
                SecurityCompanyHost.Close();
            }
             AuthenticationServiceHost = new ServiceHostDecorator(typeof(AuthenticationService));
             AuthorizationServiceHost = new ServiceHostDecorator(typeof(AuthorizationService));
             GroupServiceHost = new ServiceHostDecorator(typeof(GroupService));
             ManagementServiceHost = new ServiceHostDecorator(typeof(ManagementService));
             MembershipProviderServiceHost = new ServiceHostDecorator(typeof(MembershipProviderService));
             PermissionServiceHost = new ServiceHostDecorator(typeof(PermissionService));
             ResourceServiceHost = new ServiceHostDecorator(typeof(ResourceService));
             RoleServiceHost = new ServiceHostDecorator(typeof(RoleService));
             SecurityUserServiceHost = new ServiceHostDecorator(typeof(SecurityUserService));
             DataServiceHost = new ServiceHostDecorator(typeof(DataService));
             ApplicationDomainServiceHost = new ServiceHostDecorator(typeof(ApplicationDomainService));
             OperationServiceHost = new ServiceHostDecorator(typeof(OperationService));
             SecurityCompanyHost = new ServiceHostDecorator(typeof(SecurityCompanyService));
            try
            {
                LogManager.GetLogger().Info("Service Opened.");

                RoleServiceHost.Open();
                

                AuthenticationServiceHost.Open();
                

                AuthorizationServiceHost.Open();
                

                GroupServiceHost.Open();
                

                ManagementServiceHost.Open();
                

                MembershipProviderServiceHost.Open();
                

                PermissionServiceHost.Open();
                

                ResourceServiceHost.Open();
                

                SecurityUserServiceHost.Open();
                

                DataServiceHost.Open();
                

                ApplicationDomainServiceHost.Open();
                

                OperationServiceHost.Open();
                

                SecurityCompanyHost.Open();
                

                

                //******************************************************************
            }
            catch (Exception ex)
            {
                // log exception
                LogManager.GetLogger().Error(ex);

                
            }
           
        }
        protected override void OnStop()
        {
            if (AuthenticationServiceHost != null)
            {
                AuthenticationServiceHost.Close();
                AuthenticationServiceHost = null;
            }
            if (AuthorizationServiceHost != null)
            {
                AuthorizationServiceHost.Close();
                AuthorizationServiceHost = null;
            }
            if (GroupServiceHost != null)
            {
                GroupServiceHost.Close();
                GroupServiceHost = null;
            }
            if (ManagementServiceHost != null)
            {
                ManagementServiceHost.Close();
                ManagementServiceHost = null;
            }
            if (MembershipProviderServiceHost != null)
            {
                MembershipProviderServiceHost.Close();
                MembershipProviderServiceHost = null;
            }
            if (PermissionServiceHost != null)
            {
                PermissionServiceHost.Close();
                PermissionServiceHost = null;
            }
            if (ResourceServiceHost != null)
            {
                ResourceServiceHost.Close();
                ResourceServiceHost = null;
            }
            if (RoleServiceHost != null)
            {
                RoleServiceHost.Close();
                RoleServiceHost = null;
            }
            if (SecurityUserServiceHost != null)
            {
                SecurityUserServiceHost.Close();
                SecurityUserServiceHost = null;
            }
            if (DataServiceHost != null)
            {
                DataServiceHost.Close();
                DataServiceHost = null;
            }
            if (ApplicationDomainServiceHost != null)
            {
                ApplicationDomainServiceHost.Close();
                ApplicationDomainServiceHost = null;
            }
            if (OperationServiceHost != null)
            {
                OperationServiceHost.Close();
                OperationServiceHost = null;
            }
            if (SecurityCompanyHost != null)
            {
                SecurityCompanyHost.Close();
                SecurityCompanyHost = null;
            }
            LogManager.GetLogger().Info("Service Closed.");
        }

        private void InitializeComponent()
        {
            // 
            // SMWindowsService
            // 
            this.ServiceName = "SMWindowsService";

        }
    }
}
