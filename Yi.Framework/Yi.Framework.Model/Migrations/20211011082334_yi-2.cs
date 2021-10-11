using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class yi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "user",
                newName: "username");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "user",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ip",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "is_delete",
                table: "user",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nick",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "user",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_name = table.Column<string>(type: "TEXT", nullable: true),
                    introduce = table.Column<string>(type: "TEXT", nullable: true),
                    is_delete = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user");

            migrationBuilder.DropColumn(
                name: "icon",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ip",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "user");

            migrationBuilder.DropColumn(
                name: "nick",
                table: "user");

            migrationBuilder.DropColumn(
                name: "password",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "user",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
