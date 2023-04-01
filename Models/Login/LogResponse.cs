using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SAMS.Globals.Globals;

namespace SAMS.BLL.Login
{
    public class LogResponse
    {
        public int EmployeeID { get; set; }
        public string Session { get; set; }
        public int InternalKey { get; set; }
        public string UserName { get; set; }
        public LoginTypes LoginTypes { get; set; }

    }
}