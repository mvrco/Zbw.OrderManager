using log4net;
using System.Collections.Generic;
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
            Customers = _customerService.GetAll();
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
                OnPropertyChanged();
            }
        }

        public OrderDto SelectedOrder { get; set; }
    }
}