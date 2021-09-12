using ControlzEx.Theming;
using log4net;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;
using ZbW.ITB1821H.OrderManager.UserInterface.Windows;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class ArticlesGroupsPageViewModel : BaseViewModel
    {
        private ArticleGroupDto selectedArticleGroup;
        private IArticleGroupService _articleGroupService;
        private IArticleService _articleService;

        public ArticlesGroupsPageViewModel() : base(LogManager.GetLogger(nameof(ArticlesGroupsPageViewModel)))
        {
            _articleGroupService = new ArticleGroupService(new ArticleGroupRepository());
            _articleService = new ArticleService(new ArticleRepository());
            ArticleGroups = new ObservableCollection<ArticleGroupDto>(_articleGroupService.GetAll());
        }

        public IList<ArticleGroupDto> ArticleGroups { get; private set; }

        public ArticleGroupDto SelectedArticleGroup
        {
            get
            {
                return selectedArticleGroup;
            }
            set
            {
                selectedArticleGroup = value;
                OnPropertyChanged();
            }
        }

        public ArticleDto SelectedArticle { get; set; }

        private ActionCommand deleteArticleGroup;
        public ICommand DeleteArticleGroup => deleteArticleGroup ??= new ActionCommand(PerformDeleteArticleGroup);

        private void PerformDeleteArticleGroup()
        {
            try
            {
                _articleGroupService.Delete(selectedArticleGroup);
                ArticleGroups.Remove(selectedArticleGroup);
                SelectedArticleGroup = null;
            }
            catch (Exception e)
            {
                ShowError(e.Message);
            }
        }

        private ActionCommand deleteArticleCommand;
        public ICommand DeleteArticleCommand => deleteArticleCommand ??= new ActionCommand(DeleteArticle);

        private void DeleteArticle()
        {
            try
            {
                _articleService.Delete(SelectedArticle);
                SelectedArticle = null;
            }
            catch(Exception e)
            {
                ShowError(e.Message);
            }
        }

        private ActionCommand addArticleGroup;
        public ICommand AddArticleGroup => addArticleGroup ??= new ActionCommand(PerformAddArticleGroup);

        private void PerformAddArticleGroup()
        {
            try
            {
                SingleObjectWindow window = new();
                SingleObjectWindowViewModel<ArticleGroupDto, ArticleGroup, IArticleGroupService> viewModel = new(new ArticleGroupDto() { }, _articleGroupService, true);
                window.DataContext = viewModel;
                window.Owner = Application.Current.MainWindow;
                // property grid is not theme aware, dark skin messes it up
                ThemeManager.Current.ChangeTheme(window, "Light.Blue");
                window.ShowDialog();
            }
            catch (Exception e)
            {
                ShowWarning(e.Message);
            }
        }
    }
}