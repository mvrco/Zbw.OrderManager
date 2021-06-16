using System;
using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Customer Customer { get; set; }
        public IList<Position> Positions { get; }

        // TODO tostring
        public override string ToString()
        {
            return base.ToString() + "; " +
                nameof(Id) + "; " + Id + "; " +
                nameof(DateOfPurchase) + "; " + DateOfPurchase + "; " +
                nameof(Customer) + "; " + Customer.ToString() + "; " +
                nameof(Positions) + "; " + Positions?.ToString();
        }
    }
}