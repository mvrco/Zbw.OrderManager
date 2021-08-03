using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleService : ServiceBase<Article>
    {
        public ArticleService() : base() { }
        public ArticleService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { }

        public new List<Article> GetAll(Func<Article, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleRepository(context).GetAll(filter);
            }
        }

        public new List<Article> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleRepository(context).GetAll();
            }
        }

        public new Article GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleRepository(context).GetSingle(pkValue);
            }
        }
    }
}
