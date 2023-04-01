using Newtonsoft.Json;
using SAMS.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.Stock.StockMDL;

namespace SAMS.BLL.Stocks
{
    public class StockBLL
    {
        public static string Addstock(string session, Stock stocks)
        {
            try
            {
                // check if business partner exists

                var Post = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(stocks), "InventoryGenEntries");

                return "Done";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
