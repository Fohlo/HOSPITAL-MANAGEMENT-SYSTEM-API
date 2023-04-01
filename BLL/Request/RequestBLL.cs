using Newtonsoft.Json;
using SAMS.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Request
{
    public class RequestBLL
    {

        public static List<RequestMDL> GetRequest(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<RequestMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<RequestMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static RequestMDL Getspecific(string session, int Docentry)
        {
            try
            {
                var clause = "REQUEST(" + Docentry + ")";
                var getData = Pipeline.Pipeline.Get(session, clause);
                var data = (JsonConvert.DeserializeObject<RequestMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static RequestMDL Post(string session, PostrequestMDL details)
        {
            try
            {
                details.U_RequestByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                details.U_RequestBy = Globals.Globals.AuthSessions[session].EmployeeName;
                var getData = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(details), "REQUEST");
                var data = (JsonConvert.DeserializeObject<RequestMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string Patch(string session, PatchrequestMDL details)
        {
            try
            {
                details.U_DisbursedByID = (int)Globals.Globals.AuthSessions[session].EmployeeID;
                details.U_DisbursedBy = Globals.Globals.AuthSessions[session].EmployeeName;
                var getData = Pipeline.Pipeline.Patch(session, JsonConvert.SerializeObject(details), "REQUEST");
                
                return getData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
