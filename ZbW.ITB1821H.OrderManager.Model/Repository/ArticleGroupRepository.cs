using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class ArticleGroupRepository : RepositoryBase<ArticleGroup>
    {
        public new List<ArticleGroup> GetAll(Func<ArticleGroup, bool> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ArticleGroup>()
                    .Include(x => x.Articles)
                    .Include(x => x.SubArticleGroups)
                    .Include(x => x.ParentGroup)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<ArticleGroup> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ArticleGroup>()
                    .Include(x => x.Articles)
                    .Include(x => x.SubArticleGroups)
                    .Include(x => x.ParentGroup)
                    .ToList();
            }
        }

        public new ArticleGroup GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<ArticleGroup>()
                    .Include(x => x.Articles)
                    .Include(x => x.SubArticleGroups)
                    .Include(x => x.ParentGroup)
                    .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}
