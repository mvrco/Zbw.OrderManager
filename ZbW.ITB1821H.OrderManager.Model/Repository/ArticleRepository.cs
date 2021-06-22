using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class ArticleRepository : RepositoryBase<Article>
    {
        public new List<Article> GetAll(Func<Article, bool> filter)
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
