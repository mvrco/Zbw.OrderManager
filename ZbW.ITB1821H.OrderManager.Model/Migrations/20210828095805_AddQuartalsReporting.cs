using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class AddQuartalsReporting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[CountArticlesAsOfDate]
                                    (	
	                                    @date as datetime
                                    )
                                    RETURNS TABLE 
                                    AS
                                    RETURN
                                    (
	                                    SELECT a.* from Articles a
	                                    outer apply (Select top 1 hc.OldValue from HistoryChanges hc where hc.TableName='Articles' and hc.ColumnName='IsActive' and a.Id=hc.DataId and hc.ChangeDate>=@date order by ChangeDate desc) HC
	                                    where a.CreateDate<=@date and (HC.OldValue is null and a.IsActive=1 or HC.OldValue = 1)
                                    )
                                    GO");

			migrationBuilder.Sql(@"CREATE PROC [dbo].[GetQuartalsReports]
                                    AS
                                    with QuartalsReport (Category, YOYinPercent, QuartalMinus0, QuartalMinus1, QuartalMinus2, QuartalMinus3, QuartalMinus4, QuartalMinus5, QuartalMinus6, QuartalMinus7, QuartalMinus8, QuartalMinus9, QuartalMinus10, QuartalMinus11)
                                    as (
                                    select Category, 
                                        100 / sum(isnull(YearMinus1,1)) * sum(isnull(YearMinus0, 1)) - 100 as YOYinPercent,
	                                    sum(isnull(QuartalMinus0,0)) as QuartalMinus0, 
	                                    sum(isnull(QuartalMinus1,0)) as QuartalMinus1, 
	                                    sum(isnull(QuartalMinus2,0)) as QuartalMinus2, 
	                                    sum(isnull(QuartalMinus3,0)) as QuartalMinus3, 
	                                    sum(isnull(QuartalMinus4,0)) as QuartalMinus4, 
	                                    sum(isnull(QuartalMinus5,0)) as QuartalMinus5, 
	                                    sum(isnull(QuartalMinus6,0)) as QuartalMinus6, 
	                                    sum(isnull(QuartalMinus7,0)) as QuartalMinus7,
	                                    sum(isnull(QuartalMinus8,0)) as QuartalMinus8, 
	                                    sum(isnull(QuartalMinus9,0)) as QuartalMinus9, 
	                                    sum(isnull(QuartalMinus10,0)) as QuartalMinus10, 
	                                    sum(isnull(QuartalMinus11,0)) as QuartalMinus11
                                     from (
                                     Select 'Anzahl Aufträge' as Category, 
		                                    'QuartalMinus' + LTRIM(STR(datediff(Month, ord.DateOfPurchase, datefromparts(year(GETDATE()) ,(floor((Datepart(month, GETDATE())-1) / 3) + 1) * 3, 1)) / 3)) as Quartal,
		                                    'YearMinus' + LTRIM(STR(datediff(Year, ord.DateOfPurchase, GETDATE()))) as Years,
		                                    count(Id) OVER (PARTITION BY Id ORDER BY ord.DateOfPurchase) as CounterQ,
		                                    count(Id) OVER (PARTITION BY year(ord.DateOfPurchase)) as CounterY
                                     from Orders ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus0' as Quartal,
		                                    'YearMinus0' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    count(Id) over () as CounterY
                                     from CountArticlesAsOfDate(GETDATE()) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus1' as Quartal,
		                                    'YearMinus0' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1), GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus2' as Quartal,
		                                    'YearMinus0' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 3, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus3' as Quartal,
		                                    'YearMinus0' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 6, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus4' as Quartal,
		                                    'YearMinus1' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    count(Id) OVER () as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 9, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus5' as Quartal,
		                                    'YearMinus1' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 12, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus6' as Quartal,
		                                    'YearMinus1' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 15, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus7' as Quartal,
		                                    'YearMinus2' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 18, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus8' as Quartal,
		                                    'YearMinus2' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 21, GETDATE()))) ord
									 union all
									 Select 'Anzahl verwaltete Artikel' as Category, 
		                                    'QuartalMinus9' as Quartal,
		                                    'YearMinus2' as Years,
		                                    count(Id) OVER (PARTITION BY Id) as CounterQ,
		                                    0 as CounterY
                                     from CountArticlesAsOfDate(EOMONTH(dateadd(Month, 0 - (((MONTH(GETDATE())-1)%3)+1) - 24, GETDATE()))) ord
                                    union all
                                     Select 'Gesamtumsatz' as Category, 
		                                    'QuartalMinus' + LTRIM(STR(datediff(Month, ord.DateOfPurchase, datefromparts(year(GETDATE()) ,(floor((Datepart(month, GETDATE())-1) / 3) + 1) * 3, 1)) / 3)) as Quartal,
		                                    'YearMinus' + LTRIM(STR(datediff(Year, ord.DateOfPurchase, GETDATE()))) as Years,
		                                    sum(art.Price) OVER (PARTITION BY art.id) as CounterQ,
		                                    sum(art.Price) OVER (PARTITION BY art.id, year(ord.DateOfPurchase)) as CounterY
                                     from Orders ord
                                      inner join Positions pos on pos.OrderId=ord.Id 
                                     inner join Articles art on art.Id=pos.ArticleId
                                    )
                                    AS OrderList
                                    PIVOT(
	                                    sum(CounterQ)
	                                    FOR Quartal IN ([QuartalMinus0],[QuartalMinus1],[QuartalMinus2],[QuartalMinus3],[QuartalMinus4],[QuartalMinus5],[QuartalMinus6],[QuartalMinus7],[QuartalMinus8],[QuartalMinus9],[QuartalMinus10],[QuartalMinus11])
                                    ) AS OrdersPerQuartal
                                    PIVOT(
	                                    sum(CounterY)
	                                    FOR Years IN ([YearMinus0],[YearMinus1])
                                    ) AS OrdersPerYear
                                    group by Category
                                    union
                                    select Category, 
                                        100 / sum(isnull(YearMinus1,1)) * sum(isnull(YearMinus0, 1)) - 100 as YOYinPercent,
	                                    sum(isnull(QuartalMinus0,0)) as QuartalMinus0, 
	                                    sum(isnull(QuartalMinus1,0)) as QuartalMinus1, 
	                                    sum(isnull(QuartalMinus2,0)) as QuartalMinus2, 
	                                    sum(isnull(QuartalMinus3,0)) as QuartalMinus3, 
	                                    sum(isnull(QuartalMinus4,0)) as QuartalMinus4, 
	                                    sum(isnull(QuartalMinus5,0)) as QuartalMinus5, 
	                                    sum(isnull(QuartalMinus6,0)) as QuartalMinus6, 
	                                    sum(isnull(QuartalMinus7,0)) as QuartalMinus7,
	                                    sum(isnull(QuartalMinus8,0)) as QuartalMinus8, 
	                                    sum(isnull(QuartalMinus9,0)) as QuartalMinus9, 
	                                    sum(isnull(QuartalMinus10,0)) as QuartalMinus10, 
	                                    sum(isnull(QuartalMinus11,0)) as QuartalMinus11
                                     from (
                                      select Category, Quartal, Years, cast(CounterQ as float) as CounterQ, 
                                     avg(cast(CounterY as float)) over (PARTITION BY year(date)) as CounterY from
                                     (Select distinct 'Durchschnittliche Anzahl Artikel pro Auftrag' as Category,
		                                    'QuartalMinus' + LTRIM(STR(datediff(Month, ord.DateOfPurchase, datefromparts(year(GETDATE()) ,(floor((Datepart(month, GETDATE())-1) / 3) + 1) * 3, 1)) / 3)) as Quartal,
		                                    'YearMinus' + LTRIM(STR(datediff(Year, ord.DateOfPurchase, GETDATE()))) as Years,
		                                    count(ArticleId) OVER (PARTITION BY ord.id ORDER BY ord.DateOfPurchase) as CounterQ,
		                                    count(ArticleId) OVER (PARTITION BY ord.id) as CounterY, 
		                                    ord.DateOfPurchase as date
                                     from Orders ord
                                     left outer join Positions pos on pos.OrderId=ord.Id) as t
                                     union all
                                     select Category, Quartal, Years, cast(CounterQ as float) as CounterQ, 
                                     avg(cast(CounterY as float)) over (PARTITION BY year(date)) as CounterY from
                                     (Select distinct 'Durchschnittliche Umsatz pro Kunde/Auftrag' as Category,
		                                    'QuartalMinus' + LTRIM(STR(datediff(Month, ord.DateOfPurchase, datefromparts(year(GETDATE()) ,(floor((Datepart(month, GETDATE())-1) / 3) + 1) * 3, 1)) / 3)) as Quartal,
		                                    'YearMinus' + LTRIM(STR(datediff(Year, ord.DateOfPurchase, GETDATE()))) as Years,
		                                    sum(art.Price) OVER (PARTITION BY ord.id) as CounterQ,
		                                    sum(art.Price) OVER (PARTITION BY ord.id, year(ord.DateOfPurchase)) as CounterY, 
		                                    ord.DateOfPurchase as date
                                     from Orders ord
                                     inner join Positions pos on pos.OrderId=ord.Id 
                                     inner join Articles art on art.Id=pos.ArticleId) as t
                                    )
                                    AS OrderList
                                    PIVOT(
	                                    avg(CounterQ)
	                                    FOR Quartal IN ([QuartalMinus0],[QuartalMinus1],[QuartalMinus2],[QuartalMinus3],[QuartalMinus4],[QuartalMinus5],[QuartalMinus6],[QuartalMinus7],[QuartalMinus8],[QuartalMinus9],[QuartalMinus10],[QuartalMinus11])
                                    ) AS OrdersPerQuartal
                                    PIVOT(
	                                    avg(CounterY)
	                                    FOR Years IN ([YearMinus0],[YearMinus1])
                                    ) AS OrdersPerYear
                                    group by Category
                                    )
                                    Select * from QuartalsReport
                                    GO");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetQuartalsReports");

			migrationBuilder.Sql(@"DROP FUNCTION CountArticlesAsOfDate");
		}
    }
}
