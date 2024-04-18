using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHPWServer.Migrations
{
    public partial class OrderItemsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "OrderItems",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: "Extra Cheese");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "OrderItems");
        }
    }
}
