using Newtonsoft.Json;
using SAMS.Models.Admissions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.Fluids.FluidsDailyOrder;

namespace SAMS.BLL.Fluids
{
    public class FluidsBLL
    {
        public static AdmitPatient CreateMDL(AdmitPatient admit, string session)
        {
            try
            {
                //admit.U_PatientID = Calls.CallsBLL.GetShortID();
                admit.U_PatientID = admit.U_NationalID;
                //admit.U_Date = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                admit.U_Life = Globals.Globals.Life.Alive;
                admit.U_RoomNo = admit.U_Room;
                admit.U_WardName = "none";

                //admit.u = Globals.Globals.AuthSessions[session].EmployeeName;
                admit.U_AdmittedBy = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                admit.U_Admitted = Globals.Globals.AuthSessions[session].EmployeeName;
                foreach (Itemscollection items in admit.ITEMSCollection)
                {
                    items.U_Date = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    items.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                }

                return admit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static AdmissionMDL Create(string session, AdmitPatient admit)
        {
            try
            {
                //check if the admission is available before opening a new one
                var clause = "Admission?$filter = U_PatientID eq '" + admit.U_PatientID + "'";
                var get = GetAdmissions(session, clause);
                if (get.Count != 0)
                {
                    return get[0];
                }
                var createmodel = CreateMDL(admit, session);
                var createDoc = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(createmodel), "Admission");
                return JsonConvert.DeserializeObject<AdmissionMDL>(createDoc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<AdmissionMDL> GetAdmissions(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<AdmissionMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<AdmissionMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<FluidAdmin> GetFluidsAdmin(string session, string PatientID)
        {
            try
            {
                var clause = "FluidsAdmin?$filter = U_PatientID eq '" + PatientID + "'&$orderby=DocEntry desc&$top=1";
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<FluidAdmin>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<FluidAdmin>>(obj));
                }
                return data;
               

             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public static AdmissionMDL Patch(string session, PatchAdmission data, int DocEntry)
        //{
        //    try
        //    {
        //        var clause = "Admission(" + DocEntry + ")";
        //        var getfile = GetAdmission(session, DocEntry);
        //        data.U_NumOfdays = (DateTime.Today.Date - Convert.ToDateTime(getfile.U_Date).Date).Days;
        //        data.U_DisDate = "";
        //        data.U_Life = Globals.Globals.Life.Alive;
        //        data.U_Status = Globals.Globals.Status.Open;
        //        data.U_Date = getfile.U_Date;
        //        if (data.U_Floor == null)
        //        {
        //            data.U_Floor = getfile.U_Floor;
        //        }




        //        if (data.U_Floor == null)
        //        {
        //            data.U_Floor = getfile.U_Floor;
        //        }

        //        var PatchData = Pipeline.Pipeline.Patch(session, JsonConvert.SerializeObject(data), clause);

        //        return getfile;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
