using SAMS.Models.Floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Admissions
{
    public class AdmitMDL
    {

        public string Image { get; set; }
        public AdmitPatient AdmitPatient { get; set; }
        public string ext { get; set; }

        public EditFloor floor { get; set; }

        public int DocEntry { get; set; }
        public int DocID { get; set; }

    }


    public class UpdateMDL
    {
        public PatchAdmission patch { get; set; }
        public int Doc { get; set; }

        public EditFloor floor { get; set; }


    }


}
