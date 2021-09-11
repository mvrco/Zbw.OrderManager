using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZbW.ITB1821H.OrderManager.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [XmlIgnore]
        public virtual ICollection<Position> Positions { get; set; }
    }
}