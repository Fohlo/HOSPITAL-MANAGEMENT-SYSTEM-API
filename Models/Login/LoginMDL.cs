using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SAMS.Globals.Globals;

namespace SAMS.Models
{
    public class LoginMDL
    {


        public string CompanyDB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginTypes LoginType { get; set; }
    }

}