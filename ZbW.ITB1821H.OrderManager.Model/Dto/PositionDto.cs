using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class PositionDto : IValidate
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public int PosNr { get; set; }
        [ReadOnly(true)]
        public int OrderId { get; set; }
        public int Amount { get; set; }
        [ReadOnly(true)]
        public int ArticleId { get; set; }
        [ExpandableObject]
        public virtual OrderDto Order { get; set; }
        [ExpandableObject]
        public virtual ArticleDto Article { get; set; }

        // nothing to validate (yet)
        [Browsable(false)]
        public bool IsValid => true;
    }
}
