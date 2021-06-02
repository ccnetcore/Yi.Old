using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Yi.Model.Migrations
{
    public partial class yi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "is_delete",
                table: "student",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "student");
        }
    }
}
