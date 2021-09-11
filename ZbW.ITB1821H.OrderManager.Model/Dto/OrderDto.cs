using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            //Id = 0;
            //DateOfPurchase = DateTime.Now;
        }

        public OrderDto(DateTime dateOfPurchase)
        {
            //Id = 0;
            DateOfPurchase = dateOfPurchase;
        }
        [ReadOnly(true)]
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        [ReadOnly(true)]
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual ICollection<PositionDto> Positions { get; set; }
    }
}
