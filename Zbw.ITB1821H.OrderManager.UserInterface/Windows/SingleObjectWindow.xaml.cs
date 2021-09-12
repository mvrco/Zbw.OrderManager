namespace ZbW.ITB1821H.OrderManager.UserInterface.Windows
{
    /// <summary>
    /// Interaction logic for SingleObjectWindow.xaml
    /// </summary>
    public partial class SingleObjectWindow
    {
        public SingleObjectWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}