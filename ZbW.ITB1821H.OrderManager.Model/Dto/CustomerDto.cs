using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public string Email { get; set; }
        public string Website { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public int AddressId { get; set; }
        public virtual AddressDto Address { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }

        public override string ToString()
        {
            return nameof(Id) + "; " + Id + "; " +
                nameof(FullName) + "; " + FullName;
        }
    }
}
