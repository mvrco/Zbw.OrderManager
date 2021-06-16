using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class CustomersOrdersPageViewModel : BaseViewModel
    {
        public CustomersOrdersPageViewModel()
        {
            Customers = new ObservableCollection<Customer> {
                new Customer { Id=666, Name = "Mike", Email = "mikexyz@devil.op", LastName = "S." },
                new Customer { Id=500, Name = "Marco", Email = "marcog@gmail.com", LastName = "G.",
                    Orders = new ObservableCollection<Order>(){ new Order{ Id=1, DateOfPurchase = DateTime.Today},
                new Order{ Id=2, DateOfPurchase = DateTime.Today}} },
                new Customer { Id=123, Name = "Philip", Email = "philips@hotmail.com", LastName = "S." },
                new Customer { Id=9, Name = "Alain", Email = "alain.berset@admin.ch", LastName = "Berset" }
            };
        }

        private Customer selectedCustomer;

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
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public Order SelectedOrder { get; set; }
    }
}