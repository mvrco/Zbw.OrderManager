namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class PositionDto
    {
        public int Id { get; set; }
        public int PosNr { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public int ArticleId { get; set; }
        public virtual OrderDto Order { get; set; }
        public virtual ArticleDto Article { get; set; }
    }
}
