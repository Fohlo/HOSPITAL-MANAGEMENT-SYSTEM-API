using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Test
{
    public class TestMDL
    {

            public int DocNum { get; set; }
            public string Remark { get; set; }
            public int DocEntry { get; set; }
            public int U_CallDoc { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestStats { get; set; }
            public string U_TestOrg { get; set; }
            public string U_Date { get; set; }
        

    }

    public class AddTest
    {

        public string Remark { get; set; }
        public int U_CallDoc { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestStats { get; set; }
        public string U_TestOrg { get; set; }
        public string U_Date { get; set; }


    }

    public class PatchTest
    {

        [JsonConverter(typeof(StringEnumConverter))]
        public Result U_TestStats { get; set; }
    }


}
