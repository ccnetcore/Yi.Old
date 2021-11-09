using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class ec2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort = table.Column<int>(type: "int", nullable: false),
                    is_parent = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "spu_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generic_spec = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    special_spec = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    packing_list = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    after_service = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spu_detail", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "brand_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_brand_category_brand_brandId",
                        column: x => x.brandId,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_brand_category_category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "spec_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoryid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spec_group", x => x.id);
                    table.ForeignKey(
                        name: "FK_spec_group_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "spu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sub_title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    saleable = table.Column<int>(type: "int", nullable: false),
                    valid = table.Column<int>(type: "int", nullable: false),
                    crate_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    brandid = table.Column<int>(type: "int", nullable: true),
                    spu_Detailid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spu", x => x.id);
                    table.ForeignKey(
                        name: "FK_spu_brand_brandid",
                        column: x => x.brandid,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spu_spu_detail_spu_Detailid",
                        column: x => x.spu_Detailid,
                        principalTable: "spu_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "spec_param",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeric = table.Column<int>(type: "int", nullable: false),
                    unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generic = table.Column<int>(type: "int", nullable: false),
                    searching = table.Column<int>(type: "int", nullable: false),
                    segments = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    spec_Groupid = table.Column<int>(type: "int", nullable: true),
                    categoryid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spec_param", x => x.id);
                    table.ForeignKey(
                        name: "FK_spec_param_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spec_param_spec_group_spec_Groupid",
                        column: x => x.spec_Groupid,
                        principalTable: "spec_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "sku",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    images = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<int>(type: "int", nullable: false),
                    indexes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enable = table.Column<int>(type: "int", nullable: false),
                    own_spec = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    crate_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    spuid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sku", x => x.id);
                    table.ForeignKey(
                        name: "FK_sku_spu_spuid",
                        column: x => x.spuid,
                        principalTable: "spu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    total_pay = table.Column<int>(type: "int", nullable: false),
                    actual_pay = table.Column<int>(type: "int", nullable: false),
                    payment_type = table.Column<int>(type: "int", nullable: false),
                    post_fee = table.Column<int>(type: "int", nullable: false),
                    promotion_ids = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creat_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    shipping_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shipping_code = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_nick = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_rate = table.Column<int>(type: "int", nullable: false),
                    receiver_state = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_district = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_mobile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_zip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    invoice_type = table.Column<int>(type: "int", nullable: false),
                    source_type = table.Column<int>(type: "int", nullable: false),
                    skuid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_sku_skuid",
                        column: x => x.skuid,
                        principalTable: "sku",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    seckill_stock = table.Column<int>(type: "int", nullable: false),
                    seckill_total = table.Column<int>(type: "int", nullable: false),
                    stock_count = table.Column<int>(type: "int", nullable: false),
                    skuid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                    table.ForeignKey(
                        name: "FK_stock_sku_skuid",
                        column: x => x.skuid,
                        principalTable: "sku",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_brand_category_brandId",
                table: "brand_category",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_brand_category_categoryId",
                table: "brand_category",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_category_categoryid",
                table: "category",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_categoryspu_spusid",
                table: "categoryspu",
                column: "spusid");

            migrationBuilder.CreateIndex(
                name: "IX_order_skuid",
                table: "order",
                column: "skuid");

            migrationBuilder.CreateIndex(
                name: "IX_sku_spuid",
                table: "sku",
                column: "spuid");

            migrationBuilder.CreateIndex(
                name: "IX_spec_group_categoryid",
                table: "spec_group",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_spec_param_categoryid",
                table: "spec_param",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_spec_param_spec_Groupid",
                table: "spec_param",
                column: "spec_Groupid");

            migrationBuilder.CreateIndex(
                name: "IX_spu_brandid",
                table: "spu",
                column: "brandid");

            migrationBuilder.CreateIndex(
                name: "IX_spu_spu_Detailid",
                table: "spu",
                column: "spu_Detailid");

            migrationBuilder.CreateIndex(
                name: "IX_stock_skuid",
                table: "stock",
                column: "skuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_category");

            migrationBuilder.DropTable(
                name: "categoryspu");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "spec_param");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "spec_group");

            migrationBuilder.DropTable(
                name: "sku");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "spu");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "spu_detail");
        }
    }
}
