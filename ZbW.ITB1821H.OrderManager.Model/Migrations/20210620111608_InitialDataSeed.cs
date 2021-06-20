using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class InitialDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArticleGroups",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1000, "Mankato", "US", "96522", "MS", "711 Nulla St." },
                    { 1020, "West Deptford", "US", "08096", "NJ", "508 Manhattan Street" },
                    { 1019, "Virginia Beach", "US", "23451", "VA", "19 Paris Hill Circle" },
                    { 1018, "Stockbridge", "US", "30281", "GA ", "550 Locust Court" },
                    { 1017, "Teaneck", "US", "07666", "NJ", "77 Pearl Street" },
                    { 1016, "Westwood", "US", "07675", "NJ", "7746 Pulaski Lane" },
                    { 1015, "Lexington", "US", "27292", "NC", "873 Alderwood Ave." },
                    { 1014, "Thornton", "US", "80241", "CO", "439 San Pablo Street" },
                    { 1013, "Westport", "US", "06880", "CT", "2 S. Manhattan St." },
                    { 1012, "Long Beach", "US", "39564", "NY", "514 Hill Drive" },
                    { 1011, "West Islip", "US", "11795", "NY", "21 Lawrence Lane" },
                    { 1010, "Elgin", "US", "60120", "IL", "151 Thorne Drive" },
                    { 1009, "Ocean Springs", "US", "39564", "MS", "153 Wood St." },
                    { 1008, "Riverside", "US", "08075", "NJ", "334 Pineknoll Court" },
                    { 1006, "Torrington", "US", "06790", "CT", "8484 High Street" },
                    { 1005, "Mcdonough", "US", "30252", "GA", "279 University St." },
                    { 1004, "Milton", "US", "02186", "MA", "821 Hanover St." },
                    { 1003, "Pataskala", "US", "43062", "OH", "7376 NE. Woodman Drive" },
                    { 1002, "Ottawa", "US", "61350", "IL", "4 Arnold Ave." },
                    { 1001, "Richardson", "US", "75080", "TX", "994 North Del Monte Ave." },
                    { 1021, "Tallahassee", "US", "32303", "FL", "19 Shirley Dr." }
                });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "Description", "Name", "ParentGroupId" },
                values: new object[] { 10, "all food", "Food", null });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "Description", "Name", "ParentGroupId" },
                values: new object[,]
                {
                    { 13, "Milk for everyone!", "Dairy", 10 },
                    { 11, "Worldwide selection of Fruits", "Fruits", 10 },
                    { 12, "Good Quality Meat", "Meat", 10 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "LastName", "Name", "Password", "Website" },
                values: new object[,]
                {
                    { 9, 1015, "hawkins@ab_cd.net", "Hawkins", "Aaron", "d>Y$3rnJ", "google.com" },
                    { 7, 1014, "ray-forrester@gmail.com", "Forrester", "Ray", "ZfzQ6LYL", "https://www.forrester.com" },
                    { 15, 1013, "wallace@rosss.com", "Ross", "Wallace", "5R9Q+}p2", "rosss.com" },
                    { 14, 1012, "harr.mcg@outlook.com", "Mcguire", "Harrison", "q@3Vxb'm", "outlook.ch" },
                    { 13, 1011, "chester@bennett.com", "Bennett", "Chester", "p@sz9P;G", "www.facebook.com" },
                    { 12, 1010, "russell--adria@outlook.com", "Adria", "Russell", "Z9Jmxz'p", "russell.com" },
                    { 11, 1009, "colbyyyy@gmail.com", "Colby", "Bernard", "N)9k'9QP", "https://policies.google.com/technologies/voice?hl=de&gl=ch" },
                    { 8, 1006, "lawrence.vazquez@outlook.com", "Vazquez", "Lawrence", ">wC!'P7#", "www.youtube.com" },
                    { 6, 1005, "kyla.o_sen@outlook.com", "Olsen", "Kyla", "s/e$9A)C", "https://olsen.com" },
                    { 5, 1004, "asdf@1234.info", "Wise", "Calista", "9Nk8G-/F", "wise.de" },
                    { 4, 1003, "theo.Lowe@bdd_dd.com", "Lowe", "Theodore", "am;3W3vE", "http://lowe.net" },
                    { 3, 1002, "c3l3steee_Slater@yahoo.com", "Slater", "Celeste", "4*v[JSbq", "www.facebook.com" },
                    { 2, 1001, "iris-watson@gmail.com", "Watson", "Iris", ">bJN-6B(", "www.facebook.com/asdf" },
                    { 10, 1008, "melvin@gmail.com", "Porter", "Melvin", "X9j;(cC2", "https://www.google.com" },
                    { 1, 1000, "cecilia@chapman.com", "Chapman", "Cecilia", "q-9L8?Ac", "https://chapman.com" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 105, 13, "Based on years of experience", "Yogurt", 2.3399999999999999 },
                    { 103, 12, "Atlantic Ocean", "Salmon", 1.5600000000000001 },
                    { 102, 12, "Swiss Quality", "Chicken", 2.0299999999999998 },
                    { 101, 11, "Fresh from Columbia", "Banana", 1.1200000000000001 },
                    { 100, 11, "Fresh from Switzerland", "Apple", 0.94999999999999996 },
                    { 104, 13, "Switzerland", "Cheese", 2.2200000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DateOfPurchase" },
                values: new object[,]
                {
                    { 1232, 7, new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1248, 15, new DateTime(2021, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1247, 15, new DateTime(2021, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1246, 14, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1245, 11, new DateTime(2021, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1244, 11, new DateTime(2021, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1243, 11, new DateTime(2021, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1241, 8, new DateTime(2020, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1233, 8, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1231, 6, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1240, 4, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1230, 4, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1239, 3, new DateTime(2021, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1238, 3, new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1237, 2, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1236, 2, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1235, 2, new DateTime(2021, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1242, 10, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1234, 1, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Amount", "ArticleId", "OrderId", "PosNr" },
                values: new object[,]
                {
                    { 1, 23, 100, 1230, 1 },
                    { 20, 73, 103, 1235, 1 },
                    { 24, 451, 103, 1237, 1 },
                    { 29, 234, 103, 1238, 4 },
                    { 36, 95, 103, 1241, 2 },
                    { 41, 35, 103, 1243, 2 },
                    { 43, 15, 103, 1245, 1 },
                    { 7, 55, 104, 1232, 1 },
                    { 18, 56, 104, 1234, 2 },
                    { 23, 123, 104, 1236, 2 },
                    { 17, 134, 103, 1234, 1 },
                    { 30, 56, 104, 1238, 5 },
                    { 37, 75, 104, 1242, 1 },
                    { 44, 36, 104, 1245, 2 },
                    { 8, 35, 105, 1232, 2 },
                    { 19, 65, 105, 1234, 3 },
                    { 21, 77, 105, 1235, 2 },
                    { 22, 98, 105, 1236, 1 },
                    { 31, 134, 105, 1238, 6 },
                    { 33, 87, 105, 1239, 2 },
                    { 38, 45, 105, 1242, 2 },
                    { 32, 567, 104, 1239, 1 },
                    { 16, 90, 103, 1233, 4 },
                    { 12, 50, 103, 1232, 6 },
                    { 4, 34, 103, 1230, 4 },
                    { 5, 100, 100, 1231, 1 },
                    { 9, 20, 100, 1232, 3 },
                    { 13, 86, 100, 1233, 1 },
                    { 26, 557, 100, 1238, 1 },
                    { 39, 75, 100, 1242, 3 },
                    { 46, 100, 100, 1246, 1 },
                    { 2, 30, 101, 1230, 2 },
                    { 10, 10, 101, 1232, 4 },
                    { 14, 134, 101, 1233, 2 },
                    { 27, 45, 101, 1238, 2 },
                    { 34, 47, 101, 1240, 1 },
                    { 47, 35, 101, 1247, 1 },
                    { 3, 12, 102, 1230, 3 },
                    { 6, 200, 102, 1231, 2 },
                    { 11, 5, 102, 1232, 5 },
                    { 15, 100, 102, 1233, 3 },
                    { 25, 345, 102, 1237, 2 },
                    { 28, 256, 102, 1238, 3 },
                    { 35, 83, 102, 1241, 1 },
                    { 40, 25, 102, 1243, 1 },
                    { 48, 75, 102, 1248, 1 },
                    { 42, 51, 105, 1244, 1 },
                    { 45, 99, 105, 1245, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArticleGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
