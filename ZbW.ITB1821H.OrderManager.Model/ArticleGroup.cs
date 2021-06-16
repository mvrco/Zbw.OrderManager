using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class ArticleGroup
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ArticleGroup ParentGroup { get; }
        public IList<Article> Articles { get; set; }

        // TODO tostring
    }
}