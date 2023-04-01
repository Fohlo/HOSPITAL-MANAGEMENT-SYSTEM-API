using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Admissions
{
    public class AdmissionMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public int U_Age { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender U_Gender { get; set; }
        public int U_NumOfdays { get; set; }
        public string U_Ward { get; set; }
        public string U_Room { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Pay U_Payment { get; set; }
        public string U_MedicalAid { get; set; }
        public string U_Test { get; set; }
        public int U_AdmittedBy { get; set; }
        public string U_Admitted { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        public string U_Phone { get; set; }
        public string U_NationalID { get; set; }
        public string U_NOK { get; set; }
        public string U_NOKNUM { get; set; }
        public string U_Bed { get; set; }
        public string U_RoomNo { get; set; }
        public string U_WardName { get; set; }
        public string U_Occupation { get; set; }
        public string U_MedicalNumber { get; set; }
        public string U_DOB { get; set; }
        public string U_DisDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Life U_Life { get; set; }
        public string U_Floor { get; set; }
        public string U_NOKNRLN { get; set; }
        public string U_Nurse { get; set; }
        public string U_Doctor { get; set; }
        public string U_Location { get; set; }
        public string U_Rdoc { get; set; }
        public string U_RHosp { get; set; }
        public string U_NOKINPID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Condition U_Condition { get; set; }
        public string U_NOKNPAD { get; set; }
        public string U_Date { get; set; }
        public string U_HospitalNo { get; set; }
        public List<Itemscollection> ITEMSCollection { get; set; }
    

        public class Itemscollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public int U_Quantity { get; set; }
            public string U_Description { get; set; }
            public string U_AddedBy { get; set; }
            public string U_Date { get; set; }
        }
    }

    public class AdmitPatient
    {
        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public int U_Age { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender U_Gender { get; set; }
        public int U_NumOfdays { get; set; }
        public string U_Ward { get; set; }
        public string U_Room { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Pay U_Payment { get; set; }
        public string U_MedicalAid { get; set; }
        public string U_Test { get; set; }
        public int U_AdmittedBy { get; set; }
        public string U_Admitted { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        public string U_Phone { get; set; }
        public string U_NationalID { get; set; }
        public string U_NOK { get; set; }
        public string U_NOKNUM { get; set; }
        public string U_Bed { get; set; }
        public string U_RoomNo { get; set; }
        public string U_WardName { get; set; }
        public string U_Occupation { get; set; }
        public string U_MedicalNumber { get; set; }
        public string U_DOB { get; set; }
        public string U_DisDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Life U_Life { get; set; }
        public string U_Floor { get; set; }
        public string U_NOKNRLN { get; set; }
        public string U_Nurse { get; set; }
        public string U_Doctor { get; set; }
        public string U_Location { get; set; }
        public string U_Rdoc { get; set; }
        public string U_RHosp { get; set; }
        public string U_NOKINPID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Condition U_Condition { get; set; }
        public string U_NOKNPAD { get; set; }
        public string U_Date { get; set; }
        public string U_HospitalNo { get; set; }
        public List<Itemscollection> ITEMSCollection { get; set; }

    }

    public class PatchAdmission
    {
        public string U_PatientID { get; set; }
        public string U_PatientName { get; set; }
        public int U_Age { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender U_Gender { get; set; }
        public int U_NumOfdays { get; set; }
        public string U_Ward { get; set; }
        public string U_Room { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Pay U_Payment { get; set; }
        public string U_MedicalAid { get; set; }
        public string U_Test { get; set; }
        public int U_AdmittedBy { get; set; }
        public string U_Admitted { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        public string U_Phone { get; set; }
        public string U_NationalID { get; set; }
        public string U_NOK { get; set; }
        public string U_NOKNUM { get; set; }
        public string U_Bed { get; set; }
        public string U_RoomNo { get; set; }
        public string U_WardName { get; set; }
        public string U_Occupation { get; set; }
        public string U_MedicalNumber { get; set; }
        public string U_DOB { get; set; }
        public string U_DisDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Life U_Life { get; set; }
        public string U_Floor { get; set; }
        public string U_NOKNRLN { get; set; }
        public string U_Nurse { get; set; }
        public string U_Doctor { get; set; }
        public string U_Location { get; set; }
        public string U_Rdoc { get; set; }
        public string U_RHosp { get; set; }
        public string U_NOKINPID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Condition U_Condition { get; set; }
        public string U_NOKNPAD { get; set; }
        public string U_Date { get; set; }
        public string U_HospitalNo { get; set; }
    }

    public class Itemscollection
    {
       
        public int LineId { get; set; }
        public int U_Quantity { get; set; }
        public string U_Description { get; set; }
        public string U_AddedBy { get; set; }
        public string U_Date { get; set; }
    }

}
