using Newtonsoft.Json;
using SAMS.Models.Admissions;
using System;
using System.Collections.Generic;
using System.Globalization;
using SAMS.BLL.Drugs;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.Fluids.FluidsDailyOrder;
using static SAMS.Models.Drugs.DrugMDL;


namespace SAMS.BLL.Drugs
{
    public class DrugsBLL
    {

        public List<DrugAdmin> shipments = new List<DrugAdmin>();

        public static List<DrugAdmin> GetShipments(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<DrugAdmin>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<DrugAdmin>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DrugAdmin AddShipment(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "DRUGSADMIN");
                return JsonConvert.DeserializeObject<DrugAdmin>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DrugAdmin addShipmentPre(string session, DrugAdmin shipmentCollection)
        {
            try
            {

                return AddShipment(session, JsonConvert.SerializeObject(shipmentCollection));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DrugAdmin getCarePlanByID(string session, string PatientID)
        {
            try
            {
                var clause = "DRUGSADMIN?$filter = U_PatientID eq '" + PatientID + "'";
                var getdata = Pipeline.Pipeline.Get(clause, session);

                return JsonConvert.DeserializeObject<DrugAdmin>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DrugAdmin getPlan(string session, int DocEntry)
        {
            try
            {
                var clause = "DRUGSADMIN(" + DocEntry + ")";
                var getdata = Pipeline.Pipeline.Get(session, clause);

                return JsonConvert.DeserializeObject<DrugAdmin>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}


