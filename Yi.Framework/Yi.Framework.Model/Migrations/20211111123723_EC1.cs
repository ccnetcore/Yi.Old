using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class EC1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true, comment: "品牌名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: true, comment: "品牌图片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letter = table.Column<string>(type: "longtext", nullable: true, comment: "品牌首字母")
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
                    name = table.Column<string>(type: "longtext", nullable: true, comment: "类别名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort = table.Column<int>(type: "int", nullable: false, comment: "排序"),
                    is_parent = table.Column<int>(type: "int", nullable: false, comment: "是否父类别"),
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
                name: "mould",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mould_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mould", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    introduce = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "spu_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generic_spec = table.Column<string>(type: "longtext", nullable: true, comment: "通用规格参数数据")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    special_spec = table.Column<string>(type: "longtext", nullable: true, comment: "特有规格参数及可选值信息，json格式")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    packing_list = table.Column<string>(type: "longtext", nullable: true, comment: "包装清单")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    after_service = table.Column<string>(type: "longtext", nullable: true, comment: "售后服务")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spu_detail", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nick = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<int>(type: "int", nullable: true),
                    introduction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    num = table.Column<int>(type: "int", nullable: false),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visit", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "brandcategory",
                columns: table => new
                {
                    brandsid = table.Column<int>(type: "int", nullable: false),
                    categoriesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brandcategory", x => new { x.brandsid, x.categoriesid });
                    table.ForeignKey(
                        name: "FK_brandcategory_brand_brandsid",
                        column: x => x.brandsid,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_brandcategory_category_categoriesid",
                        column: x => x.categoriesid,
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
                    name = table.Column<string>(type: "longtext", nullable: true, comment: "规格组名称")
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
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    router = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    menu_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mouldid = table.Column<int>(type: "int", nullable: true),
                    menuid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false),
                    is_top = table.Column<int>(type: "int", nullable: false),
                    sort = table.Column<int>(type: "int", nullable: false),
                    is_show = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_menu_menuid",
                        column: x => x.menuid,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menu_mould_mouldid",
                        column: x => x.mouldid,
                        principalTable: "mould",
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
                    title = table.Column<string>(type: "longtext", nullable: true, comment: "标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sub_title = table.Column<string>(type: "longtext", nullable: true, comment: "子标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    saleable = table.Column<int>(type: "int", nullable: false, comment: "是否上架"),
                    valid = table.Column<int>(type: "int", nullable: false, comment: "是否有效"),
                    crate_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    last_update_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "最后更新时间"),
                    cid1id = table.Column<int>(type: "int", nullable: true),
                    cid2id = table.Column<int>(type: "int", nullable: true),
                    cid3id = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_spu_category_cid1id",
                        column: x => x.cid1id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spu_category_cid2id",
                        column: x => x.cid2id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spu_category_cid3id",
                        column: x => x.cid3id,
                        principalTable: "category",
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

            migrationBuilder.CreateTable(
                name: "spec_param",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true, comment: "参数名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeric = table.Column<int>(type: "int", nullable: false, comment: "是否是数字类型参数，true或false"),
                    unit = table.Column<string>(type: "longtext", nullable: true, comment: "数字类型参数的单位，非数字类型可以为空")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generic = table.Column<int>(type: "int", nullable: false, comment: "是否是sku通用属性，true或false"),
                    searching = table.Column<int>(type: "int", nullable: false, comment: "是否用于搜索过滤，true或false"),
                    segments = table.Column<string>(type: "longtext", nullable: true, comment: "数值类型参数，如果需要搜索，则添加分段间隔值，如CPU频率间隔：0.5-1.0")
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
                name: "sku",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: true, comment: "商品标题")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    images = table.Column<string>(type: "longtext", nullable: true, comment: "商品的图片，多个图片以‘,’分割")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false, comment: "销售价格，单位为分"),
                    indexes = table.Column<string>(type: "longtext", nullable: true, comment: "特有规格属性在spu属性模板中的对应下标组合")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    enable = table.Column<int>(type: "int", nullable: false, comment: "是否有效，0无效，1有效"),
                    own_spec = table.Column<string>(type: "longtext", nullable: true, comment: "sku的特有规格参数键值对，json格式，反序列化时请使用linkedHashMap，保证有序")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    crate_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    last_update_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "最后更新时间"),
                    spuid = table.Column<int>(type: "int", nullable: true),
                    specParamid = table.Column<int>(type: "int", nullable: true),
                    is_delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sku", x => x.id);
                    table.ForeignKey(
                        name: "FK_sku_spec_param_specParamid",
                        column: x => x.specParamid,
                        principalTable: "spec_param",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    total_pay = table.Column<int>(type: "int", nullable: false, comment: "总金额，单位为分"),
                    actual_pay = table.Column<int>(type: "int", nullable: false, comment: "实付金额。单位:分。如:20007，表示:200元7分"),
                    payment_type = table.Column<int>(type: "int", nullable: false, comment: "支付类型，1、在线支付，2、货到付款"),
                    post_fee = table.Column<int>(type: "int", nullable: false, comment: "邮费。单位:分。如:20007，表示:200元7分"),
                    promotion_ids = table.Column<string>(type: "longtext", nullable: true, comment: "promotion_ids")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creat_time = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "订单创建时间"),
                    shipping_name = table.Column<string>(type: "longtext", nullable: true, comment: "物流名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shipping_code = table.Column<string>(type: "longtext", nullable: true, comment: "物流单号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_message = table.Column<string>(type: "longtext", nullable: true, comment: "买家留言")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_nick = table.Column<string>(type: "longtext", nullable: true, comment: "买家昵称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    buyer_rate = table.Column<int>(type: "int", nullable: false, comment: "买家是否已经评价,0未评价，1已评价"),
                    receiver_state = table.Column<string>(type: "longtext", nullable: true, comment: "收获地址（省）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_city = table.Column<string>(type: "longtext", nullable: true, comment: "收获地址（市）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_district = table.Column<string>(type: "longtext", nullable: true, comment: "收获地址（区/县）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_address = table.Column<string>(type: "longtext", nullable: true, comment: "收获地址（街道、住址等详细地址）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_mobile = table.Column<string>(type: "longtext", nullable: true, comment: "收货人手机")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver_zip = table.Column<string>(type: "longtext", nullable: true, comment: "收货人邮编")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    receiver = table.Column<string>(type: "longtext", nullable: true, comment: "收货人")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    invoice_type = table.Column<int>(type: "int", nullable: false, comment: "发票类型:0无发票1普通发票，2电子发票，3增值税发票"),
                    source_type = table.Column<int>(type: "int", nullable: false, comment: "订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端"),
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
                    seckill_stock = table.Column<int>(type: "int", nullable: false, comment: "可秒杀库存"),
                    seckill_total = table.Column<int>(type: "int", nullable: false, comment: "秒杀总数量"),
                    stock_count = table.Column<int>(type: "int", nullable: false, comment: "库存数量"),
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
                name: "IX_brandcategory_categoriesid",
                table: "brandcategory",
                column: "categoriesid");

            migrationBuilder.CreateIndex(
                name: "IX_category_categoryid",
                table: "category",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_menu_menuid",
                table: "menu",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "IX_menu_mouldid",
                table: "menu",
                column: "mouldid");

            migrationBuilder.CreateIndex(
                name: "IX_menurole_rolesid",
                table: "menurole",
                column: "rolesid");

            migrationBuilder.CreateIndex(
                name: "IX_order_skuid",
                table: "order",
                column: "skuid");

            migrationBuilder.CreateIndex(
                name: "IX_roleuser_usersid",
                table: "roleuser",
                column: "usersid");

            migrationBuilder.CreateIndex(
                name: "IX_sku_specParamid",
                table: "sku",
                column: "specParamid");

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
                name: "brandcategory");

            migrationBuilder.DropTable(
                name: "menurole");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "roleuser");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "visit");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "sku");

            migrationBuilder.DropTable(
                name: "mould");

            migrationBuilder.DropTable(
                name: "spec_param");

            migrationBuilder.DropTable(
                name: "spu");

            migrationBuilder.DropTable(
                name: "spec_group");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "spu_detail");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
