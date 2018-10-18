using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Helper
{
    public class ManagementLogGenerator
    {
        public static void GenerateManagementLog(long? userId,string action,string service,short statues,string message,short logTyp)
        {
            ManagementLogBussiness managementLogBs = new ManagementLogBussiness();
            ManagementLogDto log = new ManagementLogDto() { 
                LogType=logTyp,
                Message = message,
                Service = service,
                Statues =statues,
                UserId  = userId,                
            };
            try
            {
                managementLogBs.Insert(log);
            }
            catch
            {

            }
        }
    }
}
