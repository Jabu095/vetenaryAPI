//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Runtime.Serialization;
//using System.Web.Http;
//using System.Web.Mvc;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Security.Cryptography.SHA1;
//using System.IO.Pipes;

//namespace Veterinary_Appointment_API.WorkFolder.Controllers
//{
//    public class InvoiceController : ApiController
//    {
//        [System.Web.Http.HttpGet]
//        public Invoices GenerateInvoice()
//        {
                //return GenerateInvoices();
//        }

//        private static decimal _grandTotal;
//        private static decimal _grandGrandTotal;


//        private Invoices GenerateInvoices()
//        {
//            Invoice inv1 = GenerateInvoice1();

//            Invoice inv2 = GenerateInvoice2();
//            Invoice inv3 = GenerateInvoice3();

//            List<Invoice> inv = new List<Invoice>();
//            inv.Add(inv1);
//            inv.Add(inv2);
//            inv.Add(inv3);


//            foreach (var invoice in inv)
//            {
//                _grandGrandTotal += invoice.Total;
//            }

//            return new Invoices() { invoiceList = inv, Total = _grandGrandTotal, TotalInvoices = inv.Count };
//        }

//        private Invoice GenerateInvoice3()
//        {
//            Invoice i = new Invoice();
//            i.InvoiceNumber = "0003";
//            i.Date = DateTime.Now;
//            i.Customer_ID = "0003";
//            i.Customer_Name = "James";

//            i.InvoiceItem = new invoice_Item[3];
//            i.InvoiceItem[0] = new invoice_Item();
//            i.InvoiceItem[0].description = "Pet Frog appointment";

//            decimal Amount = 55003.00m;
//            decimal VAT = CalculateVAT(Amount.ToString());
//            decimal Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[0].amount = Amount;
//            i.InvoiceItem[0].VAT = VAT;
//            i.InvoiceItem[0].Total = Total;


//            i.InvoiceItem[1] = new invoice_Item();
//            i.InvoiceItem[1].description = "Pet Anaconda appointment";

//            Amount = 1086.19m;
//            VAT = CalculateVAT(Amount.ToString());
//            Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[1].amount = Amount;
//            i.InvoiceItem[1].VAT = VAT;
//            i.InvoiceItem[1].Total = Total;



//            i.InvoiceItem[2].description = "Pet Rabbit appointment";

//            Amount = 50;

//            Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[2].amount = Amount;
//            i.InvoiceItem[2].VAT = VAT;
//            i.InvoiceItem[2].Total = Total;


//            foreach (var item in i.InvoiceItem)
//            {
//                _grandTotal += item.Total;
//                NoOfInvoiceItems++;
//            }

//            i.Total = _grandTotal;
//            i.TotalCount = NoOfInvoiceItems;

//            return i;
//        }


//        private Invoice GenerateInvoice2()
//        {
//            Invoice i = new Invoice();
//            i.InvoiceNumber = "0002";
//            i.Date = DateTime.Now;
//            i.Customer_ID = "0002";
//            i.Customer_Name = "Harry";

//            i.InvoiceItem = new invoice_Item[2];
//            i.InvoiceItem[0] = new invoice_Item();
//            i.InvoiceItem[0].description = "Pet Platypus appointment";
//            object vat = null;
//            decimal Amount = 5500.59m;
//            decimal VAT = CalculateVAT(Amount.ToString());
//            decimal Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[0].amount = Amount;
//            i.InvoiceItem[0].VAT = VAT;
//            i.InvoiceItem[0].Total = Total;


//            string vatAmount = vat.ToString();

//            i.InvoiceItem[1] = new invoice_Item();
//            i.InvoiceItem[1].description = "Pet Megalodon appointment";

//            Amount = 105.99m;
//            VAT = CalculateVAT(Amount.ToString());
//            Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[1].amount = Amount;
//            i.InvoiceItem[1].VAT = VAT;
//            i.InvoiceItem[1].Total = Total;

//            foreach (var item in i.InvoiceItem)
//            {
//                _grandTotal += item.Total;
//                NoOfInvoiceItems++;
//            }

//            i.Total = _grandTotal;
//            i.TotalCount = NoOfInvoiceItems;

//            return i;
//        }


//        private Invoice GenerateInvoice1()
//        {
//            Invoice i = new Invoice();
//            i.InvoiceNumber = "0001";
//            i.Date = DateTime.Now;
//            i.Customer_ID = "0001";
//            i.Customer_Name = "Jake";

//            i.InvoiceItem = new invoice_Item[2];
//            i.InvoiceItem[0] = new invoice_Item();
//            i.InvoiceItem[0].description = "Pet Rottweiler appointment";

//            decimal Amount = 560.59m;
//            decimal VAT = CalculateVAT(Amount.ToString());
//            decimal Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[0].amount = Amount;
//            i.InvoiceItem[0].VAT = VAT;
//            i.InvoiceItem[0].Total = Total;

//            i.InvoiceItem[1] = new invoice_Item();
//            i.InvoiceItem[1].description = "Pet Hamster appointment";
//            Amount = 582.99m;
//            Total = CalculateTotal(Amount, VAT);

//            i.InvoiceItem[1].amount = Amount;
//            i.InvoiceItem[1].VAT = VAT;
//            i.InvoiceItem[1].Total = Total;

//            foreach (var item in i.InvoiceItem)
//            {
//                _grandTotal += item.Total;
//            }

//            i.Total = _grandTotal;

//            return i;
//        }

//        /// <summary>
//        /// VAT = always 11 %
//        /// </summary>
//        /// <returns>Calculate VAT Amount</returns>
//        protected decimal CalculateVAT(string Amount)
//        {
//            return Convert.ToDecimal(Convert.ToDecimal(Amount) / (100 * 0)); ;
//        }
//        private static decimal NoOfInvoiceItems;
//        private decimal CalculateTotal(decimal Amount, decimal VAT)
//        {
//            return Amount + VAT;
//        }
//    }


//    public partial class Invoice : Customer
//    {
//        public string InvoiceNumber;
//        public DateTime Date;
//        public invoice_Item[] InvoiceItem;

//        public string Customer_ID { get; set; }
//        public String Customer_Name { get; set; }

//        public decimal Total { get; set; }
//        public decimal TotalCount { get; set; }
//    }


//    public class invoice_Item
//    {
//        public string description;
//        public decimal amount;
//        public decimal VAT;
//        public decimal Total;
//    }

//    public interface Customer
//    {
//        public string Customer_ID { get; set; }

//        public string Customer_Name { get; }
//    }

//    public partial class Invoice
//    {
//        public Invoice()
//        {


//        }
//    }

//    public class Invoices
//    {
//        public List<Invoice> invoiceList { get; set; }
//        public decimal Total { get; set; }
//        public decimal TotalInvoices { get; set; }
//    }
//}
