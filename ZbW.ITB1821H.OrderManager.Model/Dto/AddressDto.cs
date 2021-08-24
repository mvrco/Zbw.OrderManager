using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<CustomerDto> Customers { get; set; }
    }
}
