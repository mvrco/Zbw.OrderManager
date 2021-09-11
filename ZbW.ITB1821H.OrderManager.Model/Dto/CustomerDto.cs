using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class CustomerDto
    {
        private string name;
        [ReadOnly(true)]
        public int Id { get; set; }
        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Name
        {
            get => name; set
            {
                if (value == "666666")
                    throw new Exception("This name is invalid");
                name = value;

            }
        }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string Website { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        [ReadOnly(true)]
        public int AddressId { get; set; }
        [ExpandableObject]
        public virtual AddressDto Address { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}
