using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Food
{
    public class AfenumMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public string U_Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Schedule U_Schedule { get; set; }
        public List<Availablefoodlinescollection> AVAILABLEFOODLINESCollection { get; set; }
        
        public class Availablefoodlinescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Afood { get; set; }
        }


    }

    public class Post
    {
        public string U_Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Schedule U_Schedule { get; set; }
        public List<Availablefoodlinescollection> AVAILABLEFOODLINESCollection { get; set; }

        public class Availablefoodlinescollection
        {
            public string U_Afood { get; set; }
        }


    }

}
