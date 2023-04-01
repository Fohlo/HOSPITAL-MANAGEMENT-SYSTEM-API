using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.BLL.Drugs;
using SAMS.BLL.Patient;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using static SAMS.Models.Fluids.FluidsDailyOrder;
using static SAMS.Models.Drugs.DrugMDL;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {

        [HttpPost]
        public ErrorMDL Post(string session, DrugAdmin shipmentCollection)
        {
            try
            {
                //shipmentCollection.U_Date = DateTime.Today.ToString("dd/MM/yyyy");

                var post = DrugsBLL.addShipmentPre(session, shipmentCollection);
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
        [Route("GetAllCarePlans")]
        public ErrorMDL Get(string session)
        {
            try
            {
                var clause = "DRUGSADMIN";
                var getfloor = DrugsBLL.GetShipments(session, clause);

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
        [HttpGet]
        [Route("GetByID")]
        public ErrorMDL Get(string session, string PatientID)
        {
            try
            {
                var get = DrugsBLL.getCarePlanByID(session, PatientID);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(get)
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
        [Route("Getspecific")]
        public ErrorMDL Get(string session, int DocEntry)
        {
            try
            {
                var get = DrugsBLL.getPlan(session, DocEntry);

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(get)
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
