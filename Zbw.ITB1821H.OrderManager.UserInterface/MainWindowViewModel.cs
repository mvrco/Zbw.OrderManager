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
                new Customer { Id=666, Name = "Mike", Email = "mikexyz@devil.op", LastName = "S." },
                new Customer { Id=500, Name = "Marco", Email = "marcog@gmail.com", LastName = "G." },
                new Customer { Id=123, Name = "Philip", Email = "philips@hotmail.com", LastName = "S." },
                new Customer { Id=9, Name = "Alain", Email = "alain.berset@admin.ch", LastName = "Berset" }
            };
            Orders = new ObservableCollection<Order>
            {
                new Order{ Id=0, Customer = Customers[0], DateOfPurchase = DateTime.UtcNow},
                new Order{ Id=1, Customer = Customers[1], DateOfPurchase = DateTime.Today},
                new Order{ Id=2, Customer = Customers[2], DateOfPurchase = DateTime.Today},
                new Order{ Id=3, Customer = Customers[2], DateOfPurchase = DateTime.Today}
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