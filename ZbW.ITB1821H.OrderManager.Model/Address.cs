namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Address
    {
        public Address()
        {
            Id = 0;
        }

        public int Id { get; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Customer Customer { get; set; }

        // TODO tostring
    }
}