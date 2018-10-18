using RSAEncryptionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Utility
{
    public class RsaProvider
    {
        private static RSAEncryption rsaEncryption = null;
        public RsaProvider()
        {

        }
        public static RSAEncryption GetRsaEncryption() {
            if (rsaEncryption == null)
                rsaEncryption = new RSAEncryption();
            return rsaEncryption;
        }
    }
}
