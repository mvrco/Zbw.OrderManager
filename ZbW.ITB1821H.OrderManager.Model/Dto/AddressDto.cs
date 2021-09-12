using System.Collections.Generic;
using System.ComponentModel;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class AddressDto
    {
        private int id;
        private string street;
        private string city;
        private string state;
        private string postalCode;
        private string country;

        public AddressDto()
        {

        }

        [ReadOnly(true)]
        public int Id {
            get
            {
                return id;
            } 
            set
            {
                id = value;
            }
        }

        public string Street {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }

        public string City {
            get
            {
                return city;
            }
            set
            {
                city = value;
            } 
        }

        public string State {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        public string PostalCode {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }
        
        public string Country {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public virtual ICollection<CustomerDto> Customers { get; set; }
    }
}
