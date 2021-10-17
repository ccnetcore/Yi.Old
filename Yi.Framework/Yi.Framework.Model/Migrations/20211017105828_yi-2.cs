using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class yi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "is_show",
                table: "menu",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_show",
                table: "menu");
        }
    }
}
