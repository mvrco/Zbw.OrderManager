using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleGroupService : ServiceBase<ArticleGroup>
    {
        public ArticleGroupService() : base() { }
        public ArticleGroupService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { }

        public new List<ArticleGroup> GetAll(Func<ArticleGroup, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleGroupRepository(context).GetAll(filter);
            }
        }

        public new List<ArticleGroup> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleGroupRepository(context).GetAll();
            }
        }

        public new ArticleGroup GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new ArticleGroupRepository(context).GetSingle(pkValue);
            }
        }
    }
}
