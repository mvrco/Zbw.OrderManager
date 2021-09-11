using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class ArticlesGroupsPageViewModel : BaseViewModel
    {
        private ArticleGroupDto selectedArticleGroup;
        private IArticleGroupService _articleGroupService;

        public ArticlesGroupsPageViewModel() : base(LogManager.GetLogger(nameof(ArticlesGroupsPageViewModel)))
        {
            _articleGroupService = new ArticleGroupService(new ArticleGroupRepository());
            ArticleGroups = _articleGroupService.GetAll();
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
                if (value != null)
                    // same as customer
                    // selectedArticleGroup.Articles = App.DbContext.Articles.Where(x => x.ArticleGroupId == selectedArticleGroup.Id).ToList();
                OnPropertyChanged();
            }
        }

        public ArticleDto SelectedArticle { get; set; }
    }
}