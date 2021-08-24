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
    public class CustomersOrdersPageViewModel : BaseViewModel
    {
        private CustomerDto selectedCustomer;
        private ICustomerService _customerService;

        public CustomersOrdersPageViewModel() : base(LogManager.GetLogger(nameof(CustomersOrdersPageViewModel)))
        {
            _customerService = new CustomerService(new CustomerRepository());
            Customers = _customerService.GetAll();//App.DbContext.Customers.ToList();
        }

        public IList<CustomerDto> Customers { get; set; }

        public CustomerDto SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                if (value != null)
                    // Abfrage sollte nocht benötigt werden, da Orders mit CustomerDto geladen werden
                    //selectedCustomer.Orders = App.DbContext.Orders.Where(x => x.CustomerId == selectedCustomer.Id).ToList();
                OnPropertyChanged();
            }
        }

        public OrderDto SelectedOrder { get; set; }
    }
}