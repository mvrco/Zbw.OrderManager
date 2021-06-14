using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Customer
    {
        public virtual int Id { get; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Website { get; set; }

        public virtual IList<Address> Addresses { get; }
        public virtual IList<Order> Orders { get; }

        public override string ToString()
        {
            return base.ToString() + "; " +
                nameof(Id) + "; " + Id + "; " +
                nameof(Name) + "; " + Name + "; " +
                nameof(LastName) + "; " + LastName + "; " +
                nameof(Email) + "; " + Email + "; " +
                nameof(Website) + "; " + Website;
        }
    }
}