using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Food
{
    public class FoodMDL
    {
            public int DocNum { get; set; }
            public int DocEntry { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Status U_Status { get; set; }
            public string U_Time { get; set; }
            public List<Foodlinescollection> FOODLINESCollection { get; set; }
        

        public class Foodlinescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_PatientID { get; set; }
            public string U_PName { get; set; }
            public string U_Floor { get; set; }
            public string U_Meal { get; set; }
        }
    }

    public class PostFoodMDL
    {
        public string U_Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        public string U_Time { get; set; }
        public List<Foodlinescollection> FOODLINESCollection { get; set; }


        public class Foodlinescollection
        {
            public string U_PatientID { get; set; }
            public string U_PName { get; set; }
            public string U_Floor { get; set; }
            public string U_Meal { get; set; }
        }
    }

    public class PatchFood
    {
        public string U_Date { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        public string U_Time { get; set; }
        public List<Foodlinescollection> FOODLINESCollection { get; set; }


        public class Foodlinescollection
        {
            public int LineId { get; set; }
            public string U_PatientID { get; set; }
            public string U_PName { get; set; }
            public string U_Floor { get; set; }
            public string U_Meal { get; set; }
        }
    }

}
