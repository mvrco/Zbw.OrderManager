using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(cus => cus.Address)
                .WithMany(adr => adr.Customers)
                .HasForeignKey(cus => cus.AddressId);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LastName).IsRequired();

            builder.HasData(
                new Customer { Id = 1, Name = "Cecilia", LastName = "Chapman", Email = "cecilia@chapman.com", Website = "https://chapman.com", Password = "q-9L8?Ac", AddressId = 1000 },
                new Customer { Id = 2, Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", Password = ">bJN-6B(", AddressId = 1001 },
                new Customer { Id = 3, Name = "Celeste", LastName = "Slater", Email = "c3l3steee_Slater@yahoo.com", Website = "www.facebook.com", Password = "4*v[JSbq", AddressId = 1002 },
                new Customer { Id = 4, Name = "Theodore", LastName = "Lowe", Email = "theo.Lowe@bdd_dd.com", Website = "http://lowe.net", Password = "am;3W3vE", AddressId = 1003 },
                new Customer { Id = 5, Name = "Calista", LastName = "Wise", Email = "asdf@1234.info", Website = "wise.de", Password = "9Nk8G-/F", AddressId = 1004 },
                new Customer { Id = 6, Name = "Kyla", LastName = "Olsen", Email = "kyla.o_sen@outlook.com", Website = "https://olsen.com", Password = "s/e$9A)C", AddressId = 1005 },
                new Customer { Id = 7, Name = "Ray", LastName = "Forrester", Email = "ray-forrester@gmail.com", Website = "https://www.forrester.com", Password = "ZfzQ6LYL", AddressId = 1014 },
                new Customer { Id = 8, Name = "Lawrence", LastName = "Vazquez", Email = "lawrence.vazquez@outlook.com", Website = "www.youtube.com", Password = ">wC!'P7#", AddressId = 1006 },
                new Customer { Id = 9, Name = "Aaron", LastName = "Hawkins", Email = "hawkins@ab_cd.net", Website = "google.com", Password = $"d>Y$3rnJ", AddressId = 1015 },
                new Customer { Id = 10, Name = "Melvin", LastName = "Porter", Email = "melvin@gmail.com", Website = "https://www.google.com", Password = $"X9j;(cC2", AddressId = 1008 },
                new Customer { Id = 11, Name = "Bernard", LastName = "Colby", Email = "colbyyyy@gmail.com", Website = "https://policies.google.com/technologies/voice?hl=de&gl=ch", Password = "N)9k'9QP", AddressId = 1009 },
                new Customer { Id = 12, Name = "Russell", LastName = "Adria", Email = "russell--adria@outlook.com", Website = "russell.com", Password = "Z9Jmxz'p", AddressId = 1010 },
                new Customer { Id = 13, Name = "Chester", LastName = "Bennett", Email = "chester@bennett.com", Website = "www.facebook.com", Password = "p@sz9P;G", AddressId = 1011 },
                new Customer { Id = 14, Name = "Harrison", LastName = "Mcguire", Email = "harr.mcg@outlook.com", Website = "outlook.ch", Password = "q@3Vxb'm", AddressId = 1012 },
                new Customer { Id = 15, Name = "Wallace", LastName = "Ross", Email = "wallace@rosss.com", Website = "rosss.com", Password = "5R9Q+}p2", AddressId = 1013 }
                );
        }
    }
}
