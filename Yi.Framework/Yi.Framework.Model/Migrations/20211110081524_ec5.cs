using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class ec5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryspu");

            migrationBuilder.AddColumn<int>(
                name: "specid",
                table: "spu_detail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cid1id",
                table: "spu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cid2id",
                table: "spu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cid3id",
                table: "spu",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "sku",
                type: "double",
                nullable: false,
                comment: "销售价格，单位为分",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "销售价格，单位为分");

            migrationBuilder.CreateIndex(
                name: "IX_spu_detail_specid",
                table: "spu_detail",
                column: "specid");

            migrationBuilder.CreateIndex(
                name: "IX_spu_cid1id",
                table: "spu",
                column: "cid1id");

            migrationBuilder.CreateIndex(
                name: "IX_spu_cid2id",
                table: "spu",
                column: "cid2id");

            migrationBuilder.CreateIndex(
                name: "IX_spu_cid3id",
                table: "spu",
                column: "cid3id");

            migrationBuilder.AddForeignKey(
                name: "FK_spu_category_cid1id",
                table: "spu",
                column: "cid1id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spu_category_cid2id",
                table: "spu",
                column: "cid2id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spu_category_cid3id",
                table: "spu",
                column: "cid3id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spu_detail_spec_param_specid",
                table: "spu_detail",
                column: "specid",
                principalTable: "spec_param",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spu_category_cid1id",
                table: "spu");

            migrationBuilder.DropForeignKey(
                name: "FK_spu_category_cid2id",
                table: "spu");

            migrationBuilder.DropForeignKey(
                name: "FK_spu_category_cid3id",
                table: "spu");

            migrationBuilder.DropForeignKey(
                name: "FK_spu_detail_spec_param_specid",
                table: "spu_detail");

            migrationBuilder.DropIndex(
                name: "IX_spu_detail_specid",
                table: "spu_detail");

            migrationBuilder.DropIndex(
                name: "IX_spu_cid1id",
                table: "spu");

            migrationBuilder.DropIndex(
                name: "IX_spu_cid2id",
                table: "spu");

            migrationBuilder.DropIndex(
                name: "IX_spu_cid3id",
                table: "spu");

            migrationBuilder.DropColumn(
                name: "specid",
                table: "spu_detail");

            migrationBuilder.DropColumn(
                name: "cid1id",
                table: "spu");

            migrationBuilder.DropColumn(
                name: "cid2id",
                table: "spu");

            migrationBuilder.DropColumn(
                name: "cid3id",
                table: "spu");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "sku",
                type: "int",
                nullable: false,
                comment: "销售价格，单位为分",
                oldClrType: typeof(double),
                oldType: "double",
                oldComment: "销售价格，单位为分");

            migrationBuilder.CreateTable(
                name: "categoryspu",
                columns: table => new
                {
                    categoriesid = table.Column<int>(type: "int", nullable: false),
                    spusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryspu", x => new { x.categoriesid, x.spusid });
                    table.ForeignKey(
                        name: "FK_categoryspu_category_categoriesid",
                        column: x => x.categoriesid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryspu_spu_spusid",
                        column: x => x.spusid,
                        principalTable: "spu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_categoryspu_spusid",
                table: "categoryspu",
                column: "spusid");
        }
    }
}
