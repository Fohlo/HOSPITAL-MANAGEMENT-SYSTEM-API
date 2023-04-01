using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.BLL.Matrons;
using SAMS.BLL.Patient;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using SAMS.Models.MatronsReport;
using static SAMS.Models.MatronsReport.MatronsReport;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatronsController : ControllerBase
    {
        [HttpPost]


        public ErrorMDL Post(string session, MatronsDailyReport MTRONREPORTCollection)
        {
            try
            {
                //shipmentCollection.U_CreatedDate = DateTime.Today.ToString("dd/MM/yyyy");

                var post = MatronsBLL.addMatronPre(session, MTRONREPORTCollection);
                return new ErrorMDL
                {
                    Success = "Document Succesfully Added"
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
   
//public ErrorMDL Post(string session, PostMatronsDailyReport matrons)
//{
//    try
//    {
//        matrons.U_Date = DateTime.Today.ToString("dd/MM/yyyy");

//        var post = PatientBLL.addMatronsReports(session, matrons);
//        return new ErrorMDL
//        {
//            Success = "Patient Report has succesfully Added"
//        };
//    }
//    catch (Exception ex)
//    {
//        return new ErrorMDL
//        {
//            Error = ex.Message
//        };
//    }
//}
[HttpGet]
        [Route("GetByPatientID")]
        public ErrorMDL Get(string session, string PatientID)
        {
            try
            {
                var getfloor = MatronsBLL.GetMatron_Report(session, PatientID);

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
        [Route("Matron_ReportPatch")]
        public ErrorMDL Matron_ReportPatch(string session, int ColN, int row, string ChV, string PatientID, string DocType)
        {
            try
            {
                try
                {
                    var getfloor = MatronsBLL.GetMatron_Report(session, PatientID);
                    var dat = JsonConvert.DeserializeObject<List<MatronsDailyReport>>(JsonConvert.SerializeObject(getfloor));


                        //if (ColN == 0)
                        //{
                        //    dat[0].U_Time = ChV;
                        //}
                        //else if (ColN == 1)
                        //{
                        //    dat[0].U_Date = ChV;
                        //}
                        //else if (ColN == 2)
                        //{
                        //    dat[0].U_Ward = ChV;

                        //}

                        //else if (ColN == 3)
                        //{
                        //    dat[0].U_Diagnosis = ChV;
                        //}

                        //else if (ColN == 4)
                        //{
                        //    dat[0].U_PostOPDays = ChV;
                        //}

                        //else if (ColN == 5)
                        //{
                        //    dat[0].U_Doctor = ChV;
                        //}
                        //if (ColN == 6)
                        //{
                        //    dat[0].U_Age = ChV;
                        //}
                        //else if (ColN == 7)
                        //{
                        //    dat[0].U_RoomNo = ChV;
                        //}
                        //else if (ColN == 8)
                        //{
                        //    dat[0].U_Nurse = ChV;
                        //}
                        //else if (ColN == 9)
                        //{
                        //    dat[0].U_NumOfP = ChV;
                        //}
                        //else if (ColN == 10)
                        //{
                        //    dat[0].U_PatientID = ChV;
                        //}
                        //else if (ColN == 11)
                        //{
                        //    dat[0].U_PatientName = ChV;
                        //}
                        //else if (ColN == 12)
                        //{
                        //    dat[0].U_DateofAdim = ChV;
                        //}


                    
                    
                        //if (ColN == 1)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Time =(ChV);
                        //}
                        //else if (ColN == 2)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Date = (ChV);
                        //}
                        //else if (ColN == 3)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Ward = (ChV);

                        //}

                        //else if (ColN == 4)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Diagnosis = (ChV);
                        //}

                        //else if (ColN == 5)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_PostOPDays = (ChV);
                        //}

                        //else if (ColN == 6)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Doctor = (ChV);
                        //}

                        //else if (ColN == 7)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Age = (ChV);
                        //}
                        //else if (ColN == 8)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_RoomNo = (ChV);
                        //}
                        //else if (ColN == 9)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_Nurse = (ChV);
                        //}
                        //else if (ColN == 10)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_NumOfP = (ChV);
                        //}

                       if (ColN == 11)
                        {
                            dat[0].MTRONREPORTCollection[row].U_PatientID = (ChV);
                        }

                        else if (ColN == 12)
                        {
                            dat[0].MTRONREPORTCollection[row].U_PatientName =(ChV);
                        }

                        //else if (ColN == 13)
                        //{
                        //    dat[0].MTRONREPORTCollection[row].U_DateofAdim = (ChV);
                        //}
                     
                    




                    var clause = JsonConvert.SerializeObject(dat[0]);
                        var edit = Pipeline.Patch(session, clause, "Matron_Report");

                        return new ErrorMDL
                        {
                            Success = "Report Has been updated"
                        };

                    }
                
                catch (Exception ex)
                {
                    return new ErrorMDL
                    {
                        Error = "Report Has not been updated"
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

    