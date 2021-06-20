using log4net;
using System.Collections.Generic;
using System.Linq;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class CustomersOrdersPageViewModel : BaseViewModel
    {
        private Customer selectedCustomer;

        public CustomersOrdersPageViewModel() : base(LogManager.GetLogger(nameof(CustomersOrdersPageViewModel)))
        {
            Customers = App.DbContext.Customers.ToList();
        }

        public IList<Customer> Customers { get; set; }

        public Customer SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                selectedCustomer.Orders = App.DbContext.Orders.Where(x => x.CustomerId == selectedCustomer.Id).ToList();
                OnPropertyChanged();
            }
        }

        public Order SelectedOrder { get; set; }
    }
}