using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System.Diagnostics;

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
    }
}