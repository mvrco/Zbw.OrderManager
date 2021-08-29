using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.ITB1821H.OrderManager.Model.Entities
{
    public class Invoice
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
    }
}
