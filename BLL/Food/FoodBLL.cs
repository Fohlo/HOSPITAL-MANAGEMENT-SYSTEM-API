using Newtonsoft.Json;
using SAMS.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Food
{
    public class FoodBLL
    {
        public static List<FoodMDL> GetRequest(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<FoodMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<FoodMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static FoodMDL Getspecific(string session, int Docentry)
        {
            try
            {
                var clause = "FOOD(" + Docentry + ")";
                var getData = Pipeline.Pipeline.Get(session, clause);
                var data = (JsonConvert.DeserializeObject<FoodMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static FoodMDL Post(string session, PostFoodMDL details)
        {
            try
            {
                var getData = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(details), "FOOD");
                var data = (JsonConvert.DeserializeObject<FoodMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string Patch(string session, PatchFood details)
        {
            try
            {
                var getData = Pipeline.Pipeline.Patch(session, JsonConvert.SerializeObject(details), "FOOD");

                return getData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<AfenumMDL> GetAvailableFood(string session, string clause)
        {
            try
            {
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<AfenumMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<AfenumMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
