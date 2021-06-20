using MahApps.Metro.IconPacks;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.UserInterface.Controls;

namespace ZbW.ITB1821H.OrderManager
{
    public class MainWindowViewModel : BaseViewModel
    {
        private static readonly ObservableCollection<HamMenuItem> AppMenu = new ObservableCollection<HamMenuItem>();
        private static readonly ObservableCollection<HamMenuItem> AppOptionsMenu = new ObservableCollection<HamMenuItem>();

        public ObservableCollection<HamMenuItem> Menu => AppMenu;

        public ObservableCollection<HamMenuItem> OptionsMenu => AppOptionsMenu;

        public MainWindowViewModel()
        {
            // Build the menus
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid },
                Label = "Customers & Orders",
                NavigationType = typeof(CustomersOrdersPage),
                NavigationDestination = new Uri("Controls/CustomersOrdersPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.GiftSolid },
                Label = "Articles & Groups",
                NavigationType = typeof(ArticlesGroupsPage),
                NavigationDestination = new Uri("Controls/ArticlesGroupsPage.xaml", UriKind.RelativeOrAbsolute)
            });

            //this.OptionsMenu.Add(new HamMenuItem()
            //{
            //    Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FileExportSolid },
            //    Label = "Export",
            //    NavigationType = typeof(SaveFileDialog),
            //    NavigationDestination = new Uri(typeof(SaveFileDialog).Name, UriKind.RelativeOrAbsolute)
            //});
            ExportData = new ActionCommand(OnExportData);
        }

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

        public ICommand ExportData { get; set; }

        private void OnExportData()
        {
            SaveFileDialog dialog = new SaveFileDialog() { DefaultExt = "json", FileName = "OrderManagerData", Filter = "JSON file|*.json|CSV file|*.csv|XML file|*.xml" };
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                System.IO.Stream fileStream = dialog.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                sw.WriteLine("INSERT EXPORT DATA");
                sw.Flush();
                sw.Close();
            }
        }
    }
}