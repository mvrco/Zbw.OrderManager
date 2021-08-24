using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    /// <summary>
    /// Interaction logic for ArticlesGroupsPage.xaml
    /// </summary>
    public partial class ArticlesGroupsPage : Page
    {
        private string searchText;

        public ArticlesGroupsPage()
        {
            InitializeComponent();
            ApplicationEventHandler.SearchTextChanged += ApplicationEventHandler_SearchTextChanged;
        }

        private void ApplicationEventHandler_SearchTextChanged(object sender, string e)
        {
            searchText = e;
            articlesDatagrid.UnselectAll();
            articleGroupDatagrid.UnselectAll();
            CollectionView articleGroups = (CollectionView)CollectionViewSource.GetDefaultView(articleGroupDatagrid.ItemsSource);
            if (articleGroups != null)
                articleGroups.Filter = UserFilter;
            articleGroups.Refresh();
        }

        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(searchText))
                return true;
            return (item.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void ArticlesDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<ArticleDto> viewModel = new(articlesDatagrid.SelectedItem as ArticleDto);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }

        private void ArticleGroupsDataGrid_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SingleObjectWindow window = new();
            SingleObjectWindowViewModel<ArticleGroupDto> viewModel = new(articleGroupDatagrid.SelectedItem as ArticleGroupDto);
            window.DataContext = viewModel;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
            e.Handled = true;
        }
    }
}