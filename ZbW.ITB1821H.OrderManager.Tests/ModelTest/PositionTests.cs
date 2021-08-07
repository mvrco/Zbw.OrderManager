using System;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class PositionTests : TestingDb
    {
        #region Repository
        [Fact]
        public void PositionRepositoryAdd_AddNewPosition_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var position = new Position { PosNr = 1, OrderId = 1230, Amount = 23, ArticleId = 100 };
                repo.Add(position);
                var positionsContext = DbContext.Positions.ToList();

                Assert.True(positionsContext.Contains(position) == true);
            }
        }

        [Fact]
        public void PositionRepositoryCountWithFilter_CountPositions_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var positionsContext = DbContext.Positions.Where(x => x.OrderId == 1230).ToList();

                Assert.True(repo.Count(x => x.OrderId == 1230) == positionsContext.Count);
            }
        }

        [Fact]
        public void PositionRepositoryCount_CountPositions_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);

                Assert.True(repo.Count() == DbContext.Positions.Count());
            }
        }

        [Fact]
        public void PositionRepositoryDelete_DeletePosition_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var position = new Position { Id = 1 };
                repo.Delete(position);
                var positionsContext = DbContext.Positions.ToList();

                Assert.True(!positionsContext.Contains(position) && positionsContext.Count == 47);
            }
        }

        [Fact]
        public void PositionRepositoryGetAll_GetAllPositionsWithFilter_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var positionsContext = DbContext.Positions.Where(x => x.OrderId == 1230).ToList();
                var positions = repo.GetAll(x => x.OrderId == 1230);

                Assert.True(positions.Count == positionsContext.Count);
            }
        }

        [Fact]
        public void PositionRepositoryGetAll_GetAllPositions_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var positionsContext = DbContext.Positions.ToList();
                var positions = repo.GetAll();

                Assert.True(positions.Count == positionsContext.Count);
            }
        }

        [Fact]
        public void PositionRepositoryGetSingle_GetSinglePositionObject_ReturnsEqual()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var positionContext = DbContext.Positions.Where(x => x.Id == 5).SingleOrDefault();
                var position = repo.GetSingle(5);

                Assert.Equal(position, positionContext);
            }
        }

        [Fact]
        public void PositionRepositoryUpdate_UpdatePosition_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new PositionRepository(DbContext);
                var positionContext = DbContext.Positions.Where(x => x.Id == 1).SingleOrDefault();
                positionContext.OrderId = 1231;
                repo.Update(positionContext);
                var positionContextAfterUpdate = DbContext.Positions.Where(x => x.Id == 1).SingleOrDefault();

                Assert.True(positionContextAfterUpdate.OrderId == 1231);
            }
        }
        #endregion Repository

        #region Service
        [Fact]
        public void PositionServiceCount_CountAdressesWithFilter_ReturnsTrue()
        {
            var service = new PositionService(OptionsBuilder);
            var positionsContext = DbContext.Positions.Where(x => x.OrderId == 1230).ToList();

            Assert.True(service.Count(x => x.OrderId == 1230) == positionsContext.Count);
        }

        [Fact]
        public void PositionServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new PositionService(OptionsBuilder);

            Assert.True(service.Count() == DbContext.Positions.Count());
        }

        [Fact]
        public void PositionServiceGetAll_GetAllPositionsWithFilter_ReturnsTrue()
        {
            var service = new PositionService(OptionsBuilder);
            var positionsContext = DbContext.Positions.Where(x => x.OrderId == 1230).ToList();
            var positions = service.GetAll(x => x.OrderId == 1230);

            Assert.True(positions.Count == positionsContext.Count);
        }

        [Fact]
        public void PositionServiceGetAll_GetAllPositions_ReturnsTrue()
        {
            var service = new PositionService(OptionsBuilder);
            var positionsContext = DbContext.Positions.ToList();
            var positions = service.GetAll();

            Assert.True(positions.Count == positionsContext.Count);
        }

        [Fact]
        public void PositionServiceGetSingle_GetSinglePosition_ReturnsTrue()
        {
            var service = new PositionService(OptionsBuilder);
            var positionContext = DbContext.Positions.Where(x => x.Id == 5).SingleOrDefault();
            var position = service.GetSingle(5);

            Assert.True(
                position.Id == positionContext.Id
                && position.OrderId == positionContext.OrderId
                && position.Amount == positionContext.Amount
                && position.PosNr == positionContext.PosNr);
        }
        #endregion Service
    }
}
