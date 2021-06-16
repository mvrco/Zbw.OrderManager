using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            Customers = new ObservableCollection<Customer> {
                new Customer { Name = "Mike", Email = "Test", LastName = "S." },
                new Customer { Name = "Marco", Email = "Test", LastName = "G." },
                new Customer { Name = "Philip", Email = "Test", LastName = "S." }
            };
            Orders = new ObservableCollection<Order>
            {
                new Order{ Customer = Customers[0], DateOfPurchase = DateTime.Today}
            };
        }

        public IList<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }
        public IList<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }

        /// <summary>
        /// Loads and sets the scaling factor from/to user settings
        /// </summary>
        public static double SliderValue
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

        public static bool LightSwitch
        {
            get
            {
                return UserInterface.Properties.Settings.Default.LightSwitch;
            }
            set
            {
                UserInterface.Properties.Settings.Default.LightSwitch = value;
                UserInterface.Properties.Settings.Default.Save();
            }
        }

        public bool IsBusy { get => false; }

        public bool IsIdle { get => !IsBusy; }
    }
}