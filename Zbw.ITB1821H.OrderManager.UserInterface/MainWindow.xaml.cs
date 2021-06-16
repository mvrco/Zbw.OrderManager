using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows.Data;

namespace ZbW.ITB1821H.OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleSwitch_Toggled(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is ToggleSwitch toggleSwitch)
            {
                if (toggleSwitch.IsOn)
                    ThemeManager.Current.ChangeTheme(this, "Dark.Taupe");
                else
                    ThemeManager.Current.ChangeTheme(this, "Light.Taupe");
            }
        }

        private void Github_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("explorer", UserInterface.Properties.Settings.Default.GithubUrl);
        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            customersListBox.UnselectAll();
            CollectionView customers = (CollectionView)CollectionViewSource.GetDefaultView(customersListBox.ItemsSource);
            if (customers != null)
                customers.Filter = UserFilter;
            customers.Refresh();
            ordersListBox.UnselectAll();
            CollectionView orders = (CollectionView)CollectionViewSource.GetDefaultView(ordersListBox.ItemsSource);
            if (orders != null)
                orders.Filter = UserFilter;
            orders.Refresh();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
                return true;
            return (item.ToString().IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}