using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Transfer
{
    public class PatientTrans
    {
        public class PatientTransfer
        {

            public int DocEntry { get; set; }

            public string U_FromWard { get; set; }
            public string U_ToWard { get; set; }
            public string U_FromRoom { get; set; }
            public string U_Date { get; set; }
            public string U_ToRoom { get; set; }
            public string U_FromBed { get; set; }
            public string U_ToBed { get; set; }
            public string U_Time { get; set; }
            public string U_PatientID { get; set; }


           public List<Transfer> TransfersAddCollection = new List<Transfer>();




        }
        public class PostPatientTransfer
        {
            public int DocEntry { get; set; }

            public string U_FromWard { get; set; }
            public string U_ToWard { get; set; }
            public string U_FromRoom { get; set; }
            public string U_Date { get; set; }
            public string U_ToRoom { get; set; }
            public string U_FromBed { get; set; }
            public string U_ToBed { get; set; }
            public string U_Time { get; set; }
            public string U_PatientID { get; set; }


            public List<PostTransfer> TransfersAddCollection = new List<PostTransfer>();



        }


        public class Transfer
        {
            public string U_FromWard { get; set; }
            public string U_ToWard { get; set; }
            public string U_FromRoom { get; set; }
            public string U_Date { get; set; }
            public string U_ToRoom { get; set; }
            public string U_FromBed { get; set; }
            public string U_ToBed { get; set; }
            public string U_Time { get; set; }
           


        }
        public class PostTransfer
        {
            public string U_FromWard { get; set; }
            public string U_ToWard { get; set; }
            public string U_FromRoom { get; set; }
            public string U_Date { get; set; }
            public string U_ToRoom { get; set; }
            public string U_FromBed { get; set; }
            public string U_ToBed { get; set; }
            public string U_Time { get; set; }
            


        }

    }
}


