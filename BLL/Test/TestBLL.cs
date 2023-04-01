using Newtonsoft.Json;
using SAMS.BLL.Calls;
using SAMS.Models.CALLS;
using SAMS.Models.Test;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Test
{
    public class TestBLL
    {

        public static List<TestMDL> GetTests(string session, string Clause)
        {
            try
            {
                var getdata = Pipeline.Pipeline.GetMultiple(session, Clause);
                var data = new List<TestMDL> { };

                foreach (string obj in getdata)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<TestMDL>>(obj));
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TestMDL GetTest(string session, int DocEntry)
        {
            try
            {
                var clause = "test(" + DocEntry + ")";
                var getdata = Pipeline.Pipeline.Get(session, clause);

                return JsonConvert.DeserializeObject<TestMDL>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TestMDL CreateTest(string session, int DocEntry)
        {
            try
            {
                var data = new AddTest
                {
                    U_TestOrg  = Globals.Globals.AuthSessions[session].EmployeeName,
                    U_CallDoc = DocEntry,
                    U_Date = DateTime.Today.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    U_TestStats = Globals.Globals.Result.None,
                };
                var post = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(data), "test");
                return JsonConvert.DeserializeObject<TestMDL>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string testResults(string session, int DocEntry, string infor)
        {
            try
            {
                var dat = new Globals.Globals.Result();

                if (infor == "Positive")
                    dat = Globals.Globals.Result.Positive;
                else dat = Globals.Globals.Result.Negative;

                var data = new PatchTest
                {
                    U_TestStats = dat,
                };

                var edit = EditTest(session, DocEntry, JsonConvert.SerializeObject(data));

                var gettest = TestBLL.GetTest(session, DocEntry);

                var call = new PatchCall
                {
                    U_TestResult = gettest.U_TestStats
                };

                var patchcall = CallsBLL.Patch(session, JsonConvert.SerializeObject(call), gettest.U_CallDoc);

                return "Test Results Have Been Added";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string EditTest(string session, int DocEntry, string infor)
        {
            try
            {              
                var post = Pipeline.Pipeline.Patch(session, infor, "test("+DocEntry+")");
               
                return "Done";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
