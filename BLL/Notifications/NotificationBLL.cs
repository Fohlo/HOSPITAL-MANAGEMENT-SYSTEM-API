using SAMS.BLL.Responses;
using SAMS.BLL.Session;
using SAMS.Globals;
using SAMS.Models;
using SAMS.Models.Notification;
using SAMS.VC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using static SAMS.Globals.Globals;
using static SAMS.Models.Notification.DnoteMDL;
using static SAMS.Models.Notification.NotificationMDL;
using SAMS.BLL.Employee;
using SAMS.Models.Employee;

namespace SAMS.BLL.Notification
{
    public class NotificationBLL
    {
        public bool IsLive = false;
        public static DNote getID(string session, int UserId, string version, string Usertype)
        {
            var notes = new DNote
            {
                DocEntry = 0,
                Token = "",
                Line = null,
                ids = new List<string>()
            };
            string Clause = "";
           
                Clause = "DNOTE?$filter=U_Status eq 'Open'";          
            
                try
                {
                    var sessionID = SessionBLL.ValidateAppSession(session);
                    string ddfJson = Pipeline.Pipeline.Get(session,Clause);

                    var listObj = ClassVC.B1JsonListToApiJson2(ddfJson).ListValues;
                    var myDDF = JsonConvert.DeserializeObject<List<DnoteMDL>>(listObj);

                if (myDDF != null && myDDF.Count == 1)
                {
                    foreach (DnoteMDL.Notelinecollection line in myDDF[0].NOTELINECollection)
                    {
                        notes.DocEntry = myDDF[0].DocEntry;
                        if (line.U_ID == UserId )
                        {
                            notes.Token = line.U_Token;
                            notes.Line = line.LineId;
                        }

                        if (Usertype == line.U_Type && Usertype != "")
                        {
                            notes.ids.Add(line.U_Token);
                        }
                    }
                }
                    

                    return notes;
                }
                catch (Exception ex)
                {
                throw new Exception(ex.Message);
                }
            
        }

        public static DnoteMDL getDoc(string session)
        {
            try
            {
                var sessionID = SessionBLL.ValidateAppSession(session);
                string ddfJson = Pipeline.Pipeline.Get(session, "DNOTE?$filter=U_Status eq 'Open'");

                var listObj = ClassVC.B1JsonListToApiJson2(ddfJson).ListValues;
                var myDDF = JsonConvert.DeserializeObject<List<DnoteMDL>>(listObj);
                return myDDF[0];
            }
                catch (Exception ex)
                {
                throw new Exception(ex.Message);
                }

            }

        public static string createMessage(string messages, string id, string Title, List<string> multiple)
        {
            var MessageData = new Data
            {
                text = messages,
                title = Title,
                sound = "Default"
            };
            if (multiple != null)
            {

                var message = new Multiple
                {
                    notification = MessageData,
                    registration_ids = multiple,
                    priority = "high"
                };

                return JsonConvert.SerializeObject(message);
            }
            else
            {
                var message = new NotificationMDL
                {
                    notification = MessageData,
                    to = id,
                    priority = "high"
                };

                return JsonConvert.SerializeObject(message);
            }
           
        }

