using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class CreatingTriggersForHistory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreateDate",
                value: new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreateDate",
                value: new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreateDate",
                value: new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreateDate",
                value: new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreateDate",
                value: new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreateDate",
                value: new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql(@"CREATE TABLE [dbo].[HistoryChanges](
	                                [Id] [int] IDENTITY(1,1) NOT NULL,
	                                [TableName] [nvarchar](max) NOT NULL,
	                                [DataId] [int] NOT NULL,
	                                [ColumnName] [nvarchar](max) NOT NULL,
	                                [OldValue] [nvarchar](max) NULL,
	                                [ChangeDate] [datetime] NOT NULL
                                 CONSTRAINT [PK_HistoryChanges] PRIMARY KEY CLUSTERED 
                                (
	                                [Id] ASC
                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                GO");

            migrationBuilder.Sql(@"Create Trigger UpdateOfAdresses on Addresses
                                for update
                                as
	                                insert into HistoryChanges (TableName, DataId, ColumnName, OldValue, ChangeDate)
	                                Select 'Adresses', old.Id, 'City', old.City, GETDATE() from deleted old
	                                inner join inserted ins on ins.City<>old.City
	                                union
	                                Select 'Adresses', old.Id, 'Street', old.Street, GETDATE() from deleted old
	                                inner join inserted ins on ins.Street<>old.Street
	                                union
	                                Select 'Adresses', old.Id, 'State', old.State, GETDATE() from deleted old
	                                inner join inserted ins on ins.State<>old.State
	                                union
	                                Select 'Adresses', old.Id, 'PostalCode', old.PostalCode, GETDATE() from deleted old
	                                inner join inserted ins on ins.PostalCode<>old.PostalCode
	                                union
	                                Select 'Adresses', old.Id, 'Country', old.Country, GETDATE() from deleted old
	                                inner join inserted ins on ins.Country<>old.Country;
                                GO");

            migrationBuilder.Sql(@"Create Trigger UpdateOfCustomers on Customers
                                for update
                                as
	                                insert into HistoryChanges (TableName, DataId, ColumnName, OldValue, ChangeDate)
	                                Select 'Customers', old.Id, 'Name', old.Name, GETDATE() from deleted old
	                                inner join inserted ins on ins.Name<>old.Name
	                                union
	                                Select 'Customers', old.Id, 'LastName', old.LastName, GETDATE() from deleted old
	                                inner join inserted ins on ins.LastName<>old.LastName
	                                union
	                                Select 'Customers', old.Id, 'Email', old.Email, GETDATE() from deleted old
	                                inner join inserted ins on ins.Email<>old.Email
	                                union
	                                Select 'Customers', old.Id, 'Website', old.Website, GETDATE() from deleted old
	                                inner join inserted ins on ins.Website<>old.Website
	                                union
	                                Select 'Customers', old.Id, 'AddressId', old.AddressId, GETDATE() from deleted old
	                                inner join inserted ins on ins.AddressId<>old.AddressId;
                                GO");

            migrationBuilder.Sql(@"Create Trigger UpdateOfArticles on Articles
                                for update
                                as
	                                insert into HistoryChanges (TableName, DataId, ColumnName, OldValue, ChangeDate)
	                                Select 'Articles', old.Id, 'IsActive', old.IsActive, GETDATE() from deleted old
	                                inner join inserted ins on ins.IsActive<>old.IsActive;
                                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop trigger UpdateOfCustomers");

            migrationBuilder.Sql(@"drop trigger UpdateOfCustomers");

            migrationBuilder.Sql(@"drop trigger UpdateOfCustomers");

            migrationBuilder.Sql(@"drop table [dbo].[HistoryChanges]");

            migrationBuilder.AlterColumn<bool>(
                name: "CreateDate",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreateDate",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreateDate",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreateDate",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreateDate",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreateDate",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreateDate",
                value: false);
        }
    }
}
