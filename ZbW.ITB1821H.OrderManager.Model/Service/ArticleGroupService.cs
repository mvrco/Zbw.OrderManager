using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleGroupService : ServiceBase<ArticleGroup>
    {
        public ArticleGroupService() : base() { _repository = new ArticleGroupRepository(new DatabaseContext(_contextOptions.Options)); }
        public ArticleGroupService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new ArticleGroupRepository(new DatabaseContext(_contextOptions.Options)); }

        public new List<ArticleGroup> GetAll(Func<ArticleGroup, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<ArticleGroup> GetAll()
        {
            return _repository.GetAll();
        }

        public new ArticleGroup GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}
