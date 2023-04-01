using SAMS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMS.Globals
{
    public class Globals

    {
        
        public static Dictionary<string, Models.Session.SessionMDL> AuthSessions = new Dictionary<string, Models.Session.SessionMDL>();
        public static Dictionary<string, Models.Session.MultipleSession> OtherDBs = new Dictionary<string, Models.Session.MultipleSession>();
        public static Models.Session.MultipleSession Sesssions { get; set; }
        //public static string SLURL = "https://stldb:50000/b1s/v1/";
        // public static string SLURL = "https://betadb1:50000/b1s/v1/";
        public static string SLURL = "https://192.168.40.208:50000/b1s/v1/";
        public enum Responses
        {
            //responses for non list requests
            Success, //operation succeeded
            Failure, //operation failed coz of resource not found. not necessarily an error
            //Responses for list requests
            Full, //success and there is data
            Empty, //success but no data was found
            //Common responses
            Error, // An Erro Encountered in the operation. Server error in most if not all cases
            Validate, // requests a client to validate his request 
            Authenticate, // requests a client to login first to get the response
            Warning, // a warning to the user
        }

        public enum State
        {
            ICU = 0,
            HDU = 1,
            General =2,
            None = 3
        }
        public enum YesOrNo
        {
            Yes, // for yes
            No,
            None
        }
        public enum YOrN
        {
            Y = 1,
            N = 2
        }
        public enum Schedule
        {
            Breakfast = 1,
            None = 0,
            Lunch = 2,
            Dinner = 3
        }

        public enum request
        {
            Request = 1,
            Disbursed = 2,
            None = 0
        }


        public enum Level
        {
            Mild = 1,
            None = 0,
            Severe = 2,
            Moderate = 3
        }

        public enum Tests
        {
            Test = 2,
            NotTesting = 1,
            Testing = 3,
            None = 0,
        }
        public enum Result
        {
            None = 0,
            Negative = 1,
            Positive = 2,
        }

        public enum Pay
        {
            None = 0,
            Cash = 1,
            MedicalAid = 2
        }

        public enum Condition
        {
            None = 0,
            Stable = 1,
            Critical = 2,

        }
        public enum Gender
        {
            Male = 1,
            Female = 2,
            None = 0
        }

        public enum Fleet
        {
            Strauss = 2,
            Zuva = 3,
            Allied = 1,
            None = 0,
        }
        public enum Vrvstatus
        {
            Started = 1,
            Paused = 2,
            Stopped = 3,
            None = 0
        }


        public enum Type
        {
            
            None = 1,
            Mild = 2,
            Moderate = 3,
            Severe = 4,

        }

        public enum DocumentAuthorizationStatusEnum
        {
            dasWithout,
            dasPending,
            dasApproved,
            dasRejected,
            dasGenerated,
            dasGeneratedbyAuthorizer,
            dasCancelled
        }

        //[JsonConverter(typeof(StringEnumConverter))]
        public enum TyesorTno
        {
            tYES = 1,
            tNO = 2
        }

        public enum JobAndActivityStatuses
        {
            None = -1,
            Stopped = 0,
            Started = 1,
            Paused = 2
        }

        public enum LoginTypes
        {
            None = 1,
            Administrator = 2,
            Manager = 3,
            Doctor = 4,
            Nurse = 5,
            Kitchen = 6,
            Clerk = 7,
            Pharmacy = 8,
        }

        public enum B1YesOrNo
        {
            tYES = 1, // for yes
            tNO = 0
        }

        public enum Life
        {
            None = 0,
            Alive =1,
            Deceased
                
                
                
                
                
                =2
        }

        public enum Status
        {
            Open = 1,
            Closed = 2,
            None = 0,
            Discharged = 3

        }

        public enum RoomStatus
        {
            Occupied = 1,
            Open = 2,
            None = 0,

        }

        public enum LoadStatus
        {
            None = -1,
            Empty = 0,
            Loaded = 1,
            Solo = 2
        }
        public enum Bostatus
        {
            none = 0,
            bost_Open = 1,
            bost_Close = 2,
            bost_Paid = 3,
            bost_Delivered = 4
        }
        public enum Gatepass
        {
            None = 0,
            In = 1,
            Out = 2,
            Done = 3,
            Discarded = 4
        }

        public enum Load
        {
            None = -1,
            Empty = 0,
            Loaded = 2,
            Solo = 1
        }

        public enum Status2
        {
            None = -1,
            Open = 0,
            Closed = 1
        }
        public enum Choose
        {
            none = -1,
            No = 0,
            Yes = 1

        }
        public enum DataB
        {   None = 0,
            Bricks = 1,
            Tiles =2,
        }

        public enum DocStatus
        {
            cdsClosed = 0,
            cdsOpen = 1
        }
    }

}

