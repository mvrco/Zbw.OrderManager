using System.Windows;
using System.Windows.Controls;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    /// <summary>
    /// Interaction logic for ArticlesGroupsPage.xaml
    /// </summary>
    public partial class ArticlesGroupsPage : Page
    {
        public ArticlesGroupsPage()
        {
            InitializeComponent();
        }

        private void ArticlesDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<Article> viewModel = new(articlesDatagrid.SelectedItem as Article);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }

        private void ArticleGroupsDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<ArticleGroup> viewModel = new(articleGroupDatagrid.SelectedItem as ArticleGroup);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }
    }
}