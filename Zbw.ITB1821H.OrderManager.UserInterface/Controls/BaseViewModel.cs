using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.ITB1821H.OrderManager.Controls
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TaskScheduler uiThread => TaskScheduler.FromCurrentSynchronizationContext();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}