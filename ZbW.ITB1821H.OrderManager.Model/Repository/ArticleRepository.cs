using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class ArticleRepository : RepositoryBase<Article>
    {
        public ArticleRepository(DatabaseContext context) : base(context) { }

        public new List<Article> GetAll(Func<Article, bool> filter)
        {
            return _context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .Where(filter)
                .ToList();
        }

        public new List<Article> GetAll()
        {
            return _context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .ToList();
        }

        public new Article GetSingle(int pkValue)
        {
            return _context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .FirstOrDefault(x => x.Id == pkValue);
        }
    }
}
