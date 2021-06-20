using System;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Util
{
    public class ApplicationEventHandler
    {
        public static event EventHandler<string> SearchTextChanged;

        internal static void OnSearchTextChanged(object sender, string searchText)
        {
            SearchTextChanged.Invoke(sender, searchText);
        }
    }
}