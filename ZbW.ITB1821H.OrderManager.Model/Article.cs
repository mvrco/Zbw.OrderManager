namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Article
    {
        public virtual int Id { get; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }

        public virtual ArticleGroup ArticleGroup { get; set; }

        // TODO tostring
    }
}