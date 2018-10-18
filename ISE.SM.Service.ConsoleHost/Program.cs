using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness.Dependency;
using Router.Contracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
           Configuration.Configure();
           ServiceHostDecorator AuthenticationServiceHost = new ServiceHostDecorator(typeof(AuthenticationService));
           ServiceHostDecorator AuthorizationServiceHost = new ServiceHostDecorator(typeof(AuthorizationService));
           ServiceHostDecorator GroupServiceHost = new ServiceHostDecorator(typeof(GroupService));
           ServiceHostDecorator ManagementServiceHost = new ServiceHostDecorator(typeof(ManagementService));
           ServiceHostDecorator MembershipProviderServiceHost = new ServiceHostDecorator(typeof(MembershipProviderService));
           ServiceHostDecorator PermissionServiceHost = new ServiceHostDecorator(typeof(PermissionService));
           ServiceHostDecorator ResourceServiceHost = new ServiceHostDecorator(typeof(ResourceService));
           ServiceHostDecorator RoleServiceHost = new ServiceHostDecorator(typeof(RoleService));
           ServiceHostDecorator SecurityUserServiceHost = new ServiceHostDecorator(typeof(SecurityUserService));
           ServiceHostDecorator DataServiceHost = new ServiceHostDecorator(typeof(DataService));
           ServiceHostDecorator ApplicationDomainServiceHost = new ServiceHostDecorator(typeof(ApplicationDomainService));
           ServiceHostDecorator OperationServiceHost = new ServiceHostDecorator(typeof(OperationService));
           ServiceHostDecorator SecurityCompanyHost = new ServiceHostDecorator(typeof(SecurityCompanyService));
            try
            {
             LogManager.GetLogger().Info("Service Opened.");

             RoleServiceHost.Open();
             Console.WriteLine(RoleServiceHost.OpenMessage);

             AuthenticationServiceHost.Open();
             Console.WriteLine(AuthenticationServiceHost.OpenMessage);

             AuthorizationServiceHost.Open();
             Console.WriteLine(AuthorizationServiceHost.OpenMessage);

             GroupServiceHost.Open();
             Console.WriteLine(GroupServiceHost.OpenMessage);

             ManagementServiceHost.Open();
             Console.WriteLine(ManagementServiceHost.OpenMessage);

             MembershipProviderServiceHost.Open();
             Console.WriteLine(MembershipProviderServiceHost.OpenMessage);

             PermissionServiceHost.Open();
             Console.WriteLine(PermissionServiceHost.OpenMessage);

             ResourceServiceHost.Open();
             Console.WriteLine(ResourceServiceHost.OpenMessage);

             SecurityUserServiceHost.Open();
             Console.WriteLine(SecurityUserServiceHost.OpenMessage);

             DataServiceHost.Open();
             Console.WriteLine(DataServiceHost.OpenMessage);

             ApplicationDomainServiceHost.Open();
             Console.WriteLine(ApplicationDomainServiceHost.OpenMessage);

             OperationServiceHost.Open();
             Console.WriteLine(OperationServiceHost.OpenMessage);

             SecurityCompanyHost.Open();
             Console.WriteLine(SecurityCompanyHost.OpenMessage);

            Console.WriteLine("Press <Enter> to stop the services");
            Console.ReadKey();
           
            //******************************************************************
            }
            catch (Exception ex)
            {
                // log exception
                LogManager.GetLogger().Error(ex);

                Console.WriteLine(ex.Message);
                if(ex.InnerException!=null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            finally
            {

                if (RoleServiceHost.State != CommunicationState.Faulted)
                    RoleServiceHost.Close();
                if (AuthenticationServiceHost.State != CommunicationState.Faulted)
                    AuthenticationServiceHost.Close();
                if (AuthorizationServiceHost.State != CommunicationState.Faulted)
                    AuthorizationServiceHost.Close();
                if (GroupServiceHost.State != CommunicationState.Faulted)
                    GroupServiceHost.Close();
                if (ManagementServiceHost.State != CommunicationState.Faulted)
                    ManagementServiceHost.Close();
                if (MembershipProviderServiceHost.State != CommunicationState.Faulted)
                    MembershipProviderServiceHost.Close();
                if (PermissionServiceHost.State != CommunicationState.Faulted)
                    PermissionServiceHost.Close();
                if (ResourceServiceHost.State != CommunicationState.Faulted)
                    ResourceServiceHost.Close();
                if (SecurityUserServiceHost.State != CommunicationState.Faulted)
                    SecurityUserServiceHost.Close();
                if (DataServiceHost.State != CommunicationState.Faulted)
                    DataServiceHost.Close();
                if (ApplicationDomainServiceHost.State != CommunicationState.Faulted)
                    ApplicationDomainServiceHost.Close();
                if (OperationServiceHost.State != CommunicationState.Faulted)
                    OperationServiceHost.Close();
                if (SecurityCompanyHost.State != CommunicationState.Faulted)
                    SecurityCompanyHost.Close();
                LogManager.GetLogger().Info("Service Closed.");
            }

        }
    }
}
