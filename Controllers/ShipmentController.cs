using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using static SAMS.Models.Shipment.Test;
using SAMS.BLL.Shipment;
//using SAMS.Models.Shipment;
//using ShipmentMDL = SAMS.Models.Shipment.ShipmentMDL;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        [HttpPost]
        public ErrorMDL Post(string session, ShipmentMDL shipmentCollection)
        {
            try
            {
                //shipmentCollection.U_CreatedDate = DateTime.Today.ToString("dd/MM/yyyy");

                var post = ShipmentBLL.addShipmentPre(session, shipmentCollection);
                return new ErrorMDL
                {
                    Success = "Succesfully Added"
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

        [HttpGet]
        [Route("GetAllShipments")]
        public ErrorMDL Get(string session)
        {
            try
            {
                var clause = "MATONE";
                var getfloor = ShipmentBLL.GetShipments(session, clause);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getfloor)
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
