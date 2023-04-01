using Newtonsoft.Json;
using SAMS.Models.Admissions;
using SAMS.Models.Business_Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.BusinessPartner
{
    public class BPBLL
    {
        public static BPMDL createMDl(AdmissionMDL patient)
        {
            var contact = new List<BPMDL.Contactemployee> {

            new BPMDL.Contactemployee
            {
                CardCode = patient.U_NationalID,
                Name = patient.U_PatientName,

            }
            
            };

            var adress = new List<BPMDL.Bpaddress>
            {
                new BPMDL.Bpaddress
                {
                    AddressName = patient.U_PatientName,
                    BPCode = patient.U_PatientID,
                    City = "Harare",
                    AddressType = "bo_BillTo",
                    Street = patient.U_Location,
                    Country = "ZW"

                }
            };
            var phones = new List<string> { };
            if (patient.U_Phone.Contains(";"))
            {
                phones = patient.U_Phone.Split(";").ToList();

            } 
            else
            {
                phones.Add(patient.U_Phone);
                phones.Add("None");
            }


            return new BPMDL
            {
                Address = patient.U_Location,
                CardCode = patient.U_PatientID,
                CardName = patient.U_PatientName,
                CardType = "cCustomer",
                BPAddresses = adress,
                ContactEmployees = contact,
                Phone1 = phones[0],
                Phone2 = phones[1] ,
                ContactPerson = patient.U_PatientName,
                Cellular = patient.U_Phone,
                Country = "ZW",
                CardForeignName = patient.U_PatientID,
                City = "Harare",

            };
        }
        public static List<BPMDL> getBusinessPartner(string session, string clause)
        {
            try
            {
                
                var getData = Pipeline.Pipeline.GetMultiple(session, clause);
                var data = new List<BPMDL>();
                foreach (string obj in getData)
                {
                    data.AddRange(JsonConvert.DeserializeObject<List<BPMDL>>(obj));
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string AddBusinesP(string session, AdmissionMDL Admit)
        {
            try
            {
                // check if business partner exists
                var clause = "BusinessPartners?$filter = CardCode eq '"+Admit.U_NationalID+"'";
                var Business = getBusinessPartner(session, clause);
                if (Business.Count == 0)
                {
                    var create = createMDl(Admit);
                    var Post = Pipeline.Pipeline.Post(session, JsonConvert.SerializeObject(create), "BusinessPartners");
                }               
               // return "Done";
            }
            catch (Exception ex)
            {
              
                //throw new Exception(ex.Message);
            }
            return "Done";
        }

    }
}
