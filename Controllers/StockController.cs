using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMS.BLL;
using SAMS.BLL.Stocks;
using SAMS.Models;
using SAMS.Models.Order;
using static SAMS.Models.Stock.StockMDL;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        [HttpPost]
        public ErrorMDL Post(string session, Stock stocks)
        {
            try
            {

                var stockss = StockBLL.Addstock(session, stocks);

                return new ErrorMDL
                {
                    Success = "Stock has been Added"
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
