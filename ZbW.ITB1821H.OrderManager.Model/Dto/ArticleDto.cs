using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class ArticleDto
    {
        private string name;
        [ReadOnly(true)]
        public int Id { get; set; }
        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ReadOnly(true)]
        public int ArticleGroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        [ExpandableObject]
        public virtual ArticleGroupDto ArticleGroup { get; set; }
        public virtual ICollection<PositionDto> Positions { get; private set; }
    }
}
