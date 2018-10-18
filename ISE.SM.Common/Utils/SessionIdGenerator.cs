using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Common.Utils
{
    public class SessionIdGenerator
    {
        public static string GenrateNewSessionId()
        {
            
                return Guid.NewGuid().ToString();
            
        }
        public static string GetStringSessionId(byte[] sessionId)
        {
           return  new Guid(sessionId).ToString();

        }
        public static string GetStringSessionId(long sessionId)
        {
            return new Guid(sessionId.ToString()).ToString();

        }
        public static byte[] GetByteSessionId(string sessionID)
        {
            return new Guid(sessionID).ToByteArray();
        }
    }
}
