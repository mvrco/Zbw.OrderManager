using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleGroupService : ServiceBase<ArticleGroup, ArticleGroupDto>, IArticleGroupService
    {
        public ArticleGroupService(IArticleGroupRepository repo) : base(repo) { }
    }
}
