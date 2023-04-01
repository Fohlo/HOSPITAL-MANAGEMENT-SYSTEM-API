using Newtonsoft.Json;
using SAMS.Models.Vitals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Vitals
{
    public class VitalsBLL
    {

        public static List<VitalMDL> GetVitals(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<VitalMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<VitalMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static VitalMDL Getspecific(string session, int Docentry)
        {
            try
            {
                var clause = "VITALLIST(" + Docentry + ")";
                var getData = Pipeline.Pipeline.Get(session, clause);
                var data = (JsonConvert.DeserializeObject<VitalMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
