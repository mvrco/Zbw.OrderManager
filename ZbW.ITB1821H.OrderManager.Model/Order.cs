using System;
using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Order
    {
        public virtual int Id { get; }
        public virtual DateTime DateOfPurchase { get; set; }
        public virtual Customer Customer { get; }
        public virtual IList<Position> Positions { get; }

        // TODO tostring
    }
}