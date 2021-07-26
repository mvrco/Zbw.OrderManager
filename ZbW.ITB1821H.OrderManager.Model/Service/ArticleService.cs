using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleService : ServiceBase<Article>
    {
        public ArticleService() : base() { _repository = new ArticleRepository(new DatabaseContext(_contextOptions.Options)); }
        public ArticleService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new ArticleRepository(new DatabaseContext(_contextOptions.Options)); }

        public new List<Article> GetAll(Func<Article, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<Article> GetAll()
        {
            return _repository.GetAll();
        }

        public new Article GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}
