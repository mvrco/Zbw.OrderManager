using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class AddInvoiceReporting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER Trigger [dbo].[UpdateOfCustomers] on [dbo].[Customers]
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
	                                Select 'Customers', old.Id, 'AddressId', CONVERT(nvarchar, old.AddressId), GETDATE() from deleted old
	                                inner join inserted ins on ins.AddressId<>old.AddressId
									union
	                                Select 'Customers', old.Id, 'Website', old.Website, GETDATE() from deleted old
	                                inner join inserted ins on ins.Website<>old.Website");


            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[AddressesTVFhistory]
                                    (	
	                                    @date as datetime
                                    )
                                    RETURNS TABLE 
                                    AS
                                    RETURN 
                                    (
	                                    Select adr.Id, ISNULL(aStreet.OldValue, adr.Street) as Street, ISNULL(aCity.OldValue, adr.City) as City, ISNULL(aState.OldValue, adr.State) as State, ISNULL(aPostalCode.OldValue, adr.PostalCode) as PostalCode, ISNULL(aCountry.OldValue, adr.Country) as Country from Addresses adr
	                                    outer apply (Select top 1 a.OldValue from HistoryChanges a where a.DataId=adr.Id and a.TableName='Adresses' and a.ColumnName='Street' and a.ChangeDate>=@date order by ChangeDate asc) aStreet
	                                    outer apply (Select top 1 a.OldValue from HistoryChanges a where a.DataId=adr.Id and a.TableName='Adresses' and a.ColumnName='City' and a.ChangeDate>=@date order by ChangeDate asc) aCity
	                                    outer apply (Select top 1 a.OldValue from HistoryChanges a where a.DataId=adr.Id and a.TableName='Adresses' and a.ColumnName='State' and a.ChangeDate>=@date order by ChangeDate asc) aState
	                                    outer apply (Select top 1 a.OldValue from HistoryChanges a where a.DataId=adr.Id and a.TableName='Adresses' and a.ColumnName='PostalCode' and a.ChangeDate>=@date order by ChangeDate asc) aPostalCode
	                                    outer apply (Select top 1 a.OldValue from HistoryChanges a where a.DataId=adr.Id and a.TableName='Adresses' and a.ColumnName='Country' and a.ChangeDate>=@date order by ChangeDate asc) aCountry
                                    )
                                    GO");

            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[CustomersTVFhistory]
                                    (	
	                                    @date as datetime
                                    )
                                    RETURNS TABLE 
                                    AS
                                    RETURN 
                                    (
	                                    Select cus.Id, ISNULL(cName.OldValue, cus.Name) as Name, ISNULL(cLastName.OldValue, cus.LastName) as LastName, ISNULL(cEmail.OldValue, cus.Email) as Email, ISNULL(cWebsite.OldValue, cus.Website) as Website, ISNULL(cAddressId.OldValue, cus.AddressId) as AddressId from Customers cus
	                                    outer apply (Select top 1 c.OldValue from HistoryChanges c where c.DataId=cus.Id and c.TableName='Customers' and c.ColumnName='Name' and c.ChangeDate>=@date order by ChangeDate asc) cName
	                                    outer apply (Select top 1 c.OldValue from HistoryChanges c where c.DataId=cus.Id and c.TableName='Customers' and c.ColumnName='LastName' and c.ChangeDate>=@date order by ChangeDate asc) cLastName
	                                    outer apply (Select top 1 c.OldValue from HistoryChanges c where c.DataId=cus.Id and c.TableName='Customers' and c.ColumnName='Email' and c.ChangeDate>=@date order by ChangeDate asc) cEmail
	                                    outer apply (Select top 1 c.OldValue from HistoryChanges c where c.DataId=cus.Id and c.TableName='Customers' and c.ColumnName='Website' and c.ChangeDate>=@date order by ChangeDate asc) cWebsite
	                                    outer apply (Select top 1 c.OldValue from HistoryChanges c where c.DataId=cus.Id and c.TableName='Customers' and c.ColumnName='AddressId' and c.ChangeDate>=@date order by ChangeDate asc) cAddressId
                                    )
                                    GO");

            migrationBuilder.Sql(@"CREATE PROC [dbo].[GetInvoices]
                                    AS
                                    with Invoices (CustomerId, Name, Street, PostalCode, City, Country, DateOfPurchase, OrderId, Amount)
                                    as (
	                                    Select cus.id, cus.Name + ' ' + cus.Lastname, adr.Street, adr.PostalCode, adr.City, adr.Country, ord.DateOfPurchase, ord.Id, sum(pos.Amount * art.Price) from Orders ord
	                                    inner join Positions pos on pos.OrderId=ord.Id
	                                    inner join Articles art on art.id=pos.ArticleId
	                                    Cross Apply (Select * from CustomersTVFhistory(ord.DateOfPurchase) c where c.Id=ord.CustomerId) cus
	                                    Cross Apply (Select * from AddressesTVFhistory(ord.DateOfPurchase) a where a.id=cus.AddressId) adr
	                                    group by cus.id, cus.Name, cus.Lastname, adr.Street, adr.PostalCode, adr.City, adr.Country, ord.DateOfPurchase, ord.Id
                                    )
                                    Select * from Invoices");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetInvoices");

            migrationBuilder.Sql(@"DROP FUNCTION CustomersTVFhistory");

            migrationBuilder.Sql(@"DROP FUNCTION AddressesTVFhistory");
		}
    }
}
