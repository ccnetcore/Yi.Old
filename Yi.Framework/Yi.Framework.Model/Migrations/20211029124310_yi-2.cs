using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class yi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menurole");

            migrationBuilder.DropTable(
                name: "roleuser");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roleid",
                table: "menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_userid",
                table: "role",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_menu_roleid",
                table: "menu",
                column: "roleid");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_role_roleid",
                table: "menu",
                column: "roleid",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_role_user_userid",
                table: "role",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_role_roleid",
                table: "menu");

            migrationBuilder.DropForeignKey(
                name: "FK_role_user_userid",
                table: "role");

            migrationBuilder.DropIndex(
                name: "IX_role_userid",
                table: "role");

            migrationBuilder.DropIndex(
                name: "IX_menu_roleid",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "role");

            migrationBuilder.DropColumn(
                name: "roleid",
                table: "menu");

            migrationBuilder.CreateTable(
                name: "menurole",
                columns: table => new
                {
                    menusid = table.Column<int>(type: "int", nullable: false),
                    rolesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menurole", x => new { x.menusid, x.rolesid });
                    table.ForeignKey(
                        name: "FK_menurole_menu_menusid",
                        column: x => x.menusid,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menurole_role_rolesid",
                        column: x => x.rolesid,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roleuser",
                columns: table => new
                {
                    rolesid = table.Column<int>(type: "int", nullable: false),
                    usersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleuser", x => new { x.rolesid, x.usersid });
                    table.ForeignKey(
                        name: "FK_roleuser_role_rolesid",
                        column: x => x.rolesid,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roleuser_user_usersid",
                        column: x => x.usersid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_menurole_rolesid",
                table: "menurole",
                column: "rolesid");

            migrationBuilder.CreateIndex(
                name: "IX_roleuser_usersid",
                table: "roleuser",
                column: "usersid");
        }
    }
}
