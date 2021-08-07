using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class ArticleGroupTests : TestingDb
    {
        #region Repository
        [Fact]
        public void ArticleGroupRepositoryAdd_AddNewArticleGroup_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleGroupRepository(DbContext);
                var articleGroup = new ArticleGroup { Name = "Food Test", Description = "test all food" };
                repo.Add(articleGroup);
                var articleGroupsContext = DbContext.ArticleGroups.ToList();

                Assert.True(articleGroupsContext.Contains(articleGroup) == true);
            }
        }

        [Fact]
        public void ArticleGroupRepositoryCountWithFilter_CountArticleGroups_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleGroupRepository(DbContext);
                var articleGroupsContext = DbContext.ArticleGroups.Where(x => x.ParentGroupId == 10).ToList();

                Assert.True(repo.Count(x => x.ParentGroupId == 10) == articleGroupsContext.Count);
            }
        }

        [Fact]
        public void ArticleGroupRepositoryCount_CountArticleGroups_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleGroupRepository(DbContext);

                Assert.True(repo.Count() == DbContext.ArticleGroups.Count());
            }
        }

        [Fact]
        public void ArticleGroupRepositoryDelete_DeleteArticleGroup_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleGroupRepository(DbContext);
                var articleGroup = new ArticleGroup { Id = 13 };
                repo.Delete(articleGroup);
                var articleGroupsContext = DbContext.ArticleGroups.ToList();

                Assert.True(!articleGroupsContext.Contains(articleGroup) && articleGroupsContext.Count == 3);
            }
        }

        // Tests failing because of incompatibility between SQL and SQLite, Exec command
        //[Fact]
        //public void ArticleGroupRepositoryGetAll_GetAllArticleGroupsWithFilter_ReturnsTrue()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new ArticleGroupRepository(DbContext);
        //        var articleGroupsContext = DbContext.ArticleGroups.Where(x => x.ParentGroupId == 10).ToList();
        //        var articleGroups = repo.GetAll(x => x.ParentGroupId == 10);

        //        Assert.True(articleGroups.Count == articleGroupsContext.Count);
        //    }
        //}

        //[Fact]
        //public void ArticleGroupRepositoryGetAll_GetAllArticleGroups_ReturnsTrue()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new ArticleGroupRepository(DbContext);
        //        var articleGroupsContext = DbContext.ArticleGroups.ToList();
        //        var articleGroups = repo.GetAll();

        //        Assert.True(articleGroups.Count == articleGroupsContext.Count);
        //    }
        //}

        //[Fact]
        //public void ArticleGroupRepositoryGetSingle_GetSingleArticleGroupObject_ReturnsEqual()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new ArticleGroupRepository(DbContext);
        //        var articleGroupContext = DbContext.ArticleGroups.Where(x => x.Id == 10).SingleOrDefault();
        //        var articleGroup = repo.GetSingle(10);

        //        Assert.Equal(articleGroup, articleGroupContext);
        //    }
        //}

        [Fact]
        public void ArticleGroupRepositoryUpdate_UpdateArticleGroup_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new ArticleGroupRepository(DbContext);
                var articleGroupContext = DbContext.ArticleGroups.Where(x => x.Id == 11).SingleOrDefault();
                articleGroupContext.ParentGroupId = 12;
                repo.Update(articleGroupContext);
                var articleGroupContextAfterUpdate = DbContext.ArticleGroups.Where(x => x.Id == 11).SingleOrDefault();

                Assert.True(articleGroupContextAfterUpdate.ParentGroupId == 12);
            }
        }
        #endregion Repository

        #region Service
        [Fact]
        public void ArticleGroupServiceCount_CountAdressesWithFilter_ReturnsTrue()
        {
            var service = new ArticleGroupService(OptionsBuilder);
            var articleGroupsContext = DbContext.ArticleGroups.Where(x => x.ParentGroupId == 10).ToList();

            Assert.True(service.Count(x => x.ParentGroupId == 10) == articleGroupsContext.Count);
        }

        [Fact]
        public void ArticleGroupServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new ArticleGroupService(OptionsBuilder);

            Assert.True(service.Count() == DbContext.ArticleGroups.Count());
        }

        // Tests failing because of incompatibility between SQL and SQLite, Exec command
        //[Fact]
        //public void ArticleGroupServiceGetAll_GetAllArticleGroupsWithFilter_ReturnsTrue()
        //{
        //    var service = new ArticleGroupService(OptionsBuilder);
        //    var articleGroupsContext = DbContext.ArticleGroups.Where(x => x.ParentGroupId == 10).ToList();
        //    var articleGroups = service.GetAll(x => x.ParentGroupId == 10);

        //    Assert.True(articleGroups.Count == articleGroupsContext.Count);
        //}

        //[Fact]
        //public void ArticleGroupServiceGetAll_GetAllArticleGroups_ReturnsTrue()
        //{
        //    var service = new ArticleGroupService(OptionsBuilder);
        //    var articleGroupsContext = DbContext.ArticleGroups.ToList();
        //    var articleGroups = service.GetAll();

        //    Assert.True(articleGroups.Count == articleGroupsContext.Count);
        //}

        //[Fact]
        //public void ArticleGroupServiceGetSingle_GetSingleArticleGroup_ReturnsTrue()
        //{
        //    var service = new ArticleGroupService(OptionsBuilder);
        //    var articleGroupContext = DbContext.ArticleGroups.Where(x => x.Id == 1000).SingleOrDefault();
        //    var articleGroup = service.GetSingle(1000);

        //    Assert.True(
        //        articleGroup.Id == articleGroupContext.Id
        //        && articleGroup.Name == articleGroupContext.Name
        //        && articleGroup.ParentGroup == articleGroupContext.ParentGroup
        //        && articleGroup.Description == articleGroupContext.Description);
        //}
        #endregion Service
    }
}
