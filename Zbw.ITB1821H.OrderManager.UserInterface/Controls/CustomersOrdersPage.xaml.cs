using System.Windows;
using System.Windows.Controls;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    /// <summary>
    /// Interaction logic for CustomersOrdersPage.xaml
    /// </summary>
    public partial class CustomersOrdersPage : Page
    {
        public CustomersOrdersPage()
        {
            InitializeComponent();
        }

        private void CustomersDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<Customer> viewModel = new(customersDatagrid.SelectedItem as Customer);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }

        private void OrdersDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<Order> viewModel = new(ordersDatagrid.SelectedItem as Order);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }
    }
}