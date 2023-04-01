using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Drugs
{
    public class DrugMDL
    {
        public class DrugAdmin
        {

           
           
            public string U_PatientID { get; set; }
            public string U_PatientName { get; set; }

            public Druggs[] DRUGSADMINROWSCollection { get; set; }


        }
        public class PostDrugAdmin
        {
            public string U_PatientID { get; set; }
            public string U_PatientName { get; set; }



            public Druggs[] DRUGSADMINROWSCollection { get; set; }


        }


        public class Druggs
        {
            public string U_DrgNa { get; set; }
            public string U_DrgCo { get; set; }
            public string U_Qnty { get; set; }
            public string U_Date { get; set; }
            public string U_Schedule { get; set; }
            public string U_Time { get; set; }
            public string U_DayNo { get; set; }
            public string U_Route { get; set; }
            public string U_CrrntD { get; set; }


        }
        public class PostDruggs
        {
            public string U_DrgNa { get; set; }
            public string U_DrgCo { get; set; }
            public string U_Qnty { get; set; }
            public string U_Date { get; set; }
            public string U_Schedule { get; set; }
            public string U_Time { get; set; }
            public string U_DayNo { get; set; }
            public string U_Route { get; set; }
            public string U_CrrntD { get; set; }


        }

    }
}
    