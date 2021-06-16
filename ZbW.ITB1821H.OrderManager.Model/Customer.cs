using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string Website { get; set; }

        public IList<Address> Addresses { get; }
        public IList<Order> Orders { get; }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}