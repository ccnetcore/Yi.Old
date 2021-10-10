using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.ElectronicCommerce.Common.IOCOptions
{
    public class JWTTokenOptions
    {
        public string Audience
        {
            get;
            set;
        }
        public string SecurityKey
        {
            get;
            set;
        }
        //public SigningCredentials Credentials
        //{
        //    get;
        //    set;
        //}
        public string Issuer
        {
            get;
            set;
        }
    }
}
