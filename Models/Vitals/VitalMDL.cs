using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Vitals
{
    public class VitalMDL
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public string U_Type { get; set; }
        public string U_Status { get; set; }
        public List<Vitallistcollection> VITALLISTCollection { get; set; }
        
        public class Vitallistcollection
        {
            public int DocEntry { get; set; }
            public int LineId { get; set; }
            public string U_Details { get; set; }
        }

    }

    public class AddVital
    {
        public string U_Type { get; set; }
        public string U_Status { get; set; }
        public List<Vitallistcollection> VITALLISTCollection { get; set; }

        public class Vitallistcollection
        {
            public string U_Details { get; set; }
        }

    }

}
