using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class ArticlesGroupsPageViewModel : BaseViewModel
    {
        private ArticleGroup selectedArticleGroup;

        public ArticlesGroupsPageViewModel() : base(LogManager.GetLogger(nameof(ArticlesGroupsPageViewModel)))
        {
            ArticleGroups = App.DbContext.ArticleGroups.ToList();
        }

        public IList<ArticleGroup> ArticleGroups { get; private set; }

        public ArticleGroup SelectedArticleGroup
        {
            get
            {
                return selectedArticleGroup;
            }
            set
            {
                selectedArticleGroup = value;
                if (value != null)
                    selectedArticleGroup.Articles = App.DbContext.Articles.Where(x => x.ArticleGroupId == selectedArticleGroup.Id).ToList();
                OnPropertyChanged();
            }
        }

        public Article SelectedArticle { get; set; }
    }
}