using Microsoft.EntityFrameworkCore.Migrations;

namespace ZbW.ITB1821H.OrderManager.Model.Migrations
{
    public partial class CreatingTriggersForHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CreateDate",
                table: "Articles",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Articles");
        }
    }
}
