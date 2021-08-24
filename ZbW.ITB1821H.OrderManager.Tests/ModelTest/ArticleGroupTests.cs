using Moq;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class ArticleGroupTests
    {
        #region ArticleGroup Service/Repository
        [Fact]
        public void ArticleGroupService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();
            var articleGroup = new ArticleGroup { Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };
            var dto = new ArticleGroupDto { Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };

            mock.Setup(x => x.Add(It.IsAny<ArticleGroup>()))
                .Callback(() => inMemoryDatabase.ArticleGroups.Add(articleGroup));

            var service = new ArticleGroupService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.ArticleGroups.Contains(articleGroup));
        }

        [Fact]
        public void ArticleGroupService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();

            mock.Setup(x => x.Count(x => x.ParentGroupId == 10))
                .Returns(() => inMemoryDatabase.ArticleGroups.Where(x => x.ParentGroupId == 10).Count());

            var service = new ArticleGroupService(mock.Object);
            var count = service.Count(x => x.ParentGroupId == 10);

            Assert.True(count == 3);
        }

        [Fact]
        public void ArticleGroupService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.ArticleGroups.Count);

            var service = new ArticleGroupService(mock.Object);
            var count = service.Count();

            Assert.True(count == 4);
        }

        [Fact]
        public void ArticleGroupService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();
            var articleGroup = new ArticleGroup { Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };
            var dto = new ArticleGroupDto { Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };

            mock.Setup(x => x.Delete(It.IsAny<ArticleGroup>()))
                .Callback(() => inMemoryDatabase.ArticleGroups.Remove(articleGroup));

            var service = new ArticleGroupService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.ArticleGroups.Contains(articleGroup));
        }

        [Fact]
        public void ArticleGroupService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();

            mock.Setup(x => x.GetAll(x => x.ParentGroupId == 10))
                .Returns(() => inMemoryDatabase.ArticleGroups.Where(x => x.ParentGroupId == 10).ToList());

            var service = new ArticleGroupService(mock.Object);
            var list = service.GetAll(x => x.ParentGroupId == 10);

            Assert.True(list.Count == 3);
        }

        [Fact]
        public void ArticleGroupService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.ArticleGroups.ToList());

            var service = new ArticleGroupService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 4);
        }

        [Fact]
        public void ArticleGroupService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();
            var dto = new ArticleGroupDto { Id = 11, Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };

            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.ArticleGroups.Where(a => a.Id == 11).FirstOrDefault());

            var service = new ArticleGroupService(mock.Object);
            var articleGroup = service.GetSingle(11);

            Assert.True(
                articleGroup.Id == dto.Id
                && articleGroup.Name == dto.Name
                && articleGroup.Description == dto.Description
                && articleGroup.ParentGroupId == dto.ParentGroupId);
        }

        [Fact]
        public void ArticleGroupService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IArticleGroupRepository>();
            var articleGroup = new ArticleGroup { Id = 11, Name = "Bread", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };
            var dto = new ArticleGroupDto { Id = 11, Name = "Bread", Description = "Worldwide selection of Fruits", ParentGroupId = 10 };

            mock.Setup(x => x.Update(It.IsAny<ArticleGroup>()))
                .Callback(() => {
                    foreach (var a in inMemoryDatabase.ArticleGroups)
                    {
                        if (a.Id == articleGroup.Id)
                        {
                            a.Name = articleGroup.Name;
                            break;
                        }
                    }
                });

            var service = new ArticleGroupService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.ArticleGroups.Where(x => x.Id == articleGroup.Id).FirstOrDefault();

            Assert.True(
                articleGroup.Id == afterUpdate.Id
                && articleGroup.Name == afterUpdate.Name
                && articleGroup.Description == afterUpdate.Description);
        }
        #endregion
    }
}
