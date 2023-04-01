//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
//using SAMS.Globals;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using static SAMS.Globals.Globals;

//namespace SAMS.Models.Admissions
//{
//    public class AdmissionsMDL
//    {
//        public int DocNum { get; set; }
//        public string Remark { get; set; }
//        public int DocEntry { get; set; }
//        public string U_Allergies { get; set; }
//        public string U_DisDate { get; set; }
//        public string U_DOB { get; set; }
//        public string U_PatientID { get; set; }
//        public string U_PatientName { get; set; }
//        public int U_Age { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Gender U_Gender { get; set; }
//        public string U_Floor { get; set; }
//        public int U_NumOfdays { get; set; }
//        public string U_Ward { get; set; }
//        public string U_Room { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Pay U_Payment { get; set; }
//        public string U_MedicalAid { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Result U_Test { get; set; }
//        public string U_TestDate { get; set; }
//        public int U_AdmittedBy { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Status U_Status { get; set; }
//        public string U_Phone { get; set; }
//        public string U_NationalID { get; set; }
//        public string U_NOK { get; set; }
//        public string U_NOKNUM { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Condition U_Condition { get; set; }
//        public string U_Date { get; set; }
//        public string U_NOKINPID { get; set; }
//        public string U_RHosp { get; set; }
//        public string U_Rdoc { get; set; }
//        public string U_Nurse { get; set; }
//        public string U_Doctor { get; set; }
//        public string U_NOKNPAD { get; set; }
//        public string U_NOKNRLN { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Life U_Life { get; set; }
//        public string U_Location { get; set; }
//        public List<Actionscollection> ACTIONSCollection { get; set; }
//        public List<Itemscollection> ITEMSCollection { get; set; }
//        public List<Symptomscollection> SYMPTOMSCollection { get; set; }

//        public List<Notescollection> NOTESCollection { get; set; }

//        public class Notescollection
//        {
//            public int LineId { get; set; }
//            public string U_Detail { get; set; }
//            public string U_Date { get; set; }
//        }


//        public class Actionscollection
//        {
//            public int DocEntry { get; set; }
//            public int LineId { get; set; }
//            public string U_Date { get; set; }
//            public string U_Action { get; set; }
//            public string U_For { get; set; }
//            public string U_AddedBy { get; set; }
//            public int U_AddedByID { get; set; }
//            public string U_LoginType { get; set; }
//        }

//        public class Itemscollection
//        {
//            public int DocEntry { get; set; }
//            public int LineId { get; set; }
//            public string U_Quantity { get; set; }
//            public string U_Description { get; set; }
//            public string U_AddedBy { get; set; }
//            public string U_Date { get; set; }
//        }

//        public class Symptomscollection
//        {
//            public int DocEntry { get; set; }
//            public int LineId { get; set; }
//            public string U_Details { get; set; }
//            public string U_Date { get; set; }
//            [JsonConverter(typeof(StringEnumConverter))]
//            public Globals.Globals.Type U_Type { get; set; }
//            public string U_AddedBy { get; set; }
//            public string U_AddedByID { get; set; }


//        }

//    }


//    public class AdmitPatient
//    {
//        public string U_PatientID { get; set; }
//        public string U_Floor { get; set; }
//        public string U_PatientName { get; set; }
//        public string U_Allergies { get; set; }
//        public string U_DisDate { get; set; }
//        public string U_DOB { get; set; }
//        public int U_Age { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Gender U_Gender { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Life U_Life { get; set; }
//        public int U_NumOfdays { get; set; }
//        public string U_Ward { get; set; }
//        public string U_Room { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Pay U_Payment { get; set; }
//        public string U_MedicalAid { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Result U_Test { get; set; }
//        public string U_TestDate { get; set; }
//        public int U_AdmittedBy { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Status U_Status { get; set; }
//        public string U_Phone { get; set; }
//        public string U_NationalID { get; set; }
//        public string U_NOK { get; set; }
//        public string U_NOKNUM { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Condition U_Condition { get; set; }
//        public string U_Date { get; set; }
//        public string U_NOKNPID { get; set; }
//        public string U_RHosp { get; set; }

//        public string U_Nurse { get; set; }
//        public string U_Doctor { get; set; }
//        public string U_Rdoc { get; set; }
//        public string U_NOKNPAD { get; set; }
//        public string U_Location { get; set; }
//        public List<Actionscollection> ACTIONSCollection { get; set; }
//        public List<Itemscollection> ITEMSCollection { get; set; }
//        public List<Symptomscollection> SYMPTOMSCollection { get; set; }
//        public string U_NOKNRLN { get; internal set; }

//        public class Actionscollection
//        {
//            public string U_Date { get; set; }
//            public string U_Action { get; set; }
//            public string U_For { get; set; }
//            public string U_AddedBy { get; set; }
//            public int U_AddedByID { get; set; }
//            public string U_LoginType { get; set; }
//        }

//        public class Itemscollection
//        {
//            public string U_Quantity { get; set; }
//            public string U_Description { get; set; }
//            public string U_AddedBy { get; set; }
//            public string U_Date { get; set; }
//        }

//        public class Symptomscollection
//        {
//            public string U_Details { get; set; }
//            public string U_Date { get; set; }
//            [JsonConverter(typeof(StringEnumConverter))]
//            public Level U_Level { get; set; }
//            [JsonConverter(typeof(StringEnumConverter))]
//            public Globals.Globals.Type U_Type { get; set; }
//            public string U_AddedBy { get; set; }
//            public string U_AddedByID { get; set; }


//        }

//    }

//    public class PatchAdmissionsMDL
//    {
//        public string U_Ward { get; set; }
//        public string U_Floor { get; set; }
//        public string U_Room { get; set; }
//        [JsonConverter(typeof(StringEnumConverter))]
//        public Condition U_Condition { get; set; }
//        public int U_NumOfdays { get; set; }
//        public List<Actionscollection> ACTIONSCollection { get; set; }
//        public List<Symptomscollection> SYMPTOMSCollection { get; set; }

//        public List<Notescollection> NOTESCollection { get; set; }

//        public class Notescollection
//        {
//            public int LineId { get; set; }
//            public string U_Detail { get; set; }
//        }


//        public class Actionscollection
//        {

//            public string U_Date { get; set; }
//            public string U_Action { get; set; }
//            public string U_For { get; set; }
//            public string U_AddedBy { get; set; }
//            public int U_AddedByID { get; set; }
//        }

//        public class Symptomscollection
//        {

//            public string U_Details { get; set; }
//            [JsonConverter(typeof(StringEnumConverter))]
//            public Level U_Level { get; set; }
//            public string U_Date { get; set; }
//            [JsonConverter(typeof(StringEnumConverter))]
//            public Globals.Globals.Type U_Type { get; set; }
//            public string U_AddedBy { get; set; }
//            public int U_AddedByID { get; set; }
//        }

//    }

//}
