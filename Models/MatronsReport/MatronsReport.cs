using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.MatronsReport
{
    public class MatronsReport
    {

        public class MatronsDailyReport
        {


        //    public int DocEntry { get; set; }
            //public string U_RoomNo { get; set; }
            //public string U_Age { get; set; }
            //public string U_Doctor { get; set; }
            //public string U_PostOPDays { get; set; }
            //public string U_Diagnosis { get; set; }
            //public string U_Ward { get; set; }
            //public string U_Date { get; set; }
            //public string U_Time { get; set; }
            //public string U_NumOfP { get; set; }
            //public string U_PatientID { get; set; }
            //public string U_PatientName { get; set; }
            //public string U_DateofAdim { get; set; }
            //public string U_Nurse { get; set; }

            public List<MatronReport> MTRONREPORTCollection = new List<MatronReport>();


        }
        public class PostMatronsDailyReport
        {

         //   public int DocEntry { get; set; }

            //public string U_RoomNo { get; set; }
            //public string U_Age { get; set; }
            //public string U_Doctor { get; set; }
            //public string U_PostOPDays { get; set; }
            //public string U_Diagnosis { get; set; }
            //public string U_Ward { get; set; }
            //public string U_Date { get; set; }
            //public string U_Time { get; set; }
            //public string U_NumOfP { get; set; }
            //public string U_PatientID { get; set; }
            //public string U_PatientName { get; set; }
            //public string U_DateofAdim { get; set; }
            //public string U_Nurse { get; set; }

            public List<PostMatronReport> MTRONREPORTCollection { get; set; } = new List<PostMatronReport>();


        }
        public class MatronReport
        {

            //public int DocEntry { get; set; }
            //public string U_RoomNo { get; set; }
            //public string U_Age { get; set; }
            //public string U_Doctor { get; set; }
            //public string U_PostOPDays { get; set; }
            //public string U_Diagnosis { get; set; }
            //public string U_Ward { get; set; }
            //public string U_Date { get; set; }
            //public string U_Time { get; set; }
            //public string U_NumOfP { get; set; }
            public string U_PatientID { get; set; }
            public string U_PatientName { get; set; }
            //public string U_DateofAdim { get; set; }
            //public string U_Nurse { get; set; }


        }
        public class PostMatronReport
        {
            //public int DocEntry { get; set; }
            //public string U_RoomNo { get; set; }
            //public string U_Age { get; set; }
            //public string U_Doctor { get; set; }
            //public string U_PostOPDays { get; set; }
            //public string U_Diagnosis { get; set; }
            //public string U_Ward { get; set; }
            //public string U_Date { get; set; }
            //public string U_Time { get; set; }
            //public string U_NumOfP { get; set; }
            public string U_PatientID { get; set; }
            public string U_PatientName { get; set; }
            //public string U_DateofAdim { get; set; }
            //public string U_Nurse { get; set; }

        }
    }
}
