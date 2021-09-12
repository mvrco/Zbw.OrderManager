using log4net;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
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

        private ActionCommand deleteCustomerCommand;
        public ICommand DeleteCustomerCommand => deleteCustomerCommand ??= new ActionCommand(DeleteCustomer);

        private void DeleteCustomer()
        {
            try
            {
                _customerService.Delete(selectedCustomer);
                SelectedCustomer = null;
            }
            catch(Exception e)
            {
                MessageBox.Show("");
            }
        }
    }
}