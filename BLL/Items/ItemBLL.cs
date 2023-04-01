using Newtonsoft.Json;
using SAMS.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Items
{
    public class ItemBLL
    {

        public static ItemMDL Getspecific(string session, int Docentry)
        {
            try
            {
                var clause = "Items(" + Docentry + ")";
                var getData = Pipeline.Pipeline.Get(session, clause);
                var data = (JsonConvert.DeserializeObject<ItemMDL>(getData));
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ItemMDL> GetMultiple(string session, string clause)
        {
            try
            {               
                var getData = Pipeline.Pipeline.GetMultiples(session, clause);
                var dat = new List<ItemMDL>();
                foreach (string obj in getData)
                {
                    dat.AddRange((JsonConvert.DeserializeObject<List<ItemMDL>>(obj)));
                }
               
                return dat;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
