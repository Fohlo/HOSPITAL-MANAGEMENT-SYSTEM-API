using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SAMS.Globals.Globals;

namespace SAMS.Models.Stock
{
    public class StockMDL
    {


        public class Stock
        {

            //public int DocEntry { get; set; }
            //public int DocNum { get; set; }

            //public string DocType { get; set; }


            //public string HandWritten { get; set; }

            //public string Printed { get; set; }

            //public double DocTotal { get; set; }

            //public double DocRate { get; set; }

            //public string Reference1 { get; set; }

            //public string Reference2 { get; set; }

            public DateTime? DocDate { get; set; }
            public DateTime? DocDueDate { get; set; }

         //   public string DocCurrency { get; set; }

            public string JournalMemo { get; set; }

          //  public int PaymentGroupCode { get; set; }
          //  public DateTime? DocTime { get; set; }
            //public int SalesPersonCode { get; set; }
            
            //public int TransportationCode { get; set; } 
            //public string Confirmed { get; set; } 
            //public string CreationDate { get; set; }
            //public string UpdateDate { get; set; }
            //public int FinancialPeriod { get; set; }
            //public int TransNum { get; set; }




            public List<Stocks> DocumentLines = new List<Stocks>();
        }

        public class PostStock
        {


           
            public List<PostStocks> DocumentLines { get; set; } = new List<PostStocks>();

            //public int DocEntry { get; set; }
            //public int DocNum { get; set; }

            //public string DocType { get; set; }


            //public string HandWritten { get; set; }

            //public string Printed { get; set; }

            //public double DocTotal { get; set; }

            //public double DocRate { get; set; }

            //public string Reference1 { get; set; }

            //public string Reference2 { get; set; }

            public DateTime? DocDate { get; set; }
            public DateTime? DocDueDate { get; set; }

         //   public string DocCurrency { get; set; }

            public string JournalMemo { get; set; }

            //public int PaymentGroupCode { get; set; }
            //public DateTime? DocTime { get; set; }
            //public int SalesPersonCode { get; set; }

            //public int TransportationCode { get; set; }
            //public string Confirmed { get; set; }
            //public string CreationDate { get; set; }
            //public string UpdateDate { get; set; }
            //public int FinancialPeriod { get; set; }
            //public int TransNum { get; set; }


        }
        public class PostStocks
        {
         //   public int LineNum { get; set; }

            public string ItemCode { get; set; }
            public string ItemDescription { get; set; }
            public double  Quantity { get; set; }
            public double Price { get; set; }
          //  public string Currency { get; set; }
          //  public string Rate { get; set; }

        }
        public class Stocks
        {


           // public int LineNum { get; set; }

            public string ItemCode { get; set; }
            public string ItemDescription { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
          //  public string Currency { get; set; }
          //  public string Rate { get; set; }


           
        }
    }
}
