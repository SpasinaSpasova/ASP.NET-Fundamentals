using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Core.Migrations
{
    public partial class ProductsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Product name"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Products price"),
                    quantity = table.Column<int>(type: "int", nullable: false, comment: "Products quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                },
                comment: "Products to sell.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
