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
        }

        public IList<Customer> Customers { get; private set; }
        public Customer SelectedCustomer { get; set; }
        public IList<Order> Orders { get; private set; }
        public Order SelectedOrder { get; set; }

        /// <summary>
        /// Loads and sets the scaling factor from/to user settings
        /// </summary>
        public double SliderValue
        {
            get
            {
                return UserInterface.Properties.Settings.Default.ScalingFactor;
            }
            set
            {
                UserInterface.Properties.Settings.Default.ScalingFactor = value;
                UserInterface.Properties.Settings.Default.Save();
            }
        }
    }
}