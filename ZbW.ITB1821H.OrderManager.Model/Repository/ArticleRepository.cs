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
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository() : base() { }

        public new List<Article> GetAll(Expression<Func<Article, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .Where(filter)
                .ToList();
            }
        }

        public new List<Article> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .ToList();
            }
        }

        public new Article GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Article>()
                .Include(x => x.ArticleGroup)
                .Include(x => x.Positions)
                .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}
