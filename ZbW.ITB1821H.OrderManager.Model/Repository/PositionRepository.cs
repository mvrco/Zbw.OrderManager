using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository() : base() { }
        
        public new List<Position> GetAll(Expression<Func<Position, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .Where(filter)
                .ToList();
            }
        }

        public new List<Position> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .ToList();
            }
        }

        public new Position GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Position>()
                .Include(x => x.Order)
                .Include(x => x.Article)
                .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}

