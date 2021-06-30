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
                new Customer { Id = 1, Name = "Cecilia", LastName = "Chapman", Email = "cecilia@chapman.com", Website = "https://chapman.com", PasswordSalt = "12837163", PasswordHash = "E14CE3435BC3194B77C609F26EF6075E", AddressId = 1000 },
                new Customer { Id = 2, Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 },
                new Customer { Id = 3, Name = "Celeste", LastName = "Slater", Email = "c3l3steee_Slater@yahoo.com", Website = "www.facebook.com", PasswordSalt = "79543238", PasswordHash = "D363DA161F0435AFA33522ECE8CF9028", AddressId = 1002 },
                new Customer { Id = 4, Name = "Theodore", LastName = "Lowe", Email = "theo.Lowe@bdd_dd.com", Website = "http://lowe.net", PasswordSalt = "09820278", PasswordHash = "236ED504E07B07B0A5A258267A076280", AddressId = 1003 },
                new Customer { Id = 5, Name = "Calista", LastName = "Wise", Email = "asdf@1234.info", Website = "wise.de", PasswordSalt = "02649823", PasswordHash = "63DFD2DAC00052149A13AD90D46E72F4", AddressId = 1004 },
                new Customer { Id = 6, Name = "Kyla", LastName = "Olsen", Email = "kyla.o_sen@outlook.com", Website = "https://olsen.com", PasswordSalt = "48219463", PasswordHash = "A4AD9F5525A4A438A30D9BA6F439EE11", AddressId = 1005 },
                new Customer { Id = 7, Name = "Ray", LastName = "Forrester", Email = "ray-forrester@gmail.com", Website = "https://www.forrester.com", PasswordSalt = "34298733", PasswordHash = "0D165FB2F6A4BDC58AA47F27A61D7CC3", AddressId = 1014 },
                new Customer { Id = 8, Name = "Lawrence", LastName = "Vazquez", Email = "lawrence.vazquez@outlook.com", Website = "www.youtube.com", PasswordSalt = "92736482", PasswordHash = "0615B09A41716D1D0B82AFE7776DAA63", AddressId = 1006 },
                new Customer { Id = 9, Name = "Aaron", LastName = "Hawkins", Email = "hawkins@ab_cd.net", Website = "google.com", PasswordSalt = "09374832", PasswordHash = "24C5B4576280B8758727185655D4AF01", AddressId = 1015 },
                new Customer { Id = 10, Name = "Melvin", LastName = "Porter", Email = "melvin@gmail.com", Website = "https://www.google.com", PasswordSalt = "26374819", PasswordHash = "D5C3FCDDA77E375170260A70ADF46185", AddressId = 1008 },
                new Customer { Id = 11, Name = "Bernard", LastName = "Colby", Email = "colbyyyy@gmail.com", Website = "https://policies.google.com/technologies/voice?hl=de&gl=ch", PasswordSalt = "16370362", PasswordHash = "60EDAF581460E45293444C173AEC4445", AddressId = 1009 },
                new Customer { Id = 12, Name = "Russell", LastName = "Adria", Email = "russell--adria@outlook.com", Website = "russell.com", PasswordSalt = "98873662", PasswordHash = "786BD8C931054AE53B10575711F3A6BD", AddressId = 1010 },
                new Customer { Id = 13, Name = "Chester", LastName = "Bennett", Email = "chester@bennett.com", Website = "www.facebook.com", PasswordSalt = "47823891", PasswordHash = "65BAD922A870FBFC45A98B4C223B989E", AddressId = 1011 },
                new Customer { Id = 14, Name = "Harrison", LastName = "Mcguire", Email = "harr.mcg@outlook.com", Website = "outlook.ch", PasswordSalt = "67541952", PasswordHash = "1ADB43FEDBAB65E3B46170C41A21076A", AddressId = 1012 },
                new Customer { Id = 15, Name = "Wallace", LastName = "Ross", Email = "wallace@rosss.com", Website = "rosss.com", PasswordSalt = "12340534", PasswordHash = "D797C7C0C03EAC0CCF9AC8D2E826ED5C", AddressId = 1013 }
                );
        }
    }
}
