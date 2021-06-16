namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Article
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ArticleGroup ArticleGroup { get; set; }

        // TODO tostring
    }
}