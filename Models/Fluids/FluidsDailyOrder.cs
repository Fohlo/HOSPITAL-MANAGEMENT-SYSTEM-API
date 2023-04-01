using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SAMS.Models.Fluids
{
    public class FluidsDailyOrder
    {
        public class PostFluidsDailyOrder
        {


            public int DocNum { get; set; }
            public int DocEntry { get; set; }
            public string U_Date { get; set; }

            public string U_PatientID { get; set; }
            public List<FluidsSchedule> FLUIDSRCollection { get; set; }

            public class FluidsSchedule
            {
                public string U_FluidKey { get; set; }
                public string U_FluidType { get; set; }
                public string U_TotalQ
                { get; set; }
                public string U_Schedule
                { get; set; }

                public string U_QSchedule

                { get; set; }
            }
           

           
        }


        public class FluidAdmin
        {

            public int DocEntry { get; set; }

            public string U_A { get; set; }
            public string U_Date { get; set; }
            public string U_B { get; set; }

            public string U_C { get; set; }
            public string U_D { get; set; }

            public string U_E { get; set; }
            public string U_F { get; set; }

            public string U_G { get; set; }
            public string U_DN { get; set; }

            public string U_DNPM { get; set; }
            public string U_DNN { get; set; }

            public string U_H { get; set; }
            public string U_OC { get; set; }

            public string U_OD { get; set; }

            public string U_OE { get; set; }
            public string U_OF { get; set; }

            public string U_PatientID { get; set; }


            public List<FluidsIntakes> FINTAKESCollection = new List<FluidsIntakes>();




        }
        public class PostFluidAdmin
        {
            public string U_A { get; set; }
            public string U_Date { get; set; }
            public string U_B { get; set; }

            public string U_C { get; set; }
            public string U_D { get; set; }

            public string U_E { get; set; }
            public string U_F { get; set; }

            public string U_G { get; set; }
            public string U_DN { get; set; }

            public string U_DNPM { get; set; }
            public string U_DNN { get; set; }

            public string U_H { get; set; }
            public string U_OC { get; set; }

            public string U_OD { get; set; }

            public string U_OE { get; set; }
            public string U_OF { get; set; }

            public string U_PatientID { get; set; }

            public List<PostFluidsIntakes> FINTAKESCollection { get; set; } = new List<PostFluidsIntakes>();



        }


        public class FluidsIntakes
        {
            public int LineId { get; set; }
            public double U_A { get; set; }
            public double U_B { get; set; }                    

            public double U_C { get; set; }
            public double U_D { get; set; }

            public double U_E { get; set; }
            public double U_F { get; set; }

            public string U_Time { get; set; }

            public double U_G { get; set; }
            public double U_H { get; set; }

            public double U_HRT { get; set; }
            public double U_UR { get; set; }
            public double U_HUT { get; set; }
            public double U_NIG { get; set; }
            public double U_OC { get; set; }

            public double U_OD { get; set; }
            public double U_OE { get; set; }

            public double U_OF { get; set; }
            public double U_RT { get; set; }

            public double U_HR { get; set; }
            


        }
        public class PostFluidsIntakes
        {
          
            public double U_A { get; set; }
            public double U_B { get; set; }

            public double U_C { get; set; }
            public double U_D { get; set; }

            public double U_E { get; set; }
            public double U_F { get; set; }

            public string U_Time { get; set; }

            public double U_G { get; set; }
            public double U_H { get; set; }

            public double U_HRT { get; set; }
            public double U_UR { get; set; }
            public double U_HUT { get; set; }
            public double U_NIG { get; set; }
            public double U_OC { get; set; }

            public double U_OD { get; set; }
            public double U_OE { get; set; }

            public double U_OF { get; set; }
            public double U_RT { get; set; }

            public double U_HR { get; set; }



        }

        public class TransactionDetail
        {


            public string ID { get; set; }

            public string Name { get; set; }

            public string Category { get; set; }

            public double Spent { get; set; }
            public DateTime Date { get; set; }
            public string U_A { get; set; }
            public string U_B { get; set; }
            public string U_C { get; set; }
            public string U_E { get; set; }
            public string U_D { get; set; }
            public string U_F { get; set; }
            public string U_G { get; set; }
            public string U_H { get; set; }
            public string U_DN { get; set; }
            public string U_DNPM { get; set; }
            public string U_DNN { get; set; }
            public string U_OC { get; set; }
            public string U_OD { get; set; }
            public string U_OE { get; set; }
            public string U_OF { get; set; }
        }
    }
}
