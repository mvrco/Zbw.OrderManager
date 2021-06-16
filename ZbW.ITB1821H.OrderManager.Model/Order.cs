using System;
using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Order
    {
        public int Id { get; }
        public DateTime DateOfPurchase { get; set; }
        public Customer Customer { get; set; }
        public IList<Position> Positions { get; }

        // TODO tostring
    }
}