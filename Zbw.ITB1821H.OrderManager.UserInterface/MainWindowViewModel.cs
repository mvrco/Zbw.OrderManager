using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            Customers = new List<Customer> {
                new Customer { Name = "Mike", Email = "Test", LastName = "S." },
                new Customer { Name = "Marco", Email = "Test", LastName = "G." },
                new Customer { Name = "Philip", Email = "Test", LastName = "S." }
            };
            Orders = new List<Order>
            {
                new Order{ Customer = Customers[0], DateOfPurchase = DateTime.Today}
            };
            StatusText = "Ready.";
        }

        public IList<Customer> Customers { get; private set; }
        public IList<Order> Orders { get; private set; }

        public string StatusText { get; private set; }
    }
}