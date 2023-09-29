using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TotalAmount",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TotalAvailable",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalAvailable",
                table: "Products");
        }
    }
}
