using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class DefaultValueRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "products",
                type: "bit",
                nullable: false,
                comment: "Product is active",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true,
                oldComment: "Product is active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Product is active",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Product is active");
        }
    }
}
