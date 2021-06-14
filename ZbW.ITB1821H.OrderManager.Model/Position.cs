namespace ZbW.ITB1821H.OrderManager.Model
{
    public class Position
    {
        public virtual int Id { get; }
        public virtual Order Order { get; }
        public virtual Article Article { get; set; }

        // TODO tostring
    }
}