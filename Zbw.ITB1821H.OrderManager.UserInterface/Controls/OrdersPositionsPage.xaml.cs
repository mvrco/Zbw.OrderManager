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
    /// Interaction logic for OrdersPositionsPage.xaml
    /// </summary>
    public partial class OrdersPositionsPage : Page
    {
        private string searchText;

        public OrdersPositionsPage()
        {
            InitializeComponent();
            ApplicationEventHandler.SearchTextChanged += ApplicationEventHandler_SearchTextChanged;
        }

        private void ApplicationEventHandler_SearchTextChanged(object sender, string e)
        {
            searchText = e;
            positionsDatagrid.UnselectAll();
            ordersDatagrid.UnselectAll();
            CollectionView orders = (CollectionView)CollectionViewSource.GetDefaultView(ordersDatagrid.ItemsSource);
            if (orders != null)
                orders.Filter = UserFilter;
            orders.Refresh();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(searchText))
                return true;
            return (item.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
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

        private void PositionsDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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