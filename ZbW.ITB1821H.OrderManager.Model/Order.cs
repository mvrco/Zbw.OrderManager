using System;
using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Order
    {
        public Order()
        {
            //Id = 0;
            //DateOfPurchase = DateTime.Now;
        }

        public Order(DateTime dateOfPurchase)
        {
            //Id = 0;
            DateOfPurchase = dateOfPurchase;
        }

        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

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