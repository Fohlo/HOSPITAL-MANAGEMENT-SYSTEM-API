using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.CALLS
{
    public class CallsMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public string U_OrgName { get; set; }
        public string U_PtName { get; set; }
        public string U_Age { get; set; }
        public string U_Location { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender U_Gender { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Tests U_TestStatus { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestResult { get; set; }
        public string U_NationalID { get; set; }
        public string U_PatientID { get; set; }
        public string U_Date { get; set; }
        public string U_Phone { get; set; }
        public List<Callslinescollection> CALLSLINESCollection { get; set; }
        
        public class Callslinescollection
        {
            public int LineId { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Level U_Level { get; set; }
            public string U_Symptom { get; set; }
            public string U_Date { get; set; }
        }

    }


    public class AddCallsMDL
    {
        public string U_OrgName { get; set; }
        public string U_PtName { get; set; }
        public string U_Age { get; set; }
        public string U_Location { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender U_Gender { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Tests U_TestStatus { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestResult { get; set; }
        public string U_PatientID { get; set; }
        public string U_NationalID { get; set; }
        public string U_Date { get; set; }
        public string U_Phone { get; set; }
        public List<Callslinescollection> CALLSLINESCollection { get; set; }

        public class Callslinescollection
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public Level U_Level { get; set; }
            public string U_Symptom { get; set; }
            public string U_Date { get; set; }

        }

    }

    public class PatchCall
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestResult { get; set; }
    }
    
}
