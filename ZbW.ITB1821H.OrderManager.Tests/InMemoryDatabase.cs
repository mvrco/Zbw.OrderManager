using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Entities;

namespace ZbW.ITB1821H.OrderManager.Tests
{
    public class InMemoryDatabase
    {
        public IList<Customer> Customers { get; private set; }
        public IList<Address> Addresses { get; private set; }
        public IList<ArticleGroup> ArticleGroups { get; private set; }
        public IList<Article> Articles { get; private set; }
        public IList<Order> Orders { get; private set; }
        public IList<Position> Positions { get; private set; }
        public IList<Invoice> Invoices { get; private set; }
        public IList<QuartalsReporting> QuarterReportings { get; private set; }

        public InMemoryDatabase()
        {
            Customers = new List<Customer> {
                new Customer { Id = 1, CustomerId = "CU10001", Name = "Cecilia", LastName = "Chapman", Email = "cecilia@chapman.com", Website = "https://chapman.com", PasswordSalt = "12837163", PasswordHash = "E14CE3435BC3194B77C609F26EF6075E", AddressId = 1000 },
                new Customer { Id = 2, CustomerId = "CU10002", Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 },
                new Customer { Id = 3, CustomerId = "CU10003", Name = "Celeste", LastName = "Slater", Email = "c3l3steee_Slater@yahoo.com", Website = "www.facebook.com", PasswordSalt = "79543238", PasswordHash = "D363DA161F0435AFA33522ECE8CF9028", AddressId = 1002 },
                new Customer { Id = 4, CustomerId = "CU10004", Name = "Theodore", LastName = "Lowe", Email = "theo.Lowe@bdd_dd.com", Website = "http://lowe.net", PasswordSalt = "09820278", PasswordHash = "236ED504E07B07B0A5A258267A076280", AddressId = 1003 },
                new Customer { Id = 5, CustomerId = "CU10005", Name = "Calista", LastName = "Wise", Email = "asdf@1234.info", Website = "wise.de", PasswordSalt = "02649823", PasswordHash = "63DFD2DAC00052149A13AD90D46E72F4", AddressId = 1004 },
                new Customer { Id = 6, CustomerId = "CU10006", Name = "Kyla", LastName = "Olsen", Email = "kyla.o_sen@outlook.com", Website = "https://olsen.com", PasswordSalt = "48219463", PasswordHash = "A4AD9F5525A4A438A30D9BA6F439EE11", AddressId = 1005 },
                new Customer { Id = 7, CustomerId = "CU10007", Name = "Ray", LastName = "Forrester", Email = "ray-forrester@gmail.com", Website = "https://www.forrester.com", PasswordSalt = "34298733", PasswordHash = "0D165FB2F6A4BDC58AA47F27A61D7CC3", AddressId = 1014 },
                new Customer { Id = 8, CustomerId = "CU10008", Name = "Lawrence", LastName = "Vazquez", Email = "lawrence.vazquez@outlook.com", Website = "www.youtube.com", PasswordSalt = "92736482", PasswordHash = "0615B09A41716D1D0B82AFE7776DAA63", AddressId = 1006 },
                new Customer { Id = 9, CustomerId = "CU10009", Name = "Aaron", LastName = "Hawkins", Email = "hawkins@ab_cd.net", Website = "google.com", PasswordSalt = "09374832", PasswordHash = "24C5B4576280B8758727185655D4AF01", AddressId = 1015 },
                new Customer { Id = 10, CustomerId = "CU10010", Name = "Melvin", LastName = "Porter", Email = "melvin@gmail.com", Website = "https://www.google.com", PasswordSalt = "26374819", PasswordHash = "D5C3FCDDA77E375170260A70ADF46185", AddressId = 1008 },
                new Customer { Id = 11, CustomerId = "CU10011", Name = "Bernard", LastName = "Colby", Email = "colbyyyy@gmail.com", Website = "https://policies.google.com/technologies/voice?hl=de&gl=ch", PasswordSalt = "16370362", PasswordHash = "60EDAF581460E45293444C173AEC4445", AddressId = 1009 },
                new Customer { Id = 12, CustomerId = "CU10012", Name = "Russell", LastName = "Adria", Email = "russell--adria@outlook.com", Website = "russell.com", PasswordSalt = "98873662", PasswordHash = "786BD8C931054AE53B10575711F3A6BD", AddressId = 1010 },
                new Customer { Id = 13, CustomerId = "CU10013", Name = "Chester", LastName = "Bennett", Email = "chester@bennett.com", Website = "www.facebook.com", PasswordSalt = "47823891", PasswordHash = "65BAD922A870FBFC45A98B4C223B989E", AddressId = 1011 },
                new Customer { Id = 14, CustomerId = "CU10014", Name = "Harrison", LastName = "Mcguire", Email = "harr.mcg@outlook.com", Website = "outlook.ch", PasswordSalt = "67541952", PasswordHash = "1ADB43FEDBAB65E3B46170C41A21076A", AddressId = 1012 },
                new Customer { Id = 15, CustomerId = "CU10015", Name = "Wallace", LastName = "Ross", Email = "wallace@rosss.com", Website = "rosss.com", PasswordSalt = "12340534", PasswordHash = "D797C7C0C03EAC0CCF9AC8D2E826ED5C", AddressId = 1013 }
            };

            Addresses = new List<Address> {
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
            };

            ArticleGroups = new List<ArticleGroup> {
                new ArticleGroup { Id = 10, Name = "Food", Description = "all food" },
                new ArticleGroup { Id = 11, Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 },
                new ArticleGroup { Id = 12, Name = "Meat", Description = "Good Quality Meat", ParentGroupId = 10 },
                new ArticleGroup { Id = 13, Name = "Dairy", Description = "Milk for everyone!", ParentGroupId = 10 }
            };

            Articles = new List<Article> {
                new Article { Id = 100, Name = "Apple", Description = "Fresh from Switzerland", Price = 0.95, ArticleGroupId = 11 },
                new Article { Id = 101, Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 },
                new Article { Id = 102, Name = "Chicken", Description = "Swiss Quality", Price = 2.03, ArticleGroupId = 12 },
                new Article { Id = 103, Name = "Salmon", Description = "Atlantic Ocean", Price = 1.56, ArticleGroupId = 12 },
                new Article { Id = 104, Name = "Cheese", Description = "Switzerland", Price = 2.22, ArticleGroupId = 13 },
                new Article { Id = 105, Name = "Yogurt", Description = "Based on years of experience", Price = 2.34, ArticleGroupId = 13 }
            };

            Orders = new List<Order> {
                new Order { Id = 1234, DateOfPurchase = new DateTime(2021, 1, 30), CustomerId = 1 },
                 new Order { Id = 1235, DateOfPurchase = new DateTime(2021, 1, 23), CustomerId = 2},
                 new Order { Id = 1236, DateOfPurchase = new DateTime(2021, 1, 2), CustomerId = 2},
                 new Order { Id = 1237, DateOfPurchase = new DateTime(2021, 2, 4), CustomerId = 2},
                 new Order { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 },
                 new Order { Id = 1239, DateOfPurchase = new DateTime(2021, 2, 22), CustomerId = 3 },
                 new Order { Id = 1230, DateOfPurchase = new DateTime(2021, 3, 31), CustomerId = 4 },
                 new Order { Id = 1240, DateOfPurchase = new DateTime(2021, 3, 1), CustomerId = 4 },
                 new Order { Id = 1231, DateOfPurchase = new DateTime(2021, 3, 25), CustomerId = 6 },
                 new Order { Id = 1232, DateOfPurchase = new DateTime(2020, 12, 12), CustomerId = 7 },
                 new Order { Id = 1233, DateOfPurchase = new DateTime(2020, 12, 1), CustomerId = 8 },
                 new Order { Id = 1241, DateOfPurchase = new DateTime(2020, 11, 22), CustomerId = 8 },
                 new Order { Id = 1242, DateOfPurchase = new DateTime(2020, 10, 9), CustomerId = 10 },
                 new Order { Id = 1243, DateOfPurchase = new DateTime(2021, 5, 8), CustomerId = 11 },
                 new Order { Id = 1244, DateOfPurchase = new DateTime(2021, 3, 7), CustomerId = 11 },
                 new Order { Id = 1245, DateOfPurchase = new DateTime(2021, 4, 3), CustomerId = 11 },
                 new Order { Id = 1246, DateOfPurchase = new DateTime(2021, 4, 5), CustomerId = 14 },
                 new Order { Id = 1247, DateOfPurchase = new DateTime(2021, 3, 14), CustomerId = 15 },
                 new Order { Id = 1248, DateOfPurchase = new DateTime(2021, 4, 17), CustomerId = 15 }
            };

            Positions = new List<Position> {
                 new Position { Id = 1, PosNr = 1, OrderId = 1230, Amount = 23, ArticleId = 100 },
                  new Position { Id = 2, PosNr = 2, OrderId = 1230, Amount = 30, ArticleId = 101 },
                  new Position { Id = 3, PosNr = 3, OrderId = 1230, Amount = 12, ArticleId = 102 },
                  new Position { Id = 4, PosNr = 4, OrderId = 1230, Amount = 34, ArticleId = 103 },
                  new Position { Id = 5, PosNr = 1, OrderId = 1231, Amount = 100, ArticleId = 100 },
                  new Position { Id = 6, PosNr = 2, OrderId = 1231, Amount = 200, ArticleId = 102 },
                  new Position { Id = 7, PosNr = 1, OrderId = 1232, Amount = 55, ArticleId = 104 },
                  new Position { Id = 8, PosNr = 2, OrderId = 1232, Amount = 35, ArticleId = 105 },
                  new Position { Id = 9, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 },
                  new Position { Id = 10, PosNr = 4, OrderId = 1232, Amount = 10, ArticleId = 101 },
                  new Position { Id = 11, PosNr = 5, OrderId = 1232, Amount = 5, ArticleId = 102 },
                  new Position { Id = 12, PosNr = 6, OrderId = 1232, Amount = 50, ArticleId = 103 },
                  new Position { Id = 13, PosNr = 1, OrderId = 1233, Amount = 86, ArticleId = 100 },
                  new Position { Id = 14, PosNr = 2, OrderId = 1233, Amount = 134, ArticleId = 101 },
                  new Position { Id = 15, PosNr = 3, OrderId = 1233, Amount = 100, ArticleId = 102 },
                  new Position { Id = 16, PosNr = 4, OrderId = 1233, Amount = 90, ArticleId = 103 },
                  new Position { Id = 17, PosNr = 1, OrderId = 1234, Amount = 134, ArticleId = 103 },
                  new Position { Id = 18, PosNr = 2, OrderId = 1234, Amount = 56, ArticleId = 104 },
                  new Position { Id = 19, PosNr = 3, OrderId = 1234, Amount = 65, ArticleId = 105 },
                  new Position { Id = 20, PosNr = 1, OrderId = 1235, Amount = 73, ArticleId = 103 },
                  new Position { Id = 21, PosNr = 2, OrderId = 1235, Amount = 77, ArticleId = 105 },
                  new Position { Id = 22, PosNr = 1, OrderId = 1236, Amount = 98, ArticleId = 105 },
                  new Position { Id = 23, PosNr = 2, OrderId = 1236, Amount = 123, ArticleId = 104 },
                  new Position { Id = 24, PosNr = 1, OrderId = 1237, Amount = 451, ArticleId = 103 },
                  new Position { Id = 25, PosNr = 2, OrderId = 1237, Amount = 345, ArticleId = 102 },
                  new Position { Id = 26, PosNr = 1, OrderId = 1238, Amount = 557, ArticleId = 100 },
                  new Position { Id = 27, PosNr = 2, OrderId = 1238, Amount = 45, ArticleId = 101 },
                  new Position { Id = 28, PosNr = 3, OrderId = 1238, Amount = 256, ArticleId = 102 },
                  new Position { Id = 29, PosNr = 4, OrderId = 1238, Amount = 234, ArticleId = 103 },
                  new Position { Id = 30, PosNr = 5, OrderId = 1238, Amount = 56, ArticleId = 104 },
                  new Position { Id = 31, PosNr = 6, OrderId = 1238, Amount = 134, ArticleId = 105 },
                  new Position { Id = 32, PosNr = 1, OrderId = 1239, Amount = 567, ArticleId = 104 },
                  new Position { Id = 33, PosNr = 2, OrderId = 1239, Amount = 87, ArticleId = 105 },
                  new Position { Id = 34, PosNr = 1, OrderId = 1240, Amount = 47, ArticleId = 101 },
                  new Position { Id = 35, PosNr = 1, OrderId = 1241, Amount = 83, ArticleId = 102 },
                  new Position { Id = 36, PosNr = 2, OrderId = 1241, Amount = 95, ArticleId = 103 },
                  new Position { Id = 37, PosNr = 1, OrderId = 1242, Amount = 75, ArticleId = 104 },
                  new Position { Id = 38, PosNr = 2, OrderId = 1242, Amount = 45, ArticleId = 105 },
                  new Position { Id = 39, PosNr = 3, OrderId = 1242, Amount = 75, ArticleId = 100 },
                  new Position { Id = 40, PosNr = 1, OrderId = 1243, Amount = 25, ArticleId = 102 },
                  new Position { Id = 41, PosNr = 2, OrderId = 1243, Amount = 35, ArticleId = 103 },
                  new Position { Id = 42, PosNr = 1, OrderId = 1244, Amount = 51, ArticleId = 105 },
                  new Position { Id = 43, PosNr = 1, OrderId = 1245, Amount = 15, ArticleId = 103 },
                  new Position { Id = 44, PosNr = 2, OrderId = 1245, Amount = 36, ArticleId = 104 },
                  new Position { Id = 45, PosNr = 3, OrderId = 1245, Amount = 99, ArticleId = 105 },
                  new Position { Id = 46, PosNr = 1, OrderId = 1246, Amount = 100, ArticleId = 100 },
                  new Position { Id = 47, PosNr = 1, OrderId = 1247, Amount = 35, ArticleId = 101 },
                  new Position { Id = 48, PosNr = 1, OrderId = 1248, Amount = 75, ArticleId = 102 }
            };

            Invoices = new List<Invoice> {
                new Invoice { CustomerId = 1, Name = "Cecilia Chapman", Street = "711 Nulla St.", PostalCode = "96522", City = "Mankato", Country = "US", DateOfPurchase = new DateTime(2021, 1, 30), OrderId = 1234, Amount = 85.41 },
                new Invoice { CustomerId = 1, Name = "Cecilia Chapman", Street = "711 Nulla St.", PostalCode = "96522", City = "Mankato", Country = "US", DateOfPurchase = new DateTime(2021, 5, 4), OrderId = 1235, Amount = 100.00 },
                new Invoice { CustomerId = 1, Name = "Cecilia Chapman", Street = "711 Nulla St.", PostalCode = "96522", City = "Mankato", Country = "US", DateOfPurchase = new DateTime(2021, 5, 4), OrderId = 1236, Amount = 224.15 },
                new Invoice { CustomerId = 1, Name = "Cecilia Chapman", Street = "711 Nulla St.", PostalCode = "96522", City = "Mankato", Country = "US", DateOfPurchase = new DateTime(2021, 6, 30), OrderId = 1237, Amount = 89.20 }
            };

            QuarterReportings = new List<QuartalsReporting> {
                new QuartalsReporting { Category = "Category 1", QuartalMinus0 = 0, QuartalMinus1 = 1, QuartalMinus2 = 2, QuartalMinus3 = 3, QuartalMinus4 = 4, QuartalMinus5 = 5, QuartalMinus6 = 6, QuartalMinus7 = 7, QuartalMinus8 = 8, QuartalMinus9 = 9, QuartalMinus11 = 11, QuartalMinus10 = 10, YOYinPercent = 10 },
                new QuartalsReporting { Category = "Category 2", QuartalMinus0 = 0, QuartalMinus1 = 1, QuartalMinus2 = 2, QuartalMinus3 = 3, QuartalMinus4 = 4, QuartalMinus5 = 5, QuartalMinus6 = 6, QuartalMinus7 = 7, QuartalMinus8 = 8, QuartalMinus9 = 9, QuartalMinus11 = 11, QuartalMinus10 = 10, YOYinPercent = 10 },
                new QuartalsReporting { Category = "Category 3", QuartalMinus0 = 0, QuartalMinus1 = 1, QuartalMinus2 = 2, QuartalMinus3 = 3, QuartalMinus4 = 4, QuartalMinus5 = 5, QuartalMinus6 = 6, QuartalMinus7 = 7, QuartalMinus8 = 8, QuartalMinus9 = 9, QuartalMinus11 = 11, QuartalMinus10 = 10, YOYinPercent = 10 },
                new QuartalsReporting { Category = "Category 4", QuartalMinus0 = 0, QuartalMinus1 = 1, QuartalMinus2 = 2, QuartalMinus3 = 3, QuartalMinus4 = 4, QuartalMinus5 = 5, QuartalMinus6 = 6, QuartalMinus7 = 7, QuartalMinus8 = 8, QuartalMinus9 = 9, QuartalMinus11 = 11, QuartalMinus10 = 10, YOYinPercent = 10 }
            };
        }
    }
}
