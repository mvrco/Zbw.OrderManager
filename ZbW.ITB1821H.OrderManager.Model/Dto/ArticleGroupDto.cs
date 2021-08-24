using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class ArticleGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentGroupId { get; set; }

        public virtual ArticleGroupDto ParentGroup { get; set; }
        public virtual ICollection<ArticleGroupDto> SubArticleGroups { get; set; }
        public virtual ICollection<ArticleDto> Articles { get; set; }

        // TODO tostring
    }
}
