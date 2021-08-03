using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class PositionService : ServiceBase<Position>
    {
        public PositionService() : base() { }
        public PositionService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { }

        public new List<Position> GetAll(Func<Position, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new PositionRepository(context).GetAll(filter);
            }
        }

        public new List<Position> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new PositionRepository(context).GetAll();
            }
        }

        public new Position GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new PositionRepository(context).GetSingle(pkValue);
            }
        }
    }
}
