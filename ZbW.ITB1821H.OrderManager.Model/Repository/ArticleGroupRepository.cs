using System;
using System.Collections.Generic;
using System.Linq;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class ArticleGroupRepository : RepositoryBase<ArticleGroup>
    {
        public ArticleGroupRepository(DatabaseContext context) : base(context) { }

        public new List<ArticleGroup> GetAll(Func<ArticleGroup, bool> filter)
        {
            return _context.GetAllArticleGroups()
                .Where(filter)
                .ToList();
        }

        public new List<ArticleGroup> GetAll()
        {
            return _context.GetAllArticleGroups()
                .ToList();

        }

        public new ArticleGroup GetSingle(int pkValue)
        {
            return _context.GetArticleGroupsWithParents(pkValue)
                .FirstOrDefault(x => x.Id == pkValue);
        }
    }
}
