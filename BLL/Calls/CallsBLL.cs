using Newtonsoft.Json;
using SAMS.BLL.Test;
using SAMS.Models.CALLS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.BLL.Calls
{
    public class CallsBLL
    {

        public static List<CallsMDL> getCalls(string session)
        {
            try
            {
                //var clause = "CALLS?$filter = U_Status eq 'Tested'";
                var clause = "CALLS";
                var getdata = Pipeline.Pipeline.GetMultiple( session, clause);
                var data = new List<CallsMDL> { };

                foreach (string obj in getdata)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<CallsMDL>>(obj));
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CallsMDL getCall(string session,int DocEntry)
        {
            try
            {
                var clause = "CALLS("+DocEntry+")";
                var getdata = Pipeline.Pipeline.Get(session,clause);
               
                return JsonConvert.DeserializeObject<CallsMDL>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CallsMDL getCallByID(string session, string PatientID)
        {
            try
            {
                var clause = "CALLS?$filter = U_PatientID eq '"+PatientID+"'";
                var getdata = Pipeline.Pipeline.Get(clause, session);

                return JsonConvert.DeserializeObject<CallsMDL>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static CallsMDL CreateCall(string session, AddCallsMDL Addd)
        {
            try
            {
                if (Addd.U_TestStatus == Tests.Testing)
                {
                    Addd.U_PatientID = "COVD"+ GetShortID().Substring(0, 5);
                }
                foreach ( AddCallsMDL.Callslinescollection line in Addd.CALLSLINESCollection)
                {
                    line.U_Date = DateTime.Today.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                Addd.U_TestResult = Result.None;
                Addd.U_OrgName = Globals.Globals.AuthSessions[session].EmployeeName;
                Addd.U_Date = DateTime.Today.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                var post = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(Addd), "CALLS");
                var result  = JsonConvert.DeserializeObject<CallsMDL>(post);
                //var test = TestBLL.CreateTest(session, result.DocEntry);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GetShortID()
        {
            var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var bytes = new byte[5];
            crypto.GetBytes(bytes); // get an array of random bytes.      
            return BitConverter.ToString(bytes).Replace("-", string.Empty); // convert array to hex values.
        }

        public static string Patch(string session, string data, int DocEntry)
        {
            try
            {
                var Patch = Pipeline.Pipeline.Patch(session, data, "CALLS("+DocEntry+")");
                return "Done";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
