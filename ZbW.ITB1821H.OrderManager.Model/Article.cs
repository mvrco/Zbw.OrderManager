using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ArticleGroupId { get; set; }

        public virtual ArticleGroup ArticleGroup { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

        // TODO tostring
    }
}