using Microsoft.EntityFrameworkCore.Migrations;

namespace BethanyPieShop.Migrations
{
    public partial class add_country_to_order_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");
        }
    }
}
