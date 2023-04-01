using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Request
{
    public class RequestMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public request U_Status { get; set; }
        public string U_RequestBy { get; set; }
        public int U_RequestByID { get; set; }
        public string U_DisbursedBy { get; set; }
        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public int U_DisbursedByID { get; set; }
        public List<Requestlinescollection> REQUESTLINESCollection { get; set; }


        public class Requestlinescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_PatientID { get; set; }
            public string U_Details { get; set; }
            public int U_Quantity { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Choose U_Disbursed { get; set; }
            public string U_Schedule { get; set; }
        }
    }

    public class PostrequestMDL
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public request U_Status { get; set; }

        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public string U_RequestBy { get; set; }
        public int U_RequestByID { get; set; }
        public string U_DisbursedBy { get; set; }
        public int U_DisbursedByID { get; set; }
        public List<Requestlinescollection> REQUESTLINESCollection { get; set; }


        public class Requestlinescollection
        {
            public string U_PatientID { get; set; }
            public string U_Details { get; set; }
            public int U_Quantity { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Choose U_Disbursed { get; set; }
            public string U_Schedule { get; set; }
        }
    }

    public class PatchrequestMDL
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public request U_Status { get; set; }
        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public string U_RequestBy { get; set; }
        public int U_RequestByID { get; set; }
        public string U_DisbursedBy { get; set; }
        public int U_DisbursedByID { get; set; }
        public List<Requestlinecollection> REQUESTLINESCollection { get; set; }

        public class Requestlinecollection
        {
            public int LineId { get; set; }
            public string U_PatientID { get; set; }
            public string U_Details { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Choose U_Disbursed { get; set; }
            public string U_Schedule { get; set; }
            public int U_Quantity { get; set; }
        }
    }

}
