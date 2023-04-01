using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.NursingCarePlan
{
    public class NursingCarePlan
    {
        public class CarePlan
        {

            ///   public int DocEntry { get; set; }
            ///   

            public string U_Age { get; set; }
            public string U_BedNo { get; set; }
            public string U_Allergies { get; set; }
            public string U_HospitalNo { get; set; }
            public string U_Diagnosis { get; set; }
            public string U_PatientName { get; set; }
            public string U_PatientID { get; set; }


         //  public List<CareNurse> CAREPLANROWSCollection = new List<CareNurse>();
            public CareNurse[] CAREPLANNROWSCollection { get; set; }



        }
        public class PostCarePlan {

            public string U_Age { get; set; }
            public string U_BedNo { get; set; }
            public string U_Allergies { get; set; }
            public string U_HospitalNo { get; set; }
            public string U_Diagnosis { get; set; }
            public string U_PatientName { get; set; }
            public string U_PatientID { get; set; }

            public CareNurse[] CAREPLANNROWSCollection { get; set; }
            // public List<PostCareNurse> NursingCareCollection = new List<PostCareNurse>();

        }


        public class CareNurse
        {
           
            public string U_Assessment { get; set; }
            public string U_Date { get; set; }
            public string U_NursingD { get; set; }

            public string U_Goals { get; set; }
            public string U_Management { get; set; }

            public string U_Outcome { get; set; }


        }
        public class PostCareNurse { 

            public string U_Assessment { get; set; }
            public string U_Date { get; set; }
            public string U_NursingD { get; set; }

            public string U_Goals { get; set; }
            public string U_Management { get; set; }

            public string U_Outcome { get; set; }



        }

    }
}
