using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class CustomerDto
    {
        private const string EMAIL_REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private string name;
        private string email;
        private string website;
        private string customerId;

        [ReadOnly(true)]
        public int Id { get; set; }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string CustomerId {
            get
            {
                return customerId;
            }
            set
            {
                if (!value.StartsWith("CU"))
                    throw new ApplicationException("Must start with 'CU'");
                if (value.Length != 7)
                    throw new ApplicationException("Not long enough");
                customerId = value;
            }
        }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string LastName { get; set; }

        [ReadOnly(true)]
        public string FullName => Name + " " + LastName;

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Regex regex = new Regex(EMAIL_REGEX);
                if (!regex.IsMatch(value))
                    throw new ApplicationException("Email address is invalid.");
                email = value;
            }
        }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                    throw new ApplicationException("Website is invalid.");
                website = value;
            }
        }
        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string Password { get; set; }
        [ReadOnly(true)]
        public string PasswordSalt { get; set; }
        [ReadOnly(true)]
        public string PasswordHash { get; set; }
        [ReadOnly(true)]
        public int AddressId { get; set; }
        [ExpandableObject]
        public virtual AddressDto Address { get; set; }
        public virtual ICollection<OrderDto> Orders { get; private set; }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}
