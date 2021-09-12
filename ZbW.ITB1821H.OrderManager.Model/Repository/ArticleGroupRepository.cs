using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class ArticleGroupRepository : RepositoryBase<ArticleGroup>, IArticleGroupRepository
    {
        public ArticleGroupRepository() : base() { }

        public new List<ArticleGroup> GetAll(Expression<Func<ArticleGroup, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.GetAllArticleGroups()
                .Where(filter)
                .ToList();
            }
        }

        public new List<ArticleGroup> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.GetAllArticleGroups()
                .ToList();
            }
        }

        public new ArticleGroup GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.GetArticleGroupsWithParents(pkValue)
                .FirstOrDefault(x => x.Id == pkValue);
            }
        }

        public void Delete(ArticleGroup entity)
        {
            if (entity.SubArticleGroups == null && entity.Articles == null)
            {
                using (var context = new DatabaseContext())
                {
                    context.Set<ArticleGroup>().Remove(entity);
                    context.SaveChanges();
                }
            }
            else
            {
                throw new InvalidOperationException("The articelgroup depends to other entities and therefore cannot be deleted.");
            }
        }
    }
}
