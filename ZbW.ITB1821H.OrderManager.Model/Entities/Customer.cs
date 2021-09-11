using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZbW.ITB1821H.OrderManager.Model.Entities
{

    [XmlRoot("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string Website { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        [XmlIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}