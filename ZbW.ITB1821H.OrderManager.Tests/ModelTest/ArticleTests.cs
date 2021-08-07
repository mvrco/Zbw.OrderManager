using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class ArticleTests : TestingDb
    {
        #region Repository
        [Fact]
        public void ArticleRepositoryAdd_AddNewArticle_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var article = new Article { Id = 150, Name = "Apple", Description = "Fresh from Switzerland", Price = 0.95, ArticleGroupId = 11 };
                repo.Add(article);
                var articlesContext = DbContext.Articles.ToList();

                Assert.True(articlesContext.Contains(article) == true);
            }
        }

        [Fact]
        public void ArticleRepositoryCountWithFilter_CountArticles_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var articlesContext = DbContext.Articles.Where(x => x.ArticleGroupId == 11).ToList();

                Assert.True(repo.Count(x => x.ArticleGroupId == 11) == articlesContext.Count);
            }
        }

        [Fact]
        public void ArticleRepositoryCount_CountArticles_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);

                Assert.True(repo.Count() == DbContext.Articles.Count());
            }
        }

        [Fact]
        public void ArticleRepositoryDelete_DeleteArticle_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var article = new Article { Id = 100 };
                repo.Delete(article);
                var articlesContext = DbContext.Articles.ToList();

                Assert.True(!articlesContext.Contains(article) && articlesContext.Count == 5);
            }
        }

        [Fact]
        public void ArticleRepositoryGetAll_GetAllArticlesWithFilter_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var articlesContext = DbContext.Articles.Where(x => x.ArticleGroupId == 11).ToList();
                var articles = repo.GetAll(x => x.ArticleGroupId == 11);

                Assert.True(articles.Count == articlesContext.Count);
            }
        }

        [Fact]
        public void ArticleRepositoryGetAll_GetAllArticles_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var articlesContext = DbContext.Articles.ToList();
                var articles = repo.GetAll();

                Assert.True(articles.Count == articlesContext.Count);
            }
        }

        [Fact]
        public void ArticleRepositoryGetSingle_GetSingleArticleObject_ReturnsEqual()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var articleContext = DbContext.Articles.Where(x => x.Id == 100).SingleOrDefault();
                var article = repo.GetSingle(100);

                Assert.Equal(article, articleContext);
            }
        }

        [Fact]
        public void ArticleRepositoryUpdate_UpdateArticle_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleRepository(DbContext);
                var articleContext = DbContext.Articles.Where(x => x.Id == 100).SingleOrDefault();
                articleContext.ArticleGroupId = 12;
                repo.Update(articleContext);
                var articleContextAfterUpdate = DbContext.Articles.Where(x => x.Id == 100).SingleOrDefault();

                Assert.True(articleContextAfterUpdate.ArticleGroupId == 12);
            }
        }
        #endregion Repository

        #region Service
        [Fact]
        public void ArticleServiceCount_CountAdressesWithFilter_ReturnsTrue()
        {
            var service = new ArticleService(OptionsBuilder);
            var articlesContext = DbContext.Articles.Where(x => x.ArticleGroupId == 11).ToList();

            Assert.True(service.Count(x => x.ArticleGroupId == 11) == articlesContext.Count);
        }

        [Fact]
        public void ArticleServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new ArticleService(OptionsBuilder);

            Assert.True(service.Count() == DbContext.Articles.Count());
        }

        [Fact]
        public void ArticleServiceGetAll_GetAllArticlesWithFilter_ReturnsTrue()
        {
            var service = new ArticleService(OptionsBuilder);
            var articlesContext = DbContext.Articles.Where(x => x.ArticleGroupId == 11).ToList();
            var articles = service.GetAll(x => x.ArticleGroupId == 11);

            Assert.True(articles.Count == articlesContext.Count);
        }

        [Fact]
        public void ArticleServiceGetAll_GetAllArticles_ReturnsTrue()
        {
            var service = new ArticleService(OptionsBuilder);
            var articlesContext = DbContext.Articles.ToList();
            var articles = service.GetAll();

            Assert.True(articles.Count == articlesContext.Count);
        }

        [Fact]
        public void ArticleServiceGetSingle_GetSingleArticle_ReturnsTrue()
        {
            var service = new ArticleService(OptionsBuilder);
            var articleContext = DbContext.Articles.Where(x => x.Id == 100).SingleOrDefault();
            var article = service.GetSingle(100);

            Assert.True(
                article.Id == articleContext.Id
                && article.Name == articleContext.Name
                && article.ArticleGroupId == articleContext.ArticleGroupId
                && article.Price == articleContext.Price
                && article.Description == articleContext.Description);
        }
        #endregion Service
    }
}
