namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Position
    {
        public int Id { get; }
        public Order Order { get; }
        public Article Article { get; set; }

        // TODO tostring
    }
}