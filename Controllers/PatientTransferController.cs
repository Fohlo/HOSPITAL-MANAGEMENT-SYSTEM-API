using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.BLL.Transfer; 
using SAMS.BLL.Patient;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using static SAMS.Models.Fluids.FluidsDailyOrder;
using static SAMS.Models.Transfer.PatientTrans;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTransferController : ControllerBase
    {
        [HttpPost]
        public ErrorMDL Post(string session, PostPatientTransfer trans)
        {
            try
            {
                trans.U_Date = DateTime.Today.ToString("dd/MM/yyyy");

                var post = PatientBLL.addTransferPatient(session, trans);
                return new ErrorMDL
                {
                    Success = "Patient transfer has succesfully Added"
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
        public ErrorMDL Get(string session, string PatientID)
        {
            try
            {
                var getfloor = TransferBLL.GetWARDSXFERR(session, PatientID);

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
        [Route("WARDSXFERRPatch")]
        public ErrorMDL WARDSXFERRPatch(string session, int ColN, int row, string ChV, string PatientID, string DocType)
        {
            try
            {
                try
                {
                    var getfloor = TransferBLL.GetWARDSXFERR(session, PatientID);
                    var dat = JsonConvert.DeserializeObject<List<PatientTransfer>>(JsonConvert.SerializeObject(getfloor));
                  
                        if (ColN == 0)
                        {
                            dat[0].U_FromWard = ChV;
                        }
                        else if (ColN == 1)
                        {
                            dat[0].U_ToWard = ChV;
                        }
                        else if (ColN == 2)
                        {
                            dat[0].U_FromRoom = ChV;

                        }

                        else if (ColN == 3)
                        {
                            dat[0].U_ToRoom = ChV;
                        }

                        else if (ColN == 2)
                        {
                            dat[0].U_FromBed = ChV;

                        }

                        else if (ColN == 3)
                        {
                            dat[0].U_ToBed = ChV;
                        }

                        else if (ColN == 4)
                        {
                            dat[0].U_Date = ChV;
                        }

                        else if (ColN == 5)
                        {
                            dat[0].U_Time = ChV;
                        }

                    //}

                    //else
                    //{
                    //    if (ColN == 1)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_FromWard = ChV;
                    //    }
                    //    else if (ColN == 2)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_ToWard = ChV;
                    //    }
                    //    else if (ColN == 3)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_FromRoom = ChV;

                    //    }

                    //    else if (ColN == 4)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_ToRoom = ChV;
                    //    }

                    //    else if (ColN == 5)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_FromBed = ChV;
                    //    }

                    //    else if (ColN == 6)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_ToBed = ChV;
                    //    }

                    //    else if (ColN == 7)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_Date = ChV;
                    //    }

                    //    else if (ColN == 8)
                    //    {
                    //        dat[0].TransfersAddCollection[row].U_Time = ChV;
                    //    }


                    //}

                    var clause = JsonConvert.SerializeObject(dat[0]);
                    var edit = Pipeline.Patch(session, clause, "WARDSXFERR(" + dat[0].DocEntry + ")");

                    return new ErrorMDL
                    {
                        Success = "Patient transfer Has been updated"
                    };

                }
                catch (Exception ex)
                {
                    return new ErrorMDL
                    {
                        Error = "Patient transfer Has not been updated"
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



