using Moq;
using System;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class PositionTests
    {
        #region Position Service/Repository
        [Fact]
        public void PositionService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();
            var position = new Position { Id = 100, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 };
            var dto = new PositionDto { Id = 100, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 };

            mock.Setup(x => x.Add(It.IsAny<Position>()))
                .Callback(() => inMemoryDatabase.Positions.Add(position));

            var service = new PositionService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.Positions.Contains(position));
        }

        [Fact]
        public void PositionService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();

            mock.Setup(x => x.Count(x => x.OrderId == 1230))
                .Returns(() => inMemoryDatabase.Positions.Where(x => x.OrderId == 1230).Count());

            var service = new PositionService(mock.Object);
            var count = service.Count(x => x.OrderId == 1230);

            Assert.True(count == 4);
        }

        [Fact]
        public void PositionService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.Positions.Count);

            var service = new PositionService(mock.Object);
            var count = service.Count();

            Assert.True(count == 48);
        }

        [Fact]
        public void PositionService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();
            var position = new Position { Id = 9, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 };
            var dto = new PositionDto { Id = 9, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 };

            mock.Setup(x => x.Delete(It.IsAny<Position>()))
                .Callback(() => inMemoryDatabase.Positions.Remove(position));

            var service = new PositionService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.Positions.Contains(position));
        }

        [Fact]
        public void PositionService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();

            mock.Setup(x => x.GetAll(x => x.OrderId == 1230))
                .Returns(() => inMemoryDatabase.Positions.Where(x => x.OrderId == 1230).ToList());

            var service = new PositionService(mock.Object);
            var list = service.GetAll(x => x.OrderId == 1230);

            Assert.True(list.Count == 4);
        }

        [Fact]
        public void PositionService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.Positions.ToList());

            var service = new PositionService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 48);
        }

        [Fact]
        public void PositionService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();
            var dto = new PositionDto { Id = 9, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Positions.Where(x => x.Id == 9).FirstOrDefault());

            var service = new PositionService(mock.Object);
            var position = service.GetSingle(9);

            Assert.True(
                position.Id == dto.Id
                && position.PosNr == dto.PosNr
                && position.OrderId == dto.OrderId);
        }

        [Fact]
        public void PositionService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IPositionRepository>();
            var position = new Position { Id = 9, PosNr = 10, OrderId = 1233, Amount = 20, ArticleId = 100 };
            var dto = new PositionDto { Id = 9, PosNr = 10, OrderId = 1233, Amount = 20, ArticleId = 100 };

            mock.Setup(x => x.Update(It.IsAny<Position>()))
                .Callback(() => {
                    foreach (var a in inMemoryDatabase.Positions)
                    {
                        if (a.Id == position.Id)
                        {
                            a.PosNr = position.PosNr;
                            a.OrderId = position.OrderId;
                            break;
                        }
                    }
                });

            var service = new PositionService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Positions.Where(x => x.Id == position.Id).FirstOrDefault();

            Assert.True(
                position.Id == afterUpdate.Id
                && position.PosNr == afterUpdate.PosNr
                && position.OrderId == dto.OrderId);
        }
        #endregion
    }
}
