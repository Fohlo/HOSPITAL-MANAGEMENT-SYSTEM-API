using Newtonsoft.Json;
using SAMS.Models.Admissions;
using SAMS.Models.Floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.BLL.Floors
{
    public class FloorBLL
    {

        public static List<FloorMDL> GetFloors(string session)
        {
            try
            {
                var clause = "FLOOR";
                return JsonConvert.DeserializeObject<List<FloorMDL>>(Pipeline.Pipeline.GetMultiple(session,clause)[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static FloorMDL GetFloor(string session, int floorID)
        {
            try
            {
                var clause = "FLOOR(" + floorID+")";
                return JsonConvert.DeserializeObject<FloorMDL>(Pipeline.Pipeline.Get(session, clause));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string EditRoom(string session, int DocEntry, EditFloor floor)
        {
            try
            {
                var edit = Pipeline.Pipeline.Patch(session, JsonConvert.SerializeObject(floor), "FLOOR(" + DocEntry+")");
                return edit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string EditRoom(string session, EditFloor floor, AdmissionMDL admit)
        {
            try
            {
                var getpreviousAssigned = GetFloors(session);

                floor.FLOORLINESCollection[0].U_AdDoc = admit.DocEntry;
                floor.FLOORLINESCollection[0].U_PatientID = admit.U_PatientID;
                var linetobeedited = new List<EditFloor.Floorlinescollection> { };
                int Docentry = 0;
                foreach (FloorMDL fl in getpreviousAssigned)
                {
                    if (fl.U_FloorName == admit.U_Floor)
                    {
                        Docentry = fl.DocEntry;

                        var find = (from x in fl.FLOORLINESCollection where x.U_Ward == admit.U_Ward && x.U_Room == admit.U_Room select x).ToList();
                        if (find.Count != 0)
                        {

                            var line = JsonConvert.DeserializeObject<EditFloor.Floorlinescollection>(JsonConvert.SerializeObject(find[0]));
                            linetobeedited.Add(line);
                        }
                    }
                }
                if (linetobeedited.Count > 0)
                {
                    linetobeedited[0].U_Status = Globals.Globals.RoomStatus.Open;
                    linetobeedited[0].U_AdDoc = 0;
                    linetobeedited[0].U_PatientID = "None";
                    //linetobeedited.Add(floor.FLOORLINESCollection[0]);
                    var edit = new EditFloor { FLOORLINESCollection = linetobeedited };
                    var editor = Pipeline.Pipeline.Patch(session, JsonConvert.SerializeObject(edit), "FLOOR(" + Docentry + ")");
                }
                
                    return EditRoom(session, floor.FLOORLINESCollection[0].DocEntry, floor);                    
                
                             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
