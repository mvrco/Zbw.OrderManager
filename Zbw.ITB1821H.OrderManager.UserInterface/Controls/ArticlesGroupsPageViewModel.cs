using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class ArticlesGroupsPageViewModel : BaseViewModel
    {
        private ArticleGroup selectedArticleGroup;

        public ArticlesGroupsPageViewModel()
        {
            ArticleGroups = new ObservableCollection<ArticleGroup>
            {
                new ArticleGroup{Description = "TestDescription", Name = "Figures",
                Articles = new ObservableCollection<Article>(){ new Article() { Name="Spongebob", Price = 45},
                } },
                new ArticleGroup{Description = "TestDescription", Name = "Vases"},
                new ArticleGroup{Description = "TestDescription", Name = "Drings"},
                new ArticleGroup{Description = "TestDescription", Name = "Animal food"}
            };
        }

        public IList<ArticleGroup> ArticleGroups { get; set; }

        public ArticleGroup SelectedArticleGroup
        {
            get
            {
                return selectedArticleGroup;
            }
            set
            {
                selectedArticleGroup = value;
                OnPropertyChanged(nameof(SelectedArticleGroup));
            }
        }

        public Article SelectedArticle { get; set; }
    }
}