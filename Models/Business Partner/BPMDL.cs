using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Business_Partner
{
    public class BPMDL
    {
            public string CardCode { get; set; }
            public string CardName { get; set; }
            public string CardType { get; set; }
            public string Address { get; set; }
            public string Phone1 { get; set; }
            public object Phone2 { get; set; }
            public string ContactPerson { get; set; }
            public string Cellular { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string Country { get; set; }
            public string CardForeignName { get; set; }
            public List<Bpaddress> BPAddresses { get; set; }
            public List<Contactemployee> ContactEmployees { get; set; }
        

        public class Bpaddress
        {
            public string AddressName { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public object County { get; set; }
            public string Country { get; set; }
            public object State { get; set; }
            public string AddressType { get; set; }
            public object AddressName2 { get; set; }
            public object AddressName3 { get; set; }
            public object TypeOfAddress { get; set; }
            public object StreetNo { get; set; }
            public string BPCode { get; set; }
            public object GlobalLocationNumber { get; set; }
        }

        public class Contactemployee
        {
            public string CardCode { get; set; }
            public string Name { get; set; }
        }


    }
}