        public static string Register(string data, int Docentry, string type, string session)
        {
            try
            {
                string Clause = "";
               
                    Clause = "DNOTE";  
                

                string sessionId = SessionBLL.ValidateAppSession(session);
                if (type == "Post")
                {                        
                        string ddfJson = Pipeline.Pipeline.Post(session,data, Clause);

                        string DDFjson = ClassVC.B1JsonListToApiJson(ddfJson);
                        
                        var myDDF = JsonConvert.DeserializeObject<DnoteMDL>(ddfJson);

                        return "done";                  
                }
                else
                {
                    string ddfJson = Pipeline.Pipeline.Patch(session, data, Clause+"(" + Docentry + ")");

                    return "Patched";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public static void Registration(string session, string version, string Token, string release)
        {

                var create = createMessage("You are Notified", Token, "St Annes APP", null);
               var send = SendMessages(create);

            //var check = getID(session, (int)Globals.Globals.AuthSessions[session].EmployeeID , version, "");

            //if (check.DocEntry == 0)
            //{
            //    var createmdl = Notes(session, Token, 0, release, version, check.Line);
            //    var saveToken = Register(createmdl, 0, "Post", session);
            //    var create = createMessage("You are Notified", Token, "Delivery APP", null);
            //    var send = SendMessages(create);
            //}
            //else 
            //if(check.Token == "" && check.DocEntry != 0 )
            //{
            //    var createmdl = Notes(session, Token, check.DocEntry, release, version, check.Line);
            //    var saveToken = Register(createmdl, check.DocEntry, "Patch", session);
            //    var create = createMessage("You are Notified", Token, "Delivery APP", null);
            //    var send = SendMessages(create);
            //}
            //else if (Token != check.Token && check.Line != null)
            //{
            //    var createmdl = Notes(session, Token, check.DocEntry, release, version, check.Line);
            //    var saveToken = Register(createmdl, check.DocEntry, "Patch", session);

            //}
        }

        public static string Notes(string session, string token, int DocEntry, string release, string version, int? line)
        {
            string m = Enum.GetName(typeof(LoginTypes), AuthSessions[session].LoginType);
            if (DocEntry == 0)
            {
                var lines = new Notelinecollection
                {
                    U_ID = (int)AuthSessions[session].EmployeeID,
                    U_Token = token,
                    U_Type = m,
                    

                };
                var data = new List<Notelinecollection> { lines };
                var notes = new DnoteMDL
                {
                    U_Release = release,
                    U_Version = version,
                    NOTELINECollection = data,
                    U_Status = Status2.Open
                };

                return JsonConvert.SerializeObject(notes);
            }
            else
            {
                
                    var lines = new DnoteMDL.Notelinecollection
                    {
                        U_ID = (int)AuthSessions[session].EmployeeID,
                        U_Token = token,
                        U_Type = m,
                        DocEntry = DocEntry,
                        LineId = line
                    };
                var patch = new DnotePatch
                {
                    NOTELINECollection = new List<Notelinecollection> { lines }
                };

                return JsonConvert.SerializeObject(patch);
                
            }
            
           
        }
        
        public static string SendMessages(string data)
        {
            try
            {
                var result = "-1";
                var webAddr = "https://fcm.googleapis.com/fcm/send";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization:key=AAAA9yqFyxA:APA91bGxKjaUaPWCuCplIQvdPieoF-De6E-ln5i8s3f2J06wE3VvRf4ij4phzJ5x3EMJaq_dTLu8vGO6SKHLWaHh3SvWFh6zLTURdClHvuDBdw4GldcrlZPYgfTnAgmGyRWd7iBslqPT");
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = data;


                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return result;
            }
            catch (WebException ex)
            {
                var exception = ResponseBLL.WebExceptionJsonString(ex);
                throw new Exception(exception);
            }
            
            }
        
        public static ErrorMDL Send(string session, int ID, string message, string Title, Globals.Globals.LoginTypes Usertype)
        {
            try
            {
                var employee = new EmployeeMDL();
                var employees = new List<EmployeeMDL>();
                var SessionId = SessionBLL.ValidateAppSession(session);
               
                if (Usertype != LoginTypes.None)
                {
                    if (Usertype == LoginTypes.Nurse)
                    {
                        employees = EmployeeBLL.UsersByLoginType(session, "Nurse");
                    }
                    else
                    {
                        employees = EmployeeBLL.UsersByLoginType(session, "Doctor");
                    }
                        
                }

                if (ID != 0)
                {
                    employee = EmployeeBLL.DriverName(session, ID);
                }

                if (employees.Count != 0)
                {
                    var tokens = (from x in employees where x.U_NoToken != null && x.U_NoToken.Length > 15 select x.U_NoToken).ToList();
                    var created = NotificationBLL.createMessage(message, null, Title, tokens);
                }

                if (employee.U_NoToken != null && employee.U_NoToken.Length >15)
                {
                    var created = NotificationBLL.createMessage(message, employee.U_NoToken, Title, null);
                    var send = NotificationBLL.SendMessages(created);
                    return new ErrorMDL { Success = send };
                }
                return new ErrorMDL {};
            }
            catch (Exception ex )
            {
                return new ErrorMDL { Error = ex.Message };
            }
           
        }

        //public static string ExcutePushNotification(string title, string msg, string fcmToken, object data)
        //{
        //    var serverKey = ConfigurationManager.AppSettings["Serverkey"];
        //    var senderId = ConfigurationManager.AppSettings["SenderID"];

        //    var result = "-1";

        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //    httpWebRequest.ContentType = "application/json";
        //    httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
        //    httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
        //    httpWebRequest.Method = "POST";

        //    var payload = new
        //    {
        //        notification = new
        //        {
        //            title = title,
        //            body = msg,
        //            sound = "default"
        //        },

        //        data = new
        //        {
        //            info = data
        //        },
        //        to = fcmToken,
        //        priority = "high",
        //        content_available = true,

        //    };

        //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //    {
        //        string json = JsonConvert.SerializeObject(payload);
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //    }

        //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //    {
        //        result = streamReader.ReadToEnd();
        //    }
        //    return result;
        //}

    }
}