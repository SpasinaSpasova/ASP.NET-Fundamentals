using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class IsActiveAddedToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Product is active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "products");
        }
    }
}
