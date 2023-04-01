using Newtonsoft.Json;
using SAMS.Models.Admissions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Models.NursingCarePlan.NursingCarePlan;

namespace SAMS.BLL.NursingBLL
{
    public class NursingBLL
    { 
         
        public List<CarePlan> shipments = new List<CarePlan>();

        public static List<CarePlan> GetShipments(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<CarePlan>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<CarePlan>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CarePlan AddShipment(string session, string data)
        {
            try
            {
                var post = Pipeline.Pipeline.Post(session, data, "CAREPLANN");
                return JsonConvert.DeserializeObject<CarePlan>(post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CarePlan addShipmentPre(string session, CarePlan shipmentCollection)
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

        public static CarePlan getCarePlanByID(string session, string PatientID)
        {
            try
            {
                var clause = "CAREPLANN?$filter = U_PatientID eq '" + PatientID + "'";
                var getdata = Pipeline.Pipeline.Get(clause, session);

                return JsonConvert.DeserializeObject<CarePlan>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static CarePlan getPlan(string session, int DocEntry)
        {
            try
            {
                var clause = "CAREPLANN(" + DocEntry + ")";
                var getdata = Pipeline.Pipeline.Get(session, clause);

                return JsonConvert.DeserializeObject<CarePlan>(getdata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}

