using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.City).IsRequired();

            builder.HasData(
                new Address { Id = 1000, Street = "711 Nulla St.", City = "Mankato", State = "MS", PostalCode = "96522", Country = "US" },
                new Address { Id = 1001, Street = "994 North Del Monte Ave.", City = "Richardson", State = "TX", PostalCode = "75080", Country = "US" },
                new Address { Id = 1002, Street = "4 Arnold Ave.", City = "Ottawa", State = "IL", PostalCode = "61350", Country = "US" },
                new Address { Id = 1003, Street = "7376 NE. Woodman Drive", City = "Pataskala", State = "OH", PostalCode = "43062", Country = "US" },
                new Address { Id = 1004, Street = "821 Hanover St.", City = "Milton", State = "MA", PostalCode = "02186", Country = "US" },
                new Address { Id = 1005, Street = "279 University St.", City = "Mcdonough", State = "GA", PostalCode = "30252", Country = "US" },
                new Address { Id = 1006, Street = "8484 High Street", City = "Torrington", State = "CT", PostalCode = "06790", Country = "US" },
                new Address { Id = 1008, Street = "334 Pineknoll Court", City = "Riverside", State = "NJ", PostalCode = "08075", Country = "US" },
                new Address { Id = 1009, Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" },
                new Address { Id = 1010, Street = "151 Thorne Drive", City = "Elgin", State = "IL", PostalCode = "60120", Country = "US" },
                new Address { Id = 1011, Street = "21 Lawrence Lane", City = "West Islip", State = "NY", PostalCode = "11795", Country = "US" },
                new Address { Id = 1012, Street = "514 Hill Drive", City = "Long Beach", State = "NY", PostalCode = "39564", Country = "US" },
                new Address { Id = 1013, Street = "2 S. Manhattan St.", City = "Westport", State = "CT", PostalCode = "06880", Country = "US" },
                new Address { Id = 1014, Street = "439 San Pablo Street", City = "Thornton", State = "CO", PostalCode = "80241", Country = "US" },
                new Address { Id = 1015, Street = "873 Alderwood Ave.", City = "Lexington", State = "NC", PostalCode = "27292", Country = "US" },
                new Address { Id = 1016, Street = "7746 Pulaski Lane", City = "Westwood", State = "NJ", PostalCode = "07675", Country = "US" },
                new Address { Id = 1017, Street = "77 Pearl Street", City = "Teaneck", State = "NJ", PostalCode = "07666", Country = "US" },
                new Address { Id = 1018, Street = "550 Locust Court", City = "Stockbridge", State = "GA ", PostalCode = "30281", Country = "US" },
                new Address { Id = 1019, Street = "19 Paris Hill Circle", City = "Virginia Beach", State = "VA", PostalCode = "23451", Country = "US" },
                new Address { Id = 1020, Street = "508 Manhattan Street", City = "West Deptford", State = "NJ", PostalCode = "08096", Country = "US" },
                new Address { Id = 1021, Street = "19 Shirley Dr.", City = "Tallahassee", State = "FL", PostalCode = "32303", Country = "US" }
                );
        }
    }
}
