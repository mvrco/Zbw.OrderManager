using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class PositionRepository : RepositoryBase<Position>
    {
        public PositionRepository(DatabaseContext context) : base(context) { }

        public new List<Position> GetAll(Func<Position, bool> filter)
        {
            return _context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .Where(filter)
                .ToList();
        }

        public new List<Position> GetAll()
        {
            return _context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .ToList();
        }

        public new Position GetSingle(int pkValue)
        {
            return _context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .FirstOrDefault(x => x.Id == pkValue);
        }
    }
}
