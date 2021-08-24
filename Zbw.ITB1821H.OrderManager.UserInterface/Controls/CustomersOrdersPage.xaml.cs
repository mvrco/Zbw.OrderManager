using ControlzEx.Theming;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    /// <summary>
    /// Interaction logic for CustomersOrdersPage.xaml
    /// </summary>
    public partial class CustomersOrdersPage : Page
    {
        private string searchText;

        public CustomersOrdersPage()
        {
            InitializeComponent();
            ApplicationEventHandler.SearchTextChanged += ApplicationEventHandler_SearchTextChanged;
        }

        private void ApplicationEventHandler_SearchTextChanged(object sender, string e)
        {
            searchText = e;
            ordersDatagrid.UnselectAll();
            customersDatagrid.UnselectAll();
            CollectionView customers = (CollectionView)CollectionViewSource.GetDefaultView(customersDatagrid.ItemsSource);
            if (customers != null)
                customers.Filter = UserFilter;
            customers.Refresh();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(searchText))
                return true;
            return (item.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void CustomersDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<CustomerDto> viewModel = new(customersDatagrid.SelectedItem as CustomerDto);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            // property grid is not theme aware, dark skin messes it up
            ThemeManager.Current.ChangeTheme(window, "Light.Blue");
            window.ShowDialog();
        }

        private void OrdersDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<OrderDto> viewModel = new(ordersDatagrid.SelectedItem as OrderDto);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            // property grid is not theme aware, dark skin messes it up
            ThemeManager.Current.ChangeTheme(window, "Light.Blue");
            window.ShowDialog();
        }
    }
}