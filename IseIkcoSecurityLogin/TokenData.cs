using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SecurityLogin
{
    public  class TokenData
    {
       public bool IsValid(){
           return (this.ExpiredDate > DateTime.Now); 
       } 
            

        public string Token { get; set; }

        public string NationalCode { get; set; }

        public string PersonelCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        public int AppCode { get; set; }

        public string SignedToken { get; set; }
    }
}
