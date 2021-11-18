using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yi.Framework.Model.Migrations
{
    public partial class ec1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "total_pay",
                table: "order",
                type: "double",
                nullable: true,
                comment: "总金额，单位为分",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "总金额，单位为分");

            migrationBuilder.AlterColumn<int>(
                name: "source_type",
                table: "order",
                type: "int",
                nullable: true,
                comment: "订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端");

            migrationBuilder.AlterColumn<int>(
                name: "post_fee",
                table: "order",
                type: "int",
                nullable: true,
                comment: "邮费。单位:分。如:20007，表示:200元7分",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "邮费。单位:分。如:20007，表示:200元7分");

            migrationBuilder.AlterColumn<int>(
                name: "invoice_type",
                table: "order",
                type: "int",
                nullable: true,
                comment: "发票类型:0无发票1普通发票，2电子发票，3增值税发票",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "发票类型:0无发票1普通发票，2电子发票，3增值税发票");

            migrationBuilder.AlterColumn<int>(
                name: "buyer_rate",
                table: "order",
                type: "int",
                nullable: true,
                comment: "买家是否已经评价,0未评价，1已评价",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "买家是否已经评价,0未评价，1已评价");

            migrationBuilder.AlterColumn<double>(
                name: "actual_pay",
                table: "order",
                type: "double",
                nullable: true,
                comment: "实付金额。单位:分。如:20007，表示:200元7分",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "实付金额。单位:分。如:20007，表示:200元7分");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "order",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "total_pay",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "总金额，单位为分",
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true,
                oldComment: "总金额，单位为分");

            migrationBuilder.AlterColumn<int>(
                name: "source_type",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "订单来源：1:app端，2：pc端，3：M端，4：微信端，5：手机qq端");

            migrationBuilder.AlterColumn<int>(
                name: "post_fee",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "邮费。单位:分。如:20007，表示:200元7分",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "邮费。单位:分。如:20007，表示:200元7分");

            migrationBuilder.AlterColumn<int>(
                name: "invoice_type",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "发票类型:0无发票1普通发票，2电子发票，3增值税发票",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "发票类型:0无发票1普通发票，2电子发票，3增值税发票");

            migrationBuilder.AlterColumn<int>(
                name: "buyer_rate",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "买家是否已经评价,0未评价，1已评价",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "买家是否已经评价,0未评价，1已评价");

            migrationBuilder.AlterColumn<int>(
                name: "actual_pay",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "实付金额。单位:分。如:20007，表示:200元7分",
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true,
                oldComment: "实付金额。单位:分。如:20007，表示:200元7分");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
