using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SAMS.Globals.Globals;
using static SAMS.Models.Notification.DnoteMDL;

namespace SAMS.Models.Notification
{
    public class DnoteMDL
    {
            public int DocNum { get; set; }
            public int DocEntry { get; set; }
            public string U_Version { get; set; }
            public string U_Release { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public Status2 U_Status { get; set; }
            public List<Notelinecollection> NOTELINECollection { get; set; }
        

        public class Notelinecollection
        {
            public int DocEntry { get; set; }
            public int? LineId { get; set; }
            public int U_ID { get; set; }
            public string U_Token { get; set; }
            public string U_Type { get; set; }
        }


    }

    public class DNote
    {
        public int? Line { get; set; }
        public int DocEntry { get; set; }
        public string Token { get; set; }
        public List<string> ids { get; set; }
    }

    public class DnotePatch
    {
        public List<Notelinecollection> NOTELINECollection { get; set; }
    }
}