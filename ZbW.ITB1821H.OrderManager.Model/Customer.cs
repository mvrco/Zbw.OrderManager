using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Customer
    {
        public Customer()
        {
            //Id = 0;
            //Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string Website { get; set; }
        public int AdressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}