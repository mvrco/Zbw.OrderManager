using Moq;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class ArticleTests
    {
        #region Article Service/Repository
        [Fact]
        public void ArticleService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();
            var article = new Article { Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 };
            var dto = new ArticleDto { Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 };

            mock.Setup(x => x.Add(It.IsAny<Article>()))
                .Callback(() => inMemoryDatabase.Articles.Add(article));

            var service = new ArticleService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.Articles.Contains(article));
        }

        [Fact]
        public void ArticleService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();

            mock.Setup(x => x.Count(x => x.ArticleGroupId == 11))
                .Returns(() => inMemoryDatabase.Articles.Where(x => x.ArticleGroupId == 11).Count());

            var service = new ArticleService(mock.Object);
            var count = service.Count(x => x.ArticleGroupId == 11);

            Assert.True(count == 2);
        }

        [Fact]
        public void ArticleService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.Articles.Count);

            var service = new ArticleService(mock.Object);
            var count = service.Count();

            Assert.True(count == 6);
        }

        [Fact]
        public void ArticleService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();
            var dto = new ArticleDto { Id = 101, Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 };

            mock.Setup(x => x.Delete(It.IsAny<Article>()))
                .Callback(() => { 
                    foreach (var a in inMemoryDatabase.Articles)
                    {
                        if(a.Id == dto.Id)
                        {
                            a.IsActive = false;
                        }
                    }
                });

            var service = new ArticleService(mock.Object);
            service.Delete(dto);

            var article = inMemoryDatabase.Articles.Where(x => x.Id == 101).FirstOrDefault();
            Assert.True(article.IsActive == false);
        }

        [Fact]
        public void ArticleService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();

            mock.Setup(x => x.GetAll(x => x.ArticleGroupId == 11))
                .Returns(() => inMemoryDatabase.Articles.Where(x => x.ArticleGroupId == 11).ToList());

            var service = new ArticleService(mock.Object);
            var list = service.GetAll(x => x.ArticleGroupId == 11);

            Assert.True(list.Count == 2);
        }

        [Fact]
        public void ArticleService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.Articles.ToList());

            var service = new ArticleService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 6);
        }

        [Fact]
        public void ArticleService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();
            var dto = new ArticleDto { Id = 101, Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Articles.Where(a => a.Id == 101).FirstOrDefault());

            var service = new ArticleService(mock.Object);
            var article = service.GetSingle(101);

            Assert.True(
                article.Id == dto.Id
                && article.Name == dto.Name
                && article.Description == dto.Description
                && article.Price == dto.Price);
        }

        [Fact]
        public void ArticleService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleRepository>();
            var article = new Article { Id = 101, Name = "Pineapple", Description = "Fresh", Price = 1.12, ArticleGroupId = 11 };
            var dto = new ArticleDto { Id = 101, Name = "Pineapple", Description = "Fresh", Price = 1.12, ArticleGroupId = 11 };

            mock.Setup(x => x.Update(It.IsAny<Article>()))
                .Callback(() => {
                    foreach (var a in inMemoryDatabase.Articles)
                    {
                        if (a.Id == article.Id)
                        {
                            a.Name = article.Name;
                            a.Description = article.Description;
                            break;
                        }
                    }
                });

            var service = new ArticleService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Articles.Where(x => x.Id == article.Id).FirstOrDefault();

            Assert.True(
                article.Id == dto.Id
                && article.Name == dto.Name
                && article.Description == dto.Description
                && article.Price == dto.Price);
        }
        #endregion
    }
}
