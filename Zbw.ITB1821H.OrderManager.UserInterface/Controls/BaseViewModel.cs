using log4net;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

namespace ZbW.ITB1821H.OrderManager.Controls
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ILog log;

        public BaseViewModel(ILog currentLog)
        {
            log = currentLog;
        }

        protected TaskScheduler uiThread => TaskScheduler.FromCurrentSynchronizationContext();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            log.Debug(nameof(OnPropertyChanged) + "; " + propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void ShowError(string message)
        {
            log.Info(nameof(ShowError) + "; " + message);
            MessageBox.Show(App.Current.MainWindow, message, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        protected void ShowInfo(string message, string caption)
        {
            log.Info(nameof(ShowInfo) + "; " + message);
            MessageBox.Show(App.Current.MainWindow, message, caption, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        protected void ShowWarning(string message)
        {
            log.Info(nameof(ShowWarning) + "; " + message);
            MessageBox.Show(App.Current.MainWindow, message, "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }
    }
}