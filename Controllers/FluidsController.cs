using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.BLL.Fluids;
using SAMS.BLL.Patient;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using static SAMS.Models.Fluids.FluidsDailyOrder;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluidsController : ControllerBase
    {

        [HttpPost]
        public ErrorMDL Post(string session, PostFluidAdmin fluids)
        {
            try
            {
                fluids.U_Date = DateTime.Today.ToString("dd/MM/yyyy");

                var post = PatientBLL.addFluidsOrder(session, fluids);
                return new ErrorMDL
                {
                    Success = "Patient Schedule has succesfully Added"
                };
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        } // GET: api/<FluidsController>

        [HttpGet]
        [Route("GetByPatientID")]
        public ErrorMDL Get(string session, string  PatientID)
        {
            try
            {
                var getfloor = FluidsBLL.GetFluidsAdmin(session, PatientID);
              
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
        [Route("FluidsAdminPatch")]
        public ErrorMDL FluidsAdminPatch(string session, int ColN, int row,string ChV,string PatientID, string DocType)
       {
            try
            {
                try
                {
                   var getfloor = FluidsBLL.GetFluidsAdmin(session, PatientID);
                    var dat = JsonConvert.DeserializeObject<List<FluidAdmin>>(JsonConvert.SerializeObject(getfloor));
                    if(DocType == "Header1")
                    {
                        if (ColN == 0)
                        {
                            dat[0].U_A = ChV;
                        }
                        else if (ColN == 1)
                        {
                            dat[0].U_B = ChV;
                        }
                        else if (ColN == 2)
                        {
                            dat[0].U_C = ChV;

                        }

                        else if (ColN == 3)
                        {
                            dat[0].U_D = ChV;
                        }

                        else if (ColN == 4)
                        {
                            dat[0].U_E = ChV;
                        }

                        else if (ColN == 5)
                        {
                            dat[0].U_F = ChV;
                        }
                       
                    }
                    else if(DocType == "Header2")
                        {
                        if (ColN == 0)
                        {
                            dat[0].U_G = ChV;
                        }
                        else if (ColN == 1)
                        {
                            dat[0].U_H = ChV;
                        }
                        else if (ColN == 2)
                        {
                            dat[0].U_OC = ChV;
                        }
                        else if (ColN == 3)
                        {
                            dat[0].U_OD = ChV;

                        }

                        else if (ColN == 4)
                        {
                            dat[0].U_OE = ChV;
                        }

                        else if (ColN == 5)
                        {
                            dat[0].U_OF = ChV;
                        }

                    }
                    else
                    {
                        if (ColN == 1)
                        {
                            dat[0].FINTAKESCollection[row].U_A = double.Parse(ChV);
                        }
                        else if (ColN == 2)
                        {
                            dat[0].FINTAKESCollection[row].U_B = double.Parse(ChV);
                        }
                        else if (ColN == 3)
                        {
                            dat[0].FINTAKESCollection[row].U_C = double.Parse(ChV);

                        }

                        else if (ColN == 4)
                        {
                            dat[0].FINTAKESCollection[row].U_D = double.Parse(ChV);
                        }

                        else if (ColN == 5)
                        {
                            dat[0].FINTAKESCollection[row].U_E = double.Parse(ChV);
                        }

                        else if (ColN == 6)
                        {
                            dat[0].FINTAKESCollection[row].U_F = double.Parse(ChV);
                        }

                        else if (ColN == 7)
                        {
                            dat[0].FINTAKESCollection[row].U_G = double.Parse(ChV);
                        }
                        else if (ColN == 8)
                        {
                            dat[0].FINTAKESCollection[row].U_H = double.Parse(ChV);
                        }
                        else if (ColN == 9)
                        {
                            dat[0].FINTAKESCollection[row].U_HRT = double.Parse(ChV);
                        }
                        else if (ColN == 10)
                        {
                            dat[0].FINTAKESCollection[row].U_UR = double.Parse(ChV);
                        }

                        else if (ColN == 11)
                        {
                            dat[0].FINTAKESCollection[row].U_HUT = double.Parse(ChV);
                        }

                        else if (ColN == 12)
                        {
                            dat[0].FINTAKESCollection[row].U_NIG = double.Parse(ChV);
                        }

                        else if (ColN == 13)
                        {
                            dat[0].FINTAKESCollection[row].U_OC = double.Parse(ChV);
                        }

                        else if (ColN == 14)
                        {
                            dat[0].FINTAKESCollection[row].U_OD = double.Parse(ChV);
                        }

                        else if (ColN == 15)
                        {
                            dat[0].FINTAKESCollection[row].U_OE = double.Parse(ChV);
                        }
                        else if (ColN == 16)
                        {
                            dat[0].FINTAKESCollection[row].U_OF = double.Parse(ChV);
                        }
                        else if (ColN == 17)
                        {
                            dat[0].FINTAKESCollection[row].U_RT = double.Parse(ChV);
                        }
                        else if (ColN == 18)
                        {
                            dat[0].FINTAKESCollection[row].U_HR = double.Parse(ChV);
                        }
                    }
                    
                    var clause = JsonConvert.SerializeObject(dat[0]);
                    var edit = Pipeline.Patch(session, clause, "FluidsAdmin(" + dat[0].DocEntry + ")");

                    return new ErrorMDL
                    {
                        Success = "Fluid Chart Has been updated"
                    };

                }
                catch (Exception ex)
                {
                    return new ErrorMDL
                    {
                       Error = "Fluid Chart Has not been updated"
                    };

                }

                
               
                //var edit = Pipeline.Patch(session, clause, "FluidsAdmin(" + fluidAdmin.U_PatientID + ")");



               
            }
            catch (Exception ex)
            {
                return new ErrorMDL
                {
                    Error = ex.Message
                };
            }
        }

        // PUT api/<FluidsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FluidsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
