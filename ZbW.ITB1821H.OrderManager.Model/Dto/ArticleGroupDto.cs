using System.Collections.Generic;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class ArticleGroupDto : IValidate
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ReadOnly(true)]
        public int? ParentGroupId { get; set; }
        [ExpandableObject]
        public virtual ArticleGroupDto ParentGroup { get; set; }
        public virtual ICollection<ArticleGroupDto> SubArticleGroups { get; set; }
        public virtual ICollection<ArticleDto> Articles { get; set; }

        // nothing to validate (yet)
        [Browsable(false)]
        public bool IsValid => true;

        // TODO tostring
    }
}
