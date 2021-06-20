namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Position
    {
        public int Id { get; set; }
        public int PosNr { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public int ArticleId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Article Article { get; set; }

        // TODO tostring
    }
}