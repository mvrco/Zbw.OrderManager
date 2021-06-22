using log4net;
using ZbW.ITB1821H.OrderManager.Controls;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Windows
{
    public class SingleObjectWindowViewModel<T> : BaseViewModel
    {
        public SingleObjectWindowViewModel(T currentBusinessObject) : base(LogManager.GetLogger(nameof(SingleObjectWindowViewModel<T>)))
        {
            BusinessObject = currentBusinessObject;
        }

        public T BusinessObject { get; set; }
    }
}