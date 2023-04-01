using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Employee;
using SAMS.BLL.Food;
using SAMS.BLL.Items;
using SAMS.BLL.Vitals;
using SAMS.Models;
using SAMS.Models.Employee;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiscController : ControllerBase
    {
        // GET: api/Misc
        [HttpGet]
        [Route("Employees")]
        public ErrorMDL Get(string session)
        {
            try
            {
                var getDoc = EmployeeBLL.UsersByLoginType(session, "Doctor");
                var getNurse = EmployeeBLL.UsersByLoginType(session, "Nurse");
                getDoc.AddRange(getNurse);
                foreach (EmployeeMDL emp in getDoc)
                {
                    emp.FullName = emp.FirstName + " " + emp.LastName;
                }
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getDoc),
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
        [Route("FluidList")]
        public ErrorMDL GetfFluids(string session)
        {
            try
            {
                string clause = "";
                
                    clause = "VITALLIST";
               
                   
              

                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(VitalsBLL.GetVitals(session, clause)),
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
        [Route("VitalList")]
        public ErrorMDL GetVitals(string session, string Type)
        {
            try
            {
                string clause = "";
                if (Type == "All")
                {
                     clause = "VITALLIST?$filter = U_Status eq 'Open'";
                }
                else
                {
                     clause = "VITALLIST?$filter = U_Type eq '" + Type + "'";
                }
               
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(VitalsBLL.GetVitals(session, clause)),
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

        // GET: api/Misc/5
        [HttpGet]
        [Route("FoodList")]
        public ErrorMDL GetFoodList (string session, string schedule)
        {
            try
            {
                var clause = "AFENUM?$filter = U_Date eq '" + DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + "' and U_Schedule eq '"+schedule+"'";
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(FoodBLL.GetAvailableFood(session, clause)),
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
        [Route("Medicals")]
        public ErrorMDL getMedicals(string session)
        {
            try
            {
                var clause = "Items?$filter = U_Medical eq 'Yes'";
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(ItemBLL.GetMultiple(session, clause)),
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
