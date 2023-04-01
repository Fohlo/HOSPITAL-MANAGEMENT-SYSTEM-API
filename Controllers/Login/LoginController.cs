using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL;
using SAMS.Models;
using SAMS.BLL.Login;
using SAMS.BLL.Notification;
using SAMS.BLL.Employee;
using SAMS.BLL.Pipeline;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/Login
        [HttpPost]
        public ErrorMDL Post(UseMDL users)
        {
            try
            {
                SLY.Class1.SLURL = "https://192.192.192.192:50000/b1s/v1/";
                //SLY.Class1.SLURL = "https://192.192.192.192:50000/b1s/v1/";
                //SLY.Class1.SLURL = "https://220.220.220.202:50000/b1s/v1/";
                LoginMDL login = new LoginMDL
                {
                    CompanyDB = users.CompanyDB,
                    UserName = users.UserName,
                    Password = users.Password
                };
                var userlogin = LoginBLL.Login(login);
                if (users.Token != null && users.Token != "")
                {
                    var getuser = EmployeeBLL.DriverName(userlogin.Session, userlogin.EmployeeID);
                    if (getuser.U_NoToken == users.Token)
                    {
                        var data = "{\"U_NoToken\": \"" + users.Token + "\"}";
                       var  patchToken = Pipeline.Patch(userlogin.Session,data, "EmployeesInfo("+userlogin.EmployeeID+")");

                    }
                    NotificationBLL.Registration(userlogin.Session, users.Version, users.Token, users.Release);
                }


                var Success = new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(userlogin)
                };
                return Success;
            }
            catch (Exception ex)
            {
                var error = new ErrorMDL
                {
                    Error = ex.Message
                };
                return error;
            }
        }

    }
}
