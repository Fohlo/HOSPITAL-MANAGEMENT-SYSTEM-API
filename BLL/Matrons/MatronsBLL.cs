using Newtonsoft.Json;
using SAMS.Models.Admissions;
using SAMS.Models.MatronsReport;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.Fluids.FluidsDailyOrder;
using static SAMS.Models.MatronsReport.MatronsReport;

namespace SAMS.BLL.Matrons
{
    public class MatronsBLL
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
        public static MatronsDailyReport AddMatronn(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "Matron_Report");
                return JsonConvert.DeserializeObject<MatronsDailyReport>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static MatronsDailyReport addMatronPre(string session, MatronsDailyReport MTRONREPORTCollection)
        {
            try
            {

                return AddMatronn(session, JsonConvert.SerializeObject(MTRONREPORTCollection));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    public static List<MatronsDailyReport> GetMatron_Report(string session, string PatientID)
        {
            try
            {
                var clause = "Matron_Report?$filter = U_PatientID eq '" + PatientID;
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<MatronsDailyReport>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<MatronsDailyReport>>(obj));
                }
                return data;



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}