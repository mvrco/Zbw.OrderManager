using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}