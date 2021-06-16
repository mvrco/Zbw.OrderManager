using System.Windows;

namespace ZbW.ITB1821H.OrderManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new SplashScreen("splashscreen.jpg").Show(true);
            MainWindowViewModel mainWindowViewModel = new();
            MainWindow mainWindow = new()
            {
                DataContext = mainWindowViewModel
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}