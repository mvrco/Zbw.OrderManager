using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class CreateCteStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC GetAllArticleGroups
                                    AS
                                    with cte_articleGroup (id, Name, Description, ParentGroupId)
                                    as (
                                    select Id, Name, Description, ParentGroupId
                                    from ArticleGroups
                                    where ParentGroupId is null
                                    union all
                                    select ag.Id, ag.Name, ag.Description, ag.ParentGroupId
                                    from ArticleGroups ag
                                    inner join cte_articleGroup as ag2
                                    on ag2.id = ag.ParentGroupId
                                    )
                                    Select * from cte_articleGroup
                                    GO");

            migrationBuilder.Sql(@"CREATE PROC GetArticleGroupsWithParents @ID INT
                                    AS
                                    with cte_articleGroup (id, Name, Description, ParentGroupId)
                                    as (
                                    select Id, Name, Description, ParentGroupId
                                    from ArticleGroups
                                    where id = @ID
                                    union all
                                    select ag.Id, ag.Name, ag.Description, ag.ParentGroupId
                                    from ArticleGroups ag
                                    inner join cte_articleGroup as ag2
                                    on ag.id = ag2.ParentGroupId
                                    )
                                    Select * from cte_articleGroup
                                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetAllArticleGroups");

            migrationBuilder.Sql("DROP PROCEDURE GetArticleGroupsWithParents");
        }
    }
}
