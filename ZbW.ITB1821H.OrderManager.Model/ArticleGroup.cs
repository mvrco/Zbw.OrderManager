using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class ArticleGroup
    {
        public virtual int Id { get; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ArticleGroup ParentGroup { get; }
        public virtual IList<Article> Articles { get; }

        // TODO tostring
    }
}