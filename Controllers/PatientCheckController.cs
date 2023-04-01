using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Patient;
using SAMS.Models;
using SAMS.Models.Patient;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCheckController : ControllerBase
    {
        // GET: api/PatientCheck
        [HttpGet]
        public ErrorMDL Get(string session)
        {
            try
            {
                var clause = "CheckPatient?$filter = U_Status eq 'Open'";
                var getcheck = PatientBLL.GetCheck(session, clause);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getcheck),
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
        [Route("ByPatientID")]
        public ErrorMDL Get(string session, string PatientID)
        {
            try
            {
                var clause = "CheckPatient?$filter = U_Status eq 'Open' and U_PatientID eq '"+PatientID+"'";
                var getcheck = PatientBLL.GetCheck(session, clause);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getcheck),
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
        [Route("ByPatientDoc")]
        public ErrorMDL Get(string session, int DocEntry)
        {
            try
            {
                var clause = "CheckPatient?$filter = U_Status eq 'Open' and U_AdmissionID eq " + DocEntry + "";
                var getcheck = PatientBLL.GetCheck(session, clause);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getcheck),
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


        // POST: api/PatientCheck
        [HttpPost]
        public ErrorMDL Post(PostCheck Post, string session, string State)
        {
            try
            { var statee = new Globals.Globals.State();
                if (State == "ICU")
                {
                    statee = Globals.Globals.State.ICU;
                }
                else if(State == "HDU")
                {
                    statee = Globals.Globals.State.HDU;
                }
                else
                {
                    statee = Globals.Globals.State.General;
                }
                var post = PatientBLL.addDocument(session, Post, statee);
                return new ErrorMDL
                {
                    Success = "Patient check document Has been created"
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

        [HttpPost]
        [Route("Update")]
        public ErrorMDL Patch(PatchCheck Post, string session, int DocEntry, string State)
        {
            try
            {
                var statee = new Globals.Globals.State();
                if (State == "ICU")
                {
                    statee = Globals.Globals.State.ICU;
                }
                else if (State == "HDU")
                {
                    statee = Globals.Globals.State.HDU;
                }
                else
                {
                    statee = Globals.Globals.State.General;
                }
                var post = PatientBLL.PatchDocument(session, Post, Post.U_AdmissionID, statee);
                return new ErrorMDL
                {
                    Success = "Patient check document Has been created"
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
