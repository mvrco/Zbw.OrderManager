using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly NavigationServiceWithFrame navigationService;

        public MainWindow()
        {
            InitializeComponent();
            this.navigationService = new NavigationServiceWithFrame();
            this.navigationService.Navigated += this.NavigationService_OnNavigated;
            this.HamburgerMenuControl.Content = this.navigationService.Frame;

            // Navigate to the home page.
            this.navigationService.Navigate(new Uri("Controls/CustomersOrdersPage.xaml", UriKind.RelativeOrAbsolute));
        }

        protected void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is HamMenuItem menuItem)
                this.navigationService.Navigate(menuItem.NavigationDestination);
        }

        private void NavigationService_OnNavigated(object sender, NavigationEventArgs e)
        {
            // select the menu item
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
                                                         .Items
                                                         .OfType<HamMenuItem>()
                                                         .FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
                                                                .OptionsItems
                                                                .OfType<HamMenuItem>()
                                                                .FirstOrDefault(x => x.NavigationDestination == e.Uri);

            // or when using the NavigationType on menu item
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
                                                         .Items
                                                         .OfType<HamMenuItem>()
                                                         .FirstOrDefault(x => x.NavigationType == e.Content?.GetType());
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
                                                                .OptionsItems
                                                                .OfType<HamMenuItem>()
                                                                .FirstOrDefault(x => x.NavigationType == e.Content?.GetType());

            // update back button
            //this.GoBackButton.Visibility = this.navigationService.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.navigationService.GoBack();
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleSwitch toggleSwitch)
            {
                if (toggleSwitch.IsOn)
                    ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Blue");
                else
                    ThemeManager.Current.ChangeTheme(Application.Current, "Light.Blue");
            }
        }

        private void Github_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer", UserInterface.Properties.Settings.Default.GithubUrl);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ////customersListBox.UnselectAll();
            //CollectionView customers = (CollectionView)CollectionViewSource.GetDefaultView(customersDatagrid.ItemsSource);
            //if (customers != null)
            //    customers.Filter = UserFilter;
            //customers.Refresh();
            ////ordersListBox.UnselectAll();
            //CollectionView orders = (CollectionView)CollectionViewSource.GetDefaultView(ordersDatagrid.ItemsSource);
            //if (orders != null)
            //    orders.Filter = UserFilter;
            //orders.Refresh();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
                return true;
            return (item.ToString().IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }

    public class HamMenuItem : HamburgerMenuIconItem
    {
        public static readonly DependencyProperty NavigationDestinationProperty = DependencyProperty.Register(
          nameof(NavigationDestination), typeof(Uri), typeof(MenuItem), new PropertyMetadata(default(Uri)));

        public Uri NavigationDestination
        {
            get => (Uri)this.GetValue(NavigationDestinationProperty);
            set => this.SetValue(NavigationDestinationProperty, value);
        }

        public static readonly DependencyProperty NavigationTypeProperty = DependencyProperty.Register(
          nameof(NavigationType), typeof(Type), typeof(MenuItem), new PropertyMetadata(default(Type)));

        public Type NavigationType
        {
            get => (Type)this.GetValue(NavigationTypeProperty);
            set => this.SetValue(NavigationTypeProperty, value);
        }

        public bool IsNavigation => this.NavigationDestination != null;
    }
}