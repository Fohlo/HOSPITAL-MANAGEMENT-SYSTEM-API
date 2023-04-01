using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Shipment
{
    public class ShipmentMDL
    {

        public string U_Containers { get; set; }
        public string U_LPort { get; set; }
        public string U_VesselName { get; set; }
        //public string CreatedDate { get; set; }
        //public string Remark { get; set; }
        public string U_EtaDate { get; set; }
        public string U_Status { get; set; }
        //public string Voyage { get; set; }

        public List<ShipmentCollection> shipmentCollection { get; set; }

        public class ShipmentCollection
        {
            //public string LineId { get; set; }
            //public string VisOrder { get; set; }
            public string U_BLNum { get; set; }
            ///public string BPInvoiceNum { get; set; }
            //public string U_Commodity { get; set; }
            public string U_Consignee { get; set; }
            //public string U_ContainerNum { get; set; }
            //public string U_DaysToLoad { get; set; }
            //public string U_Demurage { get; set; }
            //public string U_DispDate { get; set; }
            //public string U_Driver { get; set; }
            //public string U_DropShipInvoice { get; set; }
            //public string U_DropShipTo { get; set; }
            //public string U_EmptyCont { get; set; }
            //public string U_Expenses { get; set; }
            //public string U_Fuel { get; set; }
            //public string U_GRVNum { get; set; }
            //public string U_InvAmtMM { get; set; }
            //public string U_InvoiceNumMM { get; set; }
            //public string U_InvoiceAmt { get; set; }
            //public string U_Lisence { get; set; }
            //public string U_NtcDate { get; set; }
            //public string U_OffLoadDate { get; set; }
            //public string U_Passport { get; set; }
            //public string U_POD { get; set; }
            //public string U_PortDays { get; set; }
            //public string U_PytStatus { get; set; }
            //public string U_Rate { get; set; }
            //public string U_RemarksFinance { get; set; }
            //public string U_RemarksLogistics { get; set; }
            //public string U_RemarksOther { get; set; }
            //public string U_Savings { get; set; }
            //public string U_Size { get; set; }
            //public string U_StdRate { get; set; }
            //public string U_TrailerDetails { get; set; }
            //public string U_Transporter { get; set; }
            //public string U_TripLog { get; set; }
            //public string U_TruckDetails { get; set; }
            //public string U_TurnTime { get; set; }
            //public string U_UsdTotal { get; set; }
            //public string U_WareHouse { get; set; }
            //public string U_ZwlTotal { get; set; }

        }
    }
}
