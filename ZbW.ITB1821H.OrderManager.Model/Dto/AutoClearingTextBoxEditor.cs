using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Util
{
    //Custom editors that are used as attributes MUST implement the ITypeEditor interface.
    public class AutoClearingTextBoxEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        static bool firstTimeFocus = false;
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
        {
            TextBox textBox = new TextBox();
            //textBox.Background = new SolidColorBrush(Colors.Red);

            //create the binding from the bound property item to the editor
            var _binding = new Binding("Value"); //bind to the Value property of the PropertyItem
            _binding.Source = propertyItem;
            _binding.ValidatesOnExceptions = true;
            _binding.ValidatesOnDataErrors = true;
            _binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            _binding.Mode = BindingMode.TwoWay;
            textBox.GotFocus += TextBox_GotKeyboardFocus;
            BindingOperations.SetBinding(textBox, TextBox.TextProperty, _binding);
            return textBox;
        }

        private void TextBox_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if (!firstTimeFocus)
                (sender as TextBox).Clear();
            firstTimeFocus = true;
        }
    }
}
