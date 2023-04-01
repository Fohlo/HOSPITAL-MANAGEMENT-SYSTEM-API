using Newtonsoft.Json;
using SAMS.Models.Admissions;
using System;
using System.Collections.Generic;
using System.Globalization;
using SAMS.BLL.Drugs;
using System.Linq;
using System.Threading.Tasks;

using static SAMS.Models.Shipment.Test;

namespace SAMS.BLL.Shipment
{
    public class ShipmentBLL
    {
        public List<ShipmentMDL> shipments = new List<ShipmentMDL>();

        public static List<ShipmentMDL> GetShipments(string session, string clause)
        {
            try 
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<ShipmentMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<ShipmentMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static ShipmentMDL AddShipment(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "MATONE");
                return JsonConvert.DeserializeObject<ShipmentMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ShipmentMDL addShipmentPre(string session, ShipmentMDL shipmentCollection)
        {
            try
            {

                return AddShipment(session, JsonConvert.SerializeObject(shipmentCollection));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
