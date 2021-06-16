using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Windows
{
    public class SingleObjectWindowViewModel<T> : BaseViewModel
    {
        public SingleObjectWindowViewModel(T currentBusinessObject)
        {
            BusinessObject = currentBusinessObject;
        }

        public T BusinessObject { get; set; }
    }
}