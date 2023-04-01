using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models.Order
{
    public class Orders
    {
    }

    public class OrderEntryLine
    {
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public string QuantityIssued { get; set; }
        public string Comment { get; set; }
        public string Dispensed { get; set; }
        // public string Currency { get; set; }
        // public decimal DiscountPercent { get; set; }
        //public string WarehouseCode { get; set; }
        //public string AccountCode { get; set; }
        public string VatGroup { get; set; }
      //  public string TaxType { get; set; }
        //public string TaxLiable { get; set; }
        public string UnitPrice { get; set; }
    }
    public class OrderEntry
    {
        public string DocType { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
        public List<OrderEntryLine> DocumentLines { get; set; }
    }
    public class PostOrderEntry
    {
        public string DocType { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string CardCode { get; set; }
        public List<OrderEntryLine> DocumentLines { get; set; }
    }
}

