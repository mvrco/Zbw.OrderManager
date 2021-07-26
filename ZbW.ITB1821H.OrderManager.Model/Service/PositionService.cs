using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class PositionService : ServiceBase<Position>
    {
        public PositionService() : base() { _repository = new PositionRepository(new DatabaseContext(_contextOptions.Options)); }
        public PositionService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new PositionRepository(new DatabaseContext(_contextOptions.Options)); }

        public new List<Position> GetAll(Func<Position, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<Position> GetAll()
        {
            return _repository.GetAll();
        }

        public new Position GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}
