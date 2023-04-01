using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Floor
{
    public class FloorMDL
    {
    
            public int DocNum { get; set; }
            public int DocEntry { get; set; }
            public string U_FloorID { get; set; }
            public string U_FloorName { get; set; }
            public List<Floorlinescollection> FLOORLINESCollection { get; set; }
        

        public class Floorlinescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Ward { get; set; }
            public string U_Room { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public RoomStatus U_Status { get; set; }
            public string U_PatientID { get; set; }
            public int? U_AdDoc { get; set; }
        }

    }

    public class EditFloor
    {
        public List<Floorlinescollection> FLOORLINESCollection { get; set; }
        public class Floorlinescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Ward { get; set; }
            public string U_Room { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public RoomStatus U_Status { get; set; }
            public string U_PatientID { get; set; }
            public int? U_AdDoc { get; set; }
        }

    }



}
