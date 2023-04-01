using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.BLL.BusinessPartner;
using SAMS.BLL.Files;
using SAMS.BLL.Floors;
using SAMS.BLL.Notification;
using SAMS.BLL.Patient;
using SAMS.BLL.Pipeline;
using SAMS.Models;
using SAMS.Models.Admissions;
using SAMS.Models.Floor;

namespace SAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsController : ControllerBase
    {
        [HttpGet]
        public ErrorMDL Get(string session)
        {
            try
            {
                var clause = "Admission?$filter = U_Status eq 'Open'";
                var getfloors = AdmissionsBLL.GetAdmissions(session, clause);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getfloors)
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
        [Route("GetDischarged")]
        public ErrorMDL Gett(string session)
        {
            try
            {
                var clause = "Admission?$filter = U_Status eq 'Discharged'";
                var getfloors = AdmissionsBLL.GetAdmissions(session, clause);
                return new ErrorMDL
                {
                    Success = JsonConvert.SerializeObject(getfloors)
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



        // GET: api/Floors/5
        [HttpGet]
        [Route("GetByPatientID")]
        public ErrorMDL Get(string session, int PatientID)
        {
            try
            {
                var getfloor = AdmissionsBLL.GetAdmission(session, PatientID);
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
        [Route("Discharge")]
        public ErrorMDL Discharge(string session, int Docentry, string life)
        {
            try
            {
                var  lives = new Globals.Globals.Life();
                if (life == "Yes")
                {
                    lives  = Globals.Globals.Life.Alive;
                }
                else
                {
                    lives = Globals.Globals.Life.Deceased;
                }
                var getDoc = AdmissionsBLL.GetAdmission(session, Docentry);
                var num = ( DateTime.Today.Date - Convert.ToDateTime(getDoc.U_Date).Date).Days;
                var clause = "{\"U_Status\": \"Discharged\",\"U_Life\": \""+lives+ "\",\"U_NumOfdays\":" + num+",\"U_DisDate\": \""+ DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + "\"}";

                var edit = Pipeline.Patch(session,clause, "Admission(" + Docentry+")" );

                var line = new EditFloor.Floorlinescollection();
                var room = FloorBLL.GetFloors(session);

                foreach (FloorMDL flor in room)
                {
                    if (flor.U_FloorID == getDoc.U_Floor)
                    {
                        line = JsonConvert.DeserializeObject<EditFloor.Floorlinescollection>(JsonConvert.SerializeObject((from x in flor.FLOORLINESCollection where x.U_Room == getDoc.U_Room select x).ToList()[0]));
                        line.U_Status = Globals.Globals.RoomStatus.Open;
                        line.U_PatientID = "None";
                        line.U_AdDoc = 0;
                    }
                }

                if (line.U_Room != null)
                {
                    var full = new EditFloor
                    {
                        FLOORLINESCollection = new List<EditFloor.Floorlinescollection> { line }
                    };
                    var edits = Pipeline.Patch(session, JsonConvert.SerializeObject(full), "FLOOR("+line.DocEntry+")");
                }
                var clauses = "CheckPatient?$filter = U_Status eq 'Open' and U_PatientID eq '" + getDoc.U_PatientID + "'";
                var closePatientCheck = PatientBLL.GetCheck(session, clauses);
                var patcher = "{\"U_Status\": \"Closed\"}";
                var close = PatientBLL.patch(session, patcher, closePatientCheck[0].DocEntry);
                return new ErrorMDL
                {
                    Success = "Patient Has been Discharged"
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

        // POST: api/Floors
        [HttpPost]
        public ErrorMDL Post(string session, AdmitMDL floor)
        {
            try
            { 
                if (floor.Image != null)
                {
                    var upload = new FileBLL();
                    byte[] bytes = Convert.FromBase64String(floor.Image);
                    var saveImage = upload.UploadFile(bytes, session, floor.ext, floor.AdmitPatient.U_PatientName);
                }

                var data = AdmissionsBLL.Create(session, floor.AdmitPatient);
                floor.floor.FLOORLINESCollection[0].U_PatientID = data.U_PatientID;
                floor.floor.FLOORLINESCollection[0].U_AdDoc = data.DocEntry;
                var floors = FloorBLL.EditRoom(session, floor.DocEntry, floor.floor);
                var BP = BPBLL.AddBusinesP(session, data);
                var messaage = "You have been assigned patient " + data.U_PatientName + " in " + data.U_Floor;
                var messaage2 = "New patient Admitted Name " + data.U_PatientName + " in " + data.U_Floor;
                var notify = NotificationBLL.Send(session, floor.DocID, messaage, "Admission", Globals.Globals.LoginTypes.Doctor);
                var notifies = NotificationBLL.Send(session, floor.DocID, messaage2, "Admission", Globals.Globals.LoginTypes.Doctor);
                return new ErrorMDL
                {
                    Success = "Patient  Has Been Admitted"
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
        public ErrorMDL create(string session, UpdateMDL floor)
        {
            try
            {               

                var data = AdmissionsBLL.Patch(session, floor.patch, floor.Doc);
                if(floor.floor.FLOORLINESCollection[0] != null) 
                {
                    var floors = FloorBLL.EditRoom(session,  floor.floor, data);
                }         

                return new ErrorMDL
                {
                    Success = "Patient Details have Been Updated"
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

        // PUT: api/Admissions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
