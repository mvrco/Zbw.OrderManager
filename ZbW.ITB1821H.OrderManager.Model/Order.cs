using System;
using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Order
    {
        public Order()
        {
            Id = 0;
            DateOfPurchase = DateTime.Now;
            Customer = null;
            Positions = new List<Position>();
        }

        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Customer Customer { get; set; }
        public IList<Position> Positions { get; set; }

        // TODO tostring
        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(DateOfPurchase) + "; " + DateOfPurchase + "; " +
                nameof(Customer) + "; " + Customer?.ToString() + "; " +
                nameof(Positions) + "; " + Positions?.ToString();
        }
    }
}