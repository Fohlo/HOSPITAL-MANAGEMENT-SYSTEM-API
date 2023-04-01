using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Shipment
{
    public class Test
    {
        public class ShipmentMDL
        {

            public string U_PatientID { get; set; }
            public string U_PatientName { get; set; }
            public string U_RoomNo { get; set; }
            public string U_Age { get; set; }
            public string U_Doctor { get; set; }
            //public string U_Voyage { get; set; }
            //public string Remark { get; set; }
            public Vess1collection[] MATONEECollection { get; set; }
        }

        public class Vess1collection
        {

             public string U_Pstopd { get; set; }
             public string U_Diagnosis { get; set; }
             public string U_Nurse { get; set; }
             public string U_DofA{ get; set; }
            public string U_Ward { get; set; }
            public string U_Date { get; set; }
            public string U_Time { get; set; }
            public string U_NumOfP { get; set; }
            //public string U_BLNum { get; set; }
            //public int DocEntry { get; set; }
            //public int LineId { get; set; }
            //public int VisOrder { get; set; }
            //public string Object { get; set; }
            //public object LogInst { get; set; }
            //public string U_BLNum { get; set; }
            //public object U_BPInvoiceNum { get; set; }
            //public string U_Commodity { get; set; }
            //public object U_Consignee { get; set; }
            //public object U_ContainerNum { get; set; }
            //public object U_DaysToLoad { get; set; }
            //public object U_Demurage { get; set; }
            //public object U_DispDate { get; set; }
            //public object U_Driver { get; set; }
            //public object U_DropShipInvoice { get; set; }
            //public object U_DropShipTo { get; set; }
            //public object U_EmptyCont { get; set; }
            //public object U_Expenses { get; set; }
            //public object U_Fuel { get; set; }
            //public object U_GrvNum { get; set; }
            //public object U_InvAmtMM { get; set; }
            //public object U_InvNumMM { get; set; }
            //public object U_InvoiceAmt { get; set; }
            //public object U_License { get; set; }
            //public object U_LoadDate { get; set; }
            //public object U_NtcDate { get; set; }
            //public object U_OffLoadDate { get; set; }
            //public object U_Passport { get; set; }
            //public object U_POD { get; set; }
            //public object U_PortDays { get; set; }
            //public object U_PytStatus { get; set; }
            //public object U_Rate { get; set; }
            //public object U_RemarksFinance { get; set; }
            //public object U_RemarksLogistics { get; set; }
            //public object U_RemarksOther { get; set; }
            //public object U_Savings { get; set; }
            //public object U_Size { get; set; }
            //public object U_StdRate { get; set; }
            //public object U_TrailerDetails { get; set; }
            //public object U_Transporter { get; set; }
            //public object U_TripLog { get; set; }
            //public object U_TruckDetails { get; set; }
            //public object U_TurnTime { get; set; }
            //public object U_UsdTotal { get; set; }
            //public object U_Warehouse { get; set; }
            //public object U_ZwlTotal { get; set; }
        }

    }
}
