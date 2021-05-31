using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Yi.API.Migrations
{
    public partial class yi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prop",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    studentid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prop", x => x.id);
                    table.ForeignKey(
                        name: "FK_prop_student_studentid",
                        column: x => x.studentid,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prop_studentid",
                table: "prop",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prop");
        }
    }
}
