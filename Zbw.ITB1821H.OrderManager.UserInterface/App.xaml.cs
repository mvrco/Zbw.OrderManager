using log4net;
using System.Windows;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager
{
    /// <summary>
    /// Main application entry point
    /// </summary>
    public partial class App : Application
    {
        private readonly ILog log;
        public static DatabaseContext DbContext { get; } = new();
        private MainWindowViewModel mainWindowViewModel;

        public App()
        {
            new SplashScreen("splashscreen.jpg").Show(true);
            log = LogManager.GetLogger("MainApp");
            DbContext.Database.EnsureCreated();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            log.Info(nameof(OnStartup) + "; Starting main window");
            mainWindowViewModel = new();
            MainWindow mainWindow = new()
            {
                DataContext = mainWindowViewModel
            };
            base.OnStartup(e);
            mainWindow.Show();
        }
    }
}