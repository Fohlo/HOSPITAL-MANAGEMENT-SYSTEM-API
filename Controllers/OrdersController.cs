using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMS.BLL;
using SAMS.Models;
using SAMS.Models.Order;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public ErrorMDL Post(string session, OrderEntry order)
        {
            try
            {
               
                var orders = OrderBLL.Addorder(session,order);
               
                return new ErrorMDL
                {
                    Success = "Order has been Created"
                };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }
    }

    
}