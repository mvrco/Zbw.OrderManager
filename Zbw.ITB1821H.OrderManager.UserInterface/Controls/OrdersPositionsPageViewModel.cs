using log4net;
using System.Collections.Generic;
using System.Linq;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class OrdersPositionsPageViewModel : BaseViewModel
    {
        private OrderDto selectedOrder;
        private IOrderService _orderService;

        public OrdersPositionsPageViewModel() : base(LogManager.GetLogger(nameof(OrdersPositionsPageViewModel)))
        {
            _orderService = new OrderService(new OrderRepository());
            Orders = _orderService.GetAll();//App.DbContext.Orders.ToList();
        }

        public IList<OrderDto> Orders { get; set; }

        public OrderDto SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                if (value != null)
                    // sollte nicht nötig sein, da Positionen mit entsprechendem OrderDto geladen werden
                    //selectedOrder.Positions = App.DbContext.Positions.Where(x => x.OrderId == selectedOrder.Id).ToList();
                OnPropertyChanged();
            }
        }

        public PositionDto SelectedPosition { get; set; }
    }
}