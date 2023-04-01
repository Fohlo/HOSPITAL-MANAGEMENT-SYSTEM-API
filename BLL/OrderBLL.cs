using Newtonsoft.Json;
using SAMS.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL
{
    public class OrderBLL
    {

        public static string Addorder(string session, OrderEntry order)
        {
            try
            {
                // check if business partner exists
              
                    var Post = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(order), "Orders");
               
                return "Done";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
