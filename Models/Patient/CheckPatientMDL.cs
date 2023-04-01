using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Patient
{
    public class CheckPatientMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public string U_PatientID { get; set; }
        public string U_AdmissionID { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public State U_State { get; set; }
        public List<Medicalscollection> MEDICALPRESCCollection { get; set; }
        public List<Actionscollection> ACTIONSCollection { get; set; }
        public List<Notescollection> NOTESCollection { get; set; }
        public List<Vitalscheckscollection> VITALSCollection { get; set; }
        public List<Patienttestcollection> PATIENTTESTCollection { get; set; }
        public List<Symptoms> SYMPTOMSCollection { get; set; }

        public class Medicalscollection
        {
            public int DocEntry { get; set; }
            public int U_Quantity { get; set; }
            public int LineId { get; set; }
            public string U_Date { get; set; }
            public string U_Dispensed { get; set; }
            public string U_Prescription { get; set; }
            public string U_QuantityIssued { get; set; }
            public string U_Comment { get; set; }
            public string U_AddedBy { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public object U_Schedule { get; set; }
            public string U_Description { get; set; }
        }

        public class Actionscollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Date { get; set; }
            public string U_Action { get; set; }
            public string U_For { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
        }

        public class Notescollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Vitalscheckscollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Date { get; set; }
            public string U_VitalName { get; set; }
            public string U_Measurement { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Patienttestcollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_TestName { get; set; }
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }


        public class Symptoms
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Level { get; set; }
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            public string U_Type { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }


    }

    public class PostCheck
    {
        public string U_PatientID { get; set; }
        public int U_AdmissionID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public State U_State { get; set; }
        public List<Medicalscollection> MEDICALPRESCCollection { get; set; }
        public List<Actionscollection> ACTIONSCollection { get; set; }
        public List<Notescollection> NOTESCollection { get; set; }
        public List<Vitalscheckscollection> VITALSCollection { get; set; }
        //public List<Patienttestcollection> PATIENTTESTCollection { get; set; }
        public List<Symptoms> SYMPTOMSCollection { get; set; }
        public class Medicalscollection
        {
            public string U_Date { get; set; }
            public int U_Quantity { get; set; }
            public string U_Prescription { get; set; }
            public string U_Description { get; set; }
            public string U_Dispensed { get; set; }           
            public string U_QuantityIssued { get; set; }
            public string U_Comment { get; set; }
            public string U_AddedBy { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_Schedule { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Actionscollection
        {
            public string U_Date { get; set; }
            public string U_Action { get; set; }
            public string U_For { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
        }

        public class Notescollection
        {
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Vitalscheckscollection
        {
            public string U_Date { get; set; }
            public string U_VitalName { get; set; }
            public string U_Measurement { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        //public class Patienttestcollection
        //{
        //    public string U_TestName { get; set; }
        //    public string U_Details { get; set; }
        //    public string U_Date { get; set; }
        //    [JsonConverter(typeof(StringEnumConverter))]
           
        //    public string U_AddedBy { get; set; }
        //    public int U_AddedbyID { get; set; }
        //}

        public class Symptoms
        {
            public string U_Details { get; set; }
            public string U_Level { get; set; }
            public string U_Date { get; set; }
            public string U_Type { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }
    }

    public class PatchCheck
    {
        public string U_PatientID { get; set; }
        public int U_AdmissionID { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status U_Status { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public State U_State { get; set; }
        public List<Medicalcollection> MEDICALPRESCCollection { get; set; }
        public List<Actioncollection> ACTIONSCollection { get; set; }
        public List<Notecollection> NOTESCollection { get; set; }
        public List<Vitalcheckscollection> VITALSCollection { get; set; }
       // public List<Patientestcollection> PATIENTTESTCollection { get; set; }
        public List<Symptom> SYMPTOMSCollection { get; set; }

        public class Symptom
        {
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            public string U_Level { get; set; }
            public string U_Type { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }
        public class Medicalcollection
        {
            public string U_Date { get; set; }
            public string U_Prescription { get; set; }
            public string U_Description { get; set; }
            public string U_Dispensed { get; set; }
            public string U_QuantityIssued { get; set; }
            public string U_Comment { get; set; }
            public string U_AddedBy { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public int U_Quantity { get; set; }
            public string U_Schedule { get; set; }
            public int U_AddedByID { get; internal set; }
        }

        public class Actioncollection
        {
            public string U_Date { get; set; }
            public string U_Action { get; set; }
            public string U_For { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
        }

        public class Notecollection
        {
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Vitalcheckscollection
        {
            public string U_Date { get; set; }
            public string U_VitalName { get; set; }
            public string U_Measurement { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedByID { get; set; }
        }

        public class Patientestcollection
        {
            public string U_TestName { get; set; }
            public string U_Details { get; set; }
            public string U_Date { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public LoginTypes U_LoginType { get; set; }
            public string U_AddedBy { get; set; }
            public int U_AddedbyID { get; set; }
        }

    }

}
