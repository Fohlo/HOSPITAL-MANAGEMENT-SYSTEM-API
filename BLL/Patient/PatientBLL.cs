using Newtonsoft.Json;
using SAMS.BLL.Admissions;
using SAMS.Models.MatronsReport;
using SAMS.Models.Patient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.Drugs.DrugMDL;
using static SAMS.Models.Fluids.FluidsDailyOrder;
using static SAMS.Models.MatronsReport.MatronsReport;
using static SAMS.Models.NursingCarePlan.NursingCarePlan;
using static SAMS.Models.Transfer.PatientTrans;

namespace SAMS.BLL.Patient
{
    public class PatientBLL
    {
        public static List<CheckPatientMDL> GetCheck(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<CheckPatientMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<CheckPatientMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CheckPatientMDL Getspecific(string session, int Docentry)
        {
            try
            {
                var clause = "CheckPatient(" + Docentry + ")";
                var getData = Pipeline.Pipeline.Get(session, clause);
                var data = (JsonConvert.DeserializeObject<CheckPatientMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CheckPatientMDL AddDoc(string session, string data)
        {
            try
            {
               var post = Pipeline.Pipeline.Post(session, data, "CheckPatient");
                return JsonConvert.DeserializeObject<CheckPatientMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CheckPatientMDL AddDocFluids(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "FluidsAdmin");
                return JsonConvert.DeserializeObject<CheckPatientMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CheckPatientMDL AddDocPlans(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "CAREPLAN");
                return JsonConvert.DeserializeObject<CheckPatientMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CheckPatientMDL AddDocTransfer(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "WARDSXFERR");
                return JsonConvert.DeserializeObject<CheckPatientMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static MatronsDailyReport AddDocMatrons(string session, string data)
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
        public static CheckPatientMDL AddDocDrugs(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "DrugsAdmin");
                return JsonConvert.DeserializeObject<CheckPatientMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string patch(string session, string data, int DocEntry)
        {
            try
            {
                var post = Pipeline.Pipeline.Patch(session, data, "CheckPatient(" + DocEntry+")");
                //var post1= Pipeline.Pipeline.Patch(session, data, "MTRONREPORT(" + DocEntry + ")");
                //var post2 = Pipeline.Pipeline.Patch(session, data, "CAREPLAN(" + DocEntry + ")");
                //var post3 = Pipeline.Pipeline.Patch(session, data, "DrugsAdmin(" + DocEntry + ")");
                //var post4 = Pipeline.Pipeline.Patch(session, data, "WARDSXFERR(" + DocEntry + ")");
                return "Document Updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      


        public static CheckPatientMDL addFluidsOrder(string session,  PostFluidAdmin Fluids)
        {
            try
            {
                
                return AddDocFluids(session, JsonConvert.SerializeObject(Fluids));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static MatronsDailyReport addMatronsReports(string session, PostMatronsDailyReport Matrons)
        {
            try
            {

                return AddDocMatrons(session, JsonConvert.SerializeObject(Matrons));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CheckPatientMDL addNursingPlan(string session, PostCarePlan Plans)
        {
            try
            {

                return AddDocPlans(session, JsonConvert.SerializeObject(Plans));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CheckPatientMDL addDrugsPre(string session, PostDrugAdmin Drugs)
        {
            try
            {

                return AddDocDrugs(session, JsonConvert.SerializeObject(Drugs));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CheckPatientMDL addTransferPatient(string session, PostPatientTransfer Trans)
        {
            try
            {

                return AddDocTransfer(session, JsonConvert.SerializeObject(Trans));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static CheckPatientMDL addDocument(string session, PostCheck Patient, Globals.Globals.State State)
        {
            try
            {
                foreach (PostCheck.Actionscollection act in Patient.ACTIONSCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                   // act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                foreach (PostCheck.Vitalscheckscollection act in Patient.VITALSCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                foreach (PostCheck.Notescollection act in Patient.NOTESCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                //foreach (PostCheck.Patienttestcollection act in Patient.PATIENTTESTCollection)
                //{
                //   // act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                //   // act.U_AddedbyID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                //   //// act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                //   // act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                //}
                foreach (PostCheck.Medicalscollection act in Patient.MEDICALPRESCCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                   // act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                var clause = "Admission?$filter = U_PatientID eq '" + Patient.U_PatientID+"'";
                var getAdmission = AdmissionsBLL.GetAdmissions(session, clause);
                Patient.U_Status = Globals.Globals.Status.Open;
                Patient.U_State = State;
                Patient.U_AdmissionID = getAdmission[0].DocEntry;
                return AddDoc(session, JsonConvert.SerializeObject(Patient));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public static string PatchDocument(string session, PatchCheck Patient, int Docentry, Globals.Globals.State State )
        {
            try
            {
                foreach (PatchCheck.Actioncollection act in Patient.ACTIONSCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                foreach (PatchCheck.Vitalcheckscollection act in Patient.VITALSCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                foreach (PatchCheck.Notecollection act in Patient.NOTESCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

               
                foreach (PatchCheck.Medicalcollection act in Patient.MEDICALPRESCCollection)
                {
                    act.U_AddedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                    act.U_AddedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                    act.U_LoginType = Globals.Globals.AuthSessions[session].LoginType;
                    act.U_Date = DateTime.Today.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }

                Patient.U_Status = Globals.Globals.Status.Open;
                Patient.U_State = State;
                //var clause = "Admission?$filter = U_PatientID eq '" + Patient.U_PatientID + "'";
                return patch(session, JsonConvert.SerializeObject(Patient), Docentry);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
