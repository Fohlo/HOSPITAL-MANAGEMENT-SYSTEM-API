using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMS.Models.Notification
{
    public class NotificationMDL
    {
            public string priority { get; set; }
            public string to { get; set; }
            public Data notification { get; set; }     
    }

    public class Data
    {
        public string title { get; set; }
        public string text { get; set; }
        public string sound { get; set; }
    }

    public class Multiple
    {
        public string priority { get; set; }
        public List<string> registration_ids { get; set; }
        public Data notification { get; set; }
    }
}