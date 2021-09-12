using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using ZbW.ITB1821H.OrderManager.Model.Service;
using ZbW.ITB1821H.OrderManager.UserInterface.Util;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class CustomerDto : INotifyPropertyChanged
    {
        private const string EMAIL_REGEX = @"^[a-zA-Z][\w\d\-\.]+[a-zA-Z]@([\w\-\d]+\.)+[\w-]{2,4}$";
        private string name;
        private string email;
        private string website;
        private string customerId;
        private string password;
        private string lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CustomerDto()
        {
            password = "*****";
        }

        [ReadOnly(true)]
        public int Id { get; set; }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string CustomerId
        {
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
                OnPropertyChanged(nameof(FullName));
            }
        }

        [Editor(typeof(TextBoxValidationEditor), typeof(TextBoxValidationEditor))]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

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

        [Editor(typeof(AutoClearingTextBoxEditor), typeof(AutoClearingTextBoxEditor))]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length < 8)
                    throw new ApplicationException("Not long enough.");
                if (!value.Any(char.IsDigit))
                    throw new ApplicationException("Must include at least one number.");
                if (value.All(char.IsLetterOrDigit))
                    throw new ApplicationException("Must include at least one special character.");

                password = value;
            }
        }
        [Browsable(false)]
        public string PasswordSalt { get; set; }
        [Browsable(false)]
        public string PasswordHash { get; set; }
        [Browsable(false)]
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
