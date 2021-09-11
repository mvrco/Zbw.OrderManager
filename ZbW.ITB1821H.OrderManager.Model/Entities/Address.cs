using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZbW.ITB1821H.OrderManager.Model.Entities
{

    [XmlRoot("Address")]
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [XmlIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}