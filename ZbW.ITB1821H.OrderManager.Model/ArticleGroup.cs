using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class ArticleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentGroupId { get; set; }

        public virtual ArticleGroup ParentGroup { get; set; }
        public virtual ICollection<ArticleGroup> SubArticleGroups { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        // TODO tostring
    }
}