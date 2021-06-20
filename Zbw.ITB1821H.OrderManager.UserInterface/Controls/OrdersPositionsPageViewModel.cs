using log4net;
using System.Collections.Generic;
using System.Linq;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class OrdersPositionsPageViewModel : BaseViewModel
    {
        private Order selectedOrder;

        public OrdersPositionsPageViewModel() : base(LogManager.GetLogger(nameof(OrdersPositionsPageViewModel)))
        {
            Orders = App.DbContext.Orders.ToList();
        }

        public IList<Order> Orders { get; set; }

        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                if (value != null)
                    selectedOrder.Positions = App.DbContext.Positions.Where(x => x.OrderId == selectedOrder.Id).ToList();
                OnPropertyChanged();
            }
        }

        public Position SelectedPosition { get; set; }
    }
}