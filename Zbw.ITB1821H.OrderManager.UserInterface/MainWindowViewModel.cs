using log4net;
using MahApps.Metro.IconPacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.UserInterface.Controls;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager
{
    public class MainWindowViewModel : BaseViewModel
    {
        private DatabaseContext dbContext;

        private static readonly IList<HamMenuItem> AppMenu = new ObservableCollection<HamMenuItem>();
        private static readonly IList<HamMenuItem> AppOptionsMenu = new ObservableCollection<HamMenuItem>();

        private string searchText;

        public MainWindowViewModel() : base(LogManager.GetLogger(nameof(MainWindowViewModel)))
        {
            this.dbContext = App.DbContext;
            // create main menu
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid },
                Label = "Customers",
                NavigationType = typeof(CustomersOrdersPage),
                NavigationDestination = new Uri("Controls/CustomersOrdersPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.GiftSolid },
                Label = "Articles",
                NavigationType = typeof(ArticlesGroupsPage),
                NavigationDestination = new Uri("Controls/ArticlesGroupsPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.ChessBoardSolid },
                Label = "Orders",
                NavigationType = typeof(ArticlesGroupsPage),
                NavigationDestination = new Uri("Controls/OrdersPositionsPage.xaml", UriKind.RelativeOrAbsolute)
            });

            //this.OptionsMenu.Add(new HamMenuItem()
            //{
            //    Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FileExportSolid },
            //    Label = "Export",
            //    NavigationType = typeof(SaveFileDialog),
            //    NavigationDestination = new Uri(typeof(SaveFileDialog).Name, UriKind.RelativeOrAbsolute)
            //});
            // create commands
            ExportData = new ActionCommand(OnExportData);
        }

        // Commands
        public ICommand ExportData { get; set; }

        private void OnExportData()
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog() { DefaultExt = "json", FileName = "OrderManagerData", Filter = "JSON file|*.json|XML file|*.xml" };
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    Stream fileStream = dialog.OpenFile();
                    StreamWriter sw = new StreamWriter(fileStream);
                    // get json string
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(App.DbContext.Customers.ToList(), new JsonSerializerOptions() { WriteIndented = true });
                    switch (dialog.SafeFileName.Split(".").Last())
                    {
                        case "json":
                            // write json string to file
                            sw.Write(jsonString);
                            break;

                        case "xml":
                            // convert json string to xml string anf write to file
                            XmlDocument doc = JsonConvert.DeserializeXmlNode("{'Customer':" + jsonString + "}", "OrderManagerData");
                            //doc.InnerXml
                            XmlWriter writer = XmlWriter.Create(fileStream, new XmlWriterSettings { Indent = true });
                            doc.WriteTo(writer);
                            writer.Flush();
                            break;
                    }
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (IOException ioExc)
            {
                ShowError(ioExc.Message);
            }
        }

        // For this view model relevant data
        public IList<HamMenuItem> Menu => AppMenu;

        public IList<HamMenuItem> OptionsMenu => AppOptionsMenu;

        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged();
                ApplicationEventHandler.OnSearchTextChanged(this, searchText);
            }
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

        /// <summary>
        /// Loads and sets the theme selection from/to user settings
        /// </summary>
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