using ISE.ClassLibrary;

using ISE.Framework.Common.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.CurrentContext
{
    public class ContextHelper
    {
        //public static UserInformation CurrentUserInfo { get; private set; }
        //public static ConsumerDto CurrentConsumer
        //{
        //    get
        //    {
        //        if (ISE.Food.Common.FoodContext.UserContext.CurrentConsumer == null){
        //            if(CurrentUserInfo!=null)
        //            {
        //                SetCurrentUser(CurrentUserInfo);
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        return ISE.Food.Common.FoodContext.UserContext.CurrentConsumer;                
        //    }
        //}
        public static void SetCurrentUser()
        {

            ClientContext context = new ClientContext();

            context.UserID = "";
            context.UserHeaderToken.Add("UserName", "");
            context.UserHeaderToken.Add("PerId", "");
            context.UserHeaderToken.Add("PerNo", "");
            context.UserHeaderToken.Add("ActionId", "");
            context.UserHeaderToken.Add("RoleId", "");
            ClientContextBucket.SetBucket(context);
                                
        }
        //public static ConsumerDto GetCurrentConsumer(string personelCode)
        //{
        //    if (CurrentConsumer == null || (CurrentConsumer != null && CurrentConsumer.PersonelCode != personelCode))
        //    {
                
        //            ConsumerPresenter presenter = new ConsumerPresenter();
        //            var consumer = presenter.GetConsumerByPersonelCode(personelCode);
        //            ISE.Food.Common.FoodContext.UserContext.SetCurrentConsumer(consumer);
                
                
        //    }
        //    return ISE.Food.Common.FoodContext.UserContext.CurrentConsumer;     
        //}
        //public static void DisposeContext()
        //{
        //    CurrentUserInfo = null;
        //    ISE.Food.Common.FoodContext.UserContext.DisposeCurrentConsumer();
        //}
    }
}
