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
    public class CustomerDto : INotifyPropertyChanged, IValidate
    {
        private const string EMAIL_REGEX = @"^[a-zA-Z][\w\d\-\.]+[a-zA-Z]@([\w\-\d]+\.)+[\w-]{2,4}$";
        private string name;
        private string email;
        private string website;
        private string customerId;
        private string password;
        private string lastName;

        private bool isEmailValid, isCustomerIdValid, isWebsiteValid, isPasswordValid;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CustomerDto()
        {
            password = "*****";
            isPasswordValid = true;
            isWebsiteValid = true;
            isCustomerIdValid = true;
            isEmailValid = true;
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
                {
                    isCustomerIdValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Must start with 'CU'");
                }
                else if (value.Length != 7)
                {
                    isCustomerIdValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Not long enough");
                }
                isCustomerIdValid = true;
                customerId = value;

                OnPropertyChanged(nameof(IsValid));
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
                {
                    isEmailValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Email address is invalid.");
                }
                isEmailValid = true;
                email = value;

                OnPropertyChanged(nameof(IsValid));
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
                {
                    isWebsiteValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Website is invalid.");
                }
                isWebsiteValid = true;
                website = value;

                OnPropertyChanged(nameof(IsValid));
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
                {
                    isPasswordValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Not long enough.");
                }
                else if (!value.Any(char.IsDigit))
                {
                    isPasswordValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Must include at least one number.");
                }
                else if (value.All(char.IsLetterOrDigit))
                {
                    isPasswordValid = false;
                    OnPropertyChanged(nameof(IsValid));
                    throw new ApplicationException("Must include at least one special character.");
                }
                isPasswordValid = true;
                password = value;

                OnPropertyChanged(nameof(IsValid));
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
        [Browsable(false)]
        public bool IsValid
        {
            get
            {
                return isCustomerIdValid && isEmailValid && isWebsiteValid && isPasswordValid;
            }
        }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}
