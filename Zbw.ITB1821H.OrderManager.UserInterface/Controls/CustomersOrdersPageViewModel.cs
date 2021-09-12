using ControlzEx.Theming;
using log4net;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class CustomersOrdersPageViewModel : BaseViewModel
    {
        private CustomerDto selectedCustomer;
        private ICustomerService _customerService;
        private IOrderService _orderService;

        public CustomersOrdersPageViewModel() : base(LogManager.GetLogger(nameof(CustomersOrdersPageViewModel)))
        {
            _customerService = new CustomerService(new CustomerRepository());
            _orderService = new OrderService(new OrderRepository());
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
                ShowError(e.Message);
            }
        }

        private ActionCommand addCustomerCommand;
        public ICommand AddCustomerCommand => addCustomerCommand ??= new ActionCommand(AddCustomer);

        private void AddCustomer()
        {
            try
            {
                SingleObjectWindow window = new();
                SingleObjectWindowViewModel<CustomerDto, Customer, ICustomerService> viewModel = new(CustomerDto.CreateNew(), _customerService, true);
                window.DataContext = viewModel;
                window.Owner = Application.Current.MainWindow;
                // property grid is not theme aware, dark skin messes it up
                ThemeManager.Current.ChangeTheme(window, "Light.Blue");
                window.ShowDialog();
            }
            catch (Exception e)
            {
                ShowWarning(e.Message);
            }
        }

        private ActionCommand addOrderCommand;
        public ICommand AddOrderCommand => addOrderCommand ??= new ActionCommand(AddOrder);

        private void AddOrder()
        {
            try
            {
                if (selectedCustomer == null)
                    throw new ApplicationException("Select a customer first.");
                SingleObjectWindow window = new();
                SingleObjectWindowViewModel<OrderDto, Order, IOrderService> viewModel = new(new OrderDto() { CustomerId = SelectedCustomer.Id, DateOfPurchase = DateTime.Now }, _orderService, true);
                window.DataContext = viewModel;
                window.Owner = Application.Current.MainWindow;
                // property grid is not theme aware, dark skin messes it up
                ThemeManager.Current.ChangeTheme(window, "Light.Blue");
                window.ShowDialog();
            }
            catch (Exception e)
            {
                ShowWarning(e.Message);
            }
        }
    }
}