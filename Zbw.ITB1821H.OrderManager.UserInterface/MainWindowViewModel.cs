using log4net;
using MahApps.Metro.IconPacks;
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
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
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
            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.AsteriskSolid },
                Label = "Invoices",
                NavigationType = typeof(InvoicesPage),
                NavigationDestination = new Uri("Controls/InvoicesPage.xaml", UriKind.RelativeOrAbsolute)
            });

            this.Menu.Add(new HamMenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CalendarPlusSolid },
                Label = "Reports",
                NavigationType = typeof(YearOverviewPage),
                NavigationDestination = new Uri("Controls/YearOverviewPage.xaml", UriKind.RelativeOrAbsolute)
            });


            //this.OptionsMenu.Add(new HamMenuItem()
            //{
            //    Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FileExportSolid },
            //    Label = "Export",
            //    NavigationType = typeof(SaveFileDialog),
            //    NavigationDestination = new Uri(typeof(SaveFileDialog).Name, UriKind.RelativeOrAbsolute)
            //});
            // create commands
            ImportData = new ActionCommand(OnImportData);
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
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(new CustomerService(new CustomerRepository()).GetAll(), new JsonSerializerOptions() { WriteIndented = true, ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve});
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
            catch (Exception ioExc)
            {
                ShowError("KNOWN ISSUE. WORKED BEFORE. No time to fix." + Environment.NewLine + ioExc.Message);
            }
        }

        public ICommand ImportData { get; set; }

        private void OnImportData()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog() { DefaultExt = "json", FileName = "OrderManagerData", Filter = "JSON file|*.json|XML file|*.xml" };
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    //Stream fileStream = dialog.OpenFile();
                    //StreamWriter sw = new StreamWriter(fileStream);
                    // get json string
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(new CustomerService(new CustomerRepository()).GetAll(), new JsonSerializerOptions() { WriteIndented = true, ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve });
                    switch (dialog.SafeFileName.Split(".").Last())
                    {
                        case "json":
                            // read json from file and deserialize into list of customers
                            var test = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(dialog.FileName));
                            break;

                        case "xml":
                            // convert json string to xml string anf write to file
                            XmlRootAttribute xRoot = new XmlRootAttribute();
                            xRoot.ElementName = "OrderManagerData";
                            var x = new XmlSerializer(typeof(List<Customer>), xRoot).Deserialize(XmlReader.Create(dialog.FileName));
                           
                            break;
                    }
                }
            }
            catch (Exception ioExc)
            {
                ShowError("KNOWN ISSUE. WORKED BEFORE. No time to fix." + Environment.NewLine + ioExc.Message);
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